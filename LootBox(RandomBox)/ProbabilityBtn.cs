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
                case 0:
                    itemList_dataGridView.Columns[0].HeaderText = "Image";
                    itemList_dataGridView.Columns[1].HeaderText = "Name";
                    itemList_dataGridView.Columns[2].HeaderText = "Probability";
                    //itemList_dataGridView.Columns[3].HeaderText = "Setting";
                    break;
                case 1:
                    itemList_dataGridView.Columns[0].HeaderText = "이미지";
                    itemList_dataGridView.Columns[1].HeaderText = "이름";
                    itemList_dataGridView.Columns[2].HeaderText = "확률";
                    //itemList_dataGridView.Columns[3].HeaderText = "설정";
                    break;
                case 2:
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
            
            /*
            for(int i=0; i < itemList.Count; i++)
            {
                switch(selectedIndex)
                {
                    case 0:
                        itemList_dataGridView[3, i].Value = "Setting";
                        break;

                    case 1:
                        itemList_dataGridView[3, i].Value = "변경";
                        break;

                    case 2:
                        itemList_dataGridView[3, i].Value = "変更";
                        break;
                }
            }
            */
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
                case 0:
                    probabilitySettingLabel.Text = "Probability Setting";
                    enterButton.Text = "OK";
                    this.Text = "Probability Setting";
                    break;

                case 1:
                    probabilitySettingLabel.Text = "확률 설정";
                    enterButton.Text = "확인";
                    this.Text = "확률 설정";
                    break;

                case 2:
                    probabilitySettingLabel.Text = "確率設定";
                    enterButton.Text = "オッケー";
                    this.Text = "確率設定";
                    break;
            }
            //위치 설정
            probabilitySettingLabel.Location = new Point(this.Width / 2 - probabilitySettingLabel.Width / 2,10);
            enterButton.Location = new Point(this.Width / 2 - enterButton.Width / 2, 335);
        }

        // 입력 버튼을 눌렀을 때 예외처리를 하고, 예외가 없을 경우 확률을 확정하여 mainForm으로 보내준다.
        private void EnterButton_Click(object sender, EventArgs e)
        {
            decimal sum = 0;
            for(int i=0; i<itemList.Count; i++) {
                decimal temp = -1;
                if (!decimal.TryParse(itemList_dataGridView.Rows[i].Cells[2].Value.ToString(),out temp))
                {
                    switch (selectedIndex)
                    {
                        case 0:
                            MessageBox.Show("It's not a number");
                            break;

                        case 1:
                            MessageBox.Show("숫자가 아닙니다.");
                            break;

                        case 2:
                            MessageBox.Show("数字ではありません。");
                            break;
                    }
                    
                    return;
                }
                else if(temp < 0 || temp > 100)
                {
                    switch (selectedIndex)
                    {
                        case 0:
                            MessageBox.Show("Probability range Exceed");
                            break;

                        case 1:
                            MessageBox.Show("확률 범위 초과!");
                            break;

                        case 2:
                            MessageBox.Show("確率範囲を超えています。");
                            break;
                    }
                    return;
                }
                else
                {
                    sum += temp;
                }
            }
            if(sum != 100)
            {
                switch (selectedIndex)
                {
                    case 0:
                        MessageBox.Show("Please set the probability at 100% ");
                        break;

                    case 1:
                        MessageBox.Show("확률이 100%가 되지 않습니다.");
                        break;

                    case 2:
                        MessageBox.Show("確率を100%に合わせてください。");
                        break;
                }

                return;
            }

            for(int i = 0; i < itemList.Count; i++)
            {
                itemList[i].Probability = decimal.Parse(itemList_dataGridView.Rows[i].Cells[2].Value.ToString());
            }

            mainForm.UpdateItemList();
            this.Close();
        }

        private void ItemList_dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
