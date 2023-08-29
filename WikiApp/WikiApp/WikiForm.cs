// Author: Damien Eddington (30042780)
// Title WikiApplication
// Date: 09/08/2023
// Description: 
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
        // Creates static readonly variables 'rows' and 'columns;.
        static readonly int rows = 12;
        static readonly int columns = 4;
        // Creates int NextEmpty with value of 0.
        int nextEmpty = 0;
        // Creates a 2D array using 'rows' and 'columns'.
        private readonly string[,] WikiArray = new string[rows, columns];
        // Creates readonly string 'saveFile'.
        readonly string saveFile = "default.dat";

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
                Delete();
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
                // Error message.
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
            // Calls BoxClear method.
            BoxClear();
            StsStripLbl.Text = "Textboxes cleared.";
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
            // Calls Delete method.
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
        /// <summary>
        /// Calls the search method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            // Calls the BinarySearch method.
            BinarySearch();
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
            // Creates int empRow equal to nextEmpty
            int empRow = nextEmpty;
            // Goes through rows in the column.
            for (int i = 0; i < rows; i++)
            {
                // Checks if the current row is empty using the IfEmpty method.
                if (IfEmpty(i))
                {
                    // Assigns empRow the value of I and breaks out of loop.
                    empRow = i;
                    break;
                }
            }
            // If all textboxes are not empty execute following code:
            if (!string.IsNullOrEmpty(TxtName.Text) &&
                !string.IsNullOrEmpty(TxtCategory.Text) &&
                !string.IsNullOrEmpty(TxtStructure.Text) &&
                !string.IsNullOrEmpty(TxtDefinition.Text))
            {
                try
                {
                    // Adds data from textboxes to all 4 colomn positions in the next empty row.
                    WikiArray[empRow, 0] = TxtName.Text; 
                    WikiArray[empRow, 1] = TxtCategory.Text;
                    WikiArray[empRow, 2] = TxtStructure.Text;
                    WikiArray[empRow, 3] = TxtDefinition.Text;
                    // Adds +1 to empRow
                    empRow++;
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
            StsStripLbl.Text = "Data added";
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
            // Creates a message box with yes and no options.
            DialogResult delRes = MessageBox.Show("Are you sure you want to delete the selected item?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            // If message box button yes is selected:
            if (delRes == DialogResult.Yes)
            {
                // Creates int selectedItem equal to the current item selected.
                int selectedItem = WikiList.SelectedIndices[0];
                // If there is an item selected:
                if (selectedItem > -1)
                {
                    // Go through all columns.
                    for (int i = 0; i < columns; i++)
                    {
                        // Change values in the row to "-"
                        WikiArray[selectedItem, i] = "-";
                    }
                }
            }
            // Calls the box clear and bubblesort methods.
            BoxClear();
            BubbleSort();
            // Changes status strip text.
            StsStripLbl.Text = "Item deleted";
        }
        /// <summary>
        /// Checks cells in a row to see if they are empty or not.
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private bool IfEmpty(int empRow)
        {
            // Loop through the columns in the row.
            for (int j = 0; j < columns; j++)
            {
                // Checks to see if the item/cell is empty or not ("-")
                if (WikiArray[empRow, j] != "-")
                {
                    // If its not empty return false. (Cell not empty)
                    return false;
                }
            }
            // Otherwise return true (Cell is empty)
            return true;
        }
        /// <summary>
        /// Searches through data in the array to find the data input to the search button text box.
        /// </summary>
        private void BinarySearch()
        {
            // Creates new streamwriter that writes to Debug.txt (append).
            StreamWriter textWriter = new StreamWriter("Debug.txt", true);
            // If textbox is not empty execute following code:
            if (!string.IsNullOrEmpty(BtnSearch.Text))
            {
                // Creates int 'firstItem' equal to -1
                int firstItem = -1;
                // Creates int 'lastItem' equal to nextEmpty variable
                int lastItem = nextEmpty;
                // Creates int 'foundPos' with value 0;
                int foundPos = 0;
                // Creates bool 'found' with value false.
                bool found = false;
                // Writes next search to debug.txt (for readability)
                textWriter.WriteLine("-----Next Search-----");
                // Writes the current target to debug.txt and output - debug.
                Trace.TraceInformation("Target: {0}", TxtSearch.Text);
                textWriter.WriteLine("Target: {0}", TxtSearch.Text);
                // While target is not found and lastItem and firstItem difference is great than 0 execute following:
                while (!found && !((lastItem - firstItem) <= 0))
                {
                    // Creates int 'mid' equal to the middle of the first and last items in current search.
                    int mid = (lastItem + firstItem) / 2;
                    // Writes min, max and mid to debug.txt and output - debug.
                    Trace.TraceInformation("Min: {0}, Max: {1}", firstItem, lastItem);
                    textWriter.WriteLine("Min: {0}, Max: {1}", firstItem, lastItem);
                    Trace.TraceInformation("Mid: " + mid);
                    textWriter.WriteLine("Mid: " + mid);
                    // Compares mid to text searched and if they are the same execute following:
                    if (string.Compare(WikiArray[mid, 0], TxtSearch.Text) == 0)
                    {
                        // Sets foundPos variable to mid variable value. Sets found to true and breaks out of loop.
                        foundPos = mid;
                        found = true;
                        break;
                    }
                    // Compare mid to text searched. If value is not the same execute following:
                    else if (string.Compare(WikiArray[mid, 0], TxtSearch.Text) < 0)
                    {
                        // Sets first item variable to value of mid variable + 1.
                        firstItem = mid + 1;
                    }
                    else
                    {
                        // Sets lastItem variable to value of mid variable.
                        lastItem = mid;
                    }
                }
                // If found = true:
                if (found)
                {
                    // Writes target found to debug.txt and output - debug.
                    Trace.TraceInformation("Target Found.");
                    textWriter.WriteLine("Target Found.");
                    // Messagebox and status strip for item found.
                    MessageBox.Show($"Item found at position {foundPos + 1}.", "Found");
                    StsStripLbl.Text = "Target Found";
                }
                else
                {
                    // Trace and textwriter for target not found.
                    Trace.TraceInformation("Target not found.");
                    textWriter.WriteLine("Target not found.");
                    // Messagebox and status strip for target not found.
                    MessageBox.Show("Item not found.", "Not found");
                    StsStripLbl.Text = "Target does not exist in array.";
                }
            }
            else
            {
                // Error message for empty textbox.
                MessageBox.Show("Text box empty.", "Error");
            }
            // Close textwriter.
            textWriter.Close();
        }
        #endregion
        #region Sort
        /// <summary>
        /// Method for sorting data in the array.
        /// </summary>
        private void BubbleSort()
        {
            // Goes through rows in the array in first column.
            for (int i = 0; i < rows - 1; i++)
            {
                // Loop for comparing items in the array.
                for (int j = 0; j < rows - i - 1; j++)
                {
                    // Check items to see if they are sorted, also ensures "-" are swapped with non "-" so they are swapped to the bottom.
                    if (WikiArray[j, 0] == "-" && WikiArray[j + 1, 0] != "-")
                    {
                        // Calls swap method.
                        Swap(j, j + 1);
                    }
                    // Checks for "-" if both items are not dashes execute following:
                    else if (WikiArray[j, 0] != "-" && WikiArray[j + 1, 0] != "-")
                    {
                        // Compares elements to see if they need to be swapped.
                        if (string.Compare(WikiArray[j, 0], WikiArray[j + 1, 0]) > 0)
                        {
                            // Calls swap method.
                            Swap(j, j + 1);
                        }
                    }
                }
            }
            // Calls the ArrayData method.
            ArrayData();
        }
        /// <summary>
        /// Method used by the sort method to actually swap the data into the correct order.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void Swap(int x, int y)
        {
            // Goes through each column in the array.
            for (int i = 0; i < columns; i++)
            {
                // Creates string 'temp' used to store item temporarily.
                string temp = WikiArray[x, i];
                // Swap values of 2 rows.
                WikiArray[x, i] = WikiArray[y, i];
                // Put item in temp into the second row.
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
            sfd.FileName = saveFile;
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
            // Changes status strip text.
            StsStripLbl.Text = "Data saved.";
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
                try
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
                }
                catch
                {
                    // Informs user there is missing data. Stops code crashing, missing data can still be edited.
                    MessageBox.Show("There is missing data.");
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
                    nextEmpty = i + 1;
                    break;
                }
                // Sets next empty to 0.
                nextEmpty = 0;
            }
            // Calls ArrayData method, enables the save button and changes status strip text.
            ArrayData();
            BtnSave.Enabled = true;
            StsStripLbl.Text = "Data loaded.";
        }
        #endregion
    }
}