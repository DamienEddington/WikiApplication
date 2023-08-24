// Author: Damien Eddington (30042780)
// Title WikiApplication
// Date: 09/08/2023
// Description:
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        #region Button_Clicks
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Calls the "AddItem, BubbleSort and BoxClear" methods.
            AddItem();
            BubbleSort();
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
            BubbleSort();
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            BoxClear();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
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
                    MessageBox.Show("Data was not added. Array is full.", "Error");
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
                for (int i = 0; i < columns; i++)
                {
                    WikiArray[SelectedItem, i] = "-";
                }
            }
            BoxClear();
            BubbleSort();
        }
        private void BubbleSort()
        {
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    if (WikiArray[j, 0] != "-" && WikiArray[j + 1, 0] != "-")
                    {
                        if (string.Compare(WikiArray[j, 0], WikiArray[j + 1, 0]) > 0)
                        {
                            Swap(j, j + 1);
                        }
                    }
                }
            }
            ArrayData();
        }

        private void Swap(int x, int y)
        {
            for (int i = 0; i < columns; i++)
            {
                string temp = WikiArray[x, i];
                WikiArray[x, i] = WikiArray[y, i];
                WikiArray[y, i] = temp;
            }
        }
        #endregion

        private void Save()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath;
            sfd.Filter = "Data Files|*.dat";
            sfd.FileName = SaveFile;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (BinaryWriter write = new BinaryWriter(File.Open(sfd.FileName, FileMode.Create)))
                {
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            write.Write(WikiArray[i, j]);
                        }
                    }
                }
            }
            
        }
    }
}
