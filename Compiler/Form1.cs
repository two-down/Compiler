﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Compiler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt Files (.txt)|*.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    filePath = openFileDialog.FileName;
            }

            var fileName = "test.exe";

            try
            {
                var langCode = new NewLangCode(filePath);

                var errors = langCode.Compile(fileName);

                if (string.IsNullOrWhiteSpace(errors))
                    Process.Start($"{Application.StartupPath}/{fileName}");
                else
                    MessageBox.Show(errors);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
