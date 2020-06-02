using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Brandlist_Export_Assistant_V2.Forms
{
    public partial class Alert : Form
    {
        private Stages Stage { get; set; }

        public Alert(string message, AlertType type, Stages stage)
        {
            InitializeComponent();

            this.Stage = stage;

            this.errorMessage.Text = WrapText(message, 40, false);

            switch (type)
            {
                case AlertType.Success:
                    this.BackColor = Color.SeaGreen;
                    break;
                case AlertType.Info:
                    this.BackColor = Color.Gray;
                    break;
                case AlertType.Warning:
                    this.BackColor = Color.Crimson;
                    break;
                case AlertType.Error:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public sealed override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
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

        public static void Show(string message, AlertType type, Stages stage)
        {
            new Alert(message, type, stage).ShowDialog();
        }

        public enum AlertType
        {
            Success, Info, Warning, Error
        }

        private void Alert_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            ShowAlert.Start();
        }

        private int interval = 0;

        private void ShowAlert_Tick(object sender, EventArgs e)
        {
            if (this.Top < 60)
            {
                this.Top += interval;
                interval += 2;
            } else
            {
                ShowAlert.Stop();
            }
        }

        private void CloseAlert_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.5;
            }
            else
            {
                this.Close();
            }
        }

        private void Panel1_Click(object sender, EventArgs e)
        {
            if (this.Stage == Stages.ProjectSettings)
            {
                this.Close();
            }
            else
            {
                this.CloseAlert.Start();
                Application.Restart();
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            if (this.Stage == Stages.ProjectSettings)
            {
                this.Close();
            }
            else
            {
                this.CloseAlert.Start();
                Application.Restart();
            }
        }
    }
}
