namespace CustomerMaintenance
{
    partial class frmCustomers
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnDelete = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            lstCustomers = new System.Windows.Forms.ListBox();
            btnExit = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.Location = new System.Drawing.Point(359, 72);
            btnDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(88, 27);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "&Delete";
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(359, 35);
            btnAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(88, 27);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "&Add";
            btnAdd.Click += btnAdd_Click;
            // 
            // lstCustomers
            // 
            lstCustomers.ItemHeight = 15;
            lstCustomers.Location = new System.Drawing.Point(14, 35);
            lstCustomers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lstCustomers.Name = "lstCustomers";
            lstCustomers.Size = new System.Drawing.Size(326, 169);
            lstCustomers.TabIndex = 5;
            // 
            // btnExit
            // 
            btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnExit.Location = new System.Drawing.Point(359, 108);
            btnExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(88, 27);
            btnExit.TabIndex = 9;
            btnExit.Text = "&Exit";
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(14, 10);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(112, 21);
            label1.TabIndex = 6;
            label1.Text = "Customers:";
            label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // frmCustomers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new System.Drawing.Size(470, 220);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(lstCustomers);
            Controls.Add(btnExit);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "frmCustomers";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Customer Maintenance";
            Load += frmCustomers_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstCustomers;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
    }
}

