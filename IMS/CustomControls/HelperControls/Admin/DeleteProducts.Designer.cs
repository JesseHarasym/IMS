namespace IMS.CustomControls.HelperControls.Admin
{
    partial class DeleteProducts
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
            this.boxWhichProduct = new System.Windows.Forms.ComboBox();
            this.bttDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boxWhichProduct
            // 
            this.boxWhichProduct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxWhichProduct.FormattingEnabled = true;
            this.boxWhichProduct.Location = new System.Drawing.Point(23, 30);
            this.boxWhichProduct.Name = "boxWhichProduct";
            this.boxWhichProduct.Size = new System.Drawing.Size(296, 29);
            this.boxWhichProduct.TabIndex = 28;
            // 
            // bttDelete
            // 
            this.bttDelete.BackColor = System.Drawing.Color.DarkBlue;
            this.bttDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bttDelete.Location = new System.Drawing.Point(93, 94);
            this.bttDelete.Name = "bttDelete";
            this.bttDelete.Size = new System.Drawing.Size(130, 34);
            this.bttDelete.TabIndex = 29;
            this.bttDelete.Text = "Delete Product";
            this.bttDelete.UseVisualStyleBackColor = false;
            this.bttDelete.Click += new System.EventHandler(this.bttDelete_Click);
            // 
            // DeleteProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(343, 162);
            this.Controls.Add(this.bttDelete);
            this.Controls.Add(this.boxWhichProduct);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeleteProducts";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete product in inventory";
            this.Load += new System.EventHandler(this.DeleteProducts_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox boxWhichProduct;
        private System.Windows.Forms.Button bttDelete;
    }
}