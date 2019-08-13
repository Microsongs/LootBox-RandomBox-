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
using System.Windows.Documents;
using System.Windows.Forms;

namespace LootBox_RandomBox_
{
    public partial class mainWindow : Form
    {
        // ItemListInit
        // 콤보박스
        DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
        // 이미지
        DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
        // 이름
        DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
        // 확률
        DataGridViewTextBoxColumn probabilityColumn = new DataGridViewTextBoxColumn();

        //아이템 리스트
        List<LootItem> itemList = new List<LootItem>();
        public void AddItem(LootItem myitem)
        {
            itemList.Add(myitem);
            itemList_dataGridView.Rows.Add(myitem.ItemImage, myitem.Name, myitem.Probability.ToString("N3")+"%");
        }

        public mainWindow()
        {
            InitializeComponent();
            Init();
        }

        //시작하면서 기본사항 설정
        private void Init()
        {
            // 랜덤박스의 image를 설정
            lootBoxImage.Image = Properties.Resources.lootBoxImage;
            lootBoxImage.SizeMode = PictureBoxSizeMode.StretchImage;

            //임시 추거
            //Image tempImg = Image.FromFile(@"../../images/tempSword.png");
            //box_listBox.Items.Add(new LootItem("전사의 검", tempImg, 100.0M));
            //box_listBox.DrawItem += new DrawItemEventHandler(box_listBox_DrawItem);

            // 아이템 이미지

            //추가
            ItemListInit();
            LanguageInit();
        }

        // 아이템 리스트에 데이터 추가
        private void ItemListInit()
        {
            //그룹박스
            //GroupBox checkGroup = new GroupBox();
            //checkGroup.Controls.Add(checkColumn);

            //맨 위 설정
            //checkColumn.HeaderText = "삭제";
            //checkColumn.Name = "column";

            // 열에 추가
            //itemList_dataGridView.Columns.Add(checkColumn);
            itemList_dataGridView.Columns.Add(imgColumn);
            itemList_dataGridView.Columns.Add(nameColumn);
            itemList_dataGridView.Columns.Add(probabilityColumn);

            itemList_dataGridView.Columns[0].Width = 60;
            itemList_dataGridView.Columns[1].Width = 110;
            itemList_dataGridView.Columns[2].Width = 56;

            /*
            Image image = Image.FromFile(@"../../images/tempSword.png");
            int width = 35;
            int height = 30;
            Size resize = new Size(width, height);
            Bitmap newSize = new Bitmap(image,resize);
            */

            itemList_dataGridView.ReadOnly = true;
            //itemList_dataGridView.Rows[0].ReadOnly = true;
            //itemList_dataGridView.Columns[1].ReadOnly = true;
            //itemList_dataGridView.Columns[2].ReadOnly = true;
            //itemList_dataGridView.Columns[3].ReadOnly = true;
            //itemList_dataGridView.Rows.Add(1, newSize, "전설의 검", "100");
            //itemList_dataGridView.Rows.Add(0, newSize, "불꽃의 검", "100");
            //itemList_dataGridView.Rows.Add(newSize, "ドラゴンソード", "70");
            //itemList_dataGridView.Rows.Add(newSize, "炎の剣", "30");

            itemList_dataGridView.RowHeadersVisible = false;
            itemList_dataGridView.AllowUserToDeleteRows = false;
            itemList_dataGridView.AllowUserToAddRows = false;
            //itemList_dataGridView.ColumnHeadersVisible = false;
        }

        //언어 설정 콤보박스 세팅
        private void LanguageInit()
        {
            string[] language = { "English", "한국어", "日本語" };
            language_comboList.Items.AddRange(language);
            language_comboList.SelectedIndex = 0;
        }

        private void LootBoxImage_Click(object sender, EventArgs e)
        {

        }

        // Add 버튼으로 아이템을 추가하기 위함
        private void AddButton_Click(object sender, EventArgs e)
        {
            
            AddBtnForm addBtnForm = new AddBtnForm(language_comboList.SelectedIndex, this);
            //addBtnForm.Location = new Point(Cursor.Position.X + 50,Cursor.Position.Y-200);

            addBtnForm.ShowDialog();
        }

        // language_comboList의 이벤트 핸들러
        private void Language_comboList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // English
            if (language_comboList.SelectedIndex == 0)
            {
                this.Text = "LootBox";
                boxList_label.Text = "Box List";
                addButton.Text = "Add";
                deleteButton.Text = "Delete";
                saveButton.Text = "Save";
                loadButton.Text = "Load";
                tryButton.Text = "Try";
                result_label.Text = "Result";
                // boxlist

                imgColumn.HeaderText = "Image";
                imgColumn.Name = "Image";
                nameColumn.HeaderText = "Name";
                nameColumn.Name = "text";
                probabilityColumn.HeaderText = "Probability";
                probabilityColumn.Name = "text";
            }
            // 한국어
            else if (language_comboList.SelectedIndex == 1)
            {
                this.Text = "랜덤 박스";
                boxList_label.Text = "내용물";
                addButton.Text = "추가";
                deleteButton.Text = "삭제";
                saveButton.Text = "저장";
                loadButton.Text = "불러오기";
                tryButton.Text = "뽑기";
                result_label.Text = "결과 목록";
                
                // boxlist
                imgColumn.HeaderText = "이미지";
                imgColumn.Name = "Image";
                nameColumn.HeaderText = "이름";
                nameColumn.Name = "text";
                probabilityColumn.HeaderText = "확률";
                probabilityColumn.Name = "text";
            }
            // 日本語
            else
            {
                this.Text = "ランダムボックス";
                boxList_label.Text = "アイテムリスト";
                addButton.Text = "追加";
                deleteButton.Text = "デリート";
                saveButton.Text = "セーブ";
                loadButton.Text = "ロード";
                tryButton.Text = "開く";
                result_label.Text = "結果リスト";

                // boxlist
                imgColumn.HeaderText = "イメージ";
                imgColumn.Name = "Image";
                nameColumn.HeaderText = "名前";
                nameColumn.Name = "text";
                probabilityColumn.HeaderText = "確率";
                probabilityColumn.Name = "text";
            }
        }

