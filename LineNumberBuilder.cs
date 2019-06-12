using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Notepad
{
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
}
