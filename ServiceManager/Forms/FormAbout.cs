using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Krypton.Toolkit;

namespace ServiceManager
{
    public class FormAbout : KryptonForm
    {
        private KryptonRichTextBox richTextBoxAbout;
        private KryptonButton buttonClose;

        public FormAbout()
        {
            InitializeForm();

            Icon appIcon = Utility.GetApplicationIcon();

            if (appIcon != null)
            {
                this.Icon = appIcon;
            }

            PopulateAboutText();
        }

        private void InitializeForm()
        {
            this.Text = "About Service Manager";
            this.ClientSize = new Size(500, 500);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            richTextBoxAbout = new KryptonRichTextBox();
            richTextBoxAbout.Dock = DockStyle.Fill;
            richTextBoxAbout.ReadOnly = true;

            buttonClose = new KryptonButton();
            buttonClose.Values.Text = "Close";
            buttonClose.Size = new Size(80, 25);
            buttonClose.Dock = DockStyle.Bottom;
            buttonClose.Click += (sender, e) => Close();

            this.Controls.Add(richTextBoxAbout);
            this.Controls.Add(buttonClose);
        }

        private void PopulateAboutText()
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0";

            string aboutText =
                $"Service Manager v{version}\r\n" +
                $"==========================================\r\n\r\n" +
                $"Author: Kevin Adams\r\n" +
                $"https://github.com/KevinAdams05/ServiceManager\r\n\r\n" +
                $"A Windows service management tool for monitoring and\r\n" +
                $"controlling services across multiple servers.\r\n\r\n" +
                $"Libraries\r\n" +
                $"------------------------------------------\r\n" +
                $"Krypton Suite Standard Toolkit v100.26.1.19\r\n" +
                $"  Copyright (c) 2017-2025, Krypton Suite\r\n" +
                $"  https://github.com/Krypton-Suite/Standard-Toolkit\r\n" +
                $"  License: BSD-3-Clause\r\n\r\n" +
                $"Newtonsoft.Json v13.0.3\r\n" +
                $"  Copyright (c) 2007 James Newton-King\r\n" +
                $"  https://github.com/JamesNK/Newtonsoft.Json\r\n" +
                $"  License: MIT\r\n\r\n" +
                $"System.ServiceProcess.ServiceController v9.0.4\r\n" +
                $"  Copyright (c) .NET Foundation and Contributors\r\n" +
                $"  License: MIT\r\n\r\n" +
                $"System.Management v9.0.4\r\n" +
                $"  Copyright (c) .NET Foundation and Contributors\r\n" +
                $"  License: MIT\r\n\r\n" +
                $"System.Configuration.ConfigurationManager v9.0.4\r\n" +
                $"  Copyright (c) .NET Foundation and Contributors\r\n" +
                $"  License: MIT\r\n\r\n" +
                $"Theme Palettes\r\n" +
                $"------------------------------------------\r\n" +
                $"72 palette themes from the Krypton-Suite Theme-Palettes\r\n" +
                $"community repository:\r\n" +
                $"  Copyright (c) 2020, Krypton Suite\r\n" +
                $"  https://github.com/Krypton-Suite/Theme-Palettes\r\n" +
                $"  License: BSD-3-Clause\r\n\r\n" +
                $"Theme Authors:\r\n" +
                $"  Krypton-Suite Contributors\r\n" +
                $"  Byte#7189 (Adobe CC Dark themes)\r\n\r\n" +
                $"Icons\r\n" +
                $"------------------------------------------\r\n" +
                $"Ravenna 3D Icon Set by Double-J Design\r\n" +
                $"  http://www.doublejdesign.co.uk\r\n" +
                $"  https://www.softicons.com/toolbar-icons/\r\n" +
                $"    ravenna-3d-icons-by-double-j-design\r\n" +
                $"  License: Creative Commons Attribution 3.0 Unported\r\n" +
                $"  https://creativecommons.org/licenses/by/3.0/\r\n\r\n" +
                $"Built with .NET 10 and Windows Forms\r\n";

            richTextBoxAbout.Text = aboutText;
        }
    }
}
