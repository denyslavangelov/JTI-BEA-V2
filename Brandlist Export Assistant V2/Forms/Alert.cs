using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brandlist_Export_Assistant_V2.Forms
{
    public partial class Alert : Form
    {
        private Stages Stage { get; }

        public Alert(string message, Stages stage)
        {
            InitializeComponent();

            var x = (errorMessagePanel.Size.Width - errorMessage.Size.Width) / 2;
            errorMessage.Location = new Point(x, errorMessage.Location.Y);

            this.CenterToScreen();

            this.Stage = stage;
            this.errorMessage.Text = WrapText(message, 40, false);
        }

        public static string WrapText(string text, int width, bool overflow)
        {
            var result = new StringBuilder();

            var index = 0;
            var column = 0;

            while (index < text.Length)
            {
                var spaceIndex = text.IndexOfAny(new[] { ' ', '\t', '\r', '\n' }, index);

                if (spaceIndex == -1)
                {
                    break;
                }
                else if (spaceIndex == index)
                {
                    index++;
                }
                else
                {
                    AddWord(text.Substring(index, spaceIndex - index));
                    index = spaceIndex + 1;
                }
            }

            if (index < text.Length) AddWord(text.Substring(index));

            void AddWord(string word)
            {
                if (!overflow && word.Length > width)
                {
                    var wordIndex = 0;
                    while (wordIndex < word.Length)
                    {
                        var subWord = word.Substring(wordIndex, Math.Min(width, word.Length - wordIndex));
                        AddWord(subWord);
                        wordIndex += subWord.Length;
                    }
                }
                else
                {
                    if (column + word.Length >= width)
                    {
                        if (column > 0)
                        {
                            result.AppendLine();
                            column = 0;
                        }
                    }
                    else if (column > 0)
                    {
                        result.Append(" ");
                        column++;
                    }

                    result.Append(word);
                    column += word.Length;
                }
            }

            return result.ToString();
        }

        public static void Show(string message, Stages stage)
        {
            new Alert(message, stage).ShowDialog();
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            if (this.Stage == Stages.ProjectSettings || this.Stage == Stages.Import)
            {
                this.Hide();
            }
            else
            {
                Application.Restart();
            }

        }
    }
}
