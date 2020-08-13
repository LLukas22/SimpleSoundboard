using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MetroFramework;
using NAudio.Wave;
using Soundboard.Audio;
using Soundboard.Entities;
using Soundboard.Extensions;
using Soundboard.Jason;
using Soundboard.Keyboard;
using Soundboard.Presenters;
using Soundboard.Properties;
using Soundboard.Views;



namespace Soundboard
{
	public partial class MainView : BaseView
	{
		private readonly string AudioEntityListPath = @"AudioEntityList.json";
		private readonly string SettingsEntityPath = @"SettingsEntity.json";
		private readonly JasonController jasonController;
		private readonly KeyboardController keyboardController;
		public NAudioController nAudioController;
		private readonly NotifyIcon notifyIcon = new NotifyIcon();
		private int Outputdevice1;
		private int Outputdevice2;
		public SettingsEntity settingsEntity;
		private RawInput.RawInput rawInput;

		public MainView()
		{
			
			InitializeComponent();
			Resize += MainView_Resize;
			notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
			notifyIcon.Icon = Icon;

			nAudioController = new NAudioController(VolumeSlider, VolumeSlider2);

			rawInput = new RawInput.RawInput(this.Handle, false);

			keyboardController = new KeyboardController(nAudioController, rawInput);

			jasonController = new JasonController(AudioEntityListPath, SettingsEntityPath);

			Globals.entityList = jasonController.LoadAudioEntityList();
			settingsEntity = jasonController.LoadSettingsEntity();

			Stop.Text = "STOP\n" + CleanUpButtonName(settingsEntity.StopKeys.StopKey1,
				            settingsEntity.StopKeys.StopKey2);
			VolumeSlider.Volume = settingsEntity.Volumes.Volume1;
			VolumeSlider2.Volume = settingsEntity.Volumes.Volume2;
			VolumeSlider.BackColor = Color.Transparent;
			VolumeSlider2.BackColor = Color.Transparent;

			Outputdevice1 = settingsEntity.OutputDevices.OutputDevice1;
			Outputdevice2 = settingsEntity.OutputDevices.OutputDevice2;

			for (var n = -1; n < WaveOut.DeviceCount; n++)
			{
				var caps = WaveOut.GetCapabilities(n);
				if ($"{caps.ProductName}" == "Microsoft Soundmapper") Outputdevice1 = n;
				metroComboBox1.Items.Add($"{caps.ProductName}");
				metroComboBox2.Items.Add($"{caps.ProductName}");
			}

			metroComboBox1.Text = metroComboBox1.Items[Outputdevice1 + 1].ToString();
			metroComboBox2.Text = metroComboBox2.Items[Outputdevice2 + 1].ToString();

			Globals.styleManager.Style = settingsEntity.MetroColorStyle;
			Globals.styleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
			Globals.styleManager.Clone(this);
			VolumeSlider.TextBrush = new SolidBrush(Color.AntiqueWhite);
			VolumeSlider2.TextBrush = new SolidBrush(Color.AntiqueWhite);
			VolumeSlider.RectangleBrush = new SolidBrush(Globals.styleManager.Style.GetColorFromSkin());
			VolumeSlider2.RectangleBrush = new SolidBrush(Globals.styleManager.Style.GetColorFromSkin());
			VolumeSlider.Refresh();
			VolumeSlider2.Refresh();
			grid.ForeColor = Color.AntiqueWhite;
			ChangeIcon(Globals.styleManager.Style.GetColorFromSkin());
		}

		public void ChangeIcon(Color newColor)
		{
			var newBitmap = Resources.Note.ChangeWhiteToColor(newColor);
			Icon = Icon.FromHandle(newBitmap.GetHicon());
		}

		private void RefreshEntities()
		{
			foreach (var entity in Globals.entityList) entity.Refresh();
			settingsEntity.Refresh();
		}

		private void PopulateGrid()
		{
			grid.AutoGenerateColumns = false;
			grid.Columns.Add("File", "File");
			grid.Columns.Add("Keys", "Keys");
			grid.Columns.Add("Volume", "Volume");
			grid.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
			grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			RefreshGrid();
		}

		public void RefreshGrid()
		{
			grid.ResetBindings();
			FillColumns();
			grid.Refresh();
		}

		private void FillColumns()
		{
			((List<AudioFileEntity>) Globals.entityList).Sort((x, y) =>
			{
				var result = x.KeyBinding.FirstKey.CompareTo(y.KeyBinding.FirstKey);
				return result != 0 ? result : x.KeyBinding.SecondKey.CompareTo(y.KeyBinding.SecondKey);
			});

			grid.Rows.Clear();
			foreach (var entity in Globals.entityList)
			{
				grid.Rows.Add(Path.GetFileNameWithoutExtension(entity.PathToFile), CleanUpButtonName(
					entity.KeyBinding.FirstKey, entity.KeyBinding.SecondKey,
					entity.KeyBinding.ThirdKey), entity.Volume);
			}
			
		}

