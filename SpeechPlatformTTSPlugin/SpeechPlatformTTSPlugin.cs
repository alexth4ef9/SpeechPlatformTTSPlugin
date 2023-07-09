// reference:\Program Files\Microsoft SDKs\Speech\v11.0\Assembly\Microsoft.Speech.dll
// reference:\Program Files\NAudio\NAudio.dll
// reference:\Program Files\NAudio\NAudio.Core.dll
// reference:\Program Files\NAudio\NAudio.WinMM.dll
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Speech.Synthesis;
using Advanced_Combat_Tracker;
using NAudio.Wave;

[assembly: AssemblyTitle("Speech Platform TTS Plugin")]
[assembly: AssemblyDescription("Using the Speech Platform Server for TTS output for Wine compatibility")]
[assembly: AssemblyCopyright("alexth4e9f")]
[assembly: AssemblyVersion("1.0.0.0")]

namespace SpeechPlatformTTSPlugin
{
    public partial class SpeechPlatformTTSPlugin : UserControl, IActPluginV1
    {
        #region Designer Code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblVoice = new System.Windows.Forms.Label();
            this.cmbVoice = new System.Windows.Forms.ComboBox();
            this.lblVolume = new System.Windows.Forms.Label();
            this.tbVolume = new System.Windows.Forms.TrackBar();
            this.lblRate = new System.Windows.Forms.Label();
            this.tbRate = new System.Windows.Forms.TrackBar();
            this.lblVolumeValue = new System.Windows.Forms.Label();
            this.lblRateValue = new System.Windows.Forms.Label();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRate)).BeginInit();
            this.SuspendLayout();
            //
            // tabControl1
            //
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(597, 347);
            this.tabControl1.TabIndex = 0;
            //
            // tabPage1
            //
            this.tabPage1.Controls.Add(this.lblRateValue);
            this.tabPage1.Controls.Add(this.lblVolumeValue);
            this.tabPage1.Controls.Add(this.tbRate);
            this.tabPage1.Controls.Add(this.lblRate);
            this.tabPage1.Controls.Add(this.tbVolume);
            this.tabPage1.Controls.Add(this.lblVolume);
            this.tabPage1.Controls.Add(this.cmbVoice);
            this.tabPage1.Controls.Add(this.lblVoice);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(589, 321);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            //
            // tabPage2
            //
            this.tabPage2.Controls.Add(this.lstLog);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(589, 321);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Logs";
            this.tabPage2.UseVisualStyleBackColor = true;
            //
            // lblVoice
            //
            this.lblVoice.AutoSize = true;
            this.lblVoice.Location = new System.Drawing.Point(6, 10);
            this.lblVoice.Name = "lblVoice";
            this.lblVoice.Size = new System.Drawing.Size(37, 13);
            this.lblVoice.TabIndex = 0;
            this.lblVoice.Text = "Voice:";
            //
            // cmbVoice
            //
            this.cmbVoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoice.FormattingEnabled = true;
            this.cmbVoice.Location = new System.Drawing.Point(88, 7);
            this.cmbVoice.Name = "cmbVoice";
            this.cmbVoice.Size = new System.Drawing.Size(396, 21);
            this.cmbVoice.TabIndex = 1;
            //
            // lblVolume
            //
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(6, 41);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(45, 13);
            this.lblVolume.TabIndex = 2;
            this.lblVolume.Text = "Volume:";
            //
            // tbVolume
            //
            this.tbVolume.LargeChange = 10;
            this.tbVolume.Location = new System.Drawing.Point(88, 41);
            this.tbVolume.Maximum = 100;
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(396, 45);
            this.tbVolume.SmallChange = 5;
            this.tbVolume.TabIndex = 3;
            this.tbVolume.TickFrequency = 5;
            this.tbVolume.Value = 100;
            this.tbVolume.Scroll += new System.EventHandler(this.tbVolume_Scroll);
            //
            // lblRate
            //
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(6, 105);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(33, 13);
            this.lblRate.TabIndex = 5;
            this.lblRate.Text = "Rate:";
            //
            // tbRate
            //
            this.tbRate.Location = new System.Drawing.Point(88, 105);
            this.tbRate.Minimum = -10;
            this.tbRate.Name = "tbRate";
            this.tbRate.Size = new System.Drawing.Size(396, 45);
            this.tbRate.TabIndex = 6;
            this.tbRate.Scroll += new System.EventHandler(this.tbRate_Scroll);
            //
            // lblVolumeValue
            //
            this.lblVolumeValue.AutoSize = true;
            this.lblVolumeValue.Location = new System.Drawing.Point(47, 73);
            this.lblVolumeValue.Name = "lblVolumeValue";
            this.lblVolumeValue.Size = new System.Drawing.Size(35, 13);
            this.lblVolumeValue.TabIndex = 4;
            this.lblVolumeValue.Text = "label1";
            //
            // lblRateValue
            //
            this.lblRateValue.AutoSize = true;
            this.lblRateValue.Location = new System.Drawing.Point(47, 137);
            this.lblRateValue.Name = "lblRateValue";
            this.lblRateValue.Size = new System.Drawing.Size(35, 13);
            this.lblRateValue.TabIndex = 7;
            this.lblRateValue.Text = "label1";
            //
            // lstLog
            //
            this.lstLog.FormattingEnabled = true;
            this.lstLog.Location = new System.Drawing.Point(3, 3);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(583, 316);
            this.lstLog.TabIndex = 0;
            //
            // SpeechPlatformTTSPlugin
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tabControl1);
            this.Name = "SpeechPlatformTTSPlugin";
            this.Size = new System.Drawing.Size(600, 350);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label lblVolume;
        private ComboBox cmbVoice;
        private Label lblVoice;
        private TrackBar tbRate;
        private Label lblRate;
        private TrackBar tbVolume;
        private Label lblRateValue;
        private Label lblVolumeValue;
        private ListBox lstLog;

        #endregion

        Label lblStatus;
        readonly string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\SpeechPlatformTTSPlugin.xml");
        SettingsSerializer xmlSettings;
        FormActMain.PlayTtsDelegate oldTtsEngine;
        FormActMain.PlaySoundDelegate oldSoundEngine;

        object playTtsLock = new object();
        readonly TimeSpan playTtsSeparationDiff = TimeSpan.FromMilliseconds(10);
        readonly TimeSpan playTtsSeparationSame = TimeSpan.FromMilliseconds(100);
        DateTime playTtsLastTimeStamp = DateTime.UtcNow;
        string playTtsLastText;

        public SpeechPlatformTTSPlugin()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            AssemblyName assemblyName = new AssemblyName(args.Name);
            if (assemblyName.Name == "Microsoft.Speech")
            {
                return Assembly.LoadFrom("\\Program Files\\Microsoft SDKs\\Speech\\v11.0\\Assembly\\Microsoft.Speech.dll");
            }
            else if(assemblyName.Name.StartsWith("NAudio"))
            {
                return Assembly.LoadFrom(Path.Combine("\\Program Files\\NAudio", assemblyName.Name + ".dll"));
            }
            return null;
        }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            lblStatus = pluginStatusText;
            lblStatus.Text = "Starting...";
            pluginScreenSpace.Controls.Add(this);
            oldTtsEngine = ActGlobals.oFormActMain.PlayTtsMethod;
            ActGlobals.oFormActMain.PlayTtsMethod = new FormActMain.PlayTtsDelegate(PlayTTS);
            oldSoundEngine = ActGlobals.oFormActMain.PlaySoundMethod;
            ActGlobals.oFormActMain.PlaySoundMethod = new FormActMain.PlaySoundDelegate(PlaySound);

            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                foreach (InstalledVoice voice in synth.GetInstalledVoices())
                {
                    VoiceInfo info = voice.VoiceInfo;
                    if (!string.IsNullOrEmpty(voice.VoiceInfo.Name))
                    {
                        cmbVoice.Items.Add(voice.VoiceInfo.Name);
                    }
                }
            }

            xmlSettings = new SettingsSerializer(this);
            LoadSettings();
            lblStatus.Text = "Plugin started...";
        }

        public void DeInitPlugin()
        {
            ActGlobals.oFormActMain.PlayTtsMethod = oldTtsEngine;
            ActGlobals.oFormActMain.PlaySoundMethod = oldSoundEngine;
            SaveSettings();
        }

        private void tbVolume_Scroll(object sender, EventArgs e)
        {
            lblVolumeValue.Text = tbVolume.Value.ToString();
        }

        private void tbRate_Scroll(object sender, EventArgs e)
        {
            lblRateValue.Text = tbRate.Value.ToString();
        }

        private void PlayTTS(string TtsString)
        {
            lock (playTtsLock)
            {
                if (playTtsLastText == TtsString)
                {
                    if (DateTime.UtcNow - playTtsLastTimeStamp < playTtsSeparationSame)
                    {
                        AddLog("Skipping repeated text: " + TtsString);
                        return;
                    }
                }
                else
                {
                    if (DateTime.UtcNow - playTtsLastTimeStamp < playTtsSeparationDiff)
                    {
                        Thread.Sleep(playTtsSeparationDiff);
                    }
                }
                playTtsLastTimeStamp = DateTime.UtcNow;
                playTtsLastText = TtsString;
            }

            string fileName;
            using (MD5 md5Hash = MD5.Create())
            {
                Guid guid = new Guid(md5Hash.ComputeHash(Encoding.UTF8.GetBytes(TtsString)));
                fileName = string.Format("{0}-sapi.wav", guid);
            }

            string text = Path.Combine(ActGlobals.oFormActMain.TemporaryFolder.FullName, fileName);
            if (File.Exists(text))
            {
                ActGlobals.oFormActMain.PlaySound(text);
                return;
            }

            using (SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer())
            {
                if (!string.IsNullOrEmpty(cmbVoice.Text))
                {
                    speechSynthesizer.SelectVoice(cmbVoice.Text);
                }
                speechSynthesizer.Volume = tbVolume.Value;
                speechSynthesizer.Rate = tbRate.Value;

                using (FileStream fileStream = new FileStream(text, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                {
                    fileStream.SetLength(0);
                    speechSynthesizer.SetOutputToWaveStream(fileStream);
                    speechSynthesizer.Speak(TtsString);
                    fileStream.Flush();
                }
            }
            ActGlobals.oFormActMain.PlaySound(text);
        }

        private void PlaySound(string WavFilePath, int VolumePercent)
        {
            WaveOutEvent outputDevice = new WaveOutEvent();
            AudioFileReader audioFile = new AudioFileReader(WavFilePath);
            outputDevice.Init(audioFile);
            outputDevice.Volume = (float)VolumePercent / 100.0f;
            outputDevice.Play();
        }

        void LoadSettings()
        {
            // Add any controls you want to save the state of
            xmlSettings.AddControlSetting(cmbVoice.Name, cmbVoice);
            xmlSettings.AddControlSetting(tbVolume.Name, tbVolume);
            xmlSettings.AddControlSetting(tbRate.Name, tbRate);
            if (File.Exists(settingsFile))
            {
                FileStream fs = new FileStream(settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlTextReader xReader = new XmlTextReader(fs);

                try
                {
                    while (xReader.Read())
                    {
                        if (xReader.NodeType == XmlNodeType.Element)
                        {
                            if (xReader.LocalName == "SettingsSerializer")
                            {
                                xmlSettings.ImportFromXml(xReader);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    AddLog("Error loading settings: " + ex.Message);
                }
                xReader.Close();
            }

            if (!cmbVoice.Items.Contains(cmbVoice.Text))
            {
                cmbVoice.SelectedIndex = -1;
                cmbVoice.ResetText();
            }

            lblVolumeValue.Text = tbVolume.Value.ToString();
            lblRateValue.Text = tbRate.Value.ToString();
        }

        void SaveSettings()
        {
            FileStream fs = new FileStream(settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8);
            xWriter.Formatting = Formatting.Indented;
            xWriter.Indentation = 1;
            xWriter.IndentChar = '\t';
            xWriter.WriteStartDocument(true);
            xWriter.WriteStartElement("Config");    // <Config>
            xWriter.WriteStartElement("SettingsSerializer");    // <Config><SettingsSerializer>
            xmlSettings.ExportToXml(xWriter);   // Fill the SettingsSerializer XML
            xWriter.WriteEndElement();  // </SettingsSerializer>
            xWriter.WriteEndElement();  // </Config>
            xWriter.WriteEndDocument(); // Tie up loose ends (shouldn't be any)
            xWriter.Flush();    // Flush the file buffer to disk
            xWriter.Close();
        }

        void AddLog(string logMessage)
        {
            lstLog.Items.Add(logMessage);
            while (lstLog.Items.Count > 100)
            {
                lstLog.Items.RemoveAt(0);
            }
        }
    }
}
