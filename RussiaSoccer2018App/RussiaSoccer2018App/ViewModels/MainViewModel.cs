//  CHEJ - this = regla de legibilidad, hace referencia a la propiedad interna de la case

namespace RussiaSoccer2018App.ViewModels
{
    public class MainViewModel
    {

        #region Properties

		public LoginViewModel Login
		{
			get;
			set;
		}

		#endregion Properties

		#region Constructor

		public MainViewModel()
		{
			//  Invoca una instancia de la clase Login
			this.Login = new LoginViewModel();
		}

        #endregion Constructor
    }
}