		private string CleanUpButtonName(Keys k1, Keys k2, Keys k3 = Keys.None)
		{
			var s = "";
			if (k3 == Keys.None && k2 == Keys.None)
				s = k1.ToString();
			else if (k3 == Keys.None)
				s = k1 + " + " + k2;
			else
				s = k1 + " + " + k2 + " + " + k3;
			return s;
		}

		private void NotifyIcon_DoubleClick(object sender, EventArgs e)
		{
			Show();
			WindowState = FormWindowState.Normal;
			Focus();
		}

		private void MainView_Resize(object sender, EventArgs e)
		{
			if (FormWindowState.Minimized == WindowState)
			{
				notifyIcon.Icon = Icon;
				notifyIcon.Visible = true;
				Hide();
			}
			else if (FormWindowState.Normal == WindowState)
			{
				notifyIcon.Visible = false;
			}
		}

		private void MetroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Outputdevice1 = metroComboBox1.SelectedIndex - 1;
			nAudioController.SetOutputDevices(Outputdevice1, Outputdevice2);
		}

		private void MetroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			Outputdevice2 = metroComboBox2.SelectedIndex - 1;
			nAudioController.SetOutputDevices(Outputdevice1, Outputdevice2);
		}

		private void OnVolumeSliderChanged(object sender, EventArgs e)
		{
			settingsEntity.Volumes = (VolumeSlider.Volume, settingsEntity.Volumes.Volume2);
			foreach (var volume in nAudioController.VolumeDelegates) volume.Item1?.Invoke(VolumeSlider.Volume);
		}

		private void OnVolumeSlider2Changed(object sender, EventArgs e)
		{
			settingsEntity.Volumes = (settingsEntity.Volumes.Volume1, VolumeSlider2.Volume);
			foreach (var v in nAudioController.VolumeDelegates) v.Item2?.Invoke(VolumeSlider2.Volume);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			RefreshEntities();
			PopulateGrid();
			keyboardController.Subscribe();
			keyboardController.Refresh(settingsEntity);
		}

		private void grid_DoubleClick(object sender, EventArgs e)
		{
			
			if (grid.SelectedRows.Count > 0 && grid.SelectedRows[0].Index < Globals.entityList.Count)
			{
				var editPresenter = new EditPresenter(keyboardController, settingsEntity, this);
				editPresenter.BindData(Globals.entityList.ElementAt(grid.SelectedRows[0].Index));
				editPresenter.Show();
			}
		
		}

		public override void Save()
		{
			RefreshEntities();
			settingsEntity.OutputDevices =(Outputdevice1, Outputdevice2);
			jasonController.Save(Globals.entityList, settingsEntity);
			base.Save();
		}

		#region Buttons

		private void btnPlay_Click(object sender, EventArgs e)
		{
			if (grid.SelectedRows.Count > 0 && grid.SelectedRows[0].Index < Globals.entityList.Count)
			{
				nAudioController.StartPlayback(Globals.entityList.ElementAt(grid.SelectedRows[0].Index));
			} 
			
			
		}

		private void Stop_Click_1(object sender, EventArgs e)
		{
			nAudioController.StopPlayback();
		}

		private void Add_Click(object sender, EventArgs e)
		{
			var editPresenter = new EditPresenter(keyboardController, settingsEntity, this);
			editPresenter.BindData(new AudioFileEntity());
			editPresenter.Show();
		}

		private void Settings_Click(object sender, EventArgs e)
		{
			var settingsPresenter = new SettingsPresenter(keyboardController, settingsEntity, this);
			settingsPresenter.Show();
			Stop.Text = "STOP\n" + CleanUpButtonName(settingsEntity.StopKeys.StopKey1,
				            settingsEntity.StopKeys.StopKey2);
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			Save();
			MetroMessageBox.Show(this, "File successfully saved", "Save", MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (grid.SelectedRows.Count > 0 && grid.SelectedRows[0].Index < Globals.entityList.Count)
			{
				Globals.entityList.RemoveAt(grid.SelectedRows[0].Index);
			}
			RefreshGrid();
			keyboardController.Refresh(settingsEntity);
		}

		private void DebugLabel_Click(object sender, EventArgs e)
		{
			var debugForm = new DebugForm(rawInput);
			debugForm.Show(this);
		}


		#endregion Buttons

		private void MainView_FormClosing(object sender, FormClosingEventArgs e)
		{
			Save();
		}
	}
}