namespace IMS.CustomControls
{
    partial class AdminControls
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNotification = new System.Windows.Forms.TextBox();
            this.lbNotifications = new System.Windows.Forms.ListBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAddProducts = new System.Windows.Forms.Button();
            this.dataGridInventory = new System.Windows.Forms.DataGridView();
            this.btnEditProducts = new System.Windows.Forms.Button();
            this.btnPreOrderInv = new System.Windows.Forms.Button();
            this.btnDeleteProducts = new System.Windows.Forms.Button();
            this.btnQuantity = new System.Windows.Forms.Button();
            this.btnDismissNotification = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNotification
            // 
            this.txtNotification.Enabled = false;
            this.txtNotification.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotification.ForeColor = System.Drawing.Color.Black;
            this.txtNotification.Location = new System.Drawing.Point(19, 24);
            this.txtNotification.Name = "txtNotification";
            this.txtNotification.Size = new System.Drawing.Size(684, 29);
            this.txtNotification.TabIndex = 30;
            this.txtNotification.Text = "  Notification Center: ";
            this.txtNotification.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbNotifications
            // 
            this.lbNotifications.BackColor = System.Drawing.SystemColors.Menu;
            this.lbNotifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotifications.FormattingEnabled = true;
            this.lbNotifications.ItemHeight = 20;
            this.lbNotifications.Location = new System.Drawing.Point(20, 68);
            this.lbNotifications.Name = "lbNotifications";
            this.lbNotifications.Size = new System.Drawing.Size(845, 124);
            this.lbNotifications.TabIndex = 25;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.SlateBlue;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReset.Location = new System.Drawing.Point(787, 214);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 34);
            this.btnReset.TabIndex = 31;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAddProducts
            // 
            this.btnAddProducts.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnAddProducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddProducts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProducts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddProducts.Location = new System.Drawing.Point(20, 214);
            this.btnAddProducts.Name = "btnAddProducts";
            this.btnAddProducts.Size = new System.Drawing.Size(118, 34);
            this.btnAddProducts.TabIndex = 26;
            this.btnAddProducts.Text = "Add Product";
            this.btnAddProducts.UseVisualStyleBackColor = false;
            this.btnAddProducts.Click += new System.EventHandler(this.btnAddProducts_Click);
            // 
            // dataGridInventory
            // 
            this.dataGridInventory.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInventory.Location = new System.Drawing.Point(17, 268);
            this.dataGridInventory.Name = "dataGridInventory";
            this.dataGridInventory.Size = new System.Drawing.Size(845, 215);
            this.dataGridInventory.TabIndex = 24;
            // 
            // btnEditProducts
            // 
            this.btnEditProducts.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnEditProducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditProducts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditProducts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditProducts.Location = new System.Drawing.Point(144, 214);
            this.btnEditProducts.Name = "btnEditProducts";
            this.btnEditProducts.Size = new System.Drawing.Size(120, 34);
            this.btnEditProducts.TabIndex = 27;
            this.btnEditProducts.Text = "Edit Product";
            this.btnEditProducts.UseVisualStyleBackColor = false;
            this.btnEditProducts.Click += new System.EventHandler(this.btnEditProducts_Click);
            // 
            // btnPreOrderInv
            // 
            this.btnPreOrderInv.BackColor = System.Drawing.Color.SlateBlue;
            this.btnPreOrderInv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPreOrderInv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreOrderInv.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPreOrderInv.Location = new System.Drawing.Point(592, 214);
            this.btnPreOrderInv.Name = "btnPreOrderInv";
            this.btnPreOrderInv.Size = new System.Drawing.Size(190, 34);
            this.btnPreOrderInv.TabIndex = 29;
            this.btnPreOrderInv.Text = "See Pre-Order Inventory";
            this.btnPreOrderInv.UseVisualStyleBackColor = false;
            this.btnPreOrderInv.Click += new System.EventHandler(this.btnPreOrderInv_Click);
            // 
            // btnDeleteProducts
            // 
            this.btnDeleteProducts.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnDeleteProducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteProducts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteProducts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteProducts.Location = new System.Drawing.Point(270, 214);
            this.btnDeleteProducts.Name = "btnDeleteProducts";
            this.btnDeleteProducts.Size = new System.Drawing.Size(123, 34);
            this.btnDeleteProducts.TabIndex = 28;
            this.btnDeleteProducts.Text = "Delete Product";
            this.btnDeleteProducts.UseVisualStyleBackColor = false;
            this.btnDeleteProducts.Click += new System.EventHandler(this.btnDeleteProducts_Click);
            // 
            // btnQuantity
            // 
            this.btnQuantity.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuantity.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnQuantity.Location = new System.Drawing.Point(399, 214);
            this.btnQuantity.Name = "btnQuantity";
            this.btnQuantity.Size = new System.Drawing.Size(151, 34);
            this.btnQuantity.TabIndex = 32;
            this.btnQuantity.Text = "Add Stock Quantity";
            this.btnQuantity.UseVisualStyleBackColor = false;
            this.btnQuantity.Click += new System.EventHandler(this.btnQuantity_Click);
            // 
            // btnDismissNotification
            // 
            this.btnDismissNotification.BackColor = System.Drawing.Color.SlateBlue;
            this.btnDismissNotification.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDismissNotification.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDismissNotification.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDismissNotification.Location = new System.Drawing.Point(709, 24);
            this.btnDismissNotification.Name = "btnDismissNotification";
            this.btnDismissNotification.Size = new System.Drawing.Size(153, 29);
            this.btnDismissNotification.TabIndex = 33;
            this.btnDismissNotification.Text = "Dimiss Notification";
            this.btnDismissNotification.UseVisualStyleBackColor = false;
            this.btnDismissNotification.Click += new System.EventHandler(this.btnDismissNotification_Click);
            // 
            // AdminControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.btnDismissNotification);
            this.Controls.Add(this.btnQuantity);
            this.Controls.Add(this.txtNotification);
            this.Controls.Add(this.lbNotifications);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnAddProducts);
            this.Controls.Add(this.dataGridInventory);
            this.Controls.Add(this.btnEditProducts);
            this.Controls.Add(this.btnPreOrderInv);
            this.Controls.Add(this.btnDeleteProducts);
            this.Name = "AdminControls";
            this.Size = new System.Drawing.Size(888, 502);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNotification;
        private System.Windows.Forms.ListBox lbNotifications;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAddProducts;
        private System.Windows.Forms.DataGridView dataGridInventory;
        private System.Windows.Forms.Button btnEditProducts;
        private System.Windows.Forms.Button btnPreOrderInv;
        private System.Windows.Forms.Button btnDeleteProducts;
        private System.Windows.Forms.Button btnQuantity;
        private System.Windows.Forms.Button btnDismissNotification;
    }
}
