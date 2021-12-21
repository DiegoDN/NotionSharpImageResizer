
namespace NotionSharpImageResizer
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BrowseMultipleButton = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // BrowseMultipleButton
            // 
            this.BrowseMultipleButton.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.BrowseMultipleButton.Location = new System.Drawing.Point(39, 48);
            this.BrowseMultipleButton.Name = "BrowseMultipleButton";
            this.BrowseMultipleButton.Size = new System.Drawing.Size(214, 50);
            this.BrowseMultipleButton.TabIndex = 0;
            this.BrowseMultipleButton.Text = "Load Images";
            this.BrowseMultipleButton.UseVisualStyleBackColor = true;
            this.BrowseMultipleButton.Click += new System.EventHandler(this.BrowseMultipleButton_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.BrowseMultipleButton);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Notion Sharp Image Resizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BrowseMultipleButton;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}

