// Author: Damien Eddington
// Title WikiApplication
// Date:
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WikiApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static int rows = 12;
        static int columns = 4;
        int point = 0;
        string[,] Array = new string[rows, columns];

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddItem();
            DisplayArray();
            BoxClear();
        }
        private void DisplayArray()
        {
            /*WikiBox.Items.Clear();
            for (int i = 0; i < rows; i++)
            {
                ListViewItem lstItem = new ListViewItem();
                lstItem.SubItems.Add(Array[i, 1]);
                WikiBox.Items.Add(lstItem);
            }


            */
            Array[0, 0] = "Name";
            Array[0, 1] = "Category";
            Array[0, 2] = "Structure";
            Array[0, 3] = "Definition";
            /*sWikiBox.Items.Clear();
            string fill;
            for (int i = 0; i < rows; i++)
            {
                fill = Array[i, 0] + "\t" + Array[i, 1];
                WikiBox.Items.Add(fill);
            } */
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    Array[x, y] = "a";
                }
            }
        }
        private void AddItem()
        {
            
            if (point < rows)
            {
                try
                {
                    Array[point, 0] = TxtName.Text;
                    Array[point, 1] = TxtCategory.Text;
                    point++;
                }
                catch
                {
                    MessageBox.Show("Didn't Work");
                }
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            BoxClear();
        }

        private void BoxClear()
        {
            TxtName.Clear();
            TxtCategory.Clear();
            TxtStructure.Clear();
            TxtDefinition.Clear();
        }
    }
}
