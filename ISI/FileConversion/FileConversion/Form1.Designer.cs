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
            this.xmlLoadButton = new System.Windows.Forms.Button();
            this.xmlSendButton = new System.Windows.Forms.Button();
            this.xmlVerifyButton = new System.Windows.Forms.Button();
            this.xmlTextBox = new System.Windows.Forms.RichTextBox();
            this.JSON = new System.Windows.Forms.TabPage();
            this.jsonLoadButton = new System.Windows.Forms.Button();
            this.jsonSendButton = new System.Windows.Forms.Button();
            this.jsonVerifyButton = new System.Windows.Forms.Button();
            this.jsonTextBox = new System.Windows.Forms.RichTextBox();
            this.GetDB = new System.Windows.Forms.TabPage();
            this.dataBaseGridView = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.XML.SuspendLayout();
            this.JSON.SuspendLayout();
            this.GetDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseGridView)).BeginInit();
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
            this.GetDB.Controls.Add(this.dataBaseGridView);
            this.GetDB.Location = new System.Drawing.Point(4, 22);
            this.GetDB.Name = "GetDB";
            this.GetDB.Padding = new System.Windows.Forms.Padding(3);
            this.GetDB.Size = new System.Drawing.Size(780, 412);
            this.GetDB.TabIndex = 2;
            this.GetDB.Text = "GetDB";
            this.GetDB.UseVisualStyleBackColor = true;
            // 
            // dataBaseGridView
            // 
            this.dataBaseGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBaseGridView.Location = new System.Drawing.Point(6, 6);
            this.dataBaseGridView.Name = "dataBaseGridView";
            this.dataBaseGridView.Size = new System.Drawing.Size(311, 400);
            this.dataBaseGridView.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.XML.ResumeLayout(false);
            this.JSON.ResumeLayout(false);
            this.GetDB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseGridView)).EndInit();
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
        private System.Windows.Forms.DataGridView dataBaseGridView;
        private System.Windows.Forms.Button xmlLoadButton;
        private System.Windows.Forms.Button jsonLoadButton;
        private System.Windows.Forms.Button jsonSendButton;
        private System.Windows.Forms.Button jsonVerifyButton;
    }
}

