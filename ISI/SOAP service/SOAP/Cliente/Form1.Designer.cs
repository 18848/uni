namespace Cliente
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.atualizar = new System.Windows.Forms.Button();
            this.adicionar = new System.Windows.Forms.Button();
            this.procurar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nomeBox = new System.Windows.Forms.TextBox();
            this.nifBox = new System.Windows.Forms.TextBox();
            this.GetUtentes = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.nifContactoBox = new System.Windows.Forms.TextBox();
            this.atualizarContactos = new System.Windows.Forms.Button();
            this.adicionarContactos = new System.Windows.Forms.Button();
            this.procurarContactos = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.idCasoBox = new System.Windows.Forms.TextBox();
            this.GetContactos = new System.Windows.Forms.DataGridView();
            this.dataPicker = new System.Windows.Forms.DateTimePicker();
            this.atualizarCasos = new System.Windows.Forms.Button();
            this.adicionarCasos = new System.Windows.Forms.Button();
            this.procurarCasos = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nifCasosBox = new System.Windows.Forms.TextBox();
            this.GetCasos = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GetUtentes)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GetContactos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetCasos)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(789, 438);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.atualizar);
            this.tabPage1.Controls.Add(this.adicionar);
            this.tabPage1.Controls.Add(this.procurar);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.nomeBox);
            this.tabPage1.Controls.Add(this.nifBox);
            this.tabPage1.Controls.Add(this.GetUtentes);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(781, 412);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Utentes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // atualizar
            // 
            this.atualizar.Location = new System.Drawing.Point(344, 156);
            this.atualizar.Name = "atualizar";
            this.atualizar.Size = new System.Drawing.Size(75, 23);
            this.atualizar.TabIndex = 10;
            this.atualizar.Text = "Atualizar";
            this.atualizar.UseVisualStyleBackColor = true;
            this.atualizar.Click += new System.EventHandler(this.atualizar_Click);
            // 
            // adicionar
            // 
            this.adicionar.Location = new System.Drawing.Point(169, 156);
            this.adicionar.Name = "adicionar";
            this.adicionar.Size = new System.Drawing.Size(75, 23);
            this.adicionar.TabIndex = 9;
            this.adicionar.Text = "Adicionar";
            this.adicionar.UseVisualStyleBackColor = true;
            this.adicionar.Click += new System.EventHandler(this.adicionar_Click);
            // 
            // procurar
            // 
            this.procurar.Location = new System.Drawing.Point(56, 156);
            this.procurar.Name = "procurar";
            this.procurar.Size = new System.Drawing.Size(75, 23);
            this.procurar.TabIndex = 8;
            this.procurar.Text = "Procurar";
            this.procurar.UseVisualStyleBackColor = true;
            this.procurar.Click += new System.EventHandler(this.procurar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "NIF";
            // 
            // nomeBox
            // 
            this.nomeBox.Location = new System.Drawing.Point(56, 114);
            this.nomeBox.Name = "nomeBox";
            this.nomeBox.Size = new System.Drawing.Size(188, 20);
            this.nomeBox.TabIndex = 3;
            // 
            // nifBox
            // 
            this.nifBox.Location = new System.Drawing.Point(56, 61);
            this.nifBox.Name = "nifBox";
            this.nifBox.Size = new System.Drawing.Size(188, 20);
            this.nifBox.TabIndex = 2;
            // 
            // GetUtentes
            // 
            this.GetUtentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GetUtentes.Location = new System.Drawing.Point(425, 6);
            this.GetUtentes.Name = "GetUtentes";
            this.GetUtentes.Size = new System.Drawing.Size(350, 400);
            this.GetUtentes.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.nifContactoBox);
            this.tabPage2.Controls.Add(this.atualizarContactos);
            this.tabPage2.Controls.Add(this.adicionarContactos);
            this.tabPage2.Controls.Add(this.procurarContactos);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.idCasoBox);
            this.tabPage2.Controls.Add(this.GetContactos);
            this.tabPage2.Controls.Add(this.dataPicker);
            this.tabPage2.Controls.Add(this.atualizarCasos);
            this.tabPage2.Controls.Add(this.adicionarCasos);
            this.tabPage2.Controls.Add(this.procurarCasos);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.nifCasosBox);
            this.tabPage2.Controls.Add(this.GetCasos);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(781, 412);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Casos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // nifContactoBox
            // 
            this.nifContactoBox.Location = new System.Drawing.Point(59, 293);
            this.nifContactoBox.Name = "nifContactoBox";
            this.nifContactoBox.Size = new System.Drawing.Size(188, 20);
            this.nifContactoBox.TabIndex = 28;
            // 
            // atualizarContactos
            // 
            this.atualizarContactos.Location = new System.Drawing.Point(347, 338);
            this.atualizarContactos.Name = "atualizarContactos";
            this.atualizarContactos.Size = new System.Drawing.Size(75, 23);
            this.atualizarContactos.TabIndex = 26;
            this.atualizarContactos.Text = "Atualizar";
            this.atualizarContactos.UseVisualStyleBackColor = true;
            this.atualizarContactos.Click += new System.EventHandler(this.atualizarContactos_Click);
            // 
            // adicionarContactos
            // 
            this.adicionarContactos.Location = new System.Drawing.Point(172, 338);
            this.adicionarContactos.Name = "adicionarContactos";
            this.adicionarContactos.Size = new System.Drawing.Size(75, 23);
            this.adicionarContactos.TabIndex = 25;
            this.adicionarContactos.Text = "Adicionar";
            this.adicionarContactos.UseVisualStyleBackColor = true;
            this.adicionarContactos.Click += new System.EventHandler(this.adicionarContactos_Click);
            // 
            // procurarContactos
            // 
            this.procurarContactos.Location = new System.Drawing.Point(59, 338);
            this.procurarContactos.Name = "procurarContactos";
            this.procurarContactos.Size = new System.Drawing.Size(75, 23);
            this.procurarContactos.TabIndex = 24;
            this.procurarContactos.Text = "Procurar";
            this.procurarContactos.UseVisualStyleBackColor = true;
            this.procurarContactos.Click += new System.EventHandler(this.procurarContactos_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "NIF";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "ID de Caso";
            // 
            // idCasoBox
            // 
            this.idCasoBox.Location = new System.Drawing.Point(59, 243);
            this.idCasoBox.Name = "idCasoBox";
            this.idCasoBox.Size = new System.Drawing.Size(188, 20);
            this.idCasoBox.TabIndex = 21;
            // 
            // GetContactos
            // 
            this.GetContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GetContactos.Location = new System.Drawing.Point(428, 185);
            this.GetContactos.Name = "GetContactos";
            this.GetContactos.Size = new System.Drawing.Size(350, 221);
            this.GetContactos.TabIndex = 20;
            // 
            // dataPicker
            // 
            this.dataPicker.Location = new System.Drawing.Point(59, 111);
            this.dataPicker.Name = "dataPicker";
            this.dataPicker.Size = new System.Drawing.Size(188, 20);
            this.dataPicker.TabIndex = 19;
            this.dataPicker.Value = new System.DateTime(2021, 11, 25, 9, 44, 37, 0);
            // 
            // atualizarCasos
            // 
            this.atualizarCasos.Location = new System.Drawing.Point(347, 156);
            this.atualizarCasos.Name = "atualizarCasos";
            this.atualizarCasos.Size = new System.Drawing.Size(75, 23);
            this.atualizarCasos.TabIndex = 18;
            this.atualizarCasos.Text = "Atualizar";
            this.atualizarCasos.UseVisualStyleBackColor = true;
            this.atualizarCasos.Click += new System.EventHandler(this.atualizarCasos_Click);
            // 
            // adicionarCasos
            // 
            this.adicionarCasos.Location = new System.Drawing.Point(172, 156);
            this.adicionarCasos.Name = "adicionarCasos";
            this.adicionarCasos.Size = new System.Drawing.Size(75, 23);
            this.adicionarCasos.TabIndex = 17;
            this.adicionarCasos.Text = "Adicionar";
            this.adicionarCasos.UseVisualStyleBackColor = true;
            this.adicionarCasos.Click += new System.EventHandler(this.adicionarCasos_Click);
            // 
            // procurarCasos
            // 
            this.procurarCasos.Location = new System.Drawing.Point(59, 156);
            this.procurarCasos.Name = "procurarCasos";
            this.procurarCasos.Size = new System.Drawing.Size(75, 23);
            this.procurarCasos.TabIndex = 16;
            this.procurarCasos.Text = "Procurar";
            this.procurarCasos.UseVisualStyleBackColor = true;
            this.procurarCasos.Click += new System.EventHandler(this.procurarCasos_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "NIF";
            // 
            // nifCasosBox
            // 
            this.nifCasosBox.Location = new System.Drawing.Point(59, 61);
            this.nifCasosBox.Name = "nifCasosBox";
            this.nifCasosBox.Size = new System.Drawing.Size(188, 20);
            this.nifCasosBox.TabIndex = 12;
            // 
            // GetCasos
            // 
            this.GetCasos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GetCasos.Location = new System.Drawing.Point(428, 6);
            this.GetCasos.Name = "GetCasos";
            this.GetCasos.Size = new System.Drawing.Size(350, 173);
            this.GetCasos.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GetUtentes)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GetContactos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetCasos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox nomeBox;
        private System.Windows.Forms.TextBox nifBox;
        private System.Windows.Forms.DataGridView GetUtentes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button procurar;
        private System.Windows.Forms.Button atualizar;
        private System.Windows.Forms.Button adicionar;
        private System.Windows.Forms.Button atualizarCasos;
        private System.Windows.Forms.Button adicionarCasos;
        private System.Windows.Forms.Button procurarCasos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nifCasosBox;
        private System.Windows.Forms.DataGridView GetCasos;
        private System.Windows.Forms.DateTimePicker dataPicker;
        private System.Windows.Forms.TextBox nifContactoBox;
        private System.Windows.Forms.Button atualizarContactos;
        private System.Windows.Forms.Button adicionarContactos;
        private System.Windows.Forms.Button procurarContactos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox idCasoBox;
        private System.Windows.Forms.DataGridView GetContactos;
    }
}

