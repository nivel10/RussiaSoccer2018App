namespace RussiaSoccer2018App.ViewModels
{
	using System;
	using System.Windows.Input;
	using GalaSoft.MvvmLight.Command;
	using RussiaSoccer2018App.Helpers;
	using RussiaSoccer2018App.Services;

	public class LoginViewModel : BaseViewModel
	{
		#region Attributes

		private string email;
		private string password;
		private bool isEnabled;
		private bool isRunning;
		private bool isRemembered;

		#region Services

		private DialogService dialogService;
		private ApiService apiService;

		#endregion Services

		#endregion Attributes

		#region Properties

		public string Email
		{
			get { return this.email; }
			set { SetValue(ref this.email, value); }
		}

		public string Password
		{
			get { return this.password; }
			set { SetValue(ref this.password, value); }
		}

		public bool IsEnabled
		{
			get { return this.isEnabled; }
			set { SetValue(ref this.isEnabled, value); }
		}

		public bool IsRunning
		{
			get { return this.isRunning; }
			set { SetValue(ref this.isRunning, value); }
		}

		public bool IsRemembered
		{
			get { return this.isRemembered; }
			set { SetValue(ref this.isRemembered, value); }
		}

		#region Commands

		public ICommand ForgotPasswordCommand => new RelayCommand(ForgotPassword);
		public ICommand LoginCommand => new RelayCommand(Login);
		public ICommand LoginFacebookCommand => new RelayCommand(LoginFacebook);
		public ICommand LoginInstagramCommand => new RelayCommand(LoginInstagram);
		public ICommand LoginTwitterCommand => new RelayCommand(LoginTwitter);

		//public ICommand ForgotPasswordCommand
		//{
		//	get
		//	{
		//		return new RelayCommand(ForgotPassword);
		//	}
		//}
        
		//public ICommand LoginCommand
		//{
		//	get
		//	{
		//		return new RelayCommand(Login);
		//	}
		//}

		//public ICommand LoginFacebookCommand
		//{
		//	get
		//	{
		//		return new RelayCommand(LoginFacebook);
		//	}
		//}

		//public ICommand LoginInstagramCommand
		//{
		//	get
		//	{
		//		return new RelayCommand(LoginInstagram);
		//	}
		//}

		//public ICommand LoginTwitterCommand
		//{
		//	get
		//	{
		//		return new RelayCommand(LoginTwitter);
		//	}
		//}

		#endregion Commands

		#endregion Properties

		#region Constructor

		public LoginViewModel()
		{
			//  Instancia los servicios
			dialogService = new DialogService();
			apiService = new ApiService();

			//  Asigna el estatus a los controles
			SetStatusControls(true, true, false);
			SetInitialize();
		}

		#endregion Constructor

		#region  Methods

		private async void Login()
		{
			//  Valida los controles del formulario
			if (string.IsNullOrEmpty(this.Email))
			{
				await dialogService.ShowMessage(
					"Error",
					"You must enter an email...!!!",
					"Accept");
				return;
			}

			if (!MethodsHelper.IsValidEmail(this.Email))
			{
				await dialogService.ShowMessage(
					"Error",
					"You must enter a valid email...!!!",
					"Accept");
				return;
			}

			if (string.IsNullOrEmpty(this.Password))
			{
				await dialogService.ShowMessage(
					"Error",
					"You must entar a password...!!!",
					"Accept");
				return;
			}

			//  Actualiza el estatus de los controles
			SetStatusControls(true, true, true);

			var response = await apiService.CheckConnection();
			if (!response.IsSuccess)
			{
				//  Actualiza el estatus de los controles
				SetStatusControls(true, true, false);

				await dialogService.ShowMessage(
					"Error",
					response.Message,
					"Accept");
				return;
			}

			//  Optine el Token
			var token = await apiService.GetToken(
				this.Email,
				this.Password,
				MethodsHelper.GetUrlAPI());

			if (token != null &&
			   !string.IsNullOrEmpty(token.ErrorDescription))
			{
				//  Actualiza el estatus de los controles
				SetStatusControls(true, true, false);
				await dialogService.ShowMessage(
					"Error",
					token.ErrorDescription,
					"Accept");
				return;
			}

			//  Actualiza el estatus de los controles
			SetStatusControls(true, true, false);
			SetInitialize();

			//  Octiene una instancia del Token (MainViewModel)
			MainViewModel.GetInstance().Token = token;
		}

		private void LoginInstagram()
		{
			throw new NotImplementedException();
		}

		private void LoginTwitter()
		{
			throw new NotImplementedException();
		}

		private void ForgotPassword()
		{
			throw new NotImplementedException();
		}

		private void LoginFacebook()
		{
			throw new NotImplementedException();
		}

		private void SetStatusControls(
			bool _isEnabled,
			bool _isRemembered,
			bool _isRunning)
		{
			this.IsEnabled = _isEnabled;
			this.IsRemembered = _isRemembered;
			this.IsRunning = _isRunning;
		}

		private void SetInitialize()
		{
			this.Email = "";
			this.Password = "";
		}

		#endregion Methods
	}
}
