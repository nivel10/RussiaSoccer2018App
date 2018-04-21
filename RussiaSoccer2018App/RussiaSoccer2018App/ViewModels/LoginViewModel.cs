namespace RussiaSoccer2018App.ViewModels
{
	using System;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;

    public class LoginViewModel
    {
		#region Attributes

		private string email;
		private string password;
		private bool isEnabled;
		private bool isRunning;
		private bool isRemembered;

		#endregion Attributes

		#region Properties

		public string Email
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}

		public bool IsEnabled
		{
			get;
			set;
		}

		public bool IsRunning
		{
			get;
			set;
		}

		public bool IsRemembered
		{
			get;
			set;
		}

		#region Commands

		public ICommand ForgotPasswordCommand
		{
			get
			{
				return new RelayCommand(ForgotPassword);
			}
		}

		public ICommand LoginFacebookCommand
		{
			get
			{
				return new RelayCommand(LoginFacebook);
			}
		}

		public ICommand LoginInstagramCommand
		{
			get
			{
				return new RelayCommand(LoginInstagram);
			}
		}

		public ICommand LoginTwitterCommand
		{
			get
			{
				return new RelayCommand(LoginTwitter);
			}
		}

		#endregion Commands

		#endregion Properties

		#region Constructor

		public LoginViewModel()
		{
			//  Asigna el estatus a los controles
			SetStatusControls(true, true, false);
		}

		#endregion Constructor

		#region  Methods

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

		#endregion Methods
	}
}
