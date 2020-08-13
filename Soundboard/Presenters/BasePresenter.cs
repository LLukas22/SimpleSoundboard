using Soundboard.Entities;
using Soundboard.Interfaces;
using Soundboard.Keyboard;

namespace Soundboard.Presenters
{
	public class BasePresenter : IBasePresenter
	{
		protected KeyboardController keyboardController;
		protected MainView mainView;
		protected SettingsEntity settingsEntity;

		public BasePresenter(KeyboardController keyboardController, SettingsEntity settingsEntity, MainView mainView)
		{
			this.keyboardController = keyboardController;
			this.settingsEntity = settingsEntity;
			this.mainView = mainView;
		}

		public virtual void BindData(object entity)
		{
		}

		public virtual void Show()
		{
		}
	}
}