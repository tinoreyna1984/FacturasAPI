using System.Net;

namespace FacturasAPI.Models.DTOs.Response
{
	public class BaseResponse
	{
		public int? status_code { get; set; }
		public string? status_message { get; set; }
		public object? data { get; set; }


		/// <summary>
		///    This method can be used to generate the response object from the classes which are inherited from the BaseResponse class
		/// </summary>
		/// <param name="statusCode"></param>
		/// <param name="statusMessage"></param>
		/// <param name="data"></param>
		public void CreateResponse(HttpStatusCode statusCode, string statusMessage, Object data)
		{
			status_code = (int)statusCode;
			status_message = (string)statusMessage;
			this.data = data;
		}
	}
}
