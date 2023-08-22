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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WikiApp
{
    public partial class WikiForm : Form
    {
        public WikiForm()
        {
            InitializeComponent();
        }
        static readonly int rows = 12;
        static readonly int columns = 4;
        int NextEmpty = 0;
        private readonly string[,] Array = new string[rows, columns];
        string SaveFile = "default.dat";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddItem();
            ArrayData();
            BoxClear();
        }
        private void ArrayData()
        {
            WikiList.Items.Clear();
            for (int i = 0; i < rows; i++)
            {
                ListViewItem lstItem = new ListViewItem(Array[i, 0]);
                lstItem.SubItems.Add(Array[i, 1]);
                lstItem.SubItems.Add(Array[i, 2]);
                lstItem.SubItems.Add(Array[i, 3]);
                WikiList.Items.Add(lstItem);
            }
        }
        private void AddItem()
        {

            if (NextEmpty < Array.GetLength(0) &&
                !string.IsNullOrEmpty(TxtName.Text) && 
                !string.IsNullOrEmpty(TxtCategory.Text) &&
                !string.IsNullOrEmpty(TxtStructure.Text) &&
                !string.IsNullOrEmpty(TxtDefinition.Text))
            {
                try
                {
                    Array[NextEmpty, 0] = TxtName.Text;
                    Array[NextEmpty, 1] = TxtCategory.Text;
                    Array[NextEmpty, 2] = TxtStructure.Text;
                    Array[NextEmpty, 3] = TxtDefinition.Text;
                    NextEmpty++;
                }
                catch
                {
                    MessageBox.Show("Data was not added");
                }
            }
            else
            {
                MessageBox.Show("Data not added");
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
