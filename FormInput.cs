using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HazeronWatcher
{
    public partial class FormInput : Form
    {
        static public FormInput OpenInputWindow { set; get; }

        public string ReturnInput
        {
            get { return this.tbxInput.Text; }
        }

        public FormInput(string header, string info, string current = "", bool sensitive = false)
        {
            InitializeComponent();

            // Set the info label's text.
            lblInfo.Text = info;
            // Change the window's header text.
            this.Text = header;
            // Set the textbox's content.
            tbxInput.Text = current;

            // Try to make the window wider if the textbox's content is long.
            if (current.Length > 20)
                this.Width += (current.Length - 10) * 6;

            // If "sensitive" is true, the textbox will go into password mode.
            tbxInput.UseSystemPasswordChar = sensitive;

            // Set the position of the window to the center of the parent.
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void FormInput_Load(object sender, EventArgs e)
        {
            // Makes the textbox's content selected when the window opens.
            tbxInput.Select();
        }
    }
}
