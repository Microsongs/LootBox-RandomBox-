using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LootBox_RandomBox_
{
    public partial class DeleteBtnForm : Form
    {
        // 아이템리스트 데이터그리드뷰의 객체들
        // 콤보박스
        DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
        // 이미지
        DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
        // 이름
        DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();

        // 받아온 아이템리스트
        List<LootItem> itemList;

        // 메인윈도우 변수
        private mainWindow mainForm;

        // 생성자, 아이템리스트를 넘겨받음
        public DeleteBtnForm(int selected,  List<LootItem> itemList, mainWindow mainForm)
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.itemList = itemList;
            this.mainForm = mainForm;
            Init();
            deleteInit(selected);
        }
        // 명칭 설정
        private void deleteInit(int selected)
        {
            switch (selected)
            {
                case 0:
                    this.Text = "Delete";
                    itemListLabel.Text = "Item List";
                    EnterButton.Text = "Delete!";
                    itemList_dataGridView.Columns[0].HeaderText = "Check";
                    itemList_dataGridView.Columns[1].HeaderText = "Image";
                    itemList_dataGridView.Columns[2].HeaderText = "Name";
                    break;

                case 1:
                    this.Text = "삭제";
                    itemListLabel.Text = "아이템 리스트";
                    EnterButton.Text = "삭제!";
                    itemList_dataGridView.Columns[0].HeaderText = "체크";
                    itemList_dataGridView.Columns[1].HeaderText = "이미지";
                    itemList_dataGridView.Columns[2].HeaderText = "이름";
                    break;

                case 2:
                    this.Text = "デリート";
                    itemListLabel.Text = "アイテムリスト";
                    EnterButton.Text = "デリート!";
                    itemList_dataGridView.Columns[0].HeaderText = "チェック";
                    itemList_dataGridView.Columns[1].HeaderText = "イメージ";
                    itemList_dataGridView.Columns[2].HeaderText = "名前";
                    break;
            }
            itemListLabel.Location = new Point(this.Width / 2 - (itemListLabel.Width / 2), 10);
        }

        // 데이터그리드뷰 세팅
        private void Init()
        {
            itemList_dataGridView.Columns.Add(checkColumn);
            itemList_dataGridView.Columns.Add(imgColumn);
            itemList_dataGridView.Columns.Add(nameColumn);

            itemList_dataGridView.Columns[0].Width = 65;
            itemList_dataGridView.Columns[1].Width = 60;
            itemList_dataGridView.Columns[2].Width = 133;

            itemList_dataGridView.RowHeadersVisible = false;
            itemList_dataGridView.AllowUserToDeleteRows = false;
            itemList_dataGridView.AllowUserToAddRows = false;

            //itemList_dataGridView.Rows[0].ReadOnly = true;
            itemList_dataGridView.Columns[1].ReadOnly = true;
            itemList_dataGridView.Columns[2].ReadOnly = true;

            foreach (LootItem myitem in itemList)
            {
                itemList_dataGridView.Rows.Add(false, myitem.ItemImage, myitem.Name);

            }
        }

        // 체크되어있는 
        private void EnterButton_Click(object sender, EventArgs e)
        {
            List<int> deleteIndex = new List<int>();
            for(int i=0; i<itemList.Count; i++)
            {
                //System.Diagnostics.Debug.WriteLine(itemList_dataGridView.Rows[i].Cells[0].Value.ToString());
                //DataGridViewCheckBoxCell checkingCell = itemList_dataGridView.
                if(itemList_dataGridView.Rows[i].Cells[0].Value.ToString() == "True")
                {
                    deleteIndex.Add(i);
                }
            }
            mainForm.deleteList(deleteIndex);
            this.Close();
        }
    }
}
