using DataModel.Dtos.SystemUser;
using DataModel.Share;
using IRepository;
using IRepository.IRepositories;
using ServiceInterface;
using Sunstige.DataModels;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ServiceImpletment
{
	public class SystemUserManager: ISystemUserManager
	{
		private ISystemUserRepository _systemUserRepository;
		private IDapperUnitOfWorkFactory _dapperUnitOfWorkFactory;

		public SystemUserManager(ISystemUserRepository systemUserRepository, IDapperUnitOfWorkFactory dapperUnitOfWorkFactory)
		{
			_systemUserRepository = systemUserRepository;
			_dapperUnitOfWorkFactory = dapperUnitOfWorkFactory;
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

		#region User CRUD
		/// <summary>
		/// 新增或更新使用者
		/// </summary>
		/// <param name="InputModel"></param>
		/// <param name="UserId"></param>
		/// <returns></returns>
		public async Task<VerityResult> CreateOrUpdateUser(SystemUserModel InputModel, string UserId)
		{
			VerityResult result = new VerityResult();

			try
			{
				SystemUser actionItem = new SystemUser();

				if (InputModel.ID == 0)
				{
					actionItem.Code = InputModel.Code;
					actionItem.Name = InputModel.Name;
					actionItem.Password = "xxx";
					actionItem.Token = " ";
					actionItem.CreateUser = UserId;
					actionItem.CreateTime = DateTime.Now;
					actionItem.Modifier = UserId;
					actionItem.ModifyTime = DateTime.Now;

					using (var uow = _dapperUnitOfWorkFactory.Create())
					{
						_systemUserRepository.Add(actionItem);
						uow.SaveChanges();
					}

					if (result.StatusCode != HttpStatusCode.InternalServerError)
					{
						
						result.StatusCode = HttpStatusCode.OK;
						result.Message = "CreateSuccess";// string.Format(ResourceMessage.CreateSuccess, "SystemUser");
					}
				}
				else
				{
					var existUser = _systemUserRepository.Get(InputModel.ID);

					if (existUser == null)
					{
						result.StatusCode = HttpStatusCode.NotFound;
						result.Message = "NotExistedData";// string.Format(ResourceMessage.NotExistedData, InputModel.ID);
					}
					else
					{
						existUser.Modifier = UserId;
						existUser.ModifyTime = DateTime.Now;

						using (var uow = _dapperUnitOfWorkFactory.Create())
						{
							_systemUserRepository.Add(actionItem);
							uow.SaveChanges();
						}

						//_systemUserRepository.Update(dict, "ID");

						result.StatusCode = HttpStatusCode.OK;
						result.Message = "UpdateSuccess";// string.Format(ResourceMessage.UpdateSuccess, "SystemUser");
					}
				}
			}
			catch (Exception ex)
			{
				result.StatusCode = HttpStatusCode.InternalServerError;
				result.Message = ex.Message;

				ExceptionLog log = new ExceptionLog()
				{
					FunctionName = " CreateOrUpdateUser(SystemUserModel InputModel, string UserId)",
					Parameter = InputModel,
					StatusCode = HttpStatusCode.InternalServerError,
					ExceptionMessage = ex
				};
			}
			return await Task.Run(() => result);
		}
		#endregion
	}
}
