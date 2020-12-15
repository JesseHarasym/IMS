namespace IMS.CustomControls.HelperControls.Users
{
    partial class CancelOrders
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.boxWhichOrder = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DarkBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Location = new System.Drawing.Point(100, 86);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 34);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "Cancel order";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // boxWhichOrder
            // 
            this.boxWhichOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxWhichOrder.FormattingEnabled = true;
            this.boxWhichOrder.Location = new System.Drawing.Point(24, 27);
            this.boxWhichOrder.Name = "boxWhichOrder";
            this.boxWhichOrder.Size = new System.Drawing.Size(296, 29);
            this.boxWhichOrder.TabIndex = 30;
            this.boxWhichOrder.SelectionChangeCommitted += new System.EventHandler(this.boxWhichOrder_SelectionChangeCommitted);
            // 
            // CancelOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(349, 150);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.boxWhichOrder);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CancelOrders";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chose the order you\'d like to cancel";
            this.Load += new System.EventHandler(this.CancelOrders_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox boxWhichOrder;
    }
}