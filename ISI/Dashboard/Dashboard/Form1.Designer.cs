namespace Dashboard
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.equipasTab = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.casosTab = new System.Windows.Forms.TabPage();
            this.mediaGridView = new System.Windows.Forms.DataGridView();
            this.casosGridView = new System.Windows.Forms.DataGridView();
            this.casosbutton = new System.Windows.Forms.Button();
            this.visitasTab = new System.Windows.Forms.TabPage();
            this.visitas = new System.Windows.Forms.Button();
            this.dgsTab = new System.Windows.Forms.TabPage();
            this.dgs = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.visitasGridView = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.equipasTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.casosTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.casosGridView)).BeginInit();
            this.visitasTab.SuspendLayout();
            this.dgsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitasGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.equipasTab);
            this.tabControl.Controls.Add(this.casosTab);
            this.tabControl.Controls.Add(this.visitasTab);
            this.tabControl.Controls.Add(this.dgsTab);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(788, 438);
            this.tabControl.TabIndex = 0;
            // 
            // equipasTab
            // 
            this.equipasTab.Controls.Add(this.button2);
            this.equipasTab.Controls.Add(this.button1);
            this.equipasTab.Controls.Add(this.dataGridView3);
            this.equipasTab.Controls.Add(this.dataGridView2);
            this.equipasTab.Location = new System.Drawing.Point(4, 22);
            this.equipasTab.Name = "equipasTab";
            this.equipasTab.Padding = new System.Windows.Forms.Padding(3);
            this.equipasTab.Size = new System.Drawing.Size(780, 412);
            this.equipasTab.TabIndex = 0;
            this.equipasTab.Text = "Equipas";
            this.equipasTab.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(305, 233);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Produtos Mais Requisitados";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(305, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Equipas Mais Caras";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(489, 6);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(285, 400);
            this.dataGridView3.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 6);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(264, 400);
            this.dataGridView2.TabIndex = 0;
            // 
            // casosTab
            // 
            this.casosTab.Controls.Add(this.mediaGridView);
            this.casosTab.Controls.Add(this.casosGridView);
            this.casosTab.Controls.Add(this.casosbutton);
            this.casosTab.Location = new System.Drawing.Point(4, 22);
            this.casosTab.Name = "casosTab";
            this.casosTab.Padding = new System.Windows.Forms.Padding(3);
            this.casosTab.Size = new System.Drawing.Size(780, 412);
            this.casosTab.TabIndex = 1;
            this.casosTab.Text = "Casos";
            this.casosTab.UseVisualStyleBackColor = true;
            // 
            // mediaGridView
            // 
            this.mediaGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mediaGridView.Location = new System.Drawing.Point(193, 6);
            this.mediaGridView.Name = "mediaGridView";
            this.mediaGridView.Size = new System.Drawing.Size(298, 400);
            this.mediaGridView.TabIndex = 2;
            // 
            // casosGridView
            // 
            this.casosGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.casosGridView.Location = new System.Drawing.Point(497, 6);
            this.casosGridView.Name = "casosGridView";
            this.casosGridView.Size = new System.Drawing.Size(277, 400);
            this.casosGridView.TabIndex = 1;
            // 
            // casosbutton
            // 
            this.casosbutton.Location = new System.Drawing.Point(8, 126);
            this.casosbutton.Name = "casosbutton";
            this.casosbutton.Size = new System.Drawing.Size(156, 23);
            this.casosbutton.TabIndex = 0;
            this.casosbutton.Text = "Média de Casos";
            this.casosbutton.UseVisualStyleBackColor = true;
            this.casosbutton.Click += new System.EventHandler(this.casos_Click);
            // 
            // visitasTab
            // 
            this.visitasTab.Controls.Add(this.visitasGridView);
            this.visitasTab.Controls.Add(this.visitas);
            this.visitasTab.Location = new System.Drawing.Point(4, 22);
            this.visitasTab.Name = "visitasTab";
            this.visitasTab.Padding = new System.Windows.Forms.Padding(3);
            this.visitasTab.Size = new System.Drawing.Size(780, 412);
            this.visitasTab.TabIndex = 2;
            this.visitasTab.Text = "Visitas";
            this.visitasTab.UseVisualStyleBackColor = true;
            // 
            // visitas
            // 
            this.visitas.Location = new System.Drawing.Point(8, 112);
            this.visitas.Name = "visitas";
            this.visitas.Size = new System.Drawing.Size(156, 23);
            this.visitas.TabIndex = 1;
            this.visitas.Text = "Visitas Diarias";
            this.visitas.UseVisualStyleBackColor = true;
            this.visitas.Click += new System.EventHandler(this.visitas_Click);
            // 
            // dgsTab
            // 
            this.dgsTab.Controls.Add(this.dgs);
            this.dgsTab.Controls.Add(this.dataGridView1);
            this.dgsTab.Location = new System.Drawing.Point(4, 22);
            this.dgsTab.Name = "dgsTab";
            this.dgsTab.Padding = new System.Windows.Forms.Padding(3);
            this.dgsTab.Size = new System.Drawing.Size(780, 412);
            this.dgsTab.TabIndex = 3;
            this.dgsTab.Text = "DGS";
            this.dgsTab.UseVisualStyleBackColor = true;
            // 
            // dgs
            // 
            this.dgs.Location = new System.Drawing.Point(501, 101);
            this.dgs.Name = "dgs";
            this.dgs.Size = new System.Drawing.Size(75, 23);
            this.dgs.TabIndex = 1;
            this.dgs.Text = "butoum";
            this.dgs.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(340, 409);
            this.dataGridView1.TabIndex = 0;
            // 
            // visitasGridView
            // 
            this.visitasGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.visitasGridView.Location = new System.Drawing.Point(376, 6);
            this.visitasGridView.Name = "visitasGridView";
            this.visitasGridView.Size = new System.Drawing.Size(398, 400);
            this.visitasGridView.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "Dashboard";
            this.tabControl.ResumeLayout(false);
            this.equipasTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.casosTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mediaGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.casosGridView)).EndInit();
            this.visitasTab.ResumeLayout(false);
            this.dgsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitasGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage equipasTab;
        private System.Windows.Forms.TabPage casosTab;
        private System.Windows.Forms.TabPage visitasTab;
        private System.Windows.Forms.TabPage dgsTab;
        private System.Windows.Forms.Button dgs;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button casosbutton;
        private System.Windows.Forms.DataGridView casosGridView;
        private System.Windows.Forms.DataGridView mediaGridView;
        private System.Windows.Forms.Button visitas;
        private System.Windows.Forms.DataGridView visitasGridView;
    }
}

