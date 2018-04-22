//  CHEJ - this = regla de legibilidad, hace referencia a la propiedad interna de la case

using RussiaSoccer2018App.Models;

namespace RussiaSoccer2018App.ViewModels
{
    public class MainViewModel
    {
		#region Attributes

		private static MainViewModel instance;

		#endregion Attributes

        #region Properties

		public LoginViewModel Login
		{
			get;
			set;
		}

        public TokenResponse Token
		{
			get;
			set;
		}

		#endregion Properties

		#region Constructor

		public MainViewModel()
		{
			//  Genera una instancia del Sigleton
			instance = this;

			//  Invoca una instancia de la clase Login
			this.Login = new LoginViewModel();
		}

        #endregion Constructor

		#region Methods

		public static MainViewModel GetInstance()
		{
			if (instance == null)
			{
				instance = new MainViewModel();
			}
			return instance;
		}

		#endregion Methods
    }
}