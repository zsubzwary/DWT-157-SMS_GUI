namespace DWT_157_SMS_GUI
{
    partial class BroadcastForm
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
            this.txtBrodcastInfo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMessageInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBrodcastInfo
            // 
            this.txtBrodcastInfo.Location = new System.Drawing.Point(12, 21);
            this.txtBrodcastInfo.Multiline = true;
            this.txtBrodcastInfo.Name = "txtBrodcastInfo";
            this.txtBrodcastInfo.Size = new System.Drawing.Size(350, 195);
            this.txtBrodcastInfo.TabIndex = 0;
            
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(553, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 43);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMessageInfo
            // 
            this.txtMessageInfo.Location = new System.Drawing.Point(12, 232);
            this.txtMessageInfo.Multiline = true;
            this.txtMessageInfo.Name = "txtMessageInfo";
            this.txtMessageInfo.Size = new System.Drawing.Size(776, 195);
            this.txtMessageInfo.TabIndex = 2;
            // 
            // BroadcastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtMessageInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBrodcastInfo);
            this.Name = "BroadcastForm";
            this.Text = "BroadcastForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBrodcastInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMessageInfo;
    }
}