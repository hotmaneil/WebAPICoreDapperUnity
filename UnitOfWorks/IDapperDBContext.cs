using System;

namespace UnitOfWorks
{
	/// <summary>
	/// Dapper DBContext
	/// </summary>
	public interface IDapperDBContext : IDisposable
	{
		bool IsTransactionStarted { get; }

		void BeginTransaction();

		void Commit();

		void Rollback();
	}
}
