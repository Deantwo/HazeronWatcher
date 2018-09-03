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
            {
                if (color.ToArgb() == watchGroup.GroupColor.ToArgb())
                {
                    cbbxColor.SelectedItem = color;
                    break;
                }
            }
            if (cbbxColor.SelectedIndex == -1)
                nudColor.Value = watchGroup.GroupColor.R + (watchGroup.GroupColor.G * 0x0100) + (watchGroup.GroupColor.B * 0x010000);
            chbxNotification.Checked = watchGroup.Notify;
            if (watchGroup.NotifySoundFile == null)
                cbbxSound.SelectedIndex = 0;
            else
            {
                foreach (object file in cbbxSound.Items)
                {
                    string filename = file.ToString();
                    if (filename == watchGroup.NotifySoundFile.Name)
                    {
                        cbbxSound.SelectedItem = file;
                        break;
                    }
                }
            }
            btnCreateSave.Text = "Save";
            tbxName_TextChanged(null, null);
        }

        private void Initialize()
        {
            InitializeComponent();
            // Add a list of all colors to the Color combobox.
            List<Color> colors = typeof(Color).GetProperties(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Public)
                                    .Select(c => (Color)c.GetValue(null, null))
                                    .ToList();
            foreach (Color color in colors)
                cbbxColor.Items.Add(color);
            // Add all sound files to the Sound combobox.
            cbbxSound.Items.Add(DEFAULT_SOUND);
            foreach (FileInfo soundFile in (new DirectoryInfo(_appdataFolder)).GetFiles("*.wav", SearchOption.TopDirectoryOnly))
                cbbxSound.Items.Add(soundFile);
        }

        private void cbbxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbxColor.SelectedIndex == -1)
                return;
            Color color = (Color)cbbxColor.SelectedItem;
            nudColor.ValueChanged -= nudColor_ValueChanged;
            nudColor.Value = color.R + (color.G * 0x0100) + (color.B * 0x010000);
            nudColor.ValueChanged += nudColor_ValueChanged;
            lblColorTest.ForeColor = color;
        }

        private void nudColor_ValueChanged(object sender, EventArgs e)
        {
            Color color = Color.FromArgb((int)(0xff000000 + (int)nudColor.Value));
            cbbxColor.SelectedIndexChanged -= cbbxColor_SelectedIndexChanged;
            cbbxColor.SelectedIndex = -1;
            cbbxColor.SelectedIndexChanged += cbbxColor_SelectedIndexChanged;
            lblColorTest.ForeColor = color;
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            // If empty, color red and disallow create/save button.
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
            watchGroup.GroupColor = lblColorTest.ForeColor;
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

        private void btnSound_Click(object sender, EventArgs e)
        {
            // Get sound file.
            FileInfo soundFile = cbbxSound.SelectedItem as FileInfo;
            if (soundFile == null)
                soundFile = new FileInfo(Path.Combine(_appdataFolder, "Notification.wav"));
            // Play the sound.
            if (soundFile != null && soundFile.Exists)
                using (System.Media.SoundPlayer notificationSound = new System.Media.SoundPlayer(soundFile.FullName))
                    notificationSound.Play();
            else
            {
                using (System.IO.Stream s = HazeronWatcher.Properties.Resources.communi2)
                {
                    System.Media.SoundPlayer notificationSound = new System.Media.SoundPlayer(s);
                    notificationSound.Play();
                }
            }
        }
    }
}
