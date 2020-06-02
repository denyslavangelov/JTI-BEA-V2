using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Brandlist_Export_Assistant_V2.Forms;
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
            uploadButton.Text = buttonText;

            if (form != currentControl)
            {
                currentControl.Visible = false;
            }
            
            form.Controls.Add(this);
        }

        public void Hide(Control form, Control currentControl)
        {
            if (form != currentControl)
            {
                currentControl.Visible = true;
            }

            form.Controls.Remove(this);
        }
    }
}
