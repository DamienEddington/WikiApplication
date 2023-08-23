// Author: Damien Eddington (30042780)
// Title WikiApplication
// Date: 09/08/2023
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
        private readonly string[,] WikiArray = new string[rows, columns];
        string SaveFile = "default.dat";

        private void ArrayData()
        {
            WikiList.Items.Clear();
            for (int i = 0; i < rows; i++)
            {
                ListViewItem lstItem = new ListViewItem(WikiArray[i, 0]);
                lstItem.SubItems.Add(WikiArray[i, 1]);
                lstItem.SubItems.Add(WikiArray[i, 2]);
                lstItem.SubItems.Add(WikiArray[i, 3]);
                WikiList.Items.Add(lstItem);
            }
        }
        #region Button_Clicks
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddItem();
            ArrayData();
            BoxClear();
        }
        private void BtnDel_Click(object sender, EventArgs e)
        {
            DialogResult delRes = MessageBox.Show("Are you sure you want to delete the selected item?", "Are you sure?", MessageBoxButtons.YesNo);
            if (delRes == DialogResult.Yes)
            {
                Delete();
            }
            // Error trap for if no item selected
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (WikiList.SelectedItems.Count > 0 &&
                !string.IsNullOrEmpty(TxtName.Text) &&
                !string.IsNullOrEmpty(TxtCategory.Text) &&
                !string.IsNullOrEmpty(TxtStructure.Text) &&
                !string.IsNullOrEmpty(TxtDefinition.Text))
            {
                int SelectedItem = WikiList.SelectedIndices[0];
                if (SelectedItem > -1)
                {
                    WikiArray[SelectedItem, 0] = TxtName.Text;
                    WikiArray[SelectedItem, 1] = TxtCategory.Text;
                    WikiArray[SelectedItem, 2] = TxtStructure.Text;
                    WikiArray[SelectedItem, 3] = TxtDefinition.Text;
                }
            }
            else
            {
                // Error message (please select an item
            }
            BoxClear();
            ArrayData();
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            BoxClear();
        }
        #endregion
        #region Start
        private void Form1_Load(object sender, EventArgs e)
        {
            BtnSave.Enabled = false;
            StartUp();
            ArrayData();
        }

        private void StartUp()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int x = 0; x < columns; x++)
                {
                    WikiArray[i, x] = "-";
                }
            }
        }
        #endregion
        #region Methods
        private void AddItem()
        {

            if (NextEmpty < WikiArray.Length &&
                !string.IsNullOrEmpty(TxtName.Text) &&
                !string.IsNullOrEmpty(TxtCategory.Text) &&
                !string.IsNullOrEmpty(TxtStructure.Text) &&
                !string.IsNullOrEmpty(TxtDefinition.Text))
            {
                try
                {
                    WikiArray[NextEmpty, 0] = TxtName.Text;
                    WikiArray[NextEmpty, 1] = TxtCategory.Text;
                    WikiArray[NextEmpty, 2] = TxtStructure.Text;
                    WikiArray[NextEmpty, 3] = TxtDefinition.Text;
                    NextEmpty++;
                }
                catch
                {
                    MessageBox.Show("Data was not added. Array is full.");
                }
            }
            else
            {
                MessageBox.Show("Data not added.");
            }
            BtnSave.Enabled = true;
            TxtName.Focus();

        }
        private void BoxClear()
        {
            TxtName.Clear();
            TxtCategory.Clear();
            TxtStructure.Clear();
            TxtDefinition.Clear();
        }
        private void Delete()
        {
            int SelectedItem = WikiList.SelectedIndices[0];
            if (SelectedItem > -1)
            {
                WikiArray[SelectedItem, 0] = "-";
                WikiArray[SelectedItem, 1] = "-";
                WikiArray[SelectedItem, 2] = "-";
                WikiArray[SelectedItem, 3] = "-";
            }
            BoxClear();
            ArrayData();
        }

        private void BubbleSort()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows - 1; j++)
                {
                    if (string.Compare(WikiArray[i, 0], WikiArray[j, 0]) > 0)
                    {
                        Swap(i, j);
                    }
                }
            }
            ArrayData();
        }

        private void Swap(int x, int y)
        {
            string temp;
            temp = WikiArray[x, 0];
            WikiArray[x, 0] = WikiArray[y, 0];
            WikiArray[y, 0] = temp;
        }
        #endregion

        private void BtnTest_Click(object sender, EventArgs e)
        {
            BubbleSort();
        }
    }
}
