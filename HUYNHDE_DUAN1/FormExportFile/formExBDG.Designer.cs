namespace HUYNHDE_DUAN1.FormExportFile
{
    partial class formExBDG
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
            this.panelLinearGradient1 = new HUYNHDE_DUAN1.contructions_functions.panelLinearGradient();
            this.excel = new FontAwesome.Sharp.IconButton();
            this.pdf = new FontAwesome.Sharp.IconButton();
            this.btnEx = new FontAwesome.Sharp.IconButton();
            this.tt = new System.Windows.Forms.Label();
            this.panelLinearGradient1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLinearGradient1
            // 
            this.panelLinearGradient1.BackColor = System.Drawing.Color.Transparent;
            this.panelLinearGradient1.Colorleft = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelLinearGradient1.ColorRight = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(84)))), ((int)(((byte)(200)))));
            this.panelLinearGradient1.Controls.Add(this.excel);
            this.panelLinearGradient1.Controls.Add(this.pdf);
            this.panelLinearGradient1.Controls.Add(this.btnEx);
            this.panelLinearGradient1.Controls.Add(this.tt);
            this.panelLinearGradient1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLinearGradient1.Location = new System.Drawing.Point(0, 0);
            this.panelLinearGradient1.Name = "panelLinearGradient1";
            this.panelLinearGradient1.Size = new System.Drawing.Size(549, 201);
            this.panelLinearGradient1.TabIndex = 4;
            this.panelLinearGradient1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelLinearGradient1_MouseDown);
            // 
            // excel
            // 
            this.excel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(153)))), ((int)(((byte)(142)))));
            this.excel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.excel.FlatAppearance.BorderSize = 4;
            this.excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.excel.ForeColor = System.Drawing.Color.LightBlue;
            this.excel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.excel.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(254)))), ((int)(((byte)(250)))));
            this.excel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.excel.IconSize = 25;
            this.excel.Location = new System.Drawing.Point(289, 139);
            this.excel.Name = "excel";
            this.excel.Size = new System.Drawing.Size(201, 40);
            this.excel.TabIndex = 37;
            this.excel.Text = "Xuất EXCEL";
            this.excel.UseVisualStyleBackColor = false;
            this.excel.Click += new System.EventHandler(this.excel_Click);
            // 
            // pdf
            // 
            this.pdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(175)))), ((int)(((byte)(25)))));
            this.pdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pdf.FlatAppearance.BorderSize = 4;
            this.pdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pdf.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.pdf.IconChar = FontAwesome.Sharp.IconChar.None;
            this.pdf.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(254)))), ((int)(((byte)(250)))));
            this.pdf.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pdf.IconSize = 25;
            this.pdf.Location = new System.Drawing.Point(75, 139);
            this.pdf.Name = "pdf";
            this.pdf.Size = new System.Drawing.Size(201, 40);
            this.pdf.TabIndex = 36;
            this.pdf.Text = "Xuất PDF";
            this.pdf.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.pdf.UseVisualStyleBackColor = false;
            this.pdf.Click += new System.EventHandler(this.pdf_Click);
            // 
            // btnEx
            // 
            this.btnEx.BackColor = System.Drawing.Color.Transparent;
            this.btnEx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEx.FlatAppearance.BorderSize = 0;
            this.btnEx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEx.ForeColor = System.Drawing.Color.Transparent;
            this.btnEx.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btnEx.IconColor = System.Drawing.Color.White;
            this.btnEx.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEx.IconSize = 20;
            this.btnEx.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEx.Location = new System.Drawing.Point(513, 3);
            this.btnEx.Name = "btnEx";
            this.btnEx.Size = new System.Drawing.Size(33, 30);
            this.btnEx.TabIndex = 12;
            this.btnEx.UseVisualStyleBackColor = false;
            this.btnEx.Click += new System.EventHandler(this.btnEx_Click);
            // 
            // tt
            // 
            this.tt.AutoSize = true;
            this.tt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tt.ForeColor = System.Drawing.Color.White;
            this.tt.Location = new System.Drawing.Point(70, 69);
            this.tt.Name = "tt";
            this.tt.Size = new System.Drawing.Size(433, 29);
            this.tt.TabIndex = 1;
            this.tt.Text = "Bạn muốn xuất theo định dạng nào ?";
            // 
            // formExBDG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 201);
            this.Controls.Add(this.panelLinearGradient1);
            this.Name = "formExBDG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "formBDG";
            this.panelLinearGradient1.ResumeLayout(false);
            this.panelLinearGradient1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private contructions_functions.panelLinearGradient panelLinearGradient1;
        private FontAwesome.Sharp.IconButton excel;
        private FontAwesome.Sharp.IconButton pdf;
        private FontAwesome.Sharp.IconButton btnEx;
        public System.Windows.Forms.Label tt;
    }
}