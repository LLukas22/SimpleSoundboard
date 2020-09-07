using SimpleSoundboard.Interfaces.Controller.Base;
using SimpleSoundboard.Interfaces.Views;

namespace SimpleSoundboard.Controller
{
	public interface IMainController : IController<IMainView>
	{
		void Save();
		void UpdateOutputDevice(int outputDevice, string value);
		void Play();
		void Stop();
		void ChangeVolume(int outputDevice, float value);
	}
}