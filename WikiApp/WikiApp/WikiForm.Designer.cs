﻿namespace WikiApp
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
            this.BtnAdd = new System.Windows.Forms.Button();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.TxtCategory = new System.Windows.Forms.TextBox();
            this.LblName = new System.Windows.Forms.Label();
            this.LblCategory = new System.Windows.Forms.Label();
            this.BtnClear = new System.Windows.Forms.Button();
            this.LblStructure = new System.Windows.Forms.Label();
            this.LblDefinition = new System.Windows.Forms.Label();
            this.TxtStructure = new System.Windows.Forms.TextBox();
            this.WikiList = new System.Windows.Forms.ListView();
            this.ColName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TxtDefinition = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(12, 12);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(81, 47);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(100, 20);
            this.TxtName.TabIndex = 2;
            // 
            // TxtCategory
            // 
            this.TxtCategory.Location = new System.Drawing.Point(81, 73);
            this.TxtCategory.Name = "TxtCategory";
            this.TxtCategory.Size = new System.Drawing.Size(100, 20);
            this.TxtCategory.TabIndex = 3;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(30, 47);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(38, 13);
            this.LblName.TabIndex = 4;
            this.LblName.Text = "Name:";
            // 
            // LblCategory
            // 
            this.LblCategory.AutoSize = true;
            this.LblCategory.Location = new System.Drawing.Point(26, 73);
            this.LblCategory.Name = "LblCategory";
            this.LblCategory.Size = new System.Drawing.Size(52, 13);
            this.LblCategory.TabIndex = 5;
            this.LblCategory.Text = "Category:";
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(93, 12);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(75, 23);
            this.BtnClear.TabIndex = 6;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // LblStructure
            // 
            this.LblStructure.AutoSize = true;
            this.LblStructure.Location = new System.Drawing.Point(25, 102);
            this.LblStructure.Name = "LblStructure";
            this.LblStructure.Size = new System.Drawing.Size(53, 13);
            this.LblStructure.TabIndex = 7;
            this.LblStructure.Text = "Structure:";
            // 
            // LblDefinition
            // 
            this.LblDefinition.AutoSize = true;
            this.LblDefinition.Location = new System.Drawing.Point(24, 130);
            this.LblDefinition.Name = "LblDefinition";
            this.LblDefinition.Size = new System.Drawing.Size(54, 13);
            this.LblDefinition.TabIndex = 8;
            this.LblDefinition.Text = "Definition:";
            // 
            // TxtStructure
            // 
            this.TxtStructure.Location = new System.Drawing.Point(81, 99);
            this.TxtStructure.Name = "TxtStructure";
            this.TxtStructure.Size = new System.Drawing.Size(100, 20);
            this.TxtStructure.TabIndex = 9;
            // 
            // WikiList
            // 
            this.WikiList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColName,
            this.Category});
            this.WikiList.HideSelection = false;
            this.WikiList.Location = new System.Drawing.Point(290, 47);
            this.WikiList.Name = "WikiList";
            this.WikiList.Size = new System.Drawing.Size(164, 274);
            this.WikiList.TabIndex = 11;
            this.WikiList.UseCompatibleStateImageBehavior = false;
            this.WikiList.View = System.Windows.Forms.View.Details;
            // 
            // ColName
            // 
            this.ColName.Text = "Name";
            this.ColName.Width = 80;
            // 
            // Category
            // 
            this.Category.Text = "Category";
            this.Category.Width = 80;
            // 
            // TxtDefinition
            // 
            this.TxtDefinition.Location = new System.Drawing.Point(81, 127);
            this.TxtDefinition.Name = "TxtDefinition";
            this.TxtDefinition.Size = new System.Drawing.Size(184, 129);
            this.TxtDefinition.TabIndex = 12;
            this.TxtDefinition.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // WikiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtDefinition);
            this.Controls.Add(this.WikiList);
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
        private System.Windows.Forms.ListView WikiList;
        private System.Windows.Forms.RichTextBox TxtDefinition;
        private new System.Windows.Forms.ColumnHeader ColName;
        private System.Windows.Forms.ColumnHeader Category;
        private System.Windows.Forms.Button button1;
    }
}
