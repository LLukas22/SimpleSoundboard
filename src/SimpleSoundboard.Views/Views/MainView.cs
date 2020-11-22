using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Controls;
using NAudio.Gui;
using SimpleSoundboard.Interfaces.Controller;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Views;
using SimpleSoundboard.Keyboard;
using SimpleSoundboard.NameService.NAudio;
using SimpleSoundboard.Views.Base;

namespace SimpleSoundboard.Views.Views
{
	public partial class MainView : BaseView, IMainView
	{
		public MainView(MetroStyleManager styleManager) : base(styleManager)
		{
			InitializeComponent();
			//Metro form is buggy and generates this wrong 
			this.MinimizeBox = true;
		}

		public override void ApplyStyleManager()
		{
			VolumeSliderOutput1.WithStyleManager(ref styleManager);
			VolumeSliderOutput2.WithStyleManager(ref styleManager);
			base.ApplyStyleManager();
		}

		public object OutputDevice1DataSource
		{
			get => metroComboBox__OutputDevice1.DataSource;
			set => metroComboBox__OutputDevice1.DataSource = value;
		}

		public object OutputDevice2DataSource
		{
			get => metroComboBox_OutputDevice2.DataSource;
			set => metroComboBox_OutputDevice2.DataSource = value;
		}

		public VolumeSlider VolumeSlider1 => VolumeSliderOutput1;
		public VolumeSlider VolumeSlider2 => VolumeSliderOutput2;

		public IMainView RefreshGrid(List<IAudioEntryModel> audioEntries)
		{
			InitializeGrid();
			metroGrid1.Rows.Clear();
			audioEntries.Sort((x, y) =>
			{
				if (x.KeyBinding.Count > y.KeyBinding.Count) return 1;
				if (x.KeyBinding.Count < y.KeyBinding.Count) return -1;
				for (var i = 0; i < x.KeyBinding.Count; i++)
				{
					var result = x.KeyBinding[i].CompareTo(y.KeyBinding[i]);
					if (result != 0) return result;
				}

				return 0;
			});
			foreach (var audioEntry in audioEntries)
				metroGrid1.Rows.Add(Path.GetFileNameWithoutExtension(audioEntry.FilePath),
					audioEntry.KeyBinding.ToStringAdded(), audioEntry.Volume, audioEntry.Id);
			return this;
		}

		public IMainView SetStopButtonText(List<Keys> combo)
		{
			btn_Stop.Text = $@"Stop{Environment.NewLine}{combo.ToStringAdded()}";
			return this;
		}

		public IMainView SetOutputDevice1(string value)
		{
			SetComboBoxValue(metroComboBox__OutputDevice1, value);
			return this;
		}

		public IMainView SetOutputDevice2(string value)
		{
			SetComboBoxValue(metroComboBox_OutputDevice2, value);
			return this;
		}

		public IMainView SetVolumeSliderValue(int outputDevice, float value)
		{
			if (outputDevice == 0)
				VolumeSliderOutput1.Volume = value;
			else
				VolumeSliderOutput2.Volume = value;
			return this;
		}

		private void InitializeGrid()
		{
			if (metroGrid1.ColumnCount > 0) return;
			metroGrid1.AutoGenerateColumns = false;
			metroGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			metroGrid1.Columns.Add("File", "File");
			metroGrid1.Columns.Add("Keys", "Keys");
			metroGrid1.Columns.Add("Volume", "Volume");
			metroGrid1.Columns.Add("Id", "Id");
			metroGrid1.Columns[3].Visible = false;
			metroGrid1.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
			metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			metroGrid1.ScrollBars = ScrollBars.None;
			metroGrid1.Refresh();
		}

		protected override void Subscribe()
		{
			btn_Add.Click += (sender, args) => (controller as IMainController)?.Add();
			btn_Delete.Click += (sender, args) =>
				(controller as IMainController)?.Delete(metroGrid1.SelectedRows.Count > 0
					? (Guid) metroGrid1.SelectedRows[0]?.Cells["Id"]?.Value
					: Guid.Empty);
			btn_Play.Click += (sender, args) => (controller as IMainController)?.Play(metroGrid1.SelectedRows.Count > 0
				? (Guid) metroGrid1.SelectedRows[0]?.Cells["Id"]?.Value
				: Guid.Empty);
			btn_Save.Click += (sender, args) => (controller as IMainController)?.Save();
			btn_Settings.Click += (sender, args) => (controller as IMainController)?.OpenSettings();
			btn_Stop.Click += (sender, args) => (controller as IMainController)?.Stop();
			metroComboBox__OutputDevice1.SelectedValueChanged += (sender, args) =>
				(controller as IMainController)?.UpdateOutputDevice(0,
					(string) metroComboBox__OutputDevice1.SelectedValue);
			metroComboBox_OutputDevice2.SelectedValueChanged += (sender, args) =>
				(controller as IMainController)?.UpdateOutputDevice(1,
					(string) metroComboBox_OutputDevice2.SelectedValue);
			VolumeSliderOutput1.VolumeChanged += (sender, args) =>
				(controller as IMainController)?.ChangeVolume(0, VolumeSliderOutput1.Volume);
			VolumeSliderOutput2.VolumeChanged += (sender, args) =>
				(controller as IMainController)?.ChangeVolume(1, VolumeSliderOutput2.Volume);
			metroGrid1.DoubleClick += (sender, args) =>
				(controller as IMainController)?.Edit(metroGrid1.SelectedRows.Count > 0
					? (Guid) metroGrid1.SelectedRows[0]?.Cells["Id"]?.Value
					: Guid.Empty);
			base.Subscribe();
		}

		private void SetComboBoxValue(MetroComboBox comboBox, string value)
		{
			var newIndex = comboBox.FindStringExact(value);
			if (newIndex != -1)
			{
				comboBox.SelectedIndex = newIndex;
			}
			else
			{
				newIndex = comboBox.FindStringExact(NAudioControllerConstants.NoneDevice);
				comboBox.SelectedIndex = newIndex;
			}
		}

		private void Btn_DeleteOnClick(object? sender, EventArgs e)
		{
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			(controller as IMainController)?.OnClosing(e);
		}
	}
}