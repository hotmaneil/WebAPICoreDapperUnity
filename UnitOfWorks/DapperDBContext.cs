using ConnectionFactory.Connection;
using Dapper;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace UnitOfWorks
{
	/// <summary>
	/// Dapper DBContext
	/// </summary>
	public abstract class DapperDBContext : IDapperDBContext
	{
		public IDbConnection _connection;
		private IDbTransaction _transaction;
		private int? _commandTimeout = null;
		public DapperDBContextOptions _options;

		public bool IsTransactionStarted { get; private set; }

		protected abstract IDbConnection CreateConnection(string ConnectionName, string ConnectionString);

		/// <summary>
		/// Dapper DBContext
		/// </summary>
		/// <param name="optionsAccessor"></param>
		public DapperDBContext(IOptions<DapperDBContextOptions> optionsAccessor)
		{
			_options = optionsAccessor.Value;

			_connection = CreateConnection(_options.ConnectionName, _options.ConnectionString);
			_connection.Open();
		}

		#region Transaction

		public void BeginTransaction()
		{
			if (IsTransactionStarted)
				throw new InvalidOperationException("Transaction is already started.");

			_transaction = _connection.BeginTransaction();
			IsTransactionStarted = true;
		}

		public void Commit()
		{
			if (!IsTransactionStarted)
				throw new InvalidOperationException("No transaction started.");

			_transaction.Commit();
			_transaction = null;

			IsTransactionStarted = false;
		}

		public void Rollback()
		{
			if (!IsTransactionStarted)
				throw new InvalidOperationException("No transaction started.");

			_transaction.Rollback();
			_transaction.Dispose();
			_transaction = null;

			IsTransactionStarted = false;
		}

		#endregion Transaction

		#region Dapper Execute & Query

		public async Task<int> ExecuteAsync(string sql, object param = null, CommandType commandType = CommandType.Text)
		{
			return await _connection.ExecuteAsync(sql, param, _transaction, _commandTimeout, commandType);
		}

		public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, CommandType commandType = CommandType.Text)
		{
			return await _connection.QueryAsync<T>(sql, param, _transaction, _commandTimeout, commandType);
		}

		public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, CommandType commandType = CommandType.Text)
		{
			return await _connection.QueryFirstOrDefaultAsync<T>(sql, param, _transaction, _commandTimeout, commandType);
		}

		public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, string splitOn = "Id", CommandType commandType = CommandType.Text)
		{
			return await _connection.QueryAsync(sql, map, param, _transaction, true, splitOn, _commandTimeout, commandType);
		}

		#endregion Dapper Execute & Query

		public void Dispose()
		{
			if (IsTransactionStarted)
				Rollback();

			_connection.Close();
			_connection.Dispose();
			_connection = null;
		}
	}
}
