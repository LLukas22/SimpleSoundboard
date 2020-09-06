
using System;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Controls;
using NAudio.Gui;
using SimpleSoundboard.Controller;
using SimpleSoundboard.Interfaces.Views;
using SimpleSoundboard.NameService.NAudio;
using SimpleSoundboard.Views.Base;

namespace SimpleSoundboard.Views.Views
{
	public partial class MainView : BaseView, IMainView
	{
		public MainView(MetroStyleManager styleManager) : base(styleManager)
		{
			InitializeComponent();
			this.VolumeSliderOutput1.WithStyleManager(ref styleManager);
			this.VolumeSliderOutput2.WithStyleManager(ref styleManager);
		}

		public BindingContext GridBindingContext
		{
			get => this.metroGrid1.BindingContext;
			set => this.metroGrid1.BindingContext = value;
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
			this.btn_Add.Click += Btn_AddOnClick;
			this.btn_Delete.Click += Btn_DeleteOnClick;
			this.btn_Play.Click += Btn_PlayOnClick;
			this.btn_Save.Click += Btn_SaveOnClick;
			this.btn_Settings.Click += Btn_SettingsOnClick;
			this.btn_Stop.Click += Btn_StopOnClick;
			this.metroComboBox__OutputDevice1.SelectedValueChanged += MetroComboBox__OutputDevice1OnSelectedValueChanged;
			this.metroComboBox_OutputDevice2.SelectedValueChanged += MetroComboBox_OutputDevice2OnSelectedValueChanged;
			base.Subscribe();
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

		private void MetroComboBox_OutputDevice2OnSelectedValueChanged(object? sender, EventArgs e)
		{
			(controller as IMainController)?.UpdateOutputDevice(1, (string)this.metroComboBox_OutputDevice2.SelectedValue);
		}

		private void MetroComboBox__OutputDevice1OnSelectedValueChanged(object? sender, EventArgs e)
		{
			(controller as IMainController)?.UpdateOutputDevice(0, (string)this.metroComboBox__OutputDevice1.SelectedValue);
		}

		private void Btn_StopOnClick(object? sender, EventArgs e)
		{
			(controller as IMainController)?.Stop();
		}

		private void Btn_SettingsOnClick(object? sender, EventArgs e)
		{
			
		}

		private void Btn_SaveOnClick(object? sender, EventArgs e)
		{
			(controller as IMainController)?.Save();
		}

		private void Btn_PlayOnClick(object? sender, EventArgs e)
		{
			(controller as IMainController)?.Play();
		}

		private void Btn_DeleteOnClick(object? sender, EventArgs e)
		{
			
		}

		private void Btn_AddOnClick(object? sender, EventArgs e)
		{
			
		}
	}
}
