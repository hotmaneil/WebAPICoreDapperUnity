namespace DataModel.Dtos.SystemUser
{
	/// <summary>
	/// 使用者輸入/輸出模型
	/// </summary>
	public class SystemUserModel
	{
		public int ID { get; set; }

		public string Code { get; set; }

		public string Name { get; set; }

		public string Password { get; set; }

		/// <summary>
		/// 是否已啟用
		/// </summary>
		public bool IsEnabled { get; set; }
	}
}
