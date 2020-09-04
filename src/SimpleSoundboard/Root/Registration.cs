using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSoundboard.Interfaces.Root.Base;
using SimpleSoundboard.Root.Base;
using SimpleSoundboard.Root.Registrations;
using Unity;

namespace SimpleSoundboard.Root
{
	public class Registration : AbstractBaseRegistration
	{
		public Registration(IUnityContainer container) : base(container)
		{
		}

		public override IRegistration Initialize()
		{
			new ModelRegistration(container).Register().Initialize();
			new ViewRegistration(container).Register().Initialize();
			new ControllerRegistration(container).Register().Initialize();
			return base.Initialize();
		}
	}
}
