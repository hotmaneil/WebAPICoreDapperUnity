using DataModel.SearchViewModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DataModel.Share
{
	/// <summary>
	/// 驗證結果
	/// </summary>
	public class VerityResult
	{
		/// <summary>
		/// 狀態代碼
		/// 參閱HttpStatusCode 列舉 
		/// https://docs.microsoft.com/zh-tw/dotnet/api/system.net.httpstatuscode?view=netframework-4.8
		/// 或是
		/// 自訂HttpStatusCode(CustomHttpStatusCode)
		/// </summary>
		public HttpStatusCode StatusCode { get; set; }

		/// <summary>
		/// 訊息
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// 資料結果
		/// </summary>
		public Object Payload { get; set; }

		/// <summary>
		/// 總筆數
		/// </summary>
		public PaginationViewModel Pagination { get; set; }

		/// <summary>
		/// Server回覆時間
		/// </summary>
		public DateTime ResponseTime { get; set; }

		public VerityResult()
		{
			Pagination = new PaginationViewModel();
			ResponseTime = DateTime.Now;
		}
	}
}
