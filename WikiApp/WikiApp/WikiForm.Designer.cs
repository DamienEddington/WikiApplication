using System;

namespace WikiApp
{
    partial class WikiForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.TxtCategory = new System.Windows.Forms.TextBox();
            this.LblName = new System.Windows.Forms.Label();
            this.LblCategory = new System.Windows.Forms.Label();
            this.BtnClear = new System.Windows.Forms.Button();
            this.LblStructure = new System.Windows.Forms.Label();
            this.LblDefinition = new System.Windows.Forms.Label();
            this.TxtStructure = new System.Windows.Forms.TextBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TxtDefinition = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.BtnDel = new System.Windows.Forms.Button();
            this.WikiList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.StsStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.StsStripLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.StsStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(12, 11);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 4;
            this.BtnAdd.Text = "Add";
            this.toolTip1.SetToolTip(this.BtnAdd, "Add data to the array. Data will not be added if array is full.");
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(71, 44);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(100, 20);
            this.TxtName.TabIndex = 0;
            this.toolTip1.SetToolTip(this.TxtName, "Insert name of item here.");
            // 
            // TxtCategory
            // 
            this.TxtCategory.Location = new System.Drawing.Point(71, 73);
            this.TxtCategory.Name = "TxtCategory";
            this.TxtCategory.Size = new System.Drawing.Size(100, 20);
            this.TxtCategory.TabIndex = 1;
            this.toolTip1.SetToolTip(this.TxtCategory, "Insert category of item here.");
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(12, 47);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(38, 13);
            this.LblName.TabIndex = 5;
            this.LblName.Text = "Name:";
            // 
            // LblCategory
            // 
            this.LblCategory.AutoSize = true;
            this.LblCategory.Location = new System.Drawing.Point(12, 76);
            this.LblCategory.Name = "LblCategory";
            this.LblCategory.Size = new System.Drawing.Size(52, 13);
            this.LblCategory.TabIndex = 6;
            this.LblCategory.Text = "Category:";
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(177, 71);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(75, 23);
            this.BtnClear.TabIndex = 6;
            this.BtnClear.Text = "Clear";
            this.toolTip1.SetToolTip(this.BtnClear, "Clear Name, Category, Structure and Definition textboxes.");
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // LblStructure
            // 
            this.LblStructure.AutoSize = true;
            this.LblStructure.Location = new System.Drawing.Point(12, 102);
            this.LblStructure.Name = "LblStructure";
            this.LblStructure.Size = new System.Drawing.Size(53, 13);
            this.LblStructure.TabIndex = 7;
            this.LblStructure.Text = "Structure:";
            // 
            // LblDefinition
            // 
            this.LblDefinition.AutoSize = true;
            this.LblDefinition.Location = new System.Drawing.Point(12, 128);
            this.LblDefinition.Name = "LblDefinition";
            this.LblDefinition.Size = new System.Drawing.Size(54, 13);
            this.LblDefinition.TabIndex = 8;
            this.LblDefinition.Text = "Definition:";
            // 
            // TxtStructure
            // 
            this.TxtStructure.Location = new System.Drawing.Point(71, 99);
            this.TxtStructure.Name = "TxtStructure";
            this.TxtStructure.Size = new System.Drawing.Size(100, 20);
            this.TxtStructure.TabIndex = 2;
            this.toolTip1.SetToolTip(this.TxtStructure, "Insert structure of item here.");
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(177, 11);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 13;
            this.BtnSearch.Text = "Search";
            this.toolTip1.SetToolTip(this.BtnSearch, "Search for target input into textbox.");
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtDefinition
            // 
            this.TxtDefinition.Location = new System.Drawing.Point(71, 125);
            this.TxtDefinition.Multiline = true;
            this.TxtDefinition.Name = "TxtDefinition";
            this.TxtDefinition.Size = new System.Drawing.Size(181, 200);
            this.TxtDefinition.TabIndex = 3;
            this.toolTip1.SetToolTip(this.TxtDefinition, "Insert definition of item here.");
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(364, 331);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 15;
            this.BtnSave.Text = "Save";
            this.toolTip1.SetToolTip(this.BtnSave, "Save data into .dat files.");
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnLoad
            // 
            this.BtnLoad.Location = new System.Drawing.Point(283, 331);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(75, 23);
            this.BtnLoad.TabIndex = 16;
            this.BtnLoad.Text = "Load";
            this.toolTip1.SetToolTip(this.BtnLoad, "Load data into list box using .dat files.");
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // BtnDel
            // 
            this.BtnDel.Location = new System.Drawing.Point(177, 42);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(75, 23);
            this.BtnDel.TabIndex = 17;
            this.BtnDel.Text = "Delete";
            this.toolTip1.SetToolTip(this.BtnDel, "Delete current selected item in list view box.");
            this.BtnDel.UseVisualStyleBackColor = true;
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // WikiList
            // 
            this.WikiList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.WikiList.HideSelection = false;
            this.WikiList.Location = new System.Drawing.Point(258, 39);
            this.WikiList.Name = "WikiList";
            this.WikiList.Size = new System.Drawing.Size(181, 286);
            this.WikiList.TabIndex = 18;
            this.toolTip1.SetToolTip(this.WikiList, "Item display. Click item for more information. Double click item to delete.");
            this.WikiList.UseCompatibleStateImageBehavior = false;
            this.WikiList.View = System.Windows.Forms.View.Details;
            this.WikiList.Click += new System.EventHandler(this.WikiList_Click);
            this.WikiList.DoubleClick += new System.EventHandler(this.WikiList_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Category";
            this.columnHeader2.Width = 80;
            // 
            // TxtSearch
            // 
            this.TxtSearch.Location = new System.Drawing.Point(258, 13);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(181, 20);
            this.TxtSearch.TabIndex = 19;
            this.toolTip1.SetToolTip(this.TxtSearch, "Insert search target here.");
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(96, 11);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(75, 23);
            this.BtnEdit.TabIndex = 20;
            this.BtnEdit.Text = "Edit";
            this.toolTip1.SetToolTip(this.BtnEdit, "Edit a selected item in the list view box. Ensure item is selected then change da" +
        "ta in the 4 textboxes below. Then click edit.");
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // StsStrip
            // 
            this.StsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.StsStripLbl});
            this.StsStrip.Location = new System.Drawing.Point(0, 356);
            this.StsStrip.Name = "StsStrip";
            this.StsStrip.Size = new System.Drawing.Size(442, 22);
            this.StsStrip.TabIndex = 21;
            this.StsStrip.Text = "Status:";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // StsStripLbl
            // 
            this.StsStripLbl.Name = "StsStripLbl";
            this.StsStripLbl.Size = new System.Drawing.Size(0, 17);
            // 
            // WikiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 378);
            this.Controls.Add(this.StsStrip);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.WikiList);
            this.Controls.Add(this.BtnDel);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TxtDefinition);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.TxtStructure);
            this.Controls.Add(this.LblDefinition);
            this.Controls.Add(this.LblStructure);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.LblCategory);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.TxtCategory);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.BtnAdd);
            this.Name = "WikiForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.StsStrip.ResumeLayout(false);
            this.StsStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.TextBox TxtCategory;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label LblCategory;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Label LblStructure;
        private System.Windows.Forms.Label LblDefinition;
        private System.Windows.Forms.TextBox TxtStructure;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox TxtDefinition;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.ListView WikiList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip StsStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel StsStripLbl;
    }
}

