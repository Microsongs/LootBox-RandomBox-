using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LootBox_RandomBox_
{
    public partial class ResultPage : Form
    {
        public ResultPage(LootItem item,int selected)
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            init(selected);

            PrintImage(item);
            PrintText(item);
        }
        void PrintText(LootItem item)
        {
            resultNameLabel.Text = item.Name;
            resultNameLabel.Location = new Point(this.Width / 2 - resultNameLabel.Width / 2, this.Height/100*80);
        }

        // 이미지 출력
        void PrintImage(LootItem item)
        {
            resultPictureBox.Location = new Point(this.Width / 2 - resultPictureBox.Width / 2, this.Height/100*5);

            resultPictureBox.Image = item.OriginalImage;
            resultPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // 기본 설정
        void init(int selected)
        {
            switch (selected)
            {
                case Language.english:
                    this.Text = "Result!!";
                    closeButton.Text = "Close";
                    break;

                case Language.korean:
                    this.Text = "결과!";
                    closeButton.Text = "닫기";
                    break;

                case Language.japanese:
                    this.Text = "結果!!";
                    closeButton.Text = "閉じる";
                    break;
            }
            closeButton.Location = new Point(this.Width / 2 - closeButton.Width/ 2, this.Height/100*100);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseButton_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.Button1_Click(sender, e);
            }
        }
    }
}
