namespace IMS.Controls.HelperControls.Admin
{
    partial class AddQuantity
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.boxWhichProduct = new System.Windows.Forms.ComboBox();
            this.txtCurrentQuantity = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuantityToAdd = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAdd.Location = new System.Drawing.Point(100, 190);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 34);
            this.btnAdd.TabIndex = 31;
            this.btnAdd.Text = "Add QuantityInStock";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // boxWhichProduct
            // 
            this.boxWhichProduct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxWhichProduct.FormattingEnabled = true;
            this.boxWhichProduct.Location = new System.Drawing.Point(20, 25);
            this.boxWhichProduct.Name = "boxWhichProduct";
            this.boxWhichProduct.Size = new System.Drawing.Size(313, 29);
            this.boxWhichProduct.TabIndex = 30;
            this.boxWhichProduct.SelectionChangeCommitted += new System.EventHandler(this.boxWhichProduct_SelectionChangeCommitted);
            // 
            // txtCurrentQuantity
            // 
            this.txtCurrentQuantity.Enabled = false;
            this.txtCurrentQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentQuantity.Location = new System.Drawing.Point(162, 79);
            this.txtCurrentQuantity.Name = "txtCurrentQuantity";
            this.txtCurrentQuantity.Size = new System.Drawing.Size(171, 29);
            this.txtCurrentQuantity.TabIndex = 33;
            this.txtCurrentQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 25);
            this.label2.TabIndex = 32;
            this.label2.Text = "Quantity in stock:";
            // 
            // txtQuantityToAdd
            // 
            this.txtQuantityToAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantityToAdd.Location = new System.Drawing.Point(162, 125);
            this.txtQuantityToAdd.Name = "txtQuantityToAdd";
            this.txtQuantityToAdd.Size = new System.Drawing.Size(171, 29);
            this.txtQuantityToAdd.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 34;
            this.label1.Text = "Quantity to add:";
            // 
            // AddQuantity
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(360, 249);
            this.Controls.Add(this.txtQuantityToAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCurrentQuantity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.boxWhichProduct);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddQuantity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add stock quantity to a product";
            this.Load += new System.EventHandler(this.AddProductQuantity_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox boxWhichProduct;
        private System.Windows.Forms.MaskedTextBox txtCurrentQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtQuantityToAdd;
        private System.Windows.Forms.Label label1;
    }
}