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
                for (int j = 0; j < columns; j++)
                {
                    // Adds "-" to every position.
                    WikiArray[i, j] = "-";
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
                int selectedItem = WikiList.SelectedIndices[0];
                // Makes sure an item is selected.
                if (selectedItem > -1)
                {
                    // Changes data in the 4 columns of the selected items row to the data in the 4 main textboxes.
                    WikiArray[selectedItem, 0] = TxtName.Text;
                    WikiArray[selectedItem, 1] = TxtCategory.Text;
                    WikiArray[selectedItem, 2] = TxtStructure.Text;
                    WikiArray[selectedItem, 3] = TxtDefinition.Text;
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
            // Assings int "SelectedItem" to the index of the selected item.
            int selectedItem = WikiList.SelectedIndices[0];
            // If there is an item selected:
            if (selectedItem > -1)
            {
                // Displays the data in each column of the selected row into the 4 main textboxes.
                TxtName.Text = WikiArray[selectedItem, 0];
                TxtCategory.Text = WikiArray[selectedItem, 1];
                TxtStructure.Text = WikiArray[selectedItem, 2];
                TxtDefinition.Text = WikiArray[selectedItem, 3];
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
        /// Responsible for the display of the data in the array to the list view box.
        /// </summary>
        private void ArrayData()
        {
            // Clears items in the list view box.
            WikiList.Items.Clear();
            // Loops through the rows in the array.
            for (int i = 0; i < rows; i++)
            {
                // Creates new ListViewItem with the value of the current row of the 0 column.
                ListViewItem lstItem = new ListViewItem(WikiArray[i, 0]);
                // Adds SubItems for the current row in the other columns.
                lstItem.SubItems.Add(WikiArray[i, 1]);
                lstItem.SubItems.Add(WikiArray[i, 2]);
                lstItem.SubItems.Add(WikiArray[i, 3]);
                // Adds the item and subitems to the wikilist (list view box)
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
            int selectedItem = WikiList.SelectedIndices[0];
            if (selectedItem > -1)
            {
                for (int i = 0; i < columns; i++)
                {
                    WikiArray[selectedItem, i] = "-";
                }
            }
            BoxClear();
            BubbleSort();
        }
        #endregion
        #region Sort
        /// <summary>
        /// Method for sorting data in the array.
        /// </summary>
        private void BubbleSort()
        {
            /*
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
            }*/
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    if (WikiArray[j, 0] == "-" && WikiArray[j + 1, 0] != "-")
                    {
                        Swap(j, j + 1);
                    }
                    else if (WikiArray[j, 0] != "-" && WikiArray[j + 1, 0] != "-")
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
        /// <summary>
        /// Method used by the sort method to actually swap the data into the correct order.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
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
        /// <summary>
        /// Method responsible for saving the data in the array to a file.
        /// </summary>
        private void Save()
        {
            // Creates a new SaveFileDialog "sfd".
            SaveFileDialog sfd = new SaveFileDialog();
            // Sets the initial location the dialog opens in.
            sfd.InitialDirectory = Application.StartupPath;
            // Filters the dialog to .dat files.
            sfd.Filter = "Data Files|*.dat";
            // Sets the defualt name of the file to 'SaveFile' variable.
            sfd.FileName = SaveFile;
            // If ok is selected write the data to file:
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Use a binary writer to write data to the selected or created file.
                using (BinaryWriter write = new BinaryWriter(File.Open(sfd.FileName, FileMode.Create)))
                {
                    // Goes through each row.
                    for (int i = 0; i < rows; i++)
                    {
                        // Goes through each column.
                        for (int j = 0; j < columns; j++)
                        {
                            // Write the current data in the wiki array to the file.
                            write.Write(WikiArray[i, j]);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Loads data from a file into the array using an open file dialog.
        /// </summary>
        private void LoadFile()
        {
            // Creates a new OpenFileDialog "ofd"
            OpenFileDialog ofd = new OpenFileDialog();
            // Sets the initial location the ofd opens in.
            ofd.InitialDirectory = Application.StartupPath;
            // Filters the ofd to .dat files only.
            ofd.Filter = "Data Files|*.dat";
            // If ok is selected in the ofd:
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Uses a binary reader to read data from the opened file.
                using (BinaryReader read = new BinaryReader(File.Open(ofd.FileName, FileMode.Open)))
                {
                    // Goes through each row of the array.
                    for (int i = 0; i < rows; i++)
                    {
                        // Goes through each column of the array.
                        for (int j = 0; j < columns; j++)
                        {
                            // Reads data from the file and adds it to the array.
                            WikiArray[i, j] = read.ReadString();
                        }
                    }
                }
                // Goes through all the rows in the array starting at the last row.
                for (int i = rows - 1; i >= 0; i--)
                {
                    // Creates bool variabe "hasData" with value 'false'.
                    bool hasData = false;
                    // Goes through each column.
                    for (int j = 0; j < columns; j++)
                    {
                        // If current item isn't "-":
                        if (WikiArray[i, j] != "-")
                        {
                            // Sets hasData to true and breaks out of loop.
                            hasData = true;
                            break;
                        }
                    }
                    // If hasData is true:
                    if (hasData)
                    {
                        // Sets i to NextEmpty +1 and breaks out of loop.
                        NextEmpty = i + 1;
                        break;
                    }
                }
            }
            // Calls ArrayData method.
            ArrayData();
        }
        #endregion
    }
}