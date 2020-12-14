namespace IMS.CustomControls
{
    partial class UserControls
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
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.boxSearch = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblTable = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnCancelOrders = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.btnResetOrders = new System.Windows.Forms.Button();
            this.dataGridOrders = new System.Windows.Forms.DataGridView();
            this.btnSeeAlllPreOrders = new System.Windows.Forms.Button();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrders)).BeginInit();
            this.SuspendLayout();
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
            this.pnlSearch.Location = new System.Drawing.Point(25, 3);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(642, 84);
            this.pnlSearch.TabIndex = 30;
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
            // 
            // btnCancelOrders
            // 
            this.btnCancelOrders.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnCancelOrders.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelOrders.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelOrders.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelOrders.Location = new System.Drawing.Point(150, 116);
            this.btnCancelOrders.Name = "btnCancelOrders";
            this.btnCancelOrders.Size = new System.Drawing.Size(109, 34);
            this.btnCancelOrders.TabIndex = 27;
            this.btnCancelOrders.Text = "Cancel Order";
            this.btnCancelOrders.UseVisualStyleBackColor = false;
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnAddOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrder.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddOrder.Location = new System.Drawing.Point(26, 116);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(109, 34);
            this.btnAddOrder.TabIndex = 28;
            this.btnAddOrder.Text = "Create Order";
            this.btnAddOrder.UseVisualStyleBackColor = false;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // btnResetOrders
            // 
            this.btnResetOrders.BackColor = System.Drawing.Color.SlateBlue;
            this.btnResetOrders.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResetOrders.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetOrders.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnResetOrders.Location = new System.Drawing.Point(593, 116);
            this.btnResetOrders.Name = "btnResetOrders";
            this.btnResetOrders.Size = new System.Drawing.Size(75, 34);
            this.btnResetOrders.TabIndex = 31;
            this.btnResetOrders.Text = "Reset";
            this.btnResetOrders.UseVisualStyleBackColor = false;
            this.btnResetOrders.Click += new System.EventHandler(this.btnResetOrders_Click);
            // 
            // dataGridOrders
            // 
            this.dataGridOrders.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrders.Location = new System.Drawing.Point(25, 168);
            this.dataGridOrders.Name = "dataGridOrders";
            this.dataGridOrders.Size = new System.Drawing.Size(643, 215);
            this.dataGridOrders.TabIndex = 25;
            // 
            // btnSeeAlllPreOrders
            // 
            this.btnSeeAlllPreOrders.BackColor = System.Drawing.Color.SlateBlue;
            this.btnSeeAlllPreOrders.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSeeAlllPreOrders.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeeAlllPreOrders.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSeeAlllPreOrders.Location = new System.Drawing.Point(435, 116);
            this.btnSeeAlllPreOrders.Name = "btnSeeAlllPreOrders";
            this.btnSeeAlllPreOrders.Size = new System.Drawing.Size(153, 34);
            this.btnSeeAlllPreOrders.TabIndex = 29;
            this.btnSeeAlllPreOrders.Text = "See My Pre-Orders";
            this.btnSeeAlllPreOrders.UseVisualStyleBackColor = false;
            this.btnSeeAlllPreOrders.Click += new System.EventHandler(this.btnSeeAllPreOrders_Click);
            // 
            // UserControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.btnCancelOrders);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.btnResetOrders);
            this.Controls.Add(this.dataGridOrders);
            this.Controls.Add(this.btnSeeAlllPreOrders);
            this.Name = "UserControls";
            this.Size = new System.Drawing.Size(695, 408);
            this.Load += new System.EventHandler(this.UserControls_Load);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.ComboBox boxSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnCancelOrders;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnResetOrders;
        private System.Windows.Forms.DataGridView dataGridOrders;
        private System.Windows.Forms.Button btnSeeAlllPreOrders;
    }
}
