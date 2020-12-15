namespace IMS.CustomControls.HelperControls.Admin
{
    partial class OrderPickup
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
            this.btnPickedUp = new System.Windows.Forms.Button();
            this.boxOrderPickups = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnPickedUp
            // 
            this.btnPickedUp.BackColor = System.Drawing.Color.DarkBlue;
            this.btnPickedUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPickedUp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickedUp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPickedUp.Location = new System.Drawing.Point(108, 103);
            this.btnPickedUp.Name = "btnPickedUp";
            this.btnPickedUp.Size = new System.Drawing.Size(139, 34);
            this.btnPickedUp.TabIndex = 31;
            this.btnPickedUp.Text = "Order Picked up";
            this.btnPickedUp.UseVisualStyleBackColor = false;
            this.btnPickedUp.Click += new System.EventHandler(this.btnPickedUp_Click);
            // 
            // boxOrderPickups
            // 
            this.boxOrderPickups.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxOrderPickups.FormattingEnabled = true;
            this.boxOrderPickups.Location = new System.Drawing.Point(36, 36);
            this.boxOrderPickups.Name = "boxOrderPickups";
            this.boxOrderPickups.Size = new System.Drawing.Size(296, 29);
            this.boxOrderPickups.TabIndex = 30;
            // 
            // OrderPickup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(378, 172);
            this.Controls.Add(this.btnPickedUp);
            this.Controls.Add(this.boxOrderPickups);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderPickup";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose the OrderID that\'s being picked up";
            this.Load += new System.EventHandler(this.OrderPickup_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPickedUp;
        private System.Windows.Forms.ComboBox boxOrderPickups;
    }
}