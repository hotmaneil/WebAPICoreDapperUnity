using DataModel.Dtos.SystemUser;
using DataModel.Share;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceInterface;
using Sunstige.DataModels;
using System;
using System.Net;
using System.Threading.Tasks;

namespace WebAPICoreDapperUnity.Controllers
{
	/// <summary>
	/// 系統使用者 控制器
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class SystemUserController : ControllerBase
	{
		private ISystemUserManager _systemUserManager;

		/// <summary>
		/// 系統使用者 控制器
		/// </summary>
		/// <param name="systemUserManager"></param>
		public SystemUserController(ISystemUserManager systemUserManager)
		{
			this._systemUserManager = systemUserManager;
		}

		/// <summary>
		/// 依照Id取得使用者
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("GetUser")]
		public async Task<ActionResult<SystemUser>> GetUser(int Id)
		{
			try
			{
				var data =  await _systemUserManager.Get(Id);
				return data;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// 新增與更新使用者
		/// </summary>
		/// <param name="InputModel"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("UpdateUser")]
		public async Task<ActionResult<VerityResult>> UpdateUser(SystemUserModel InputModel)
		{
			VerityResult responseResult = new VerityResult();

			try
			{
				responseResult = await _systemUserManager.CreateOrUpdateUser(InputModel, "Sys");
			}
			catch (Exception ex)
			{
				responseResult.StatusCode = HttpStatusCode.InternalServerError;
				responseResult.Message = JsonConvert.SerializeObject(ex.Message);
			}
			return responseResult;
		}
	}
}