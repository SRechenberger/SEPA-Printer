
using System.Windows.Forms;

namespace SEPA_Printer
{
    partial class SEPA
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtReceiver = new System.Windows.Forms.TextBox();
            this.TxtReceiverIBAN = new System.Windows.Forms.TextBox();
            this.TxtReceiverBIC = new System.Windows.Forms.TextBox();
            this.TxtAmount = new System.Windows.Forms.TextBox();
            this.TxtSenderIdent = new System.Windows.Forms.TextBox();
            this.TxtSenderUsage1 = new System.Windows.Forms.TextBox();
            this.TxtSenderUsage2 = new System.Windows.Forms.TextBox();
            this.TxtSenderIBAN = new System.Windows.Forms.TextBox();
            this.LblReceiver = new System.Windows.Forms.Label();
            this.LblReceiverIBAN = new System.Windows.Forms.Label();
            this.LblReceiverBIC = new System.Windows.Forms.Label();
            this.LblAmount = new System.Windows.Forms.Label();
            this.LblSenderUsage1 = new System.Windows.Forms.Label();
            this.LblSenderUsage2 = new System.Windows.Forms.Label();
            this.LblSenderIdent = new System.Windows.Forms.Label();
            this.LblSenderIBAN = new System.Windows.Forms.Label();
            this.MnuMain = new System.Windows.Forms.MenuStrip();
            this.MnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFileLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuFilePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuFileQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtReceiver
            // 
            this.TxtReceiver.Location = new System.Drawing.Point(12, 54);
            this.TxtReceiver.Name = "TxtReceiver";
            this.TxtReceiver.Size = new System.Drawing.Size(456, 22);
            this.TxtReceiver.TabIndex = 0;
            this.TxtReceiver.TextChanged += new System.EventHandler(this.TxtReceiver_TextChanged);
            // 
            // TxtReceiverIBAN
            // 
            this.TxtReceiverIBAN.Location = new System.Drawing.Point(12, 99);
            this.TxtReceiverIBAN.Name = "TxtReceiverIBAN";
            this.TxtReceiverIBAN.Size = new System.Drawing.Size(456, 22);
            this.TxtReceiverIBAN.TabIndex = 2;
            this.TxtReceiverIBAN.TextChanged += new System.EventHandler(this.TxtReceiverIBAN_TextChanged);
            // 
            // TxtReceiverBIC
            // 
            this.TxtReceiverBIC.Location = new System.Drawing.Point(12, 144);
            this.TxtReceiverBIC.Name = "TxtReceiverBIC";
            this.TxtReceiverBIC.Size = new System.Drawing.Size(219, 22);
            this.TxtReceiverBIC.TabIndex = 3;
            this.TxtReceiverBIC.TextChanged += new System.EventHandler(this.TxtReceiverBIC_TextChanged);
            // 
            // TxtAmount
            // 
            this.TxtAmount.Location = new System.Drawing.Point(234, 189);
            this.TxtAmount.Name = "TxtAmount";
            this.TxtAmount.Size = new System.Drawing.Size(234, 22);
            this.TxtAmount.TabIndex = 4;
            this.TxtAmount.TextChanged += new System.EventHandler(this.TxtAmount_TextChanged);
            // 
            // TxtSenderIdent
            // 
            this.TxtSenderIdent.Location = new System.Drawing.Point(12, 324);
            this.TxtSenderIdent.Name = "TxtSenderIdent";
            this.TxtSenderIdent.Size = new System.Drawing.Size(456, 22);
            this.TxtSenderIdent.TabIndex = 5;
            this.TxtSenderIdent.TextChanged += new System.EventHandler(this.TxtSenderIdent_TextChanged);
            // 
            // TxtSenderUsage1
            // 
            this.TxtSenderUsage1.Location = new System.Drawing.Point(12, 234);
            this.TxtSenderUsage1.Name = "TxtSenderUsage1";
            this.TxtSenderUsage1.Size = new System.Drawing.Size(456, 22);
            this.TxtSenderUsage1.TabIndex = 6;
            this.TxtSenderUsage1.TextChanged += new System.EventHandler(this.TxtSenderUsage1_TextChanged);
            // 
            // TxtSenderUsage2
            // 
            this.TxtSenderUsage2.Location = new System.Drawing.Point(12, 279);
            this.TxtSenderUsage2.Name = "TxtSenderUsage2";
            this.TxtSenderUsage2.Size = new System.Drawing.Size(456, 22);
            this.TxtSenderUsage2.TabIndex = 7;
            this.TxtSenderUsage2.TextChanged += new System.EventHandler(this.TxtSenderUsage2_TextChanged);
            // 
            // TxtSenderIBAN
            // 
            this.TxtSenderIBAN.Location = new System.Drawing.Point(12, 369);
            this.TxtSenderIBAN.Name = "TxtSenderIBAN";
            this.TxtSenderIBAN.Size = new System.Drawing.Size(456, 22);
            this.TxtSenderIBAN.TabIndex = 8;
            this.TxtSenderIBAN.TextChanged += new System.EventHandler(this.TxtSenderIBAN_TextChanged);
            // 
            // LblReceiver
            // 
            this.LblReceiver.AutoSize = true;
            this.LblReceiver.Location = new System.Drawing.Point(9, 34);
            this.LblReceiver.Name = "LblReceiver";
            this.LblReceiver.Size = new System.Drawing.Size(77, 17);
            this.LblReceiver.TabIndex = 9;
            this.LblReceiver.Text = "Empfänger";
            // 
            // LblReceiverIBAN
            // 
            this.LblReceiverIBAN.AutoSize = true;
            this.LblReceiverIBAN.Location = new System.Drawing.Point(9, 79);
            this.LblReceiverIBAN.Name = "LblReceiverIBAN";
            this.LblReceiverIBAN.Size = new System.Drawing.Size(112, 17);
            this.LblReceiverIBAN.TabIndex = 10;
            this.LblReceiverIBAN.Text = "Empfänger IBAN";
            // 
            // LblReceiverBIC
            // 
            this.LblReceiverBIC.AutoSize = true;
            this.LblReceiverBIC.Location = new System.Drawing.Point(9, 124);
            this.LblReceiverBIC.Name = "LblReceiverBIC";
            this.LblReceiverBIC.Size = new System.Drawing.Size(29, 17);
            this.LblReceiverBIC.TabIndex = 11;
            this.LblReceiverBIC.Text = "BIC";
            // 
            // LblAmount
            // 
            this.LblAmount.AutoSize = true;
            this.LblAmount.Location = new System.Drawing.Point(231, 169);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(121, 17);
            this.LblAmount.TabIndex = 12;
            this.LblAmount.Text = "Betrag: Euro,Cent";
            // 
            // LblSenderUsage1
            // 
            this.LblSenderUsage1.AutoSize = true;
            this.LblSenderUsage1.Location = new System.Drawing.Point(9, 214);
            this.LblSenderUsage1.Name = "LblSenderUsage1";
            this.LblSenderUsage1.Size = new System.Drawing.Size(303, 17);
            this.LblSenderUsage1.TabIndex = 13;
            this.LblSenderUsage1.Text = "Kunden-Referenznummer - Vewendungszweck";
            // 
            // LblSenderUsage2
            // 
            this.LblSenderUsage2.AutoSize = true;
            this.LblSenderUsage2.Location = new System.Drawing.Point(9, 259);
            this.LblSenderUsage2.Name = "LblSenderUsage2";
            this.LblSenderUsage2.Size = new System.Drawing.Size(167, 17);
            this.LblSenderUsage2.TabIndex = 14;
            this.LblSenderUsage2.Text = "noch Verwendungszweck";
            // 
            // LblSenderIdent
            // 
            this.LblSenderIdent.AutoSize = true;
            this.LblSenderIdent.Location = new System.Drawing.Point(9, 304);
            this.LblSenderIdent.Name = "LblSenderIdent";
            this.LblSenderIdent.Size = new System.Drawing.Size(229, 17);
            this.LblSenderIdent.TabIndex = 15;
            this.LblSenderIdent.Text = "Angaben zum Kontoinhaber/Zahler";
            // 
            // LblSenderIBAN
            // 
            this.LblSenderIBAN.AutoSize = true;
            this.LblSenderIBAN.Location = new System.Drawing.Point(9, 349);
            this.LblSenderIBAN.Name = "LblSenderIBAN";
            this.LblSenderIBAN.Size = new System.Drawing.Size(84, 17);
            this.LblSenderIBAN.TabIndex = 16;
            this.LblSenderIBAN.Text = "Zahler IBAN";
            // 
            // MnuMain
            // 
            this.MnuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFile,
            this.MnuAbout});
            this.MnuMain.Location = new System.Drawing.Point(0, 0);
            this.MnuMain.Name = "MnuMain";
            this.MnuMain.Size = new System.Drawing.Size(482, 28);
            this.MnuMain.TabIndex = 17;
            this.MnuMain.Text = "Hauptmenü";
            // 
            // MnuFile
            // 
            this.MnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFileNew,
            this.MnuFileSave,
            this.toolStripMenuItem1,
            this.MnuFileLoad,
            this.toolStripSeparator1,
            this.MnuFilePrint,
            this.toolStripSeparator2,
            this.MnuFileQuit});
            this.MnuFile.Name = "MnuFile";
            this.MnuFile.Size = new System.Drawing.Size(59, 24);
            this.MnuFile.Text = "Datei";
            // 
            // MnuFileNew
            // 
            this.MnuFileNew.Name = "MnuFileNew";
            this.MnuFileNew.Size = new System.Drawing.Size(224, 26);
            this.MnuFileNew.Text = "Neu";
            this.MnuFileNew.Click += new System.EventHandler(this.MnuFileNew_Click);
            // 
            // MnuFileSave
            // 
            this.MnuFileSave.Name = "MnuFileSave";
            this.MnuFileSave.Size = new System.Drawing.Size(224, 26);
            this.MnuFileSave.Text = "Speichern";
            this.MnuFileSave.Click += new System.EventHandler(this.MnuFileSave_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.toolStripMenuItem1.Text = "Speichern Unter";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.MnuFileSaveAs_Click);
            // 
            // MnuFileLoad
            // 
            this.MnuFileLoad.Name = "MnuFileLoad";
            this.MnuFileLoad.Size = new System.Drawing.Size(224, 26);
            this.MnuFileLoad.Text = "Laden";
            this.MnuFileLoad.Click += new System.EventHandler(this.MnuFileLoad_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // MnuFilePrint
            // 
            this.MnuFilePrint.Name = "MnuFilePrint";
            this.MnuFilePrint.Size = new System.Drawing.Size(224, 26);
            this.MnuFilePrint.Text = "Drucken";
            this.MnuFilePrint.Click += new System.EventHandler(this.MnuFilePrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // MnuFileQuit
            // 
            this.MnuFileQuit.Name = "MnuFileQuit";
            this.MnuFileQuit.Size = new System.Drawing.Size(224, 26);
            this.MnuFileQuit.Text = "Schließen";
            this.MnuFileQuit.Click += new System.EventHandler(this.MnuFileQuit_Click);
            // 
            // MnuAbout
            // 
            this.MnuAbout.Name = "MnuAbout";
            this.MnuAbout.Size = new System.Drawing.Size(55, 24);
            this.MnuAbout.Text = "Über";
            this.MnuAbout.Click += new System.EventHandler(this.MnuAbout_Click);
            // 
            // SEPA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 408);
            this.Controls.Add(this.LblSenderIBAN);
            this.Controls.Add(this.LblSenderIdent);
            this.Controls.Add(this.LblSenderUsage2);
            this.Controls.Add(this.LblSenderUsage1);
            this.Controls.Add(this.LblAmount);
            this.Controls.Add(this.LblReceiverBIC);
            this.Controls.Add(this.LblReceiverIBAN);
            this.Controls.Add(this.LblReceiver);
            this.Controls.Add(this.TxtSenderIBAN);
            this.Controls.Add(this.TxtSenderUsage2);
            this.Controls.Add(this.TxtSenderUsage1);
            this.Controls.Add(this.TxtSenderIdent);
            this.Controls.Add(this.TxtAmount);
            this.Controls.Add(this.TxtReceiverBIC);
            this.Controls.Add(this.TxtReceiverIBAN);
            this.Controls.Add(this.TxtReceiver);
            this.Controls.Add(this.MnuMain);
            this.MainMenuStrip = this.MnuMain;
            this.MaximizeBox = false;
            this.Name = "SEPA";
            this.Text = "SEPA Drucker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MnuMain.ResumeLayout(false);
            this.MnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtReceiver;
        private System.Windows.Forms.TextBox TxtReceiverIBAN;
        private System.Windows.Forms.TextBox TxtReceiverBIC;
        private System.Windows.Forms.TextBox TxtAmount;
        private System.Windows.Forms.TextBox TxtSenderIdent;
        private System.Windows.Forms.TextBox TxtSenderUsage1;
        private System.Windows.Forms.TextBox TxtSenderUsage2;
        private System.Windows.Forms.TextBox TxtSenderIBAN;
        private System.Windows.Forms.Label LblReceiver;
        private System.Windows.Forms.Label LblReceiverIBAN;
        private System.Windows.Forms.Label LblReceiverBIC;
        private System.Windows.Forms.Label LblAmount;
        private System.Windows.Forms.Label LblSenderUsage1;
        private System.Windows.Forms.Label LblSenderUsage2;
        private System.Windows.Forms.Label LblSenderIdent;
        private System.Windows.Forms.Label LblSenderIBAN;
        private System.Windows.Forms.MenuStrip MnuMain;
        private System.Windows.Forms.ToolStripMenuItem MnuFile;
        private System.Windows.Forms.ToolStripMenuItem MnuFileSave;
        private System.Windows.Forms.ToolStripMenuItem MnuFileLoad;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem MnuFilePrint;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem MnuFileQuit;
        private ToolStripMenuItem MnuFileNew;
        private ToolStripMenuItem MnuAbout;
    }
}

