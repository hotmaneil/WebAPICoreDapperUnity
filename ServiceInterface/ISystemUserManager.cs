using DataModel.Dtos.SystemUser;
using DataModel.Share;
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

		#region MyRegion

		/// <summary>
		/// 新增或更新使用者
		/// </summary>
		/// <param name="InputModel"></param>
		/// <param name="UserId"></param>
		/// <returns></returns>
		Task<VerityResult> CreateOrUpdateUser(SystemUserModel InputModel, string UserId);
		#endregion
	}
}
