﻿namespace RussiaSoccer2018App.Models
{
    public class Response
    {
		public bool IsSuccess
		{
			get;
			set;
		}

		public string Message
		{
			get;
			set;
		}

        public object Result
		{
			get;
			set;
		}
    }
}