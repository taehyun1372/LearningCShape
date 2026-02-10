namespace _4_Coffee_Shop
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMilk = new System.Windows.Forms.Button();
            this.tbMilk = new System.Windows.Forms.TextBox();
            this.tbMocha = new System.Windows.Forms.TextBox();
            this.btnMocha = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSoy = new System.Windows.Forms.TextBox();
            this.btnSoy = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBeverage = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTotalPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbOrder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Milk";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total Price";
            // 
            // btnMilk
            // 
            this.btnMilk.Location = new System.Drawing.Point(115, 101);
            this.btnMilk.Name = "btnMilk";
            this.btnMilk.Size = new System.Drawing.Size(75, 23);
            this.btnMilk.TabIndex = 4;
            this.btnMilk.Text = "Apply";
            this.btnMilk.UseVisualStyleBackColor = true;
            this.btnMilk.Click += new System.EventHandler(this.btnMilk_Click);
            // 
            // tbMilk
            // 
            this.tbMilk.Location = new System.Drawing.Point(9, 102);
            this.tbMilk.Name = "tbMilk";
            this.tbMilk.Size = new System.Drawing.Size(100, 22);
            this.tbMilk.TabIndex = 5;
            // 
            // tbMocha
            // 
            this.tbMocha.Location = new System.Drawing.Point(9, 164);
            this.tbMocha.Name = "tbMocha";
            this.tbMocha.Size = new System.Drawing.Size(100, 22);
            this.tbMocha.TabIndex = 8;
            // 
            // btnMocha
            // 
            this.btnMocha.Location = new System.Drawing.Point(115, 163);
            this.btnMocha.Name = "btnMocha";
            this.btnMocha.Size = new System.Drawing.Size(75, 23);
            this.btnMocha.TabIndex = 7;
            this.btnMocha.Text = "Apply";
            this.btnMocha.UseVisualStyleBackColor = true;
            this.btnMocha.Click += new System.EventHandler(this.btnMocha_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mocha";
            // 
            // tbSoy
            // 
            this.tbSoy.Location = new System.Drawing.Point(9, 231);
            this.tbSoy.Name = "tbSoy";
            this.tbSoy.Size = new System.Drawing.Size(100, 22);
            this.tbSoy.TabIndex = 11;
            // 
            // btnSoy
            // 
            this.btnSoy.Location = new System.Drawing.Point(115, 230);
            this.btnSoy.Name = "btnSoy";
            this.btnSoy.Size = new System.Drawing.Size(75, 23);
            this.btnSoy.TabIndex = 10;
            this.btnSoy.Text = "Apply";
            this.btnSoy.UseVisualStyleBackColor = true;
            this.btnSoy.Click += new System.EventHandler(this.btnSoy_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Soy";
            // 
            // cbBeverage
            // 
            this.cbBeverage.FormattingEnabled = true;
            this.cbBeverage.Location = new System.Drawing.Point(12, 36);
            this.cbBeverage.Name = "cbBeverage";
            this.cbBeverage.Size = new System.Drawing.Size(178, 24);
            this.cbBeverage.TabIndex = 12;
            this.cbBeverage.SelectedIndexChanged += new System.EventHandler(this.cbBeverage_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Beverage";
            // 
            // tbTotalPrice
            // 
            this.tbTotalPrice.Location = new System.Drawing.Point(385, 153);
            this.tbTotalPrice.Name = "tbTotalPrice";
            this.tbTotalPrice.ReadOnly = true;
            this.tbTotalPrice.Size = new System.Drawing.Size(100, 22);
            this.tbTotalPrice.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Order";
            // 
            // tbOrder
            // 
            this.tbOrder.Location = new System.Drawing.Point(310, 102);
            this.tbOrder.Name = "tbOrder";
            this.tbOrder.ReadOnly = true;
            this.tbOrder.Size = new System.Drawing.Size(175, 22);
            this.tbOrder.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 403);
            this.Controls.Add(this.tbOrder);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbTotalPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbBeverage);
            this.Controls.Add(this.tbSoy);
            this.Controls.Add(this.btnSoy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMocha);
            this.Controls.Add(this.btnMocha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMilk);
            this.Controls.Add(this.btnMilk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnMilk;
        private System.Windows.Forms.TextBox tbMilk;
        private System.Windows.Forms.TextBox tbMocha;
        private System.Windows.Forms.Button btnMocha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSoy;
        private System.Windows.Forms.Button btnSoy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbBeverage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTotalPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbOrder;
    }
}

