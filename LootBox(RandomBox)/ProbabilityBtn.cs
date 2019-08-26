using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LootBox_RandomBox_
{
    public partial class ProbabilityBtn : Form
    {
        // 언어 선택
        int selectedIndex;
        // 메인 화면
        mainWindow mainForm;

        // 아이템 리스트
        List<LootItem> itemList;

        // 이미지
        DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
        // 이름
        DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
        // 확률
        DataGridViewTextBoxColumn probColumn = new DataGridViewTextBoxColumn();
        // 변경
        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();

        public ProbabilityBtn(int selectedIndex, ref List<LootItem> itemList, mainWindow mainForm)
        {
            InitializeComponent();

            this.itemList = itemList;
            Init(selectedIndex, mainForm);

            ProbInit();

            totalLabelSetting();
        }

        // 중앙의 dataGridView를 설정해준다.
        void GridViewSetting()
        {
            itemList_dataGridView.Columns.Add(imgColumn);
            itemList_dataGridView.Columns.Add(nameColumn);
            itemList_dataGridView.Columns.Add(probColumn);
            //itemList_dataGridView.Columns.Add(buttonColumn);

            itemList_dataGridView.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(171,171,171);
            itemList_dataGridView.Columns[1].DefaultCellStyle.BackColor = Color.FromArgb(171,171,171);

            itemList_dataGridView.Columns[0].Width = 60;
            itemList_dataGridView.Columns[1].Width = 153;
            itemList_dataGridView.Columns[2].Width = 60;
            //itemList_dataGridView.Columns[3].Width = 50;

            itemList_dataGridView.RowHeadersVisible = false;
            itemList_dataGridView.AllowUserToDeleteRows = false;
            itemList_dataGridView.AllowUserToAddRows = false;

            //itemList_dataGridView.Rows[0].ReadOnly = true;
            itemList_dataGridView.Columns[0].ReadOnly = true;
            itemList_dataGridView.Columns[1].ReadOnly = true;
            //itemList_dataGridView.Columns[2].ReadOnly = true;

            switch (selectedIndex)
            {
                case Language.english:
                    itemList_dataGridView.Columns[0].HeaderText = "Image";
                    itemList_dataGridView.Columns[1].HeaderText = "Name";
                    itemList_dataGridView.Columns[2].HeaderText = "Probability";
                    //itemList_dataGridView.Columns[3].HeaderText = "Setting";
                    break;
                case Language.korean:
                    itemList_dataGridView.Columns[0].HeaderText = "이미지";
                    itemList_dataGridView.Columns[1].HeaderText = "이름";
                    itemList_dataGridView.Columns[2].HeaderText = "확률";
                    //itemList_dataGridView.Columns[3].HeaderText = "설정";
                    break;
                case Language.japanese:
                    itemList_dataGridView.Columns[0].HeaderText = "イメージ";
                    itemList_dataGridView.Columns[1].HeaderText = "名前";
                    itemList_dataGridView.Columns[2].HeaderText = "確率";
                    //itemList_dataGridView.Columns[3].HeaderText = "設定";
                    break;
            }
        }

        // GridView를 생성하고 표에 넣어준다.
        void ProbInit()
        {
            // gridViewSetting
            GridViewSetting();

            foreach (LootItem myitem in itemList)
            {
                //itemList_dataGridView.Rows.Add(myitem.ItemImage, myitem.Name, myitem.Probability,"Setting");
                itemList_dataGridView.Rows.Add(myitem.ItemImage, myitem.Name, myitem.Probability.ToString("N3"));
            }
        }

        // 확률의 총합을 구해주는 함수
        decimal TotalProbability()
        {
            decimal total = 0;
            Debug.WriteLine(itemList_dataGridView.Rows.Count);
            for (int i = 0; i < itemList_dataGridView.Rows.Count; i++)
            {
                Debug.WriteLine(decimal.Parse(itemList_dataGridView.Rows[i].Cells[2].Value.ToString()));
                total += decimal.Parse(itemList_dataGridView.Rows[i].Cells[2].Value.ToString());
            }
            
            return total;
        }
        
        // 처음 실행되었을 때 변수들을 맴버 변수에 대입시켜 다른 함수에서 이용하기 용이하게 만들고,
        // 언어 설정 이후 위치를 잡아준다.
        void Init(int selectedIndex, mainWindow mainForm)
        {
            // 메인 설정
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.selectedIndex = selectedIndex;
            this.mainForm = mainForm;

            // 텍스트 설정
            switch (selectedIndex)
            {
                // English
                case Language.english:
                    probabilitySettingLabel.Text = "Probability Setting";
                    enterButton.Text = "OK";
                    this.Text = "Probability Setting";
                    break;

                case Language.korean:
                    probabilitySettingLabel.Text = "확률 설정";
                    enterButton.Text = "확인";
                    this.Text = "확률 설정";
                    break;

                case Language.japanese:
                    probabilitySettingLabel.Text = "確率設定";
                    enterButton.Text = "オッケー";
                    this.Text = "確率設定";
                    break;
            }
            //위치 설정
            probabilitySettingLabel.Location = new Point(this.Width / 2 - probabilitySettingLabel.Width / 2,10);
            enterButton.Location = new Point(this.Width / 2 - enterButton.Width / 2, 335);
        }

        // 숫자가 입력되지 않았을 때의 메세지박스
        private void NoNumberInputMessageBox()
        {
            switch (selectedIndex)
            {
                case Language.english:
                    MessageBox.Show("It's not a number");
                    break;

                case Language.korean:
                    MessageBox.Show("숫자가 아닙니다.");
                    break;

                case Language.japanese:
                    MessageBox.Show("数字ではありません。");
                    break;
            }
        }

        // 숫자 범위 초과를 확인하는 메서드
        private bool NumberRangeOver(decimal num)
        {
            if(num < 0 || num > 100)
            {
                switch (selectedIndex)
                {
                    case Language.english:
                        MessageBox.Show("Probability range Exceed");
                        break;

                    case Language.korean:
                        MessageBox.Show("확률 범위 초과!");
                        break;

                    case Language.japanese:
                        MessageBox.Show("確率範囲を超えています。");
                        break;
                }
                return true;
            }
            return false;
        }

        private bool SumOverCheck(decimal sum)
        {
            if(sum > 100)
            {
                switch (selectedIndex)
                {
                    case Language.english:
                        MessageBox.Show("Please set the probability to 100% or less");
                        break;

                    case Language.korean:
                        MessageBox.Show("확률을 100% 이하로 맞춰주세요.");
                        break;

                    case Language.japanese:
                        MessageBox.Show("確率を100%以下に合わせてください。");
                        break;
                }
                return true;
            }
            return false;
        }

        // 입력 버튼을 눌렀을 때 예외처리를 하고, 예외가 없을 경우 확률을 확정하여 mainForm으로 보내준다.
        private void EnterButton_Click(object sender, EventArgs e)
        {
            decimal sum = 0;
            for(int i=0; i<itemList.Count; i++) {
                decimal temp = -1;
                if (!decimal.TryParse(itemList_dataGridView.Rows[i].Cells[2].Value.ToString(),out temp))
                {
                    NoNumberInputMessageBox();
                    return;
                }
                else if(NumberRangeOver(temp))
                {
                    return;
                }
                else
                {
                    sum += temp;
                }
            }
            if(SumOverCheck(sum))
            {
                return;
            }

            for(int i = 0; i < itemList.Count; i++)
            {
                itemList[i].Probability = decimal.Parse(itemList_dataGridView.Rows[i].Cells[2].Value.ToString());
            }

            mainForm.UpdateItemList();
            this.Close();
        }

        void totalLabelSetting()
        {
            switch (selectedIndex)
            {
                case Language.english:
                    totalLabel.Text = "total : " + TotalProbability();
                    break;

                case Language.korean:
                    totalLabel.Text = "합계 : " + TotalProbability();
                    break;

                case Language.japanese:
                    totalLabel.Text = "合計 : " + TotalProbability();
                    break;
            }
        }

        private void ItemList_dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            totalLabelSetting();
        }
    }
}
