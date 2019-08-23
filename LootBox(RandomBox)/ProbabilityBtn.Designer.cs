namespace LootBox_RandomBox_
{
    partial class ProbabilityBtn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProbabilityBtn));
            this.probabilitySettingLabel = new System.Windows.Forms.Label();
            this.itemList_dataGridView = new System.Windows.Forms.DataGridView();
            this.enterButton = new System.Windows.Forms.Button();
            this.totalLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.itemList_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // probabilitySettingLabel
            // 
            this.probabilitySettingLabel.AutoSize = true;
            this.probabilitySettingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.probabilitySettingLabel.Location = new System.Drawing.Point(117, 21);
            this.probabilitySettingLabel.Name = "probabilitySettingLabel";
            this.probabilitySettingLabel.Size = new System.Drawing.Size(428, 55);
            this.probabilitySettingLabel.TabIndex = 0;
            this.probabilitySettingLabel.Text = "Probability Setting";
            // 
            // itemList_dataGridView
            // 
            this.itemList_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemList_dataGridView.Location = new System.Drawing.Point(55, 92);
            this.itemList_dataGridView.Name = "itemList_dataGridView";
            this.itemList_dataGridView.RowHeadersWidth = 82;
            this.itemList_dataGridView.RowTemplate.Height = 33;
            this.itemList_dataGridView.Size = new System.Drawing.Size(551, 527);
            this.itemList_dataGridView.TabIndex = 1;
            this.itemList_dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemList_dataGridView_CellValueChanged);
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(263, 644);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(143, 62);
            this.enterButton.TabIndex = 2;
            this.enterButton.Text = "확인";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.Location = new System.Drawing.Point(429, 644);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(156, 37);
            this.totalLabel.TabIndex = 3;
            this.totalLabel.Text = "totalLabel";
            // 
            // ProbabilityBtn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 729);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.itemList_dataGridView);
            this.Controls.Add(this.probabilitySettingLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProbabilityBtn";
            this.Text = "probabilityBtn";
            ((System.ComponentModel.ISupportInitialize)(this.itemList_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label probabilitySettingLabel;
        private System.Windows.Forms.DataGridView itemList_dataGridView;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.Label totalLabel;
    }
}