namespace LootBox_RandomBox_
{
    partial class DeleteBtnForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteBtnForm));
            this.itemList_dataGridView = new System.Windows.Forms.DataGridView();
            this.itemListLabel = new System.Windows.Forms.Label();
            this.EnterButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.itemList_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // itemList_dataGridView
            // 
            this.itemList_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemList_dataGridView.Location = new System.Drawing.Point(94, 91);
            this.itemList_dataGridView.Name = "itemList_dataGridView";
            this.itemList_dataGridView.RowHeadersWidth = 82;
            this.itemList_dataGridView.RowTemplate.Height = 33;
            this.itemList_dataGridView.Size = new System.Drawing.Size(525, 556);
            this.itemList_dataGridView.TabIndex = 0;
            // 
            // itemListLabel
            // 
            this.itemListLabel.AutoSize = true;
            this.itemListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemListLabel.Location = new System.Drawing.Point(83, 9);
            this.itemListLabel.Name = "itemListLabel";
            this.itemListLabel.Size = new System.Drawing.Size(306, 61);
            this.itemListLabel.TabIndex = 1;
            this.itemListLabel.Text = "아이템 리스트";
            // 
            // EnterButton
            // 
            this.EnterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterButton.Location = new System.Drawing.Point(254, 665);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(204, 83);
            this.EnterButton.TabIndex = 2;
            this.EnterButton.Text = "확인";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // DeleteBtnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 769);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.itemListLabel);
            this.Controls.Add(this.itemList_dataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeleteBtnForm";
            this.Text = "DeleteBtnForm";
            ((System.ComponentModel.ISupportInitialize)(this.itemList_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView itemList_dataGridView;
        private System.Windows.Forms.Label itemListLabel;
        private System.Windows.Forms.Button EnterButton;
    }
}