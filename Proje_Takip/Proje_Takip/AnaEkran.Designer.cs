namespace Proje_Takip
{
    partial class AnaEkran
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_projeAdi = new System.Windows.Forms.Label();
            this.btn_yeniProje = new System.Windows.Forms.Button();
            this.lbl_kullanici = new System.Windows.Forms.Label();
            this.list_projelerim = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu_goruntule = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_gorevEkle = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_kisiDuzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.list_yapilacak = new System.Windows.Forms.ListBox();
            this.list_yapiliyor = new System.Windows.Forms.ListBox();
            this.list_tamamlanan = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lbl_projeAdi);
            this.panel1.Controls.Add(this.btn_yeniProje);
            this.panel1.Controls.Add(this.lbl_kullanici);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1848, 116);
            this.panel1.TabIndex = 0;
            // 
            // lbl_projeAdi
            // 
            this.lbl_projeAdi.AutoSize = true;
            this.lbl_projeAdi.Font = new System.Drawing.Font("Ubuntu", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_projeAdi.Location = new System.Drawing.Point(497, 35);
            this.lbl_projeAdi.Name = "lbl_projeAdi";
            this.lbl_projeAdi.Size = new System.Drawing.Size(26, 39);
            this.lbl_projeAdi.TabIndex = 2;
            this.lbl_projeAdi.Text = ".";
            // 
            // btn_yeniProje
            // 
            this.btn_yeniProje.Font = new System.Drawing.Font("Ubuntu", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_yeniProje.Location = new System.Drawing.Point(26, 16);
            this.btn_yeniProje.Name = "btn_yeniProje";
            this.btn_yeniProje.Size = new System.Drawing.Size(434, 82);
            this.btn_yeniProje.TabIndex = 1;
            this.btn_yeniProje.Text = "Yeni Proje Oluştur";
            this.btn_yeniProje.UseVisualStyleBackColor = true;
            this.btn_yeniProje.Click += new System.EventHandler(this.btn_yeniProje_Click);
            // 
            // lbl_kullanici
            // 
            this.lbl_kullanici.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_kullanici.Font = new System.Drawing.Font("Ubuntu", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_kullanici.Location = new System.Drawing.Point(1493, 21);
            this.lbl_kullanici.Name = "lbl_kullanici";
            this.lbl_kullanici.Size = new System.Drawing.Size(343, 67);
            this.lbl_kullanici.TabIndex = 0;
            this.lbl_kullanici.Text = "label4";
            this.lbl_kullanici.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // list_projelerim
            // 
            this.list_projelerim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.list_projelerim.ContextMenuStrip = this.contextMenuStrip1;
            this.list_projelerim.FormattingEnabled = true;
            this.list_projelerim.ItemHeight = 26;
            this.list_projelerim.Location = new System.Drawing.Point(26, 206);
            this.list_projelerim.Name = "list_projelerim";
            this.list_projelerim.Size = new System.Drawing.Size(434, 576);
            this.list_projelerim.TabIndex = 1;
            this.list_projelerim.SelectedIndexChanged += new System.EventHandler(this.list_projelerim_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_goruntule,
            this.menu_gorevEkle,
            this.menu_kisiDuzenle});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 70);
            // 
            // menu_goruntule
            // 
            this.menu_goruntule.Name = "menu_goruntule";
            this.menu_goruntule.Size = new System.Drawing.Size(167, 22);
            this.menu_goruntule.Text = "GÖRÜNTÜLE";
            this.menu_goruntule.Click += new System.EventHandler(this.menu_goruntule_Click);
            // 
            // menu_gorevEkle
            // 
            this.menu_gorevEkle.Name = "menu_gorevEkle";
            this.menu_gorevEkle.Size = new System.Drawing.Size(167, 22);
            this.menu_gorevEkle.Text = "YENİ GÖREV EKLE";
            this.menu_gorevEkle.Click += new System.EventHandler(this.menu_gorevEkle_Click);
            // 
            // menu_kisiDuzenle
            // 
            this.menu_kisiDuzenle.Name = "menu_kisiDuzenle";
            this.menu_kisiDuzenle.Size = new System.Drawing.Size(167, 22);
            this.menu_kisiDuzenle.Text = "KİŞİ DÜZENLE";
            this.menu_kisiDuzenle.Click += new System.EventHandler(this.menu_kisiDuzenle_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Coral;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(26, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(434, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Projelerim (My Projects)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // list_yapilacak
            // 
            this.list_yapilacak.AllowDrop = true;
            this.list_yapilacak.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.list_yapilacak.FormattingEnabled = true;
            this.list_yapilacak.ItemHeight = 26;
            this.list_yapilacak.Location = new System.Drawing.Point(504, 206);
            this.list_yapilacak.Name = "list_yapilacak";
            this.list_yapilacak.Size = new System.Drawing.Size(434, 576);
            this.list_yapilacak.TabIndex = 3;
            this.list_yapilacak.MouseDown += new System.Windows.Forms.MouseEventHandler(this.list_yapilacak_MouseDown);
            this.list_yapilacak.MouseEnter += new System.EventHandler(this.list_yapilacak_MouseEnter);
            // 
            // list_yapiliyor
            // 
            this.list_yapiliyor.AllowDrop = true;
            this.list_yapiliyor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.list_yapiliyor.FormattingEnabled = true;
            this.list_yapiliyor.ItemHeight = 26;
            this.list_yapiliyor.Location = new System.Drawing.Point(982, 206);
            this.list_yapiliyor.Name = "list_yapiliyor";
            this.list_yapiliyor.Size = new System.Drawing.Size(434, 576);
            this.list_yapiliyor.TabIndex = 5;
            this.list_yapiliyor.DragDrop += new System.Windows.Forms.DragEventHandler(this.list_yapiliyor_DragDrop);
            this.list_yapiliyor.DragEnter += new System.Windows.Forms.DragEventHandler(this.list_yapiliyor_DragEnter);
            this.list_yapiliyor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.list_yapiliyor_MouseDown);
            this.list_yapiliyor.MouseEnter += new System.EventHandler(this.list_yapiliyor_MouseEnter);
            // 
            // list_tamamlanan
            // 
            this.list_tamamlanan.AllowDrop = true;
            this.list_tamamlanan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.list_tamamlanan.FormattingEnabled = true;
            this.list_tamamlanan.ItemHeight = 26;
            this.list_tamamlanan.Location = new System.Drawing.Point(1460, 206);
            this.list_tamamlanan.Name = "list_tamamlanan";
            this.list_tamamlanan.Size = new System.Drawing.Size(434, 576);
            this.list_tamamlanan.TabIndex = 7;
            this.list_tamamlanan.DragDrop += new System.Windows.Forms.DragEventHandler(this.list_tamamlanan_DragDrop);
            this.list_tamamlanan.DragEnter += new System.Windows.Forms.DragEventHandler(this.list_tamamlanan_DragEnter);
            this.list_tamamlanan.MouseDown += new System.Windows.Forms.MouseEventHandler(this.list_tamamlanan_MouseDown);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(504, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(434, 38);
            this.label2.TabIndex = 8;
            this.label2.Text = "Yapılacak (To Do)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(982, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(434, 38);
            this.label3.TabIndex = 9;
            this.label3.Text = "Yapılıyor (In Progress)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(1460, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(434, 38);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tamamlanan (Done)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AnaEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1848, 806);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.list_tamamlanan);
            this.Controls.Add(this.list_yapiliyor);
            this.Controls.Add(this.list_yapilacak);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.list_projelerim);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Ubuntu", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimizeBox = false;
            this.Name = "AnaEkran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TAKE Proje Takip Sistemi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AnaEkran_FormClosed);
            this.Load += new System.EventHandler(this.AnaEkran_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_kullanici;
        private System.Windows.Forms.Button btn_yeniProje;
        private System.Windows.Forms.ListBox list_projelerim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_goruntule;
        private System.Windows.Forms.ToolStripMenuItem menu_gorevEkle;
        private System.Windows.Forms.ListBox list_yapilacak;
        private System.Windows.Forms.ToolStripMenuItem menu_kisiDuzenle;
        private System.Windows.Forms.ListBox list_yapiliyor;
        private System.Windows.Forms.ListBox list_tamamlanan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_projeAdi;
    }
}