using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HazeronWatcher
{
    public partial class FormWatchGroup : Form
    {
#if DEBUG
        string _appdataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HazeronWatcherTest"); // %USERPROFILE%\AppData\Roaming\HazeronWatcherTest
#else
        string _appdataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HazeronWatcher"); // %USERPROFILE%\AppData\Roaming\HazeronWatcher
#endif

        public WatchGroup ReturnValue { get; protected set; }

        private const string DEFAULT_SOUND = "<default>";

        public FormWatchGroup()
        {
            Initialize();
            this.Text = string.Format("{0} - New", this.Text);
            cbbxColor.SelectedItem = Color.White;
            cbbxSound.SelectedIndex = 0;
            btnCreateSave.Text = "Create";
            tbxName_TextChanged(null, null);
        }
        public FormWatchGroup(WatchGroup watchGroup)
        {
            Initialize();
            this.Text = string.Format("{0} - Edit \"{1}\"", this.Text, watchGroup.Name);
            tbxName.Text = watchGroup.Name;
            foreach (Color color in cbbxColor.Items)
                if (color.ToArgb() == watchGroup.GroupColor.ToArgb())
                {
                    cbbxColor.SelectedItem = color;
                    break;
                }
            chbxNotification.Checked = watchGroup.Notify;
            if (watchGroup.NotifySoundFile == null)
                cbbxSound.SelectedIndex = 0;
            else 
                foreach (string file in cbbxSound.Items)
                    if (file == watchGroup.NotifySoundFile.FullName)
                    {
                        cbbxSound.SelectedItem = file;
                        break;
                    }
            btnCreateSave.Text = "Save";
            tbxName_TextChanged(null, null);
        }

        private void Initialize()
        {
            InitializeComponent();
            // Add a list of all colors to the Color combobox.
            foreach (Color color in typeof(Color).GetProperties(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Public)
                                    .Select(c => (Color)c.GetValue(null, null))
                                    .ToList())
                cbbxColor.Items.Add(color);
            // Add all sound files to the Sound combobox.
            cbbxSound.Items.Add(DEFAULT_SOUND);
            foreach (FileInfo soundFile in (new DirectoryInfo(_appdataFolder)).GetFiles("*.wav", SearchOption.TopDirectoryOnly))
                cbbxSound.Items.Add(soundFile);
        }

        private void cbbxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblColorTest.ForeColor = (Color)cbbxColor.SelectedItem;
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            if (tbxName.Text.Trim() == string.Empty)
            {
                btnCreateSave.Enabled = false;
                lblName.ForeColor = Color.DarkRed;
            }
            else
            {
                btnCreateSave.Enabled = true;
                lblName.ForeColor = Color.Black;
            }
        }

        private void btnCreateSave_Click(object sender, EventArgs e)
        {
            WatchGroup watchGroup = new WatchGroup();
            watchGroup.Name = tbxName.Text.Trim();
            watchGroup.GroupColor = (Color)cbbxColor.SelectedItem;
            watchGroup.Notify = chbxNotification.Checked;
            if ((cbbxSound.SelectedItem as string) == DEFAULT_SOUND)
                watchGroup.NotifySoundFile = null;
            else
                watchGroup.NotifySoundFile = (FileInfo)cbbxSound.SelectedItem;
            ReturnValue = watchGroup;

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
