using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Brandlist_Export_Assistant_V2.Classes;
using Brandlist_Export_Assistant_V2.Classes.Exports;
using Brandlist_Export_Assistant_V2.Enums;

namespace Brandlist_Export_Assistant_V2.Controls
{
    public partial class SuccessScreenControl : UserControl
    {
        private string FolderPath { get; }
        public SuccessScreenControl(string folderPath)
        {
            FolderPath = folderPath;

            InitializeComponent();

            Location = new Point(323, 115);
            Size = new Size(579, 524);

            if (ProjectSettings.Platform == Platform.iField)
            {
                successBodyText.Text = successBodyText.Text.Replace("imported", "exported");
            }
        }

        private void SuccessFolderButton_Click(object sender, EventArgs e)
        {
            Process.Start(FolderPath);
        }
    }
}