        private void Box_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteBtnForm deleteBtnForm = new DeleteBtnForm(language_comboList.SelectedIndex, itemList, this);
            //deleteBtnForm.Location= new Point(Cursor.Position.X, Cursor.Position.Y);

            deleteBtnForm.ShowDialog();
        }

        // 체크된 리스트를 지우는 함수
        public void deleteList(List<int> deleteIndex)
        {
            for(int i = deleteIndex.Count - 1;i >= 0; i--)
            {
                Debug.WriteLine(deleteIndex.Count.ToString());
                Debug.WriteLine(deleteIndex[0].ToString());
                itemList.RemoveAt(deleteIndex[i]);
                itemList_dataGridView.Rows.Remove(itemList_dataGridView.Rows[deleteIndex[i]]);
                deleteIndex.RemoveAt(i);
            }
        }

        private void TestBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(itemList.Count.ToString());
        }

        // 저장 버튼
        private void SaveButton_Click(object sender, EventArgs e)
        {
            using(FileStream fs = new FileStream("data.dat", FileMode.Create))
            {
                //BinaryWriter bw = new BinaryWriter(fs);
                StreamWriter bw = new StreamWriter(fs, Encoding.UTF8);

                string[] msg = new string[3];

                if (itemList.Count != 0)
                {
                    for(int i=0; i<itemList.Count; i++)
                    {
                        if (itemList[i].ImgFIlePath == null) {
                            bw.Write(itemList[i].Name+"\n");
                            //Debug.WriteLine(Encoding.Default.GetString(itemList[i].ImgFIlePath));
                            //bw.Write(itemList[i].ItemImage.FileName);
                            bw.Write("noPath"+"\n");
                            bw.Write(itemList[i].Probability+"\n");
                        }
                        else
                        {
                            bw.Write(itemList[i].Name+"\n");
                            Debug.WriteLine(itemList[i].ImgFIlePath);
                            bw.Write(itemList[i].ImgFIlePath+"\n");
                            bw.Write(itemList[i].Probability+"\n");
                        }
                    }
                    msg[0] = "Save Complete!";
                    msg[1] = "저장 완료!";
                    msg[2] = "サーブ完了";
                    bw.Flush();
                    MessageBox.Show(msg[language_comboList.SelectedIndex]);
                }
                else
                {
                    msg[0] = "No Data to Save";
                    msg[1] = "저장할 데이터가 없습니다.";
                    msg[2] = "データがありません。";
                    bw.Flush();
                    MessageBox.Show(msg[language_comboList.SelectedIndex]);
                }
            }
        }

        // 불러오기 버튼
        private void LoadButton_Click(object sender, EventArgs e)
        {
            //이미 만들어진 리스트가 있을 떄 덮어쓸것인지   
            if(itemList.Count != 0)
            {
                string[] msg = new string[3] {
                    "The existing List will be erased. are you okay?",
                    "기존 리스트가 지워집니다. 괜찮으십니까?",
                    "今のリストが消えます。問題ありませんですか。"
                };
                string[] headmsg = new string[3]
                {
                    "Warning",
                    "경고",
                    "警告"
                };
                if (MessageBox.Show(msg[language_comboList.SelectedIndex],headmsg[language_comboList.SelectedIndex],MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            string[] saveFile = File.ReadAllLines("data.dat");
            if (saveFile != null)
            {
                for(int i=itemList.Count - 1; i>=0; i--)
                {
                    Debug.WriteLine(i);
                    itemList_dataGridView.Rows.Remove(itemList_dataGridView.Rows[i]);
                }
                itemList.Clear();
                for (int i=0; i<saveFile.Length; i += 3)
                {   //이미지 파일이 없는 경우
                    LootItem temp;
                    if (saveFile[i + 1].Equals(""))
                    {
                        temp = new LootItem(saveFile[i + 0], decimal.Parse(saveFile[i + 2]));
                    }
                    else
                    {
                        Byte[] bytes = File.ReadAllBytes(saveFile[i + 1]);
                        MemoryStream ms = new MemoryStream(bytes);
                        Image image = Image.FromStream(ms);
                        Bitmap sizeChangeImage = new Bitmap(image, new Size(35, 35));
                        temp = (new LootItem(saveFile[i + 0], sizeChangeImage, decimal.Parse(saveFile[i + 2]), saveFile[i + 1]));
                        ms.Flush();
                    }
                    AddItem(temp);
                }
            }

            /*
            using (FileStream fs = new FileStream("data.txt", FileMode.Append))
            {
                if (fs == null)
                {
                    MessageBox.Show("불러올 저장 데이터가 없습니다.");
                    return;
                }
                string[] textValue = File.ReadAllLines()
            }
            */
        }
    }
}
