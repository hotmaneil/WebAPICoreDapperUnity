using Sunstige.DataModels;
using System.Threading.Tasks;

namespace ServiceInterface
{
	public interface ISystemUserManager
	{
		#region User Data
		/// <summary>
		/// 根據 Id 取得資料
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		Task<SystemUser> Get(int Id);
		#endregion
	}
}
