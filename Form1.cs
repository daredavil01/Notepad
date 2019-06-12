using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Notepad
{
     public partial class Form1 : Form
    {
        string str = "1" + " ";
        public static string FindText;
        public static string ReplaceText;
        public static Boolean Matchcase;
        public string Path = "";
        int x;
        private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mQuit;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem mUndo;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem mCut;
		private System.Windows.Forms.MenuItem mCopy;
		private System.Windows.Forms.MenuItem mPaste;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem mSelectAll;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem mLineNumbering;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox cbConvertToSpaces;
		private System.Windows.Forms.RichTextBox SourceMemo;
		private System.Windows.Forms.TextBox eLineNumberPadding;
		private System.Windows.Forms.TextBox eTabPadding;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button bAddLineNumbers;
   

        public Form1()
        {
            InitializeComponent();
        
            this.eTabPadding = new System.Windows.Forms.TextBox();
            this.eLineNumberPadding = new System.Windows.Forms.TextBox();
            this.cbConvertToSpaces = new System.Windows.Forms.CheckBox();
            this.bAddLineNumbers = new System.Windows.Forms.Button();
    
            // eTabPadding
            // 
            this.eTabPadding.Location = new System.Drawing.Point(504, 18);
            this.eTabPadding.Name = "eTabPadding";
            this.eTabPadding.Size = new System.Drawing.Size(40, 20);
            this.eTabPadding.TabIndex = 9;
            this.eTabPadding.Text = "4";
            // 
            
            // 
            // eLineNumberPadding
            // 
            this.eLineNumberPadding.Location = new System.Drawing.Point(144, 18);
            this.eLineNumberPadding.Name = "eLineNumberPadding";
            this.eLineNumberPadding.Size = new System.Drawing.Size(40, 20);
            this.eLineNumberPadding.TabIndex = 6;
            this.eLineNumberPadding.Text = "2";
           
            
            // cbConvertToSpaces
            // 
            this.cbConvertToSpaces.Location = new System.Drawing.Point(216, 20);
            this.cbConvertToSpaces.Name = "cbConvertToSpaces";
            this.cbConvertToSpaces.Size = new System.Drawing.Size(150, 16);
            this.cbConvertToSpaces.TabIndex = 4;
            this.cbConvertToSpaces.Text = "Convert Tabs to Spaces";
  

        }
        // String findWord;
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult dr = MessageBox.Show("Do you want to save the file", "save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr.Equals(DialogResult.Yes)) //Statement that execute when user click on yes button
            {
                string filename = sfd.FileName;
                String filter = "Text Files|*.txt|All Files|*.*";
                sfd.Filter = filter;
                sfd.Title = "Save";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    //Write all of the text in txtBox to the specified file

                    System.IO.File.WriteAllText(filename, richTextBox1.Text);
                }
                else
                {
                    //Return
                    return;
                }
            }
            else
            {
                richTextBox1.Clear();
            }
        }
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult dr = MessageBox.Show("Do you want to save the file", "save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //Declare open as a new OpenFileDailog
            OpenFileDialog open = new OpenFileDialog();
            //Set the Filename of the OpenFileDailog to nothing
            open.FileName = "";
            //Declare filename as a String equal to the OpenFileDialog's FileName
            String filename = open.FileName;
            //Declare filter as a String equal to our wanted OpenFileDialog Filter
            String filter = "Text Files|*.txt|All Files|*.*";
            //Set the OpenFileDialog's Filter to filter
            open.Filter = filter;
            //Set the title of the OpenFileDialog to Open
            open.Title = "Open";
            //Show the OpenFileDialog
            if (open.ShowDialog(this) == DialogResult.OK)
            {
                sfd.Filter = filter;
                sfd.Title = "Save";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    //Write all of the text in txtBox to the specified file
                    System.IO.File.WriteAllText(filename, richTextBox1.Text);
                }
                else
                {
                    //Return
                    return;
                }
            }
            else
            {
                //Return
                return;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* //Declare save as a new SaveFileDailog
             SaveFileDialog sw = new SaveFileDialog();
             //Declare filename as a String equal to the SaveFileDialog's FileName
             string filename = sw.FileName;
             //Declare filter as a String equal to our wanted SaveFileDialog Filter
             String filter = "Text Files|*.txt|All Files|*.*";
             //Set the SaveFileDialog's Filter to filter
             sw.Filter = filter;
             //Set the title of the SaveFileDialog to Save
             sw.Title = "Save";
             //Show the SaveFileDialog
             if (sw.ShowDialog(this) == DialogResult.OK)
             {
                 //Write all of the text in txtBox to the specified file
                 System.IO.File.WriteAllText(filename, richTextBox1.Text);
             }
             else
             {
                 //Return
                 return;
             }*/
            SaveFileDialog SFD = new SaveFileDialog();
            if (Path != "")
            {
                richTextBox1.SaveFile(Path);
            }

            else
            {

                SFD.Filter = "Text files (*.Txt)| *.txt";
                SFD.FileName = "";
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SaveFile(SFD.FileName, RichTextBoxStreamType.PlainText);
                    Path = SFD.FileName;
                }
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Declare save as a new SaveFileDailog

            SaveFileDialog sw = new SaveFileDialog();

            //Declare filename as a String equal to the SaveFileDialog's FileName

            string filename = sw.FileName;

            //Declare filter as a String equal to our wanted SaveFileDialog Filter

            String filter = "Text Files|*.txt|All Files|*.*";

            //Set the SaveFileDialog's Filter to filter

            sw.Filter = filter;

            //Set the title of the SaveFileDialog to Save

            sw.Title = "Save";

            //Show the SaveFileDialog

            if (sw.ShowDialog(this) == DialogResult.OK)
            {

                //Write all of the text in txtBox to the specified file



                System.IO.File.WriteAllText(filename, richTextBox1.Text);


            }

            else
            {

                //Return

                return;

            }
        }


        //Declare prntDoc as a new PrintDocument
        System.Drawing.Printing.PrintDocument prntDoc = new System.Drawing.Printing.PrintDocument();
        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Declare print as a new PrintDialog
            PrintDialog print = new PrintDialog();
            //Declare prntDoc_PrintPage as a new EventHandler for prntDoc's Print Page
            prntDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(prntDoc_PrintPage);
            //Set prntDoc to the PrintDialog's Document
            print.Document = prntDoc;
            //Show the PrintDialog
            if (print.ShowDialog(this) == DialogResult.OK)
            {
                //Print the Page
                prntDoc.Print();
            }
        }
        private void prntDoc_PrintPage(Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Declare g as Graphics equal to the PrintPageEventArgs Graphics
            Graphics g = e.Graphics;
            //Draw the Text in txtBox to the Document
            g.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, 0, 0);
        }
        private void PageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Declare preview as a new PrintPreviewDialog
            PrintPreviewDialog preview = new PrintPreviewDialog();
            //Declare prntDoc_PrintPage as a new EventHandler for prntDoc's Print Page
            prntDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(prntDoc_PrintPage);
            //Set the PrintPreview's Document equal to prntDoc
            preview.Document = prntDoc;
            //Show the PrintPreview Dialog
            if (preview.ShowDialog(this) == DialogResult.OK)
            {
                //Generate the PrintPreview
                prntDoc.Print();
            }
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //statement that execute on click of exit button   
            //and chekcing whether textbox modified or not if modified          
            //then prompt user to save or not          
            if (richTextBox1.Modified == true)
            {
                DialogResult dr = MessageBox.Show("Do you want to save the file before exiting", "unsaved file", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string filename = sfd.FileName;
                    String filter = "Text Files|*.txt|All Files|*.*";
                    sfd.Filter = filter;
                    sfd.Title = "Save";

                    if (sfd.ShowDialog(this) == DialogResult.OK)
                    {

                        //Write all of the text in txtBox to the specified file


                        System.IO.File.WriteAllText(filename, richTextBox1.Text);



                    }

                    else
                    {

                        //Return

                        return;

                    }
                }
                else
                {
                    richTextBox1.Modified = false;
                    Application.Exit();
                }
            }
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }



        private void FindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 F = new Form2();
            F.ShowDialog();
            if (FindText != "")
            {
                richTextBox1.Find(FindText);
            }
        }

        private void FindNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FindText != "")
            {
                if (Matchcase == true)
                    x = richTextBox1.Find(FindText, (x + 1), richTextBox1.Text.Length, RichTextBoxFinds.MatchCase);
                else
                    x = richTextBox1.Find(FindText, (x + 1), richTextBox1.Text.Length, RichTextBoxFinds.None);

            }
        }

        private void ReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            replace R = new replace();
            R.ShowDialog();

            richTextBox1.Find(FindText);
            if (richTextBox1.SelectedText != "")
                richTextBox1.SelectedText = ReplaceText;
        }

        private void GoToToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void TimeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = System.DateTime.Now.ToString();
        }

        private void WordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordToolStripMenuItem.Checked == false)
            {
                wordToolStripMenuItem.Checked = true;
                richTextBox1.WordWrap = true;
            }
            else
            {
                wordToolStripMenuItem.Checked = false;
                richTextBox1.WordWrap = false;
            }
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;
            fontDialog.ShowEffects = true;
            if (fontDialog.ShowDialog(this) == DialogResult.OK)
            {
                richTextBox1.ForeColor = fontDialog.Color;
                richTextBox1.Font = fontDialog.Font;
            }
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about a = new about();
            a.ShowDialog();
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

      
        
        
        private void InsertLineNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.ExecuteLineNumbering();

        }
        #region Perform line numbering...


        private void ExecuteLineNumbering()
        {
            if (this.richTextBox1.Text.Length > 0)
            {
                LineNumberBuilder builder = new LineNumberBuilder();

                // set LineNumberBuilder properties
                builder.Text = this.richTextBox1.Text;
                builder.LineNumberPaddingWidth = Convert.ToInt32(this.eLineNumberPadding.Text);
                builder.ConvertTabsToSpaces = this.cbConvertToSpaces.Checked;
                builder.TabToSpacesWidth = Convert.ToInt32(this.eTabPadding.Text);

                // execute line-numbering
                builder.ConvertText();

                // transfer converted text to SourceMemo
                this.richTextBox1.Text = builder.Text;
            }
        }
        public class LineNumberBuilder
        {
            private string inputText;
            private int lineNumberPaddingWidth;
            private bool convertTabsToSpaces;
            private int tabToSpacesWidth;


            public LineNumberBuilder()
            {
            }


            #region PROPERTIES... (getters & setters)

            public string Text
            {
                get
                {
                    return this.inputText;
                }
                set
                {
                    this.inputText = value;
                }
            }

            public int LineNumberPaddingWidth
            {
                get
                {
                    return this.lineNumberPaddingWidth;
                }
                set
                {
                    this.lineNumberPaddingWidth = value;
                }
            }

            public bool ConvertTabsToSpaces
            {
                get
                {
                    return this.convertTabsToSpaces;
                }
                set
                {
                    this.convertTabsToSpaces = value;
                }
            }

            public int TabToSpacesWidth
            {
                get
                {
                    return this.tabToSpacesWidth;
                }
                set
                {
                    this.tabToSpacesWidth = value;
                }
            }

            #endregion


            #region METHODS...

            #region Public methods...

            public void ConvertText()
            {
                // create new StringBuilder object to hold converted text
                StringBuilder output = new StringBuilder();

                try
                {
                    // Define delimiter to use in Split function, below
                    char[] end_of_line = { (char)10 };
                    // Convert Text property (string) into string array containing 1 line per array item
                    string[] lines = this.Text.Split(end_of_line);

                    // Count lines in memo textbox
                    int line_count = lines.GetUpperBound(0) + 1;
                    // Get length of line_count as a string - used in line number padding
                    int linenumber_max_width = line_count.ToString().Length;
                    // create string to hold "padding" after line number colon
                    string padding = new String(' ', this.LineNumberPaddingWidth);

                    // for each line in string[] lines
                    for (int i = 0; i < line_count; i++)
                    {
                        // Append current line number, with padding
                        output.Append(this.GetFormattedLineNumber(i + 1, linenumber_max_width, padding));
                        // Append actual line data
                        output.Append(lines[i]);
                        // add linefeed at end of each line
                        output.Append("\r\n");
                    }

                    // Convert tabs to spaces using user-specified TabToSpacesWidth
                    if (this.ConvertTabsToSpaces)
                    {
                        // create a string of spaces of length "TabToSpacesWidth" to replace any tab characters
                        string spaces = new String(' ', this.TabToSpacesWidth);
                        // replace tabs with spaces
                        output = output.Replace("\t", spaces);
                    }
                }
                catch (Exception e)
                {
                    output.Append(e.Message);
                }

                this.Text = output.ToString();
            }

            #endregion


            #region Private methods...

            private string GetFormattedLineNumber(int lineNumber, int maxNumberWidth, string padding)
            {
                StringBuilder line = new StringBuilder();
                // insert the line number with padding
                line.Append(lineNumber.ToString().PadLeft(maxNumberWidth, ' '));
                line.Append(":");
                // add padding after the line number (and colon)
                line.Append(padding);

                return line.ToString();
            }

            #endregion
            #endregion

        }

        #endregion
    }
}
