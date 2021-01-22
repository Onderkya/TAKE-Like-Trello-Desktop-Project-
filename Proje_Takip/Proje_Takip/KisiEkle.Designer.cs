namespace Proje_Takip
{
    partial class KisiEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KisiEkle));
            this.txt_projeAdi = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_projeid = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.list_tumKisiler = new System.Windows.Forms.ListBox();
            this.list_gorevliKisiler = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ara = new DevExpress.XtraEditors.TextEdit();
            this.btn_ara = new DevExpress.XtraEditors.SimpleButton();
            this.btn_kaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_projeAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_projeid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ara.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_projeAdi
            // 
            this.txt_projeAdi.Location = new System.Drawing.Point(345, 12);
            this.txt_projeAdi.Name = "txt_projeAdi";
            this.txt_projeAdi.Properties.Appearance.Font = new System.Drawing.Font("Ubuntu", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_projeAdi.Properties.Appearance.Options.UseFont = true;
            this.txt_projeAdi.Properties.ReadOnly = true;
            this.txt_projeAdi.Properties.UseReadOnlyAppearance = false;
            this.txt_projeAdi.Size = new System.Drawing.Size(441, 32);
            this.txt_projeAdi.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(282, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "Proje";
            // 
            // txt_projeid
            // 
            this.txt_projeid.EditValue = "";
            this.txt_projeid.Location = new System.Drawing.Point(105, 12);
            this.txt_projeid.Name = "txt_projeid";
            this.txt_projeid.Properties.Appearance.Font = new System.Drawing.Font("Ubuntu", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_projeid.Properties.Appearance.Options.UseFont = true;
            this.txt_projeid.Properties.MaxLength = 4;
            this.txt_projeid.Properties.ReadOnly = true;
            this.txt_projeid.Properties.UseReadOnlyAppearance = false;
            this.txt_projeid.Size = new System.Drawing.Size(93, 32);
            this.txt_projeid.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Proje No";
            // 
            // list_tumKisiler
            // 
            this.list_tumKisiler.AllowDrop = true;
            this.list_tumKisiler.FormattingEnabled = true;
            this.list_tumKisiler.ItemHeight = 26;
            this.list_tumKisiler.Location = new System.Drawing.Point(17, 135);
            this.list_tumKisiler.Name = "list_tumKisiler";
            this.list_tumKisiler.Size = new System.Drawing.Size(328, 472);
            this.list_tumKisiler.TabIndex = 1;
            this.list_tumKisiler.DragDrop += new System.Windows.Forms.DragEventHandler(this.list_tumKisiler_DragDrop);
            this.list_tumKisiler.DragEnter += new System.Windows.Forms.DragEventHandler(this.list_tumKisiler_DragEnter);
            this.list_tumKisiler.MouseDown += new System.Windows.Forms.MouseEventHandler(this.list_tumKisiler_MouseDown);
            // 
            // list_gorevliKisiler
            // 
            this.list_gorevliKisiler.AllowDrop = true;
            this.list_gorevliKisiler.FormattingEnabled = true;
            this.list_gorevliKisiler.ItemHeight = 26;
            this.list_gorevliKisiler.Location = new System.Drawing.Point(458, 135);
            this.list_gorevliKisiler.Name = "list_gorevliKisiler";
            this.list_gorevliKisiler.Size = new System.Drawing.Size(328, 472);
            this.list_gorevliKisiler.TabIndex = 2;
            this.list_gorevliKisiler.DragDrop += new System.Windows.Forms.DragEventHandler(this.list_gorevliKisiler_DragDrop);
            this.list_gorevliKisiler.DragEnter += new System.Windows.Forms.DragEventHandler(this.list_gorevliKisiler_DragEnter);
            this.list_gorevliKisiler.MouseDown += new System.Windows.Forms.MouseEventHandler(this.list_gorevliKisiler_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(506, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 26);
            this.label3.TabIndex = 14;
            this.label3.Text = "Projede Görevli Kişiler";
            // 
            // txt_ara
            // 
            this.txt_ara.Location = new System.Drawing.Point(55, 97);
            this.txt_ara.Name = "txt_ara";
            this.txt_ara.Properties.Appearance.Font = new System.Drawing.Font("Ubuntu", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_ara.Properties.Appearance.Options.UseFont = true;
            this.txt_ara.Size = new System.Drawing.Size(290, 32);
            this.txt_ara.TabIndex = 0;
            this.txt_ara.EditValueChanged += new System.EventHandler(this.txt_ara_EditValueChanged);
            // 
            // btn_ara
            // 
            this.btn_ara.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ara.ImageOptions.Image")));
            this.btn_ara.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.BottomCenter;
            this.btn_ara.Location = new System.Drawing.Point(17, 97);
            this.btn_ara.Name = "btn_ara";
            this.btn_ara.Size = new System.Drawing.Size(32, 32);
            this.btn_ara.TabIndex = 16;
            // 
            // btn_kaydet
            // 
            this.btn_kaydet.Appearance.Font = new System.Drawing.Font("Ubuntu", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kaydet.Appearance.Options.UseFont = true;
            this.btn_kaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_kaydet.ImageOptions.Image")));
            this.btn_kaydet.Location = new System.Drawing.Point(458, 624);
            this.btn_kaydet.Name = "btn_kaydet";
            this.btn_kaydet.Size = new System.Drawing.Size(328, 61);
            this.btn_kaydet.TabIndex = 17;
            this.btn_kaydet.Text = "KAYDET";
            this.btn_kaydet.Click += new System.EventHandler(this.btn_kaydet_Click);
            // 
            // KisiEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 697);
            this.Controls.Add(this.btn_kaydet);
            this.Controls.Add(this.btn_ara);
            this.Controls.Add(this.txt_ara);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.list_gorevliKisiler);
            this.Controls.Add(this.list_tumKisiler);
            this.Controls.Add(this.txt_projeid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_projeAdi);
            this.Font = new System.Drawing.Font("Ubuntu", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "KisiEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.KisiEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_projeAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_projeid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ara.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txt_projeAdi;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txt_projeid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox list_tumKisiler;
        private System.Windows.Forms.ListBox list_gorevliKisiler;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txt_ara;
        private DevExpress.XtraEditors.SimpleButton btn_ara;
        private DevExpress.XtraEditors.SimpleButton btn_kaydet;
    }
}