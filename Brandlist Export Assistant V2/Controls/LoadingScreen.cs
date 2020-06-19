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

        public void Show(Control form, Control currentControl, string buttonText)
        {
            this.Visible = true;

            uploadButton.Text = buttonText;

            if (form != currentControl)
            {
                form.Controls.Remove(currentControl);
            }
            
            form.Controls.Add(this);
            this.Visible = true;
        }

        public void Hide(Control form, Control currentControl)
        {
            if (form != currentControl)
            {
                //form.Controls.Add(currentControl);
            }

            form.Controls.Remove(this);
            this.Visible = false;
        }
    }
}
