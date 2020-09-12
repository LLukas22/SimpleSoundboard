using System;
using System.ComponentModel;
using SimpleSoundboard.Interfaces.Controller.Base;
using SimpleSoundboard.Interfaces.Views;

namespace SimpleSoundboard.Interfaces.Controller
{
	public interface IMainController : IController<IMainView>
	{
		void Save();
		void UpdateOutputDevice(int outputDevice, string value);
		void Play(Guid id);
		void Stop();
		void Edit(Guid id);
		void Add();
		void ChangeVolume(int outputDevice, float value);
		void OpenSettings();
		void OnClosing(CancelEventArgs cancelEventArgs);
		void Delete(Guid id);
	}
}