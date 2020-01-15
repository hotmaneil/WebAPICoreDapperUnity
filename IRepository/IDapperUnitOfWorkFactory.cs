using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWorks;

namespace IRepository
{
	public interface IDapperUnitOfWorkFactory
	{
		/// <summary>
		/// 建立交易機制
		/// </summary>
		/// <returns></returns>
		IUnitOfWork Create();
	}
}
