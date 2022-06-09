
namespace SMBlueprintImageCreator
{
    partial class Main
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoadImage = new System.Windows.Forms.Button();
            this.Width = new System.Windows.Forms.NumericUpDown();
            this.Height = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CreateBlueprint = new System.Windows.Forms.Button();
            this.OpenImage = new System.Windows.Forms.OpenFileDialog();
            this.SetGameDirBtn = new System.Windows.Forms.Button();
            this.GameDirDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.BlockType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Reset = new System.Windows.Forms.Button();
            this.BlueprintSize = new System.Windows.Forms.Label();
            this.Aspect = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Height)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LoadImage
            // 
            this.LoadImage.Location = new System.Drawing.Point(290, 13);
            this.LoadImage.Name = "LoadImage";
            this.LoadImage.Size = new System.Drawing.Size(112, 32);
            this.LoadImage.TabIndex = 1;
            this.LoadImage.Text = "Open Image";
            this.LoadImage.UseVisualStyleBackColor = true;
            this.LoadImage.Click += new System.EventHandler(this.LoadImage_Click);
            // 
            // Width
            // 
            this.Width.Location = new System.Drawing.Point(290, 81);
            this.Width.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.Width.Name = "Width";
            this.Width.Size = new System.Drawing.Size(120, 23);
            this.Width.TabIndex = 2;
            this.Width.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.Width.ValueChanged += new System.EventHandler(this.SizeValueChanged);
            // 
            // Height
            // 
            this.Height.Location = new System.Drawing.Point(416, 81);
            this.Height.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.Height.Name = "Height";
            this.Height.Size = new System.Drawing.Size(120, 23);
            this.Height.TabIndex = 3;
            this.Height.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.Height.ValueChanged += new System.EventHandler(this.SizeValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(290, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(416, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Height";
            // 
            // CreateBlueprint
            // 
            this.CreateBlueprint.Enabled = false;
            this.CreateBlueprint.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CreateBlueprint.Location = new System.Drawing.Point(290, 206);
            this.CreateBlueprint.Name = "CreateBlueprint";
            this.CreateBlueprint.Size = new System.Drawing.Size(211, 63);
            this.CreateBlueprint.TabIndex = 6;
            this.CreateBlueprint.Text = "Create!";
            this.CreateBlueprint.UseVisualStyleBackColor = true;
            this.CreateBlueprint.Click += new System.EventHandler(this.CreateBlueprint_Click);
            // 
            // OpenImage
            // 
            this.OpenImage.DefaultExt = "png,jpg";
            this.OpenImage.FileName = "openFileDialog1";
            // 
            // SetGameDirBtn
            // 
            this.SetGameDirBtn.Location = new System.Drawing.Point(408, 13);
            this.SetGameDirBtn.Name = "SetGameDirBtn";
            this.SetGameDirBtn.Size = new System.Drawing.Size(112, 32);
            this.SetGameDirBtn.TabIndex = 7;
            this.SetGameDirBtn.Text = "Set Game Dir";
            this.SetGameDirBtn.UseVisualStyleBackColor = true;
            this.SetGameDirBtn.Click += new System.EventHandler(this.SetGameDirBtn_Click);
            // 
            // BlockType
            // 
            this.BlockType.FormattingEnabled = true;
            this.BlockType.Location = new System.Drawing.Point(290, 141);
            this.BlockType.Name = "BlockType";
            this.BlockType.Size = new System.Drawing.Size(246, 23);
            this.BlockType.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(290, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Block Type";
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(581, 12);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(78, 32);
            this.Reset.TabIndex = 10;
            this.Reset.Text = "Reset App";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // BlueprintSize
            // 
            this.BlueprintSize.AutoSize = true;
            this.BlueprintSize.Location = new System.Drawing.Point(13, 275);
            this.BlueprintSize.Name = "BlueprintSize";
            this.BlueprintSize.Size = new System.Drawing.Size(64, 15);
            this.BlueprintSize.TabIndex = 11;
            this.BlueprintSize.Text = "Size: 0x0px";
            // 
            // Aspect
            // 
            this.Aspect.AutoSize = true;
            this.Aspect.Location = new System.Drawing.Point(542, 85);
            this.Aspect.Name = "Aspect";
            this.Aspect.Size = new System.Drawing.Size(91, 19);
            this.Aspect.TabIndex = 12;
            this.Aspect.Text = "Keep Aspect";
            this.Aspect.UseVisualStyleBackColor = true;
            this.Aspect.CheckedChanged += new System.EventHandler(this.Aspect_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 299);
            this.Controls.Add(this.Aspect);
            this.Controls.Add(this.BlueprintSize);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BlockType);
            this.Controls.Add(this.SetGameDirBtn);
            this.Controls.Add(this.CreateBlueprint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Height);
            this.Controls.Add(this.Width);
            this.Controls.Add(this.LoadImage);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Main";
            this.Text = "SMBIC";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Height)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button LoadImage;
        private System.Windows.Forms.NumericUpDown Width;
        private System.Windows.Forms.NumericUpDown Height;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CreateBlueprint;
        private System.Windows.Forms.OpenFileDialog OpenImage;
        private System.Windows.Forms.Button SetGameDirBtn;
        private System.Windows.Forms.FolderBrowserDialog GameDirDialog;
        private System.Windows.Forms.ComboBox BlockType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Label BlueprintSize;
        private System.Windows.Forms.CheckBox Aspect;
    }
}

