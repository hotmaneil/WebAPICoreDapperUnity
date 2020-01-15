using IRepository.IRepositories;
using ServiceInterface;
using Sunstige.DataModels;
using System;
using System.Threading.Tasks;

namespace ServiceImpletment
{
	public class SystemUserManager: ISystemUserManager
	{
		private ISystemUserRepository _systemUserRepository;

		public SystemUserManager(ISystemUserRepository systemUserRepository)
		{
			_systemUserRepository = systemUserRepository;
		}

		#region User Data
		/// <summary>
		/// 根據 Id 取得資料
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		public async Task<SystemUser> Get(int Id)
		{
			try
			{
				SystemUser result = _systemUserRepository.Get(Id);
				return await Task.Run(() => result);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		#endregion
	}
}
