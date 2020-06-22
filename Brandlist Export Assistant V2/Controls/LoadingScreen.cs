using System.Drawing;
using System.Windows.Forms;
using Guna.UI.WinForms;

namespace Brandlist_Export_Assistant_V2.Controls
{
    public partial class LoadingScreen : UserControl
    {
        public LoadingScreen()
        {
            InitializeComponent();

            Location = new Point(323, 115);
            Size = new Size(579, 524);

            LoadingButtonStylize(this.uploadButton);
        }

        private void LoadingButtonStylize(GunaButton button)
        {
            button.BorderColor = ColorTranslator.FromHtml("#3D4853");
            button.ForeColor = ColorTranslator.FromHtml("#3D4853");
            button.BorderSize = 4;

            button.BaseColor = Color.Transparent;
            button.OnHoverBaseColor = Color.Transparent;
            button.OnHoverBorderColor = ColorTranslator.FromHtml("#3D4853");
            button.OnHoverForeColor = ColorTranslator.FromHtml("#3D4853");
            button.OnHoverImage = null;
            button.Image = null;
            button.TextOffsetX = 25;
            button.TextAlign = HorizontalAlignment.Right;

            loadingBarImage.Visible = true;

            button.Text = @"LOADING";
        }

        public void Show(Control mainForm, Control currentControl, string buttonText)
        {
            uploadButton.Text = buttonText;

            if (mainForm != currentControl)
            {
                mainForm.Controls.Remove(currentControl);
            }

            mainForm.Controls.Add(this);
        }

        public void Hide(Control mainForm, Control currentControl)
        {
            if (mainForm != currentControl)
            {
                if (!mainForm.Controls.Contains(currentControl))
                {
                    mainForm.Controls.Add(currentControl);
                }
            }

            mainForm.Controls.Remove(this);
        }
    }
}
