namespace Tinkering_Graphics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Title = new System.Windows.Forms.Label();
            this.DescTitle = new System.Windows.Forms.Label();
            this.EffectButton = new System.Windows.Forms.Button();
            this.Description = new System.Windows.Forms.Label();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(622, 423);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(7, 23);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(89, 25);
            this.Title.TabIndex = 1;
            this.Title.Text = "Image: ";
            // 
            // DescTitle
            // 
            this.DescTitle.AutoSize = true;
            this.DescTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescTitle.Location = new System.Drawing.Point(668, 23);
            this.DescTitle.Name = "DescTitle";
            this.DescTitle.Size = new System.Drawing.Size(308, 25);
            this.DescTitle.TabIndex = 2;
            this.DescTitle.Text = "What does this program do?";
            // 
            // EffectButton
            // 
            this.EffectButton.Location = new System.Drawing.Point(673, 451);
            this.EffectButton.Name = "EffectButton";
            this.EffectButton.Size = new System.Drawing.Size(290, 42);
            this.EffectButton.TabIndex = 5;
            this.EffectButton.Text = "Remove Fake Fires!";
            this.EffectButton.UseVisualStyleBackColor = true;
            this.EffectButton.Click += new System.EventHandler(this.EffectButton_Click);
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(0, 0);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(100, 23);
            this.Description.TabIndex = 8;
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionBox.Location = new System.Drawing.Point(673, 70);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.ReadOnly = true;
            this.DescriptionBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DescriptionBox.Size = new System.Drawing.Size(290, 356);
            this.DescriptionBox.TabIndex = 7;
            this.DescriptionBox.TabStop = false;
            this.DescriptionBox.Text = resources.GetString("DescriptionBox.Text");
            this.DescriptionBox.Enter += new System.EventHandler(this.DescriptionBox_Enter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 505);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.EffectButton);
            this.Controls.Add(this.DescTitle);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Forest fires are fake";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label DescTitle;
        private System.Windows.Forms.Button EffectButton;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.TextBox DescriptionBox;
    }
}

