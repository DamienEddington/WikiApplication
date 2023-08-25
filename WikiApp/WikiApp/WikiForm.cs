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
        readonly string SaveFile = "default.dat";

        /// <summary>
        /// On form load disables the Save button and calls StartUp and ArrayData methods.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Enables Save Button.
            BtnSave.Enabled = false;
            // Calls StartUp and ArrayData methods.
            StartUp();
            ArrayData();
        }
        /// <summary>
        /// Fills each position in the 2D array with "-".
        /// </summary>
        private void StartUp()
        {
            // Goes through all rows.
            for (int i = 0; i < rows; i++)
            {
                // Goes through all columns.
                for (int x = 0; x < columns; x++)
                {
                    // Adds "-" to every position.
                    WikiArray[i, x] = "-";
                }
            }
        }
        #region Button_Clicks
        /// <summary>
        /// Calls AddItem, BubbleSort and BoxClear methods.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Calls the "AddItem, BubbleSort and BoxClear" methods.
            AddItem();
            BubbleSort();
            BoxClear();
        }
        /// <summary>
        ///  Ensures an item is selected and calls the Delete method. Error message is displayed if there is no item selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDel_Click(object sender, EventArgs e)
        {
            // If an item is selected show message box.
            if (WikiList.SelectedItems.Count > 0)
            {
                // Creates a message box with yes and no options.
                DialogResult delRes = MessageBox.Show("Are you sure you want to delete the selected item?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                // If message box button yes is selected:
                if (delRes == DialogResult.Yes)
                {
                    // Call delete method.
                    Delete();
                }
            }
            // If no item selected:
            else
            {
                // Display messagebox error message.
                MessageBox.Show("Please select an item to delete.", "Error");
            }
        }
        /// <summary>
        /// Replaces data in the selected row with data in the textboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // Making sure an item is selected and all 4 main textboxes are filled.
            if (WikiList.SelectedItems.Count > 0 &&
                !string.IsNullOrEmpty(TxtName.Text) &&
                !string.IsNullOrEmpty(TxtCategory.Text) &&
                !string.IsNullOrEmpty(TxtStructure.Text) &&
                !string.IsNullOrEmpty(TxtDefinition.Text))
            {
                // Creates int SelectedItem and assigns it to value of the index of the selected item.
                int SelectedItem = WikiList.SelectedIndices[0];
                // Makes sure an item is selected.
                if (SelectedItem > -1)
                {
                    // Changes data in the 4 columns of the selected items row to the data in the 4 main textboxes.
                    WikiArray[SelectedItem, 0] = TxtName.Text;
                    WikiArray[SelectedItem, 1] = TxtCategory.Text;
                    WikiArray[SelectedItem, 2] = TxtStructure.Text;
                    WikiArray[SelectedItem, 3] = TxtDefinition.Text;
                }
            }
            // Displays an error if one condition is not met.
            else
            {
                MessageBox.Show("Please make sure all text boxes are filled and an item is selected.", "Error");
            }
            // Calls BoxClear and BubbleSort methods.
            BoxClear();
            BubbleSort();
        }
        /// <summary>
        /// On Clear button click calls BoxClear method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClear_Click(object sender, EventArgs e)
        {
            BoxClear();
        }
        /// <summary>
        /// On Save button click calls Save method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Calls Save methods.
            Save();
        }
        /// <summary>
        /// Displays the data in each column of the selected row into the 4 main textboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WikiList_Click(object sender, EventArgs e)
        {
            if (WikiList.SelectedItems.Count > 0)
            {
                int SelectedItem = WikiList.SelectedIndices[0];
                if (SelectedItem > -1)
                {
                    TxtName.Text = WikiArray[SelectedItem, 0];
                    TxtCategory.Text = WikiArray[SelectedItem, 1];
                    TxtStructure.Text = WikiArray[SelectedItem, 2];
                    TxtDefinition.Text = WikiArray[SelectedItem, 3];
                }
            }
        }
        /// <summary>
        /// Calls delete method when List View Item is double clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WikiList_DoubleClick(object sender, EventArgs e)
        {
            // Calls Delete method
            Delete();
        }
        /// <summary>
        /// Calls LoadFile method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            // Calls load file method.
            LoadFile();
        }
        #endregion
        #region Methods
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// Adds the data in the 4 main textboxes to the array and displays in the list view box. Enables the Save button.
        /// </summary>
        private void AddItem()
        {
            // Checks to make sure there is room in the array and all textboxes are filled.
            if (NextEmpty < WikiArray.Length &&
                !string.IsNullOrEmpty(TxtName.Text) &&
                !string.IsNullOrEmpty(TxtCategory.Text) &&
                !string.IsNullOrEmpty(TxtStructure.Text) &&
                !string.IsNullOrEmpty(TxtDefinition.Text))
            {
                try
                {
                    // Adds data from textboxes to all 4 colomn positions in the next empty row.
                    WikiArray[NextEmpty, 0] = TxtName.Text; 
                    WikiArray[NextEmpty, 1] = TxtCategory.Text;
                    WikiArray[NextEmpty, 2] = TxtStructure.Text;
                    WikiArray[NextEmpty, 3] = TxtDefinition.Text;
                    // Adds +1 to NextEmpty variable.
                    NextEmpty++;
                }
                catch
                {
                    // Error message for full array.
                    MessageBox.Show("Data was not added. Array is full.", "Error");
                }
            }
            else
            {
                // Error message for textbox missing data.
                MessageBox.Show("Data not added. Please ensure all textboxes are filled.");
            }
            // Enables the save button and refocuses on the name textbox for next data entry.
            BtnSave.Enabled = true;
            TxtName.Focus();
        }
        /// <summary>
        /// Clears all 4 main textboxes.
        /// </summary>
        private void BoxClear()
        {
            // Clears the 4 main textboxes.
            TxtName.Clear();
            TxtCategory.Clear();
            TxtStructure.Clear();
            TxtDefinition.Clear();
        }
        /// <summary>
        /// Changes items to "-" sorts the data and clears the textboxes.
        /// </summary>
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
        #endregion
        #region Sort
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
        #region SaveLoad
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
        private void LoadFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Application.StartupPath;
            ofd.Filter = "Data Files|*.dat";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (BinaryReader read = new BinaryReader(File.Open(ofd.FileName, FileMode.Open)))
                {
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            WikiArray[i, j] = read.ReadString();
                        }
                    }
                }
                for (int i = rows - 1; i >= 0; i--)
                {
                    bool hasData = false;
                    for (int j = 0; j < columns; j++)
                    {
                        if (WikiArray[i, j] != "-")
                        {
                            hasData = true;
                            break;
                        }
                    }
                    if (hasData)
                    {
                        NextEmpty = i + 1;
                        break;
                    }
                }
            }
            ArrayData();
        }
        #endregion
    }
}
