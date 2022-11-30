namespace HUYNHDE_DUAN1.FormUI
{
    partial class formMessageExFile
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
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.button = new FontAwesome.Sharp.IconButton();
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
            this.panelLinearGradient1.Controls.Add(this.iconButton1);
            this.panelLinearGradient1.Controls.Add(this.button);
            this.panelLinearGradient1.Controls.Add(this.btnEx);
            this.panelLinearGradient1.Controls.Add(this.tt);
            this.panelLinearGradient1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLinearGradient1.Location = new System.Drawing.Point(0, 0);
            this.panelLinearGradient1.Name = "panelLinearGradient1";
            this.panelLinearGradient1.Size = new System.Drawing.Size(549, 218);
            this.panelLinearGradient1.TabIndex = 1;
            this.panelLinearGradient1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelLinearGradient1_MouseDown_1);
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(153)))), ((int)(((byte)(142)))));
            this.iconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton1.FlatAppearance.BorderSize = 4;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.iconButton1.ForeColor = System.Drawing.Color.LightBlue;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(254)))), ((int)(((byte)(250)))));
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 25;
            this.iconButton1.Location = new System.Drawing.Point(289, 139);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(201, 40);
            this.iconButton1.TabIndex = 37;
            this.iconButton1.Text = "Xuất EXCEL";
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(175)))), ((int)(((byte)(25)))));
            this.button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button.FlatAppearance.BorderSize = 4;
            this.button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.button.IconChar = FontAwesome.Sharp.IconChar.None;
            this.button.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(254)))), ((int)(((byte)(250)))));
            this.button.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.button.IconSize = 25;
            this.button.Location = new System.Drawing.Point(75, 139);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(201, 40);
            this.button.TabIndex = 36;
            this.button.Text = "Xuất PDF";
            this.button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button.UseVisualStyleBackColor = false;
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
            // formMessageExFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 218);
            this.Controls.Add(this.panelLinearGradient1);
            this.Name = "formMessageExFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "formMessageExFile";
            this.Load += new System.EventHandler(this.formMessageExFile_Load);
            this.panelLinearGradient1.ResumeLayout(false);
            this.panelLinearGradient1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private contructions_functions.panelLinearGradient panelLinearGradient1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton button;
        private FontAwesome.Sharp.IconButton btnEx;
        public System.Windows.Forms.Label tt;
    }
}