using System;
using System.Data;

namespace UnitOfWorks
{
	/// <summary>
	/// 參考自 NETCore_BasicKnowledge.Examples
	/// </summary>
	public interface IUnitOfWork : IDisposable
	{
		void SaveChanges();
	}
}
