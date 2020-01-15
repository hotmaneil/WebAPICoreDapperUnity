namespace DataModel.SearchViewModel
{
	public class PageViewSearchModel
	{
		/// <summary>
		/// 分頁顯示筆數
		/// </summary>
		public int? PageSize { get; set; }

		/// <summary>
		/// 目前第幾頁
		/// </summary>
		public int? CurrentPage { get; set; }
	}
}
