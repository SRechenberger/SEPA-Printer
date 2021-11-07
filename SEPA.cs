using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.Json;
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

        private const string TITLE = "SEPA Drucker";

        private SEPACarrier carrier;

        private string currentFile;

        private bool changed;
        public SEPA()
        {
            InitializeComponent();
            currentFile = null;
            carrier = null;
            changed = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inhibit resizing of the window
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            if (!this.UnsafedChanges())
            {
                e.Cancel = true;
            }
        }

        private void RefreshTitle()
        {
            this.Text = "";
            if (this.changed)
            {
                this.Text += "* ";
            }
            this.Text += TITLE;
            if (this.currentFile != null)
            {
                this.Text += $" ({this.currentFile})";
            }
        }

        private bool InputCarrier()
        {
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
            } catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Fehler beim Lesen", MessageBoxButtons.OK);
                return false;
            } catch(FormatException ex)
            {
                MessageBox.Show("Der Betrag ist keine gültige Zahl.\n\n" + ex.StackTrace, "Fehler beim Lesen", MessageBoxButtons.OK);
                return false;
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Unerwarteter Fehler", MessageBoxButtons.OK);
                return false;
            }
            return true;
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

        private void MnuFileSave_Click(object sender, EventArgs e)
        {
            if (!this.InputCarrier()) return;

            string json = this.carrier.Save();

            if (this.currentFile == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JSON Datein (*.json) | *.json";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.currentFile = saveFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }

            File.WriteAllText(this.currentFile, json);
            this.changed = false;
            this.RefreshTitle();
        }


        private void MnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (!this.InputCarrier()) return;

            string json = this.carrier.Save();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Datein (*.json) | *.json";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.currentFile = saveFileDialog.FileName;
                File.WriteAllText(this.currentFile, json);
                this.changed = false;
                this.RefreshTitle();
            }

        }

        private void UpdateTextFields()
        {
            if (this.carrier != null)
            {
                this.TxtReceiver.Text = this.carrier.Receiver;
                this.TxtReceiverIBAN.Text = this.carrier.ReceiverIBAN;
                this.TxtReceiverBIC.Text = this.carrier.ReceiverBIC;
                this.TxtAmount.Text = this.carrier.Amount.ToString("n2");
                this.TxtSenderUsage1.Text = this.carrier.SenderUsage1;
                this.TxtSenderUsage2.Text = this.carrier.SenderUsage2;
                this.TxtSenderIdent.Text = this.carrier.SenderIdent;
                this.TxtSenderIBAN.Text = this.carrier.SenderIBAN;
            } else
            {
                this.TxtReceiver.Text = "";
                this.TxtReceiverIBAN.Text = "";
                this.TxtReceiverBIC.Text = "";
                this.TxtAmount.Text = "0,0";
                this.TxtSenderUsage1.Text ="";
                this.TxtSenderUsage2.Text = "";
                this.TxtSenderIdent.Text = "";
                this.TxtSenderIBAN.Text = "";
            }
            this.changed = false;
        }

        private bool UnsafedChanges() {
            if (this.changed)
            {
                DialogResult saveChanges = MessageBox.Show("Es gibt ungesicherte Änderungen. Möchten Sie diese Speichern?", "Ungesicherte Änderungen", MessageBoxButtons.YesNoCancel);
                if (saveChanges == DialogResult.Cancel)
                {
                    return false;
                }

                if (saveChanges == DialogResult.Yes)
                {
                    if (!this.InputCarrier()) return false;

                    string json = this.carrier.Save();

                    if (this.currentFile == null)
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "JSON Datein (*.json) | *.json";
                        saveFileDialog.FilterIndex = 1;
                        saveFileDialog.RestoreDirectory = true;

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.currentFile = saveFileDialog.FileName;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    File.WriteAllText(this.currentFile, json);
                }
            }
            return true;
        }

        private void MnuFileLoad_Click(object sender, EventArgs e)
        {
            if (!this.UnsafedChanges()) return;   

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Datein (*.json) | *.json";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string json = File.ReadAllText(openFileDialog.FileName);
                this.carrier = JsonSerializer.Deserialize<SEPACarrier>(json);
                this.currentFile = openFileDialog.FileName;

                this.UpdateTextFields();
                this.changed = false;
                this.RefreshTitle();
            }
        }

        private void TxtReceiver_TextChanged(object sender, EventArgs e)
        {
            this.changed = true;
            this.RefreshTitle();
        }

        private void TxtReceiverIBAN_TextChanged(object sender, EventArgs e)
        {
            this.changed = true;
            this.RefreshTitle();
        }

        private void TxtReceiverBIC_TextChanged(object sender, EventArgs e)
        {
            this.changed = true;
            this.RefreshTitle();
        }

        private void TxtAmount_TextChanged(object sender, EventArgs e)
        {
            this.changed = true;
            this.RefreshTitle();
        }

        private void TxtSenderUsage1_TextChanged(object sender, EventArgs e)
        {
            this.changed = true;
            this.RefreshTitle();
        }

        private void TxtSenderUsage2_TextChanged(object sender, EventArgs e)
        {
            this.changed = true;
            this.RefreshTitle();
        }

        private void TxtSenderIdent_TextChanged(object sender, EventArgs e)
        {
            this.changed = true;
            this.RefreshTitle();
        }

        private void TxtSenderIBAN_TextChanged(object sender, EventArgs e)
        {
            this.changed = true;
            this.RefreshTitle();
        }

        private void MnuFilePrint_Click(object sender, EventArgs e)
        {
            if (!this.InputCarrier()) return;
            PrintDialog pDialog = new PrintDialog();
            DialogResult printing = pDialog.ShowDialog();

            PaperSize sepaSize = new PaperSize("SEPA Überweisungsträger", 416, 590);

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
        }

        private void MnuFileQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MnuFileNew_Click(object sender, EventArgs e)
        {
            if (!this.UnsafedChanges()) return;

            this.carrier = null;
            this.currentFile = null;
            this.UpdateTextFields();
            this.RefreshTitle();
        }

        private void MnuAbout_Click(object sender, EventArgs e)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Reflection.AssemblyName name = assembly.GetName();
            MessageBox.Show(
                $"{name.Name}\nVersion {name.Version}\nCopyright Sascha Rechenberger 2021\nMIT-Lizenz",
                "Über",
                MessageBoxButtons.OK
            ); 
        }
    }
}
