using Microsoft.Extensions.Options;

namespace ConnectionFactory.Connection
{
	/// <summary>
	/// Dapper DB 連線設定
	/// </summary>
	public class DapperDBContextOptions : IOptions<DapperDBContextOptions>
	{
		/// <summary>
		/// 連線DB種類
		/// SQLServer=>MS-SQL
		/// MySQL
		/// </summary>
		public string ConnectionName { get; set; }

		/// <summary>
		/// 連線字串
		/// </summary>
		public string ConnectionString { get; set; }

		DapperDBContextOptions IOptions<DapperDBContextOptions>.Value
		{
			get { return this; }
		}
	}
}
