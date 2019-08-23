﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        // resultCountListInit
        DataGridViewImageColumn resultCountImg = new DataGridViewImageColumn();
        DataGridViewTextBoxColumn resultCountName = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn resultCountCount = new DataGridViewTextBoxColumn();

        // resultOrderListInit
        DataGridViewImageColumn resultOrderImg = new DataGridViewImageColumn();
        DataGridViewTextBoxColumn resultOrderName = new DataGridViewTextBoxColumn();

        //아이템 리스트
        List<LootItem> itemList = new List<LootItem>();
        //카운트 결과 리스트
        List<ResultLootItem> resultCountList = new List<ResultLootItem>();
        // 순서 결과 리스트
        List<ResultLootItem> resultOrderList = new List<ResultLootItem>();

        // addBtnForm.cs에서 넘겨받은 LootItem을 내 리스트에 추가시킨다.
        public void AddItem(LootItem myitem, ResultLootItem resultItem)
        {
            itemList.Add(myitem);
            resultCountList.Add(resultItem);
            
            itemList_dataGridView.Rows.Add(myitem.ItemImage, myitem.Name, myitem.Probability.ToString("N3")+"%");
            countResult_dataGridView.Rows.Add(resultItem.ItemImage, resultItem.Name, resultItem.Count);
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

            this.Width = 35 + itemList_dataGridView.Width + lootBoxImage.Width + orderResult_dataGridView.Width;

            // 위치 설정 함수
            setLocation();

            //추가
            ItemListInit();
            LanguageInit();
            resultGridViewInit();
        }
        
        //위치 설정 함수
        void setLocation()
        {
            itemList_dataGridView.Location = new Point(5, 40);
            lootBoxImage.Location = new Point(10 + itemList_dataGridView.Width, 40);
            orderResult_dataGridView.Location = new Point(15 + itemList_dataGridView.Width + lootBoxImage.Width, 40);
            countResult_dataGridView.Location = new Point(15 + itemList_dataGridView.Width + lootBoxImage.Width, 40);
            countResult_dataGridView.Visible = false;

            tryButton.Location = new Point(this.Width / 2 - tryButton.Width / 2, 315);
            boxList_label.Location = new Point(5, 20);
            result_label.Location = new Point(15 + itemList_dataGridView.Width + lootBoxImage.Width, 20);
            resultChangeBtn.Location = new Point(25 + result_label.Location.X + result_label.Width, 5);
        }

        // 아이템 리스트에 데이터 추가
        private void ItemListInit()
        {
            // 열에 추가
            itemList_dataGridView.Columns.Add(imgColumn);
            itemList_dataGridView.Columns.Add(nameColumn);
            itemList_dataGridView.Columns.Add(probabilityColumn);

            itemList_dataGridView.Columns[0].Width = 60;
            itemList_dataGridView.Columns[1].Width = 109;
            itemList_dataGridView.Columns[2].Width = 56;

            itemList_dataGridView.ReadOnly = true;

            itemList_dataGridView.RowHeadersVisible = false;
            itemList_dataGridView.AllowUserToDeleteRows = false;
            itemList_dataGridView.AllowUserToAddRows = false;
        }

        // 결과 리스트 초기화
        private void resultGridViewInit()
        {
            orderResult_dataGridView.Columns.Add(resultOrderImg);
            orderResult_dataGridView.Columns.Add(resultOrderName);

            orderResult_dataGridView.Columns[0].Width = 60;
            orderResult_dataGridView.Columns[1].Width = 165;

            orderResult_dataGridView.ReadOnly = true;

            orderResult_dataGridView.RowHeadersVisible = false;
            orderResult_dataGridView.AllowUserToDeleteRows = false;
            orderResult_dataGridView.AllowUserToAddRows = false;

            countResult_dataGridView.Columns.Add(resultCountImg);
            countResult_dataGridView.Columns.Add(resultCountName);
            countResult_dataGridView.Columns.Add(resultCountCount);

            countResult_dataGridView.Columns[0].Width = 60;
            countResult_dataGridView.Columns[1].Width = 125;
            countResult_dataGridView.Columns[2].Width = 40;

            countResult_dataGridView.ReadOnly = true;

            countResult_dataGridView.RowHeadersVisible = false;
            countResult_dataGridView.AllowUserToDeleteRows = false;
            countResult_dataGridView.AllowUserToAddRows = false;
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
            switch(language_comboList.SelectedIndex){
                case 0:
                    this.Text = "LootBox";
                    boxList_label.Text = "Box List";
                    addButton.Text = "Add";
                    deleteButton.Text = "Delete";
                    saveButton.Text = "Save";
                    loadButton.Text = "Load";
                    tryButton.Text = "Try";
                    result_label.Text = "Result";
                    probabilityButton.Text = "Probability";
                    resultChangeBtn.Text = (countResult_dataGridView.Visible == true) ? "Change in Order" : "Change to Count";

                    // boxlist
                    imgColumn.HeaderText = "Image";
                    imgColumn.Name = "Image";
                    nameColumn.HeaderText = "Name";
                    nameColumn.Name = "text";
                    probabilityColumn.HeaderText = "Probability";
                    probabilityColumn.Name = "text";

                    // resultOrderList
                    resultOrderImg.HeaderText = "Image";
                    resultOrderName.HeaderText = "Name";

                    // resultCountList
                    resultCountImg.HeaderText = "Image";
                    resultCountName.HeaderText = "Name";
                    resultCountCount.HeaderText = "Count";
                    break;

                case 1:
                    this.Text = "랜덤 박스";
                    boxList_label.Text = "내용물";
                    addButton.Text = "추가";
                    deleteButton.Text = "삭제";
                    saveButton.Text = "저장";
                    loadButton.Text = "불러오기";
                    tryButton.Text = "뽑기";
                    result_label.Text = "결과 목록";
                    probabilityButton.Text = "확률";
                    resultChangeBtn.Text = (countResult_dataGridView.Visible == true) ? "순서로 변경" : "개수로 변경";

                    // boxlist
                    imgColumn.HeaderText = "이미지";
                    imgColumn.Name = "Image";
                    nameColumn.HeaderText = "이름";
                    nameColumn.Name = "text";
                    probabilityColumn.HeaderText = "확률";
                    probabilityColumn.Name = "text";

                    //resultOrderList
                    resultOrderImg.HeaderText = "이미지";
                    resultOrderName.HeaderText = "이름";

                    // resultList
                    resultCountImg.HeaderText = "이미지";
                    resultCountName.HeaderText = "이름";
                    resultCountCount.HeaderText = "개수";
                    break;

                case 2:
                    this.Text = "ランダムボックス";
                    boxList_label.Text = "アイテムリスト";
                    addButton.Text = "追加";
                    deleteButton.Text = "デリート";
                    saveButton.Text = "セーブ";
                    loadButton.Text = "ロード";
                    tryButton.Text = "開く";
                    result_label.Text = "結果リスト";
                    probabilityButton.Text = "確率";
                    resultChangeBtn.Text = (countResult_dataGridView.Visible == true) ? "順序に変更" : "改修に変更";

                    // boxlist
                    imgColumn.HeaderText = "イメージ";
                    imgColumn.Name = "Image";
                    nameColumn.HeaderText = "名前";
                    nameColumn.Name = "text";
                    probabilityColumn.HeaderText = "確率";
                    probabilityColumn.Name = "text";

                    // resultOrderList
                    resultOrderImg.HeaderText = "イメージ";
                    resultOrderName.HeaderText = "名前";

                    // resultCountList
                    resultCountImg.HeaderText = "イメージ";
                    resultCountName.HeaderText = "名前";
                    resultCountCount.HeaderText = "改修";
                    break;

            }
        }

        private void Box_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Delete 버튼을 클릭하면 그 form으로 이동한다.
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteBtnForm deleteBtnForm = new DeleteBtnForm(language_comboList.SelectedIndex, itemList, this);

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
                resultCountList.RemoveAt(deleteIndex[i]);
                countResult_dataGridView.Rows.Remove(countResult_dataGridView.Rows[deleteIndex[i]]);
                deleteIndex.RemoveAt(i);
            }
        }
        //countResult_dataGridView를 클리어시킨다.
        public void ClearcountResultGridView()
        {
            for(int i=countResult_dataGridView.Rows.Count - 1; i >= 0; i--)
            {
                countResult_dataGridView.Rows.Remove(countResult_dataGridView.Rows[i]);
            }
        }

        // 확률을 받으면 업데이트시켜준다.
        public void UpdateItemList()
        {
            int max = itemList.Count;
            for(int i=0; i < max; i++)
            {
                itemList_dataGridView.Rows.Remove(itemList_dataGridView.Rows[i--]);
                max--;
            }
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList_dataGridView.Rows.Add(itemList[i].ItemImage,itemList[i].Name,itemList[i].Probability.ToString("N3") + "%");
            }
        }

        // 임시버튼테스트용(삭제)
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
                ClearcountResultGridView();
                for (int i=0; i<saveFile.Length; i += 3)
                {   //이미지 파일이 없는 경우
                    LootItem temp;
                    ResultLootItem resultTemp;
                    if (saveFile[i + 1].Equals(""))
                    {
                        temp = new LootItem(saveFile[i + 0], decimal.Parse(saveFile[i + 2]));
                        resultTemp = new ResultLootItem(saveFile[i + 0], decimal.Parse(saveFile[i + 2]));
                    }
                    else
                    {
                        Byte[] bytes = File.ReadAllBytes(saveFile[i + 1]);
                        MemoryStream ms = new MemoryStream(bytes);
                        Image image = Image.FromStream(ms);
                        Bitmap sizeChangeImage = new Bitmap(image, new Size(35, 35));
                        temp = (new LootItem(saveFile[i + 0], decimal.Parse(saveFile[i + 2]), sizeChangeImage,image , saveFile[i + 1]));
                        resultTemp = new ResultLootItem(saveFile[i + 0], decimal.Parse(saveFile[i + 2]), sizeChangeImage, image, saveFile[i + 1]);
                        ms.Flush();
                    }

                    AddItem(temp, resultTemp);
                }
            }
        }

        // 아이템이 없을 경우 메세지를 띄우고, 아이템이 있을 경우 확률 설정 페이지를 띄운다.
        private void ProbabilityButton_Click(object sender, EventArgs e)
        {
            if(itemList.Count == 0)
            {
                switch (language_comboList.SelectedIndex)
                {
                    // English
                    case 0:
                        MessageBox.Show("Please Add the Item");
                        break;
                    // Korean
                    case 1:
                        MessageBox.Show("아이템을 추가해 주세요");
                        break;
                    // Japanese
                    case 2:
                        MessageBox.Show("アイテムの追加してください。");
                        break;
                }
                return;
            }
            ProbabilityBtn probabilityBtn = new ProbabilityBtn(language_comboList.SelectedIndex,ref itemList, this);

            probabilityBtn.ShowDialog();
        }

        // Try버튼을 클릭하였을 때 랜덤 뽑기를 진행
        private void TryButton_Click(object sender, EventArgs e)
        {
            decimal sum = 0;

            foreach(LootItem item in itemList)
            {
                sum += item.Probability;
            }
            if(sum != 100)
            {
                switch (language_comboList.SelectedIndex)
                {
                    case 0:
                        MessageBox.Show("Please make to total probability at 100%");
                        break;

                    case 1:
                        MessageBox.Show("확률의 합계를 100%로 맞춰주세요");
                        break;

                    case 2:
                        MessageBox.Show("確率の合計を100%にしてください");
                        break;
                }

                return;
            }

            Random r = new Random(DateTime.Now.Millisecond);
            int randomResult = r.Next(0, 100000);

            decimal min = 0;
            decimal max = itemList[0].Probability;
            Debug.WriteLine(randomResult.ToString());
            for(int i=0; i<itemList.Count; i++)
            {
                Debug.WriteLine("min : {0}, prob : {1}", min*1000, itemList[i].Probability*1000);
                // 성공
                if(randomResult >= (min * 1000) && randomResult < (max * 1000))
                {
                    Debug.WriteLine("당첨!");
                    if (itemList[i].ImgFIlePath.Equals("NULL")) {
                        resultOrderList.Add(new ResultLootItem(itemList[i].Name,itemList[i].Probability));
                    }
                    else
                    {
                        resultOrderList.Add(new ResultLootItem(itemList[i].Name, itemList[i].Probability, itemList[i].ItemImage, itemList[i].OriginalImage, itemList[i].ImgFIlePath));
                    }
                    orderResult_dataGridView.Rows.Add(itemList[i].ItemImage, itemList[i].Name);
                    resultCountList[i].Count++;
                    Debug.WriteLine(countResult_dataGridView.Rows[i].Cells[2].Value);
                    Debug.WriteLine(resultCountList[i].Count);

                    countResult_dataGridView.Rows[i].Cells[2].Value = resultCountList[i].Count;

                    ResultPage resultPage = new ResultPage(itemList[i], language_comboList.SelectedIndex);

                    resultPage.ShowDialog();

                    break;
                }
                // 실패
                else
                {
                    Debug.WriteLine("실패");
                    min = itemList[i].Probability;
                    max += itemList[i + 1].Probability;
                }
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void ResultChangeBtn_Click(object sender, EventArgs e)
        {
            if (countResult_dataGridView.Visible == true)
            {
                countResult_dataGridView.Visible = false;
                orderResult_dataGridView.Visible = true;
                switch (language_comboList.SelectedIndex)
                {
                    case 0:
                        resultChangeBtn.Text = "Change to Count";
                        break;

                    case 1:
                        resultChangeBtn.Text = "개수로 변경";
                        break;

                    case 2:
                        resultChangeBtn.Text = "改修に変更";
                        break;
                }
            }
            else
            {
                countResult_dataGridView.Visible = true;
                orderResult_dataGridView.Visible = false;
                switch (language_comboList.SelectedIndex)
                {
                    case 0:
                        resultChangeBtn.Text = "Change in Order";
                        break;

                    case 1:
                        resultChangeBtn.Text = "순서로 변경";
                        break;

                    case 2:
                        resultChangeBtn.Text = "順序に変更";
                        break;
                }
            }
        }
    }
}
