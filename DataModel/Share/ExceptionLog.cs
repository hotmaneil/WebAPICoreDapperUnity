using System;
using System.Net;

namespace DataModel.Share
{
	/// <summary>
	/// 例外錯誤Log
	/// </summary>
	public class ExceptionLog
	{
		/// <summary>
		/// 函數名稱
		/// </summary>
		public string FunctionName { get; set; }

		/// <summary>
		/// 輸入的參數
		/// </summary>
		public object Parameter { get; set; }

		/// <summary>
		/// 自訂錯誤狀態代碼
		/// 參閱HttpStatusCode 列舉 
		/// https://docs.microsoft.com/zh-tw/dotnet/api/system.net.httpstatuscode?view=netframework-4.8
		/// 或是
		/// 自訂HttpStatusCode(CustomHttpStatusCode)
		/// </summary>
		public HttpStatusCode StatusCode { get; set; }

		/// <summary>
		/// 例外訊息
		/// </summary>
		public object ExceptionMessage { get; set; }

		/// <summary>
		/// 回傳錯誤時間
		/// </summary>
		public DateTime ErrorTime { get; set; }

		public ExceptionLog()
		{
			ErrorTime = DateTime.Now;
		}
	}
}
