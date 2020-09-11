
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
		}

		public override void ApplyStyleManager()
		{
			this.VolumeSliderOutput1.WithStyleManager(ref styleManager);
			this.VolumeSliderOutput2.WithStyleManager(ref styleManager);
			base.ApplyStyleManager();
		}

		public BindingList<IAudioEntryModel> GridBindingSource
		{
			get => this.metroGrid1.DataSource as BindingList<IAudioEntryModel>;
			set => this.metroGrid1.DataSource = value;
		}

		public object OutputDevice1DataSource
		{
			get => this.metroComboBox__OutputDevice1.DataSource;
			set => this.metroComboBox__OutputDevice1.DataSource = value;

		}

		public object OutputDevice2DataSource
		{
			get => this.metroComboBox_OutputDevice2.DataSource;
			set => this.metroComboBox_OutputDevice2.DataSource = value;
		}

		public VolumeSlider VolumeSlider1 => this.VolumeSliderOutput1;
		public VolumeSlider VolumeSlider2 => this.VolumeSliderOutput2;

		protected override void Subscribe()
		{
			this.btn_Add.Click += (sender, args) => (controller as IMainController)?.Add();
			this.btn_Delete.Click += Btn_DeleteOnClick;
			this.btn_Play.Click += (sender, args) => (controller as IMainController)?.Play();
			this.btn_Save.Click += (sender, args) => (controller as IMainController)?.Save();
			this.btn_Settings.Click += (sender, args) => (controller as IMainController)?.OpenSettings();
			this.btn_Stop.Click += (sender, args) => (controller as IMainController)?.Stop();
			this.metroComboBox__OutputDevice1.SelectedValueChanged += (sender, args) =>
				(controller as IMainController)?.UpdateOutputDevice(0,
					(string)this.metroComboBox__OutputDevice1.SelectedValue);
			this.metroComboBox_OutputDevice2.SelectedValueChanged += (sender, args) =>
				(controller as IMainController)?.UpdateOutputDevice(1,
					(string) this.metroComboBox_OutputDevice2.SelectedValue);
			this.VolumeSliderOutput1.VolumeChanged += (sender, args) => (controller as IMainController)?.ChangeVolume(0, VolumeSliderOutput1.Volume);
			this.VolumeSliderOutput2.VolumeChanged += (sender, args) => (controller as IMainController)?.ChangeVolume(1, VolumeSliderOutput2.Volume);
			base.Subscribe();
		}

		public IMainView RefreshGrid(IEnumerable<IAudioEntryModel> audioEntries)
		{
			metroGrid1.AutoGenerateColumns = false;
			metroGrid1.Columns.Add("File", "File");
			metroGrid1.Columns.Add("Keys", "Keys");
			metroGrid1.Columns.Add("Volume", "Volume");
			metroGrid1.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
			metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			metroGrid1.ResetBindings();
			metroGrid1.Rows.Clear();

			foreach (var audioEntry in audioEntries)
			{
				metroGrid1.Rows.Add(Path.GetFileNameWithoutExtension(audioEntry.FilePath),
					audioEntry.KeyBinding.ToStringAdded(), audioEntry.Volume);
			}
			return this;
		}

		public IMainView SetStopButtonText(List<Keys> combo)
		{
			this.btn_Stop.Text = $@"Stop{Environment.NewLine}{combo.ToStringAdded()}";
			return this;
		}

		public IMainView SetOutputDevice1(string value)
		{
			SetComboBoxValue(this.metroComboBox__OutputDevice1, value);
			return this;
		}

		public IMainView SetOutputDevice2(string value)
		{
			SetComboBoxValue(this.metroComboBox_OutputDevice2, value);
			return this;
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

		public IMainView SetVolumeSliderValue(int outputDevice, float value)
		{
			if (outputDevice == 0)
			{
				this.VolumeSliderOutput1.Volume = value;
			}
			else
			{
				this.VolumeSliderOutput2.Volume = value;
			}
			return this;
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
