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
    public enum FormInputOptions
    {
        None,
        Password,
        Multiline
    }

    public partial class FormInput : Form
    {

        public string ReturnInput
        {
            get { return this.tbxInput.Text; }
        }

        public FormInput(string header, string info, string current = "", FormInputOptions options = FormInputOptions.None)
        {
            InitializeComponent();

            // Set the info label's text.
            lblInfo.Text = info;
            // Change the window's header text.
            this.Text = header;
            // Set the textbox's content.
            tbxInput.Text = current;

            //// Make the window wider if the textbox's content is long.
            //if (current.Length > 33)
            //    this.Width += Math.Min((current.Split(new char[] { '\n' }).Max(x => x.Length) - 33) * 7, 1000);
            //// Try to make the window wider if the textbox's content is long.
            //this.Height += info.Count(x => x == '\n') * 9;

            // If "options" is set to "Password", the textbox will go into password mode.
            if (options == FormInputOptions.Password)
                tbxInput.UseSystemPasswordChar = true;

            // If "options" is set to "Multiline", the textbox will go into multiline mode.
            if (options == FormInputOptions.Multiline)
            {
                tbxInput.Multiline = true;
                tbxInput.ScrollBars = ScrollBars.Both;
                this.AcceptButton = null;
                this.Height += ((2 + Math.Min(current.Count(x => x == '\n'), 10)) * 12) + 6;
            }

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
