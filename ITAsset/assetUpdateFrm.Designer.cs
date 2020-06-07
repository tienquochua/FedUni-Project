namespace ITAsset
{
    partial class AssetUpdateForm
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.statusCbb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.itemTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.vendorCbb = new System.Windows.Forms.ComboBox();
            this.purLocationTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.itemID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(393, 304);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 36);
            this.cancelBtn.TabIndex = 22;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(295, 304);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(75, 36);
            this.updateBtn.TabIndex = 21;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // statusCbb
            // 
            this.statusCbb.Items.AddRange(new object[] {
            "Lending",
            "Borrowing",
            "Allocating",
            "Returning"});
            this.statusCbb.Location = new System.Drawing.Point(180, 245);
            this.statusCbb.Name = "statusCbb";
            this.statusCbb.Size = new System.Drawing.Size(122, 24);
            this.statusCbb.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Status";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(180, 138);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // itemTxt
            // 
            this.itemTxt.Location = new System.Drawing.Point(180, 92);
            this.itemTxt.Name = "itemTxt";
            this.itemTxt.Size = new System.Drawing.Size(200, 22);
            this.itemTxt.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Purchase date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(358, 32);
            this.label2.TabIndex = 13;
            this.label2.Text = "Asset Information Update";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Vendor";
            // 
            // vendorCbb
            // 
            this.vendorCbb.FormattingEnabled = true;
            this.vendorCbb.Location = new System.Drawing.Point(180, 207);
            this.vendorCbb.Name = "vendorCbb";
            this.vendorCbb.Size = new System.Drawing.Size(190, 24);
            this.vendorCbb.TabIndex = 23;
            // 
            // purLocationTxt
            // 
            this.purLocationTxt.Location = new System.Drawing.Point(180, 172);
            this.purLocationTxt.Name = "purLocationTxt";
            this.purLocationTxt.Size = new System.Drawing.Size(288, 22);
            this.purLocationTxt.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 17);
            this.label6.TabIndex = 24;
            this.label6.Text = "Purchase Location";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 17);
            this.label7.TabIndex = 26;
            this.label7.Text = "Item No.";
            // 
            // itemID
            // 
            this.itemID.AutoSize = true;
            this.itemID.Location = new System.Drawing.Point(114, 63);
            this.itemID.Name = "itemID";
            this.itemID.Size = new System.Drawing.Size(21, 17);
            this.itemID.TabIndex = 27;
            this.itemID.Text = "ID";
            // 
            // AssetUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 360);
            this.Controls.Add(this.itemID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.purLocationTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.vendorCbb);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.statusCbb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.itemTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AssetUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Form";
            this.Load += new System.EventHandler(this.AssetUpdateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox itemTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox vendorCbb;
        private System.Windows.Forms.TextBox purLocationTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label itemID;
        private System.Windows.Forms.ComboBox statusCbb;
    }
}