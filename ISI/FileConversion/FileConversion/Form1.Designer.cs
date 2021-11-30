namespace FileConversion
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.XML = new System.Windows.Forms.TabPage();
            this.xmlFilePath = new System.Windows.Forms.Label();
            this.xmlLoadButton = new System.Windows.Forms.Button();
            this.xmlSendButton = new System.Windows.Forms.Button();
            this.xmlVerifyButton = new System.Windows.Forms.Button();
            this.xmlTextBox = new System.Windows.Forms.RichTextBox();
            this.JSON = new System.Windows.Forms.TabPage();
            this.jsonFilePath = new System.Windows.Forms.Label();
            this.jsonLoadButton = new System.Windows.Forms.Button();
            this.jsonSendButton = new System.Windows.Forms.Button();
            this.jsonVerifyButton = new System.Windows.Forms.Button();
            this.jsonTextBox = new System.Windows.Forms.RichTextBox();
            this.GetDB = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.idFiscalizacaoTextBox = new System.Windows.Forms.TextBox();
            this.atualizarDatabase = new System.Windows.Forms.Button();
            this.irregularidadesDataGrid = new System.Windows.Forms.DataGridView();
            this.databaseGridView = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.XML.SuspendLayout();
            this.JSON.SuspendLayout();
            this.GetDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.irregularidadesDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.XML);
            this.tabControl1.Controls.Add(this.JSON);
            this.tabControl1.Controls.Add(this.GetDB);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(788, 438);
            this.tabControl1.TabIndex = 0;
            // 
            // XML
            // 
            this.XML.Controls.Add(this.xmlFilePath);
            this.XML.Controls.Add(this.xmlLoadButton);
            this.XML.Controls.Add(this.xmlSendButton);
            this.XML.Controls.Add(this.xmlVerifyButton);
            this.XML.Controls.Add(this.xmlTextBox);
            this.XML.Location = new System.Drawing.Point(4, 22);
            this.XML.Name = "XML";
            this.XML.Padding = new System.Windows.Forms.Padding(3);
            this.XML.Size = new System.Drawing.Size(780, 412);
            this.XML.TabIndex = 0;
            this.XML.Text = "XML";
            this.XML.UseVisualStyleBackColor = true;
            // 
            // xmlFilePath
            // 
            this.xmlFilePath.AutoSize = true;
            this.xmlFilePath.Location = new System.Drawing.Point(406, 11);
            this.xmlFilePath.Name = "xmlFilePath";
            this.xmlFilePath.Size = new System.Drawing.Size(29, 13);
            this.xmlFilePath.TabIndex = 4;
            this.xmlFilePath.Text = "File: ";
            // 
            // xmlLoadButton
            // 
            this.xmlLoadButton.Location = new System.Drawing.Point(325, 6);
            this.xmlLoadButton.Name = "xmlLoadButton";
            this.xmlLoadButton.Size = new System.Drawing.Size(75, 23);
            this.xmlLoadButton.TabIndex = 3;
            this.xmlLoadButton.Text = "Load";
            this.xmlLoadButton.UseVisualStyleBackColor = true;
            this.xmlLoadButton.Click += new System.EventHandler(this.xmlLoadButton_Click);
            // 
            // xmlSendButton
            // 
            this.xmlSendButton.Location = new System.Drawing.Point(325, 383);
            this.xmlSendButton.Name = "xmlSendButton";
            this.xmlSendButton.Size = new System.Drawing.Size(75, 23);
            this.xmlSendButton.TabIndex = 2;
            this.xmlSendButton.Text = "Send";
            this.xmlSendButton.UseVisualStyleBackColor = true;
            this.xmlSendButton.Click += new System.EventHandler(this.xmlSendButton_Click);
            // 
            // xmlVerifyButton
            // 
            this.xmlVerifyButton.Location = new System.Drawing.Point(325, 354);
            this.xmlVerifyButton.Name = "xmlVerifyButton";
            this.xmlVerifyButton.Size = new System.Drawing.Size(75, 23);
            this.xmlVerifyButton.TabIndex = 1;
            this.xmlVerifyButton.Text = "Verify";
            this.xmlVerifyButton.UseVisualStyleBackColor = true;
            // 
            // xmlTextBox
            // 
            this.xmlTextBox.Location = new System.Drawing.Point(6, 6);
            this.xmlTextBox.Name = "xmlTextBox";
            this.xmlTextBox.Size = new System.Drawing.Size(313, 400);
            this.xmlTextBox.TabIndex = 0;
            this.xmlTextBox.Text = "";
            // 
            // JSON
            // 
            this.JSON.Controls.Add(this.jsonFilePath);
            this.JSON.Controls.Add(this.jsonLoadButton);
            this.JSON.Controls.Add(this.jsonSendButton);
            this.JSON.Controls.Add(this.jsonVerifyButton);
            this.JSON.Controls.Add(this.jsonTextBox);
            this.JSON.Location = new System.Drawing.Point(4, 22);
            this.JSON.Name = "JSON";
            this.JSON.Padding = new System.Windows.Forms.Padding(3);
            this.JSON.Size = new System.Drawing.Size(780, 412);
            this.JSON.TabIndex = 1;
            this.JSON.Text = "JSON";
            this.JSON.UseVisualStyleBackColor = true;
            // 
            // jsonFilePath
            // 
            this.jsonFilePath.AutoSize = true;
            this.jsonFilePath.Location = new System.Drawing.Point(406, 11);
            this.jsonFilePath.Name = "jsonFilePath";
            this.jsonFilePath.Size = new System.Drawing.Size(29, 13);
            this.jsonFilePath.TabIndex = 7;
            this.jsonFilePath.Text = "File: ";
            // 
            // jsonLoadButton
            // 
            this.jsonLoadButton.Location = new System.Drawing.Point(325, 6);
            this.jsonLoadButton.Name = "jsonLoadButton";
            this.jsonLoadButton.Size = new System.Drawing.Size(75, 23);
            this.jsonLoadButton.TabIndex = 6;
            this.jsonLoadButton.Text = "Load";
            this.jsonLoadButton.UseVisualStyleBackColor = true;
            this.jsonLoadButton.Click += new System.EventHandler(this.jsonLoadButton_Click);
            // 
            // jsonSendButton
            // 
            this.jsonSendButton.Location = new System.Drawing.Point(325, 383);
            this.jsonSendButton.Name = "jsonSendButton";
            this.jsonSendButton.Size = new System.Drawing.Size(75, 23);
            this.jsonSendButton.TabIndex = 5;
            this.jsonSendButton.Text = "Send";
            this.jsonSendButton.UseVisualStyleBackColor = true;
            this.jsonSendButton.Click += new System.EventHandler(this.jsonSendButton_Click);
            // 
            // jsonVerifyButton
            // 
            this.jsonVerifyButton.Location = new System.Drawing.Point(325, 354);
            this.jsonVerifyButton.Name = "jsonVerifyButton";
            this.jsonVerifyButton.Size = new System.Drawing.Size(75, 23);
            this.jsonVerifyButton.TabIndex = 4;
            this.jsonVerifyButton.Text = "Verify";
            this.jsonVerifyButton.UseVisualStyleBackColor = true;
            this.jsonVerifyButton.Click += new System.EventHandler(this.jsonVerifyButton_Click);
            // 
            // jsonTextBox
            // 
            this.jsonTextBox.Location = new System.Drawing.Point(6, 6);
            this.jsonTextBox.Name = "jsonTextBox";
            this.jsonTextBox.Size = new System.Drawing.Size(313, 400);
            this.jsonTextBox.TabIndex = 1;
            this.jsonTextBox.Text = "";
            // 
            // GetDB
            // 
            this.GetDB.Controls.Add(this.label1);
            this.GetDB.Controls.Add(this.idFiscalizacaoTextBox);
            this.GetDB.Controls.Add(this.atualizarDatabase);
            this.GetDB.Controls.Add(this.irregularidadesDataGrid);
            this.GetDB.Controls.Add(this.databaseGridView);
            this.GetDB.Location = new System.Drawing.Point(4, 22);
            this.GetDB.Name = "GetDB";
            this.GetDB.Padding = new System.Windows.Forms.Padding(3);
            this.GetDB.Size = new System.Drawing.Size(780, 412);
            this.GetDB.TabIndex = 2;
            this.GetDB.Text = "GetDB";
            this.GetDB.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(473, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID Fiscalização";
            // 
            // idFiscalizacaoTextBox
            // 
            this.idFiscalizacaoTextBox.Location = new System.Drawing.Point(558, 6);
            this.idFiscalizacaoTextBox.Name = "idFiscalizacaoTextBox";
            this.idFiscalizacaoTextBox.Size = new System.Drawing.Size(135, 20);
            this.idFiscalizacaoTextBox.TabIndex = 3;
            // 
            // atualizarDatabase
            // 
            this.atualizarDatabase.Location = new System.Drawing.Point(699, 6);
            this.atualizarDatabase.Name = "atualizarDatabase";
            this.atualizarDatabase.Size = new System.Drawing.Size(75, 23);
            this.atualizarDatabase.TabIndex = 1;
            this.atualizarDatabase.Text = "Atualizar";
            this.atualizarDatabase.UseVisualStyleBackColor = true;
            this.atualizarDatabase.Click += new System.EventHandler(this.atualizarDatabase_Click);
            // 
            // irregularidadesDataGrid
            // 
            this.irregularidadesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.irregularidadesDataGrid.Location = new System.Drawing.Point(473, 32);
            this.irregularidadesDataGrid.Name = "irregularidadesDataGrid";
            this.irregularidadesDataGrid.Size = new System.Drawing.Size(301, 374);
            this.irregularidadesDataGrid.TabIndex = 2;
            // 
            // databaseGridView
            // 
            this.databaseGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.databaseGridView.Location = new System.Drawing.Point(0, 6);
            this.databaseGridView.Name = "databaseGridView";
            this.databaseGridView.Size = new System.Drawing.Size(467, 400);
            this.databaseGridView.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Importação XML/JSON";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.XML.ResumeLayout(false);
            this.XML.PerformLayout();
            this.JSON.ResumeLayout(false);
            this.JSON.PerformLayout();
            this.GetDB.ResumeLayout(false);
            this.GetDB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.irregularidadesDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage XML;
        private System.Windows.Forms.RichTextBox xmlTextBox;
        private System.Windows.Forms.TabPage JSON;
        private System.Windows.Forms.TabPage GetDB;
        private System.Windows.Forms.Button xmlSendButton;
        private System.Windows.Forms.Button xmlVerifyButton;
        private System.Windows.Forms.RichTextBox jsonTextBox;
        private System.Windows.Forms.DataGridView databaseGridView;
        private System.Windows.Forms.Button xmlLoadButton;
        private System.Windows.Forms.Button jsonLoadButton;
        private System.Windows.Forms.Button jsonSendButton;
        private System.Windows.Forms.Button jsonVerifyButton;
        private System.Windows.Forms.Label xmlFilePath;
        private System.Windows.Forms.Label jsonFilePath;
        private System.Windows.Forms.Button atualizarDatabase;
        private System.Windows.Forms.DataGridView irregularidadesDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idFiscalizacaoTextBox;
    }
}

