using System;

namespace UnitOfWorks
{
	/// <summary>
	/// 參考自 NETCore_BasicKnowledge.Examples
	/// </summary>
	public class UnitOfWork : IUnitOfWork
	{
		private readonly IDapperDBContext _context;

		/// <summary>
		/// 開始交易機制
		/// </summary>
		/// <param name="context"></param>
		public UnitOfWork(IDapperDBContext context)
		{
			_context = context;
			_context.BeginTransaction();
		}

		public void SaveChanges()
		{
			if (!_context.IsTransactionStarted)
				throw new InvalidOperationException("Transaction have already been commited or disposed.");

			_context.Commit();
		}

		public void Dispose()
		{
			if (_context.IsTransactionStarted)
				_context.Rollback();
		}
	}
}
