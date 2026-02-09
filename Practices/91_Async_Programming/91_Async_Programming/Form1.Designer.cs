
namespace _91_Async_Programming
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
            this.lbProgress1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbProgress2 = new System.Windows.Forms.Label();
            this.lbProgress3 = new System.Windows.Forms.Label();
            this.lbProgress4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbProgress1
            // 
            this.lbProgress1.Location = new System.Drawing.Point(83, 43);
            this.lbProgress1.Name = "lbProgress1";
            this.lbProgress1.Size = new System.Drawing.Size(246, 23);
            this.lbProgress1.TabIndex = 0;
            this.lbProgress1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lbProgress2
            // 
            this.lbProgress2.Location = new System.Drawing.Point(83, 97);
            this.lbProgress2.Name = "lbProgress2";
            this.lbProgress2.Size = new System.Drawing.Size(246, 23);
            this.lbProgress2.TabIndex = 2;
            this.lbProgress2.Text = "label1";
            // 
            // lbProgress3
            // 
            this.lbProgress3.Location = new System.Drawing.Point(83, 151);
            this.lbProgress3.Name = "lbProgress3";
            this.lbProgress3.Size = new System.Drawing.Size(246, 23);
            this.lbProgress3.TabIndex = 3;
            this.lbProgress3.Text = "label1";
            // 
            // lbProgress4
            // 
            this.lbProgress4.Location = new System.Drawing.Point(83, 209);
            this.lbProgress4.Name = "lbProgress4";
            this.lbProgress4.Size = new System.Drawing.Size(246, 23);
            this.lbProgress4.TabIndex = 4;
            this.lbProgress4.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbProgress4);
            this.Controls.Add(this.lbProgress3);
            this.Controls.Add(this.lbProgress2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbProgress1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbProgress1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbProgress2;
        private System.Windows.Forms.Label lbProgress3;
        private System.Windows.Forms.Label lbProgress4;
    }
}

