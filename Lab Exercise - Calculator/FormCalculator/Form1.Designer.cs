namespace FormCalculator
{
    partial class Form1
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
            this.valueInput1 = new System.Windows.Forms.TextBox();
            this.valueInput2 = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnMulitply = new System.Windows.Forms.Button();
            this.btnSubtract = new System.Windows.Forms.Button();
            this.btnDivide = new System.Windows.Forms.Button();
            this.valueResult = new System.Windows.Forms.TextBox();
            this.btnClearInputs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // valueInput1
            // 
            this.valueInput1.Location = new System.Drawing.Point(303, 48);
            this.valueInput1.Name = "valueInput1";
            this.valueInput1.Size = new System.Drawing.Size(100, 20);
            this.valueInput1.TabIndex = 0;
            this.valueInput1.TextChanged += new System.EventHandler(this.valueInput1_TextChanged);
            // 
            // valueInput2
            // 
            this.valueInput2.Location = new System.Drawing.Point(303, 104);
            this.valueInput2.Name = "valueInput2";
            this.valueInput2.Size = new System.Drawing.Size(100, 20);
            this.valueInput2.TabIndex = 2;
            this.valueInput2.TextChanged += new System.EventHandler(this.valueInput1_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(179, 167);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnMulitply
            // 
            this.btnMulitply.Enabled = false;
            this.btnMulitply.Location = new System.Drawing.Point(364, 167);
            this.btnMulitply.Name = "btnMulitply";
            this.btnMulitply.Size = new System.Drawing.Size(75, 23);
            this.btnMulitply.TabIndex = 4;
            this.btnMulitply.Text = "*";
            this.btnMulitply.UseVisualStyleBackColor = true;
            this.btnMulitply.Click += new System.EventHandler(this.btnMulitply_Click);
            // 
            // btnSubtract
            // 
            this.btnSubtract.Enabled = false;
            this.btnSubtract.Location = new System.Drawing.Point(272, 167);
            this.btnSubtract.Name = "btnSubtract";
            this.btnSubtract.Size = new System.Drawing.Size(75, 23);
            this.btnSubtract.TabIndex = 5;
            this.btnSubtract.Text = "-";
            this.btnSubtract.UseVisualStyleBackColor = true;
            this.btnSubtract.Click += new System.EventHandler(this.btnSubtract_Click);
            // 
            // btnDivide
            // 
            this.btnDivide.Enabled = false;
            this.btnDivide.Location = new System.Drawing.Point(465, 167);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(75, 23);
            this.btnDivide.TabIndex = 6;
            this.btnDivide.Text = "/";
            this.btnDivide.UseVisualStyleBackColor = true;
            this.btnDivide.Click += new System.EventHandler(this.btnDivide_Click);
            // 
            // valueResult
            // 
            this.valueResult.Location = new System.Drawing.Point(303, 228);
            this.valueResult.Name = "valueResult";
            this.valueResult.Size = new System.Drawing.Size(100, 20);
            this.valueResult.TabIndex = 7;
            // 
            // btnClearInputs
            // 
            this.btnClearInputs.Location = new System.Drawing.Point(574, 335);
            this.btnClearInputs.Name = "btnClearInputs";
            this.btnClearInputs.Size = new System.Drawing.Size(75, 23);
            this.btnClearInputs.TabIndex = 8;
            this.btnClearInputs.Text = "Clear";
            this.btnClearInputs.UseVisualStyleBackColor = true;
            this.btnClearInputs.Click += new System.EventHandler(this.btnClearInputs_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClearInputs);
            this.Controls.Add(this.valueResult);
            this.Controls.Add(this.btnDivide);
            this.Controls.Add(this.btnSubtract);
            this.Controls.Add(this.btnMulitply);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.valueInput2);
            this.Controls.Add(this.valueInput1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox valueInput1;
        private System.Windows.Forms.TextBox valueInput2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnMulitply;
        private System.Windows.Forms.Button btnSubtract;
        private System.Windows.Forms.Button btnDivide;
        private System.Windows.Forms.TextBox valueResult;
        private System.Windows.Forms.Button btnClearInputs;
    }
}

