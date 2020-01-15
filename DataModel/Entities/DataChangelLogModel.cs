using System;

namespace DataModel.Entities
{
	/// <summary>
	/// 資料異動日誌 Model
	/// </summary>
	public class DataChangelLogModel
	{
		/// <summary>
		/// 是否已被刪除
		/// </summary>
		public bool IsDeleted { get; set; }

		/// <summary>
		/// 建立者
		/// </summary>
		public string CreateUser { get; set; }

		/// <summary>
		/// 建立時間
		/// </summary>
		public DateTime CreateTime { get; set; }

		/// <summary>
		/// 異動者
		/// </summary>
		public string Modifier { get; set; }

		/// <summary>
		/// 異動時間
		/// </summary>
		public DateTime ModifyTime { get; set; }

		public DataChangelLogModel()
		{
			CreateUser = string.Empty;
			Modifier = string.Empty;
		}
	}
}
