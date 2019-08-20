using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LootBox_RandomBox_
{
    public partial class AddBtnForm : Form
    {
        private int selected = 0;
        private string imgFileName;
        mainWindow main;
        public AddBtnForm()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        }
        public AddBtnForm(int selected, mainWindow main)
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.selected = selected;
            this.main = main;
            nameTextbox.MaxLength = 20;
            addInit();
        }

        // 초기화
        private void addInit()
        {
            // English
            switch (selected)
            {
                case 0:
                    this.Text = "Add";
                    dataInputLabel.Text = "Enter data";
                    nameLabel.Text = "Name：";
                    probabilityLabel.Text = "Prob : ";
                    imageLabel.Text = "Image : ";
                    imageButton.Text = "Load";
                    saveButton.Text = "Save";
                    break;

                case 1:
                    this.Text = "추가";
                    dataInputLabel.Text = "데이터 입력";
                    nameLabel.Text = "이름 : ";
                    probabilityLabel.Text = "확률 : ";
                    imageLabel.Text = "이미지 : ";
                    imageButton.Text = "등록";
                    saveButton.Text = "저장";
                    break;

                case 2:
                    this.Text = "追加";
                    dataInputLabel.Text = "データを追加";
                    nameLabel.Text = "名前 : ";
                    probabilityLabel.Text = "確率 : ";
                    imageLabel.Text = "イメージ : ";
                    imageButton.Text = "登録";
                    saveButton.Text = "セーブ";
                    break;
            }
            dataInputLabel.Location = new Point((this.Width / 2) - (dataInputLabel.Width / 2), 10);
        }

        // 이미지 버튼 등록 메서드
        private void Button1_Click(object sender, EventArgs e)
        {
            string imgFile = string.Empty;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\";

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                imgFile = dialog.FileName;
            }
            else if(dialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                imagePictureBox.Image = Bitmap.FromFile(imgFile);
                imagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                imgFileName = System.IO.Path.GetFileName(imgFile);
            }
            catch(Exception ex)
            {
                switch (selected)
                {
                    case 0:
                        MessageBox.Show("Please load Image File!", "Error!");
                        break;

                    case 1:
                        MessageBox.Show("이미지 파일을 불러오세요!", "불러오기 오류!");
                        break;

                    case 2:
                        MessageBox.Show("イメージファイルをアップロードください。", "ロードエラー!");
                        break;
                }
            }
            
        }

        // 입력 여부 확인하는 메서드
        private bool noInputCheck()
        {
            // 제목 유무 확인
            if (nameTextbox.TextLength == 0)
            {
                switch (selected)
                {
                    case 0:
                        MessageBox.Show("Name Please!", "Error!");
                        break;

                    case 1:
                        MessageBox.Show("이름을 넣어주세요!", "이름 오류!");
                        break;

                    case 2:
                        MessageBox.Show("名前を入れてください。", "エラー!");
                        break;
                }
                return false;
            }

            // 20바이트 초과 유무 확인
            else if(Encoding.Default.GetBytes(nameTextbox.Text).Length > 20)
            {
                switch (selected)
                {
                    case 0:
                        MessageBox.Show("Please enter no more than 20 characters!", "Error!");
                        break;

                    case 1:
                        MessageBox.Show("20자 이하로 넣어주세요.", "글자크기 오류!");
                        break;

                    case 2:
                        MessageBox.Show("20文字以下で入力してください。", "エラー!");
                        break;
                }
                return false;
            }

            // 확률 입력 확인
            else if (probabilityTextbox.TextLength == 0)
            {
                switch (selected)
                {
                    case 0:
                        MessageBox.Show("Please input the number!", "Error!");
                        break;

                    case 1:
                        MessageBox.Show("숫자를 정확히 넣어주세요", "숫자 오류!");
                        break;

                    case 2:
                        MessageBox.Show("数字を正しく入力ください。", "エラー!");
                        break;
                }
                return false;
            }

            // 확률 범위 초과
            else if(decimal.Parse(probabilityTextbox.Text) < 0 || decimal.Parse(probabilityTextbox.Text) > 100)
            {
                switch (selected)
                {
                    case 0:
                        MessageBox.Show("Please input the right number!", "Error!");
                        break;

                    case 1:
                        MessageBox.Show("올바른 숫자를 넣어주세요", "숫자 오류!");
                        break;

                    case 2:
                        MessageBox.Show("数字を正しく入力ください。", "エラー!");
                        break;
                }
                return false;
            }
            else
                return true;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        // 세이브 버튼을 클릭하면 예외(noInputCheck)가 없을 경우 아이템을 추가하는 메서드
        private void SaveButton_Click(object sender, EventArgs e)
        {
            //string img_folder = @"../../images";
            string img_folder = "images\\";
            LootItem lootitem;

            // 저장 경로가 없을경우 생성
            if (!System.IO.Directory.Exists(img_folder))
                System.IO.Directory.CreateDirectory(img_folder);

            // 안에 내용이 안들어가거나 내용에 이상이 있을 경우
            if (!noInputCheck())
                return;

            if (imgFileName == null)
            {
                lootitem = new LootItem(nameTextbox.Text, decimal.Parse(probabilityTextbox.Text));
                main.AddItem(lootitem);
            }
            else
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    string filePath = img_folder + imgFileName;
                    imagePictureBox.Image.Save(filePath);
                    Byte[] bytes = File.ReadAllBytes(img_folder + imgFileName);
                    MemoryStream ms = new MemoryStream(bytes);

                    Image image = Image.FromStream(ms);
                    Bitmap newSize = new Bitmap(image, new Size(35, 35));

                    //lootitem = new LootItem(nameTextbox.Text, newSize, decimal.Parse(probabilityTextbox.Text));
                    lootitem = new LootItem(nameTextbox.Text, newSize, decimal.Parse(probabilityTextbox.Text), filePath);
                    main.AddItem(lootitem);
                    /*
                    using (FileStream fs = new FileStream(imgFileName, FileMode.Create, FileAccess.ReadWrite))
                    {
                    }
                    */
                }
            }
            this.Close();
        }

        // 확률에 이상한 숫자가 들어가는 것을 방지
        private void ProbabilityTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }

        private void ProbabilityTextbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
