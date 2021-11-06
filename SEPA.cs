using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEPA_Printer
{
    public partial class SEPA : Form
    {
        private const int Y_RES = 100;

        private const int READ_HEIGHT = 273;
        private const int BLOCK_HEIGHT = READ_HEIGHT / 8;
        private const int LINE_HEIGHT = BLOCK_HEIGHT / 2;
        private const int FONT_SIZE = LINE_HEIGHT * Y_RES / 100;
        private const int BLOCK_WIDTH = 20;
        private const int BLOCK_WIDTH_IBAN = 16;
        private const int BLOCKS = 27;
        private const int BLOCKS_IBAN = 34;

        private SEPACarrier carrier;

        public SEPA()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {

            PrintDialog pDialog = new PrintDialog();
            DialogResult printing = pDialog.ShowDialog();

            PaperSize sepaSize = new PaperSize("SEPA Überweisungsträger", 416, 590);

            try
            {
                carrier = new SEPACarrier(
                    this.TxtReceiver.Text,
                    this.TxtReceiverIBAN.Text,
                    this.TxtReceiverBIC.Text,
                    Single.Parse(this.TxtAmount.Text),
                    this.TxtSenderUsage1.Text,
                    this.TxtSenderUsage2.Text,
                    this.TxtSenderIdent.Text,
                    this.TxtSenderIBAN.Text
                );

                if (printing == DialogResult.OK)
                {
                    PrintDocument pd = new PrintDocument();

                    pd.DefaultPageSettings.Margins.Top = 69;
                    pd.DefaultPageSettings.Margins.Bottom = 77;
                    pd.DefaultPageSettings.Margins.Left = 30;
                    pd.DefaultPageSettings.Margins.Right = 30;
                    pd.DefaultPageSettings.PaperSize = sepaSize;
                    pd.DefaultPageSettings.PrinterResolution.X = 100;
                    pd.DefaultPageSettings.PrinterResolution.Y = 100;

                    pd.PrinterSettings.PrinterName = pDialog.PrinterSettings.PrinterName;
                    pd.PrintPage += new PrintPageEventHandler((object lsender, PrintPageEventArgs ev) =>
                    {
                        String text = this.TxtReceiver.Text;
                        float xPos = ev.MarginBounds.Left;
                        float yPos = (float)(ev.MarginBounds.Top);

                        RenderString(carrier.Receiver, BLOCK_WIDTH, 0, 0, 27, pd.DefaultPageSettings.Margins.Top, pd.DefaultPageSettings.Margins.Left, ev.Graphics);
                        RenderString(carrier.ReceiverIBAN, BLOCK_WIDTH_IBAN, 1, 0, 34, pd.DefaultPageSettings.Margins.Top, pd.DefaultPageSettings.Margins.Left, ev.Graphics);
                        RenderString(carrier.ReceiverBIC, BLOCK_WIDTH, 2, 0, 11, pd.DefaultPageSettings.Margins.Top, pd.DefaultPageSettings.Margins.Left, ev.Graphics);
                        RenderString(carrier.Amount.ToString("n2"), BLOCK_WIDTH, 3, 16, 27, pd.DefaultPageSettings.Margins.Top, pd.DefaultPageSettings.Margins.Left, ev.Graphics);
                        RenderString(carrier.SenderIdent, BLOCK_WIDTH, 4, 0, 27, pd.DefaultPageSettings.Margins.Top, pd.DefaultPageSettings.Margins.Left, ev.Graphics);
                        RenderString(carrier.SenderUsage1, BLOCK_WIDTH, 5, 0, 27, pd.DefaultPageSettings.Margins.Top, pd.DefaultPageSettings.Margins.Left, ev.Graphics);
                        RenderString(carrier.SenderUsage2, BLOCK_WIDTH, 6, 0, 27, pd.DefaultPageSettings.Margins.Top, pd.DefaultPageSettings.Margins.Left, ev.Graphics);
                        RenderString(carrier.SenderIBAN, BLOCK_WIDTH, 7, 0, 22, pd.DefaultPageSettings.Margins.Top, pd.DefaultPageSettings.Margins.Left, ev.Graphics);

                        ev.HasMorePages = false;
                    });

                    pd.Print();
                }
            } catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Fehler", MessageBoxButtons.OK);
                return;
            }
        }

        private void RenderString(string str, int blockWidth, int line, int begin, int end, int topMargin, int leftMargin, Graphics graphics)
        {
            Font printFont = new Font("Courier New", FONT_SIZE);
            StringFormat stringFormat = new StringFormat();
            for (int block = begin; block < Math.Min(begin + str.Length, end); block++)
            {
                graphics.DrawString($"{str[block-begin]}", printFont, Brushes.Black, leftMargin + block * blockWidth, topMargin + line * LINE_HEIGHT * 2, stringFormat); 
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Yeah", "You Clicken on Something", MessageBoxButtons.OK);
        }
    }
}
