namespace IMS
{
    partial class MainForm
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
            this.dataGridInventory = new System.Windows.Forms.DataGridView();
            this.lbNotifications = new System.Windows.Forms.ListBox();
            this.btnAddProducts = new System.Windows.Forms.Button();
            this.btnEditProducts = new System.Windows.Forms.Button();
            this.btnDeleteProducts = new System.Windows.Forms.Button();
            this.btnPreOrderInv = new System.Windows.Forms.Button();
            this.txtNotification = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.pnlAdmin = new System.Windows.Forms.Panel();
            this.btnHideTest = new System.Windows.Forms.Button();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.dataGridOrders = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.boxSearch = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblTable = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSeeAllPreOrders = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnDeleteOrders = new System.Windows.Forms.Button();
            this.btnModifyOrders = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInventory)).BeginInit();
            this.pnlAdmin.SuspendLayout();
            this.pnlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrders)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridInventory
            // 
            this.dataGridInventory.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInventory.Location = new System.Drawing.Point(18, 269);
            this.dataGridInventory.Name = "dataGridInventory";
            this.dataGridInventory.Size = new System.Drawing.Size(845, 213);
            this.dataGridInventory.TabIndex = 0;
            // 
            // lbNotifications
            // 
            this.lbNotifications.BackColor = System.Drawing.SystemColors.Menu;
            this.lbNotifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotifications.FormattingEnabled = true;
            this.lbNotifications.ItemHeight = 20;
            this.lbNotifications.Location = new System.Drawing.Point(21, 69);
            this.lbNotifications.Name = "lbNotifications";
            this.lbNotifications.Size = new System.Drawing.Size(845, 124);
            this.lbNotifications.TabIndex = 4;
            // 
            // btnAddProducts
            // 
            this.btnAddProducts.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnAddProducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddProducts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProducts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddProducts.Location = new System.Drawing.Point(21, 215);
            this.btnAddProducts.Name = "btnAddProducts";
            this.btnAddProducts.Size = new System.Drawing.Size(118, 34);
            this.btnAddProducts.TabIndex = 12;
            this.btnAddProducts.Text = "Add Product";
            this.btnAddProducts.UseVisualStyleBackColor = false;
            // 
            // btnEditProducts
            // 
            this.btnEditProducts.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnEditProducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditProducts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditProducts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditProducts.Location = new System.Drawing.Point(145, 215);
            this.btnEditProducts.Name = "btnEditProducts";
            this.btnEditProducts.Size = new System.Drawing.Size(120, 34);
            this.btnEditProducts.TabIndex = 13;
            this.btnEditProducts.Text = "Edit Product";
            this.btnEditProducts.UseVisualStyleBackColor = false;
            // 
            // btnDeleteProducts
            // 
            this.btnDeleteProducts.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnDeleteProducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteProducts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteProducts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteProducts.Location = new System.Drawing.Point(271, 215);
            this.btnDeleteProducts.Name = "btnDeleteProducts";
            this.btnDeleteProducts.Size = new System.Drawing.Size(123, 34);
            this.btnDeleteProducts.TabIndex = 14;
            this.btnDeleteProducts.Text = "Delete Product";
            this.btnDeleteProducts.UseVisualStyleBackColor = false;
            // 
            // btnPreOrderInv
            // 
            this.btnPreOrderInv.BackColor = System.Drawing.Color.SlateBlue;
            this.btnPreOrderInv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPreOrderInv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreOrderInv.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPreOrderInv.Location = new System.Drawing.Point(593, 215);
            this.btnPreOrderInv.Name = "btnPreOrderInv";
            this.btnPreOrderInv.Size = new System.Drawing.Size(190, 34);
            this.btnPreOrderInv.TabIndex = 19;
            this.btnPreOrderInv.Text = "See Pre-Order Inventory";
            this.btnPreOrderInv.UseVisualStyleBackColor = false;
            this.btnPreOrderInv.Click += new System.EventHandler(this.btnPreOrderInv_Click);
            // 
            // txtNotification
            // 
            this.txtNotification.Enabled = false;
            this.txtNotification.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotification.ForeColor = System.Drawing.Color.Black;
            this.txtNotification.Location = new System.Drawing.Point(20, 25);
            this.txtNotification.Name = "txtNotification";
            this.txtNotification.Size = new System.Drawing.Size(846, 29);
            this.txtNotification.TabIndex = 22;
            this.txtNotification.Text = "  Notification Center: ";
            this.txtNotification.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.SlateBlue;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReset.Location = new System.Drawing.Point(788, 215);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 34);
            this.btnReset.TabIndex = 23;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnResetInventory_Click);
            // 
            // pnlAdmin
            // 
            this.pnlAdmin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAdmin.Controls.Add(this.txtNotification);
            this.pnlAdmin.Controls.Add(this.lbNotifications);
            this.pnlAdmin.Controls.Add(this.btnReset);
            this.pnlAdmin.Controls.Add(this.btnAddProducts);
            this.pnlAdmin.Controls.Add(this.dataGridInventory);
            this.pnlAdmin.Controls.Add(this.btnEditProducts);
            this.pnlAdmin.Controls.Add(this.btnPreOrderInv);
            this.pnlAdmin.Controls.Add(this.btnDeleteProducts);
            this.pnlAdmin.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAdmin.Location = new System.Drawing.Point(686, 0);
            this.pnlAdmin.Name = "pnlAdmin";
            this.pnlAdmin.Size = new System.Drawing.Size(888, 502);
            this.pnlAdmin.TabIndex = 25;
            this.pnlAdmin.Visible = false;
            // 
            // btnHideTest
            // 
            this.btnHideTest.BackColor = System.Drawing.Color.DarkBlue;
            this.btnHideTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideTest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHideTest.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHideTest.Location = new System.Drawing.Point(605, 34);
            this.btnHideTest.Name = "btnHideTest";
            this.btnHideTest.Size = new System.Drawing.Size(59, 42);
            this.btnHideTest.TabIndex = 26;
            this.btnHideTest.Text = "Hide";
            this.btnHideTest.UseVisualStyleBackColor = false;
            this.btnHideTest.Click += new System.EventHandler(this.btnHideTest_Click);
            // 
            // pnlUser
            // 
            this.pnlUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUser.Controls.Add(this.btnHideTest);
            this.pnlUser.Controls.Add(this.dataGridOrders);
            this.pnlUser.Controls.Add(this.button1);
            this.pnlUser.Controls.Add(this.btnLogin);
            this.pnlUser.Controls.Add(this.pnlSearch);
            this.pnlUser.Controls.Add(this.btnLogout);
            this.pnlUser.Controls.Add(this.btnSeeAllPreOrders);
            this.pnlUser.Controls.Add(this.textBox1);
            this.pnlUser.Controls.Add(this.btnAddOrder);
            this.pnlUser.Controls.Add(this.textBox2);
            this.pnlUser.Controls.Add(this.btnDeleteOrders);
            this.pnlUser.Controls.Add(this.btnModifyOrders);
            this.pnlUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUser.Location = new System.Drawing.Point(0, 0);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(686, 502);
            this.pnlUser.TabIndex = 24;
            // 
            // dataGridOrders
            // 
            this.dataGridOrders.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrders.Location = new System.Drawing.Point(22, 269);
            this.dataGridOrders.Name = "dataGridOrders";
            this.dataGridOrders.Size = new System.Drawing.Size(643, 213);
            this.dataGridOrders.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SlateBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(590, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 24;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnResetOrders_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.DarkBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLogin.Location = new System.Drawing.Point(59, 34);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(98, 38);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.boxSearch);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.lblTable);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Location = new System.Drawing.Point(22, 107);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(642, 84);
            this.pnlSearch.TabIndex = 21;
            // 
            // boxSearch
            // 
            this.boxSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.boxSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxSearch.FormattingEnabled = true;
            this.boxSearch.Location = new System.Drawing.Point(304, 11);
            this.boxSearch.Name = "boxSearch";
            this.boxSearch.Size = new System.Drawing.Size(163, 29);
            this.boxSearch.TabIndex = 6;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(67, 49);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(155, 21);
            this.lblSearch.TabIndex = 18;
            this.lblSearch.Text = "Enter Search Word:";
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable.Location = new System.Drawing.Point(67, 14);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(235, 21);
            this.lblTable.TabIndex = 5;
            this.lblTable.Text = "Choose Table To Search From:";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DarkBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch.Location = new System.Drawing.Point(487, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 35);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(228, 46);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(239, 29);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.DarkBlue;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLogout.Location = new System.Drawing.Point(59, 34);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(98, 38);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnSeeAllPreOrders
            // 
            this.btnSeeAllPreOrders.BackColor = System.Drawing.Color.SlateBlue;
            this.btnSeeAllPreOrders.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSeeAllPreOrders.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeeAllPreOrders.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSeeAllPreOrders.Location = new System.Drawing.Point(431, 215);
            this.btnSeeAllPreOrders.Name = "btnSeeAllPreOrders";
            this.btnSeeAllPreOrders.Size = new System.Drawing.Size(153, 34);
            this.btnSeeAllPreOrders.TabIndex = 20;
            this.btnSeeAllPreOrders.Text = "See All Pre-Orders";
            this.btnSeeAllPreOrders.UseVisualStyleBackColor = false;
            this.btnSeeAllPreOrders.Click += new System.EventHandler(this.btnSeeAllPreOrders_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(209, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(305, 29);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = " Users Type:          Not Logged In";
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnAddOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrder.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddOrder.Location = new System.Drawing.Point(22, 215);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(103, 34);
            this.btnAddOrder.TabIndex = 17;
            this.btnAddOrder.Text = "Add Order";
            this.btnAddOrder.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(209, 18);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(305, 29);
            this.textBox2.TabIndex = 11;
            this.textBox2.Text = " Users Name:        Not Logged In";
            // 
            // btnDeleteOrders
            // 
            this.btnDeleteOrders.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnDeleteOrders.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteOrders.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteOrders.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteOrders.Location = new System.Drawing.Point(251, 215);
            this.btnDeleteOrders.Name = "btnDeleteOrders";
            this.btnDeleteOrders.Size = new System.Drawing.Size(109, 34);
            this.btnDeleteOrders.TabIndex = 16;
            this.btnDeleteOrders.Text = "Delete Order";
            this.btnDeleteOrders.UseVisualStyleBackColor = false;
            // 
            // btnModifyOrders
            // 
            this.btnModifyOrders.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnModifyOrders.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModifyOrders.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifyOrders.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnModifyOrders.Location = new System.Drawing.Point(131, 215);
            this.btnModifyOrders.Name = "btnModifyOrders";
            this.btnModifyOrders.Size = new System.Drawing.Size(114, 34);
            this.btnModifyOrders.TabIndex = 15;
            this.btnModifyOrders.Text = "Modify Order";
            this.btnModifyOrders.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1576, 502);
            this.Controls.Add(this.pnlAdmin);
            this.Controls.Add(this.pnlUser);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(686, 541);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Management System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInventory)).EndInit();
            this.pnlAdmin.ResumeLayout(false);
            this.pnlAdmin.PerformLayout();
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrders)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridInventory;
        private System.Windows.Forms.ListBox lbNotifications;
        private System.Windows.Forms.Button btnAddProducts;
        private System.Windows.Forms.Button btnEditProducts;
        private System.Windows.Forms.Button btnDeleteProducts;
        private System.Windows.Forms.Button btnPreOrderInv;
        private System.Windows.Forms.TextBox txtNotification;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel pnlAdmin;
        private System.Windows.Forms.Button btnHideTest;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.DataGridView dataGridOrders;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnModifyOrders;
        private System.Windows.Forms.Button btnDeleteOrders;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnSeeAllPreOrders;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox boxSearch;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button button1;
    }
}

