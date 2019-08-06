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
    public partial class mainWindow : Form
    {
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

            LanguageInit();
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

        private void AddButton_Click(object sender, EventArgs e)
        {

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
                lootingList_label.Text = "Result";
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
                lootingList_label.Text = "결과 목록";
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
                lootingList_label.Text = "結果リスト";
            }
        }
    }
}
