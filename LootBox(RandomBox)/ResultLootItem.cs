using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootBox_RandomBox_
{
    public class ResultLootItem : LootItem
    {
        int count;
        public ResultLootItem(string name, decimal probability, Image itemImage, Image originalImage, string imgFilePath) : base(name, probability, itemImage, originalImage, imgFilePath)
        {
            count = 0;
        }
        public ResultLootItem(string name, decimal probability) : base(name, probability)
        {
            count = 0;
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
    }
}
