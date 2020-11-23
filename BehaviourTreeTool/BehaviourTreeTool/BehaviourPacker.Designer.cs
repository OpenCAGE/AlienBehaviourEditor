namespace BehaviourTreeTool
{
    partial class BehaviourPacker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BehaviourPacker));
            this.unpackButton = new System.Windows.Forms.Button();
            this.repackButton = new System.Windows.Forms.Button();
            this.resetTrees = new System.Windows.Forms.Button();
            this.HeaderImage = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.HeaderText = new System.Windows.Forms.Label();
            this.Title4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderImage)).BeginInit();
            this.SuspendLayout();
            // 
            // unpackButton
            // 
            this.unpackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.unpackButton.Location = new System.Drawing.Point(96, 618);
            this.unpackButton.Name = "unpackButton";
            this.unpackButton.Size = new System.Drawing.Size(229, 50);
            this.unpackButton.TabIndex = 2;
            this.unpackButton.Text = "Open Editor Tool";
            this.unpackButton.UseVisualStyleBackColor = true;
            this.unpackButton.Click += new System.EventHandler(this.unpackButton_Click);
            // 
            // repackButton
            // 
            this.repackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.repackButton.Location = new System.Drawing.Point(96, 674);
            this.repackButton.Name = "repackButton";
            this.repackButton.Size = new System.Drawing.Size(229, 50);
            this.repackButton.TabIndex = 3;
            this.repackButton.Text = "Import Changes To Game";
            this.repackButton.UseVisualStyleBackColor = true;
            this.repackButton.Click += new System.EventHandler(this.repackButton_Click);
            // 
            // resetTrees
            // 
            this.resetTrees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.resetTrees.Location = new System.Drawing.Point(653, 618);
            this.resetTrees.Name = "resetTrees";
            this.resetTrees.Size = new System.Drawing.Size(229, 50);
            this.resetTrees.TabIndex = 4;
            this.resetTrees.Text = "Reset Behaviour Trees";
            this.resetTrees.UseVisualStyleBackColor = true;
            this.resetTrees.Click += new System.EventHandler(this.resetTrees_Click);
            // 
            // HeaderImage
            // 
            this.HeaderImage.BackgroundImage = global::BehaviourTreeTool.Properties.Resources.TAYLOR_min;
            this.HeaderImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HeaderImage.Location = new System.Drawing.Point(-24, -4);
            this.HeaderImage.Name = "HeaderImage";
            this.HeaderImage.Size = new System.Drawing.Size(1223, 494);
            this.HeaderImage.TabIndex = 32;
            this.HeaderImage.TabStop = false;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(1113, 806);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(64, 56);
            this.CloseButton.TabIndex = 33;
            this.CloseButton.Text = "CLOSE";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // HeaderText
            // 
            this.HeaderText.AutoSize = true;
            this.HeaderText.BackColor = System.Drawing.Color.Transparent;
            this.HeaderText.Font = new System.Drawing.Font("Jixellation", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderText.ForeColor = System.Drawing.Color.White;
            this.HeaderText.Location = new System.Drawing.Point(30, 6);
            this.HeaderText.Name = "HeaderText";
            this.HeaderText.Size = new System.Drawing.Size(612, 280);
            this.HeaderText.TabIndex = 34;
            this.HeaderText.Text = "BEHAVIOUR\r\nEDITOR";
            this.HeaderText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Title4
            // 
            this.Title4.AutoSize = true;
            this.Title4.Font = new System.Drawing.Font("Isolation", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title4.Location = new System.Drawing.Point(90, 582);
            this.Title4.Name = "Title4";
            this.Title4.Size = new System.Drawing.Size(278, 33);
            this.Title4.TabIndex = 50;
            this.Title4.Text = "Edit Behaviour Trees";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Isolation", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(647, 582);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 33);
            this.label1.TabIndex = 51;
            this.label1.Text = "Modify Files";
            // 
            // BehaviourPacker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 875);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Title4);
            this.Controls.Add(this.HeaderText);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.HeaderImage);
            this.Controls.Add(this.resetTrees);
            this.Controls.Add(this.repackButton);
            this.Controls.Add(this.unpackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BehaviourPacker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alien: Isolation Behaviour Tool";
            this.Load += new System.EventHandler(this.BehaviourPacker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button unpackButton;
        private System.Windows.Forms.Button repackButton;
        private System.Windows.Forms.Button resetTrees;
        private System.Windows.Forms.PictureBox HeaderImage;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label HeaderText;
        private System.Windows.Forms.Label Title4;
        private System.Windows.Forms.Label label1;
    }
}

