using Microsoft.AspNetCore.Mvc;
using ServiceInterface;
using Sunstige.DataModels;
using System;
using System.Threading.Tasks;

namespace WebAPICoreDapperUnity.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SystemUserController : ControllerBase
	{
		private ISystemUserManager _systemUserManager;

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
	}
}