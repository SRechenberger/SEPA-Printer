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

            if (printing == DialogResult.OK) 
            {
                Font printFont = new Font("Courier New", FONT_SIZE);
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
                    String text = this.textBox1.Text;
                    float xPos = ev.MarginBounds.Left;
                    float yPos = (float)(ev.MarginBounds.Top);
                    ev.Graphics.DrawRectangle(new Pen(Brushes.Black), 0, 0, 10, 10);
                    for (int line = 0; line < 8; line++)
                    {
                        for (int block = 0; block < BLOCKS; block++)
                        {
                            try
                            {
                                ev.Graphics.DrawString(text.Substring(block, 1), printFont, Brushes.Black, xPos + block * BLOCK_WIDTH, yPos + line * LINE_HEIGHT * 2, new StringFormat());
                            } catch(ArgumentOutOfRangeException ex)
                            {
                                // Do Nothing
                            }
                        }
                    }
                    ev.HasMorePages = false;
                });

                pd.Print();
            }
        }
    }
}
