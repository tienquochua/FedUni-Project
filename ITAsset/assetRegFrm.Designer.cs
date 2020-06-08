namespace ITAsset
{
    partial class assetRegFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.itemNameTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.statusCbb = new System.Windows.Forms.ComboBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.purLocationTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.vendorCbb = new System.Windows.Forms.ComboBox();
            this.vendorAddBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vendor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(121, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Asset Register";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Item Name";
            // 
            // itemNameTxt
            // 
            this.itemNameTxt.Location = new System.Drawing.Point(144, 80);
            this.itemNameTxt.Name = "itemNameTxt";
            this.itemNameTxt.Size = new System.Drawing.Size(200, 22);
            this.itemNameTxt.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Status";
            // 
            // statusCbb
            // 
            this.statusCbb.FormattingEnabled = true;
            this.statusCbb.Items.AddRange(new object[] {
            "Lending",
            "Borrowing",
            "Allocating",
            "Returning"});
            this.statusCbb.Location = new System.Drawing.Point(144, 262);
            this.statusCbb.Name = "statusCbb";
            this.statusCbb.Size = new System.Drawing.Size(125, 24);
            this.statusCbb.TabIndex = 9;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(357, 292);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 36);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(259, 292);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 36);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Purchase date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(144, 126);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // purLocationTxt
            // 
            this.purLocationTxt.Location = new System.Drawing.Point(144, 165);
            this.purLocationTxt.Name = "purLocationTxt";
            this.purLocationTxt.Size = new System.Drawing.Size(288, 22);
            this.purLocationTxt.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Purchase Location";
            // 
            // vendorCbb
            // 
            this.vendorCbb.FormattingEnabled = true;
            this.vendorCbb.Items.AddRange(new object[] {
            "Lending",
            "Borrowing",
            "Allocating",
            "Returning"});
            this.vendorCbb.Location = new System.Drawing.Point(144, 203);
            this.vendorCbb.Name = "vendorCbb";
            this.vendorCbb.Size = new System.Drawing.Size(190, 24);
            this.vendorCbb.TabIndex = 14;
            // 
            // vendorAddBtn
            // 
            this.vendorAddBtn.Location = new System.Drawing.Point(357, 203);
            this.vendorAddBtn.Name = "vendorAddBtn";
            this.vendorAddBtn.Size = new System.Drawing.Size(75, 24);
            this.vendorAddBtn.TabIndex = 15;
            this.vendorAddBtn.Text = "Add";
            this.vendorAddBtn.UseVisualStyleBackColor = true;
            this.vendorAddBtn.Click += new System.EventHandler(this.vendorAddBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(141, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(304, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "You can add for more vendor using Add button";
            // 
            // assetRegFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 340);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.vendorAddBtn);
            this.Controls.Add(this.vendorCbb);
            this.Controls.Add(this.purLocationTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.statusCbb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.itemNameTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "assetRegFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asset Register";
            this.Activated += new System.EventHandler(this.assetRegFrm_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox itemNameTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox statusCbb;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox purLocationTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox vendorCbb;
        private System.Windows.Forms.Button vendorAddBtn;
        private System.Windows.Forms.Label label7;
    }
}