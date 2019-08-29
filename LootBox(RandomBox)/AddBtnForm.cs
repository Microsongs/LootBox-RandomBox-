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
        mainWindow mainForm;

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
            this.mainForm = main;
            nameTextbox.MaxLength = 20;
            addInit();
        }

        // 초기화
        private void addInit()
        {
            // English
            switch (selected)
            {
                case Language.english:
                    this.Text = "Add";
                    dataInputLabel.Text = "Enter data";
                    nameLabel.Text = "Name：";
                    probabilityLabel.Text = "Prob : ";
                    imageLabel.Text = "Image : ";
                    imageButton.Text = "Load";
                    saveButton.Text = "Save";
                    break;

                case Language.korean:
                    this.Text = "추가";
                    dataInputLabel.Text = "데이터 입력";
                    nameLabel.Text = "이름 : ";
                    probabilityLabel.Text = "확률 : ";
                    imageLabel.Text = "이미지 : ";
                    imageButton.Text = "등록";
                    saveButton.Text = "저장";
                    break;

                case Language.japanese:
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


        // 제목 유무 확인
        private bool CheckName()
        {
            if (nameTextbox.TextLength == 0)
            {
                switch (selected)
                {
                    case Language.english:
                        MessageBox.Show("Name Please!", "Error!");
                        break;

                    case Language.korean:
                        MessageBox.Show("이름을 넣어주세요!", "이름 오류!");
                        break;

                    case Language.japanese:
                        MessageBox.Show("名前を入れてください。", "エラー!");
                        break;
                }
                return false;
            }
            return true;
        }

        /*
        // 기존 리스트 포함 100%가 맞는지 체크
        private bool CheckSumPercent()
        {
            decimal sum = 0;
            foreach(LootItem num in itemList)
            {
                sum += num.Probability;
            }
            sum += decimal.Parse(probabilityTextbox.ToString());
            if(sum == 100)
            {
                return true;
            }
            switch(selected){
                case Language.english:
                    MessageBox.Show("Sum the probability to 100%","probabilityError");
                    break;
                case Language.korean:
                    MessageBox.Show("확률의 합계를 100%으로 맞춰주세요", "확률 에러!");
                    break;
                case Language.Japanese:
                    MessageBox.Show("額率の合計を100%に合わせてください。");
                    break;
            }
            return false;
        }
        */

        // 20바이트 초과 유무 확인
        private bool CheckLength()
        {
            if (Encoding.Default.GetBytes(nameTextbox.Text).Length > 20)
            {
                switch (selected)
                {
                    case Language.english:
                        MessageBox.Show("Please enter no more than 20 characters!", "Error!");
                        break;

                    case Language.korean:
                        MessageBox.Show("20자 이하로 넣어주세요.", "글자크기 오류!");
                        break;

                    case Language.japanese:
                        MessageBox.Show("20文字以下で入力してください。", "エラー!");
                        break;
                }
                return false;
            }
            return true;
        }

        private bool CheckProb()
        {
            if(probabilityTextbox.TextLength == 0)
            {
                switch (selected)
                {
                    case Language.english:
                        MessageBox.Show("Please input the number!", "Error!");
                        break;

                    case Language.korean:
                        MessageBox.Show("숫자를 정확히 넣어주세요", "숫자 오류!");
                        break;

                    case Language.japanese:
                        MessageBox.Show("数字を正しく入力ください。", "エラー!");
                        break;
                }
                return false;
            }
            return true;
        }

        // 확률 범위 확인 메서드
        private bool CheckProbRange()
        {
            if (decimal.Parse(probabilityTextbox.Text) < 0 || decimal.Parse(probabilityTextbox.Text) > 100)
            {
                switch (selected)
                {
                    case Language.english:
                        MessageBox.Show("Please input the right number!", "Error!");
                        break;

                    case Language.korean:
                        MessageBox.Show("올바른 숫자를 넣어주세요", "숫자 오류!");
                        break;

                    case Language.japanese:
                        MessageBox.Show("数字を正しく入力ください。", "エラー!");
                        break;
                }
                return false;
            }
            else
                return true;
        }

        // 입력 여부 확인하는 메서드
        private bool noInputCheck()
        {

            if (CheckName() && CheckLength() && CheckProb() && CheckProbRange())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        // 세이브 버튼을 클릭하면 예외(noInputCheck)가 없을 경우 아이템을 추가하는 메서드
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string img_folder = "images\\";
            LootItem lootitem;
            ResultLootItem resultItem;

            // 저장 경로가 없을경우 생성
            if (!System.IO.Directory.Exists(img_folder))
                System.IO.Directory.CreateDirectory(img_folder);

            // 안에 내용이 안들어가거나 내용에 이상이 있을 경우
            if (!noInputCheck())
                return;

            if (imgFileName == null)
            {
                lootitem = new LootItem(nameTextbox.Text, decimal.Parse(probabilityTextbox.Text));
                resultItem = new ResultLootItem(nameTextbox.Text, decimal.Parse(probabilityTextbox.Text));
                mainForm.AddItem(lootitem, resultItem);
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

                    lootitem = new LootItem(nameTextbox.Text, decimal.Parse(probabilityTextbox.Text), newSize, image, filePath);
                    resultItem = new ResultLootItem(nameTextbox.Text, decimal.Parse(probabilityTextbox.Text), newSize, image, filePath);
                    mainForm.AddItem(lootitem, resultItem);
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

        // 이미지 버튼 등록 메서드
        private void ImageButtonClick(object sender, EventArgs e)
        {
            string imgFile = string.Empty;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgFile = dialog.FileName;
            }
            else if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                imagePictureBox.Image = Bitmap.FromFile(imgFile);
                imagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                imgFileName = System.IO.Path.GetFileName(imgFile);
            }
            catch (Exception ex)
            {
                ImageButtonMessageBox();
            }
        }

        // 이미지 버튼의 메세지박스
        private void ImageButtonMessageBox()
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
}
