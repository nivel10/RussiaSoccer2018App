namespace RussiaSoccer2018App.Services
{
	using System;
	using System.Collections.Generic;
	using System.Net.Http;
	using System.Net.Http.Headers;
	using System.Text;
	using System.Threading.Tasks;
	using Newtonsoft.Json;
	using Plugin.Connectivity;
	using RussiaSoccer2018App.Models;

	public class ApiService
	{
		/// <summary>
		/// Metodo que verifica la conexion y acceso a internet
		/// </summary>
		/// <returns>Objeto Response IsSuccess, Message, Result</returns>
		public async Task<Response> CheckConnection()
		{
			if (!CrossConnectivity.Current.IsConnected)
			{
				return new Response
				{
					IsSuccess = false,
					Message = "Plase turn on your internet settings...!!!",
					Result = null,
				};
			}

			var isRemoteReachable =
			    await CrossConnectivity.Current.IsRemoteReachable("google.com");
			if (!isRemoteReachable)
			{
				return new Response
				{
					IsSuccess = false,
					Message = "Please check your internet connection...!!!",
					Result = null,
				};
			}

			return new Response
			{
				IsSuccess = true,
				Message = "Connection to internet is ok...!!!",
				Result = null,
			};
		}

		public async Task<TokenResponse> GetToken(
    		string _userName,
    		string _userPassword,
    		string _urlBase)
		{
			try
			{
				var client = new HttpClient();
				client.BaseAddress = new Uri(_urlBase);
				var response = await client.PostAsync(
					"Token",
				    new StringContent(
				        string.Format(
				            "grant_type=password&username={0}&password={1}",
				            _userName,
				            _userPassword),
				        Encoding.UTF8,
				        "application/x-www-form-urlencoded"));

				var resulJson = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<TokenResponse>(resulJson);

				return result;
			}
			catch (Exception ex)
			{
				return new TokenResponse
				{
					ErrorDescription = ex.Message,
				};
			}
		}

		public async Task<Response> GetList<T>(
			string urlBase,
		    string servicePrefix,
		    string controller,
		    string tokenType,
		    string accessToken)
		{
			try
			{
				var client = new HttpClient();
				client.DefaultRequestHeaders.Authorization =
				new AuthenticationHeaderValue(tokenType, accessToken);
				client.BaseAddress = new Uri(urlBase);
				var url = string.Format("{0}{1}", servicePrefix, controller);
				var response = await client.GetAsync(url);
				var result = await response.Content.ReadAsStringAsync();

				if (!response.IsSuccessStatusCode)
				{
					return new Response
					{
						IsSuccess = false,
						Message = result,
					};
				}

				var list = JsonConvert.DeserializeObject<List<T>>(result);
				return new Response
				{
					IsSuccess = true,
					Message = "Ok",
					Result = list,
				};
			}
			catch (Exception ex)
			{
				return new Response
				{
					IsSuccess = false,
					Message = ex.Message,
				};
			}
		}
	}
}
