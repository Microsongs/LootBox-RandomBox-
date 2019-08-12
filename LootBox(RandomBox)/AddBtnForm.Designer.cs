namespace LootBox_RandomBox_
{
    partial class AddBtnForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBtnForm));
            this.nameLabel = new System.Windows.Forms.Label();
            this.dataInputLabel = new System.Windows.Forms.Label();
            this.nameTextbox = new System.Windows.Forms.TextBox();
            this.probabilityLabel = new System.Windows.Forms.Label();
            this.probabilityTextbox = new System.Windows.Forms.TextBox();
            this.imageLabel = new System.Windows.Forms.Label();
            this.imageButton = new System.Windows.Forms.Button();
            this.imagePictureBox = new System.Windows.Forms.PictureBox();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(52, 131);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(141, 55);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "이름 : ";
            // 
            // dataInputLabel
            // 
            this.dataInputLabel.AutoSize = true;
            this.dataInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataInputLabel.Location = new System.Drawing.Point(212, 39);
            this.dataInputLabel.Name = "dataInputLabel";
            this.dataInputLabel.Size = new System.Drawing.Size(262, 61);
            this.dataInputLabel.TabIndex = 1;
            this.dataInputLabel.Text = "데이터 입력";
            // 
            // nameTextbox
            // 
            this.nameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextbox.Location = new System.Drawing.Point(223, 131);
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(337, 62);
            this.nameTextbox.TabIndex = 2;
            // 
            // probabilityLabel
            // 
            this.probabilityLabel.AutoSize = true;
            this.probabilityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.probabilityLabel.Location = new System.Drawing.Point(52, 223);
            this.probabilityLabel.Name = "probabilityLabel";
            this.probabilityLabel.Size = new System.Drawing.Size(141, 55);
            this.probabilityLabel.TabIndex = 3;
            this.probabilityLabel.Text = "확률 : ";
            // 
            // probabilityTextbox
            // 
            this.probabilityTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.probabilityTextbox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.probabilityTextbox.Location = new System.Drawing.Point(223, 223);
            this.probabilityTextbox.Name = "probabilityTextbox";
            this.probabilityTextbox.Size = new System.Drawing.Size(337, 62);
            this.probabilityTextbox.TabIndex = 4;
            this.probabilityTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProbabilityTextbox_KeyPress);
            // 
            // imageLabel
            // 
            this.imageLabel.AutoSize = true;
            this.imageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageLabel.Location = new System.Drawing.Point(52, 317);
            this.imageLabel.Name = "imageLabel";
            this.imageLabel.Size = new System.Drawing.Size(180, 55);
            this.imageLabel.TabIndex = 5;
            this.imageLabel.Text = "이미지 : ";
            // 
            // imageButton
            // 
            this.imageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageButton.Location = new System.Drawing.Point(376, 309);
            this.imageButton.Name = "imageButton";
            this.imageButton.Size = new System.Drawing.Size(184, 70);
            this.imageButton.TabIndex = 6;
            this.imageButton.Text = "등록";
            this.imageButton.UseVisualStyleBackColor = true;
            this.imageButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // imagePictureBox
            // 
            this.imagePictureBox.Location = new System.Drawing.Point(280, 309);
            this.imagePictureBox.Name = "imagePictureBox";
            this.imagePictureBox.Size = new System.Drawing.Size(70, 70);
            this.imagePictureBox.TabIndex = 7;
            this.imagePictureBox.TabStop = false;
            this.imagePictureBox.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(206, 516);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(201, 65);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "저장하기";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AddBtnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 593);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.imagePictureBox);
            this.Controls.Add(this.imageButton);
            this.Controls.Add(this.imageLabel);
            this.Controls.Add(this.probabilityTextbox);
            this.Controls.Add(this.probabilityLabel);
            this.Controls.Add(this.nameTextbox);
            this.Controls.Add(this.dataInputLabel);
            this.Controls.Add(this.nameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddBtnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AddBtnForm";
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label dataInputLabel;
        private System.Windows.Forms.TextBox nameTextbox;
        private System.Windows.Forms.Label probabilityLabel;
        private System.Windows.Forms.TextBox probabilityTextbox;
        private System.Windows.Forms.Label imageLabel;
        private System.Windows.Forms.Button imageButton;
        private System.Windows.Forms.PictureBox imagePictureBox;
        private System.Windows.Forms.Button saveButton;
    }
}