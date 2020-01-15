using ConnectionFactory.Connection;
using Dapper;
using IRepository.IRepositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnitOfWorks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace MySQLRepository.Repositories
{
	/// <summary>
	/// 共用 Repository
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <typeparam name="TKey"></typeparam>
	public abstract class GenericRepository<TEntity, TKey> : DapperDBContext,IGenericRepository<TEntity, TKey> where TEntity :class
	{
		public GenericRepository(IOptions<DapperDBContextOptions> optionsAccessor) : base(optionsAccessor)
		{
		}

		/// <summary>
		/// 建立連線設定
		/// </summary>
		/// <param name="ConnectionName"></param>
		/// <param name="ConnectionString"></param>
		/// <returns></returns>
		protected override IDbConnection CreateConnection(string ConnectionName, string ConnectionString)
		{
			IDbConnection conn = null;
			switch (ConnectionName)
			{
				//MS-SQL
				case "SQLServer":
						conn = new SqlConnection(ConnectionString);
					break;
				//MySQL
				case "MySQL":
						conn = new MySqlConnection(ConnectionString);
					break;
				default:
						throw new Exception("name 不存在。");
			}
			return conn;
		}

		/// <summary>
		/// 取得單筆
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public TEntity Get(TKey id)
		{
			return _connection.Get<TEntity>(id);
		}

		/// <summary>
		/// 取得全部
		/// </summary>
		/// <returns></returns>
		public IEnumerable<TEntity> GetAll()
		{
			return _connection.GetList<TEntity>();
		}

		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="entity"></param>
		public void Add(TEntity entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			try
			{
				_connection.Insert<TKey, TEntity>(entity);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// 批次新增
		/// </summary>
		/// <param name="entities"></param>
		public void AddRange(IEnumerable<TEntity> entities)
		{
			foreach (var entity in entities)
			{
				Add(entity);
			}
		}

		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="entity"></param>
		public void Update(TEntity entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			try
			{
				_connection.Update(entity);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// 透過Id刪除
		/// </summary>
		/// <param name="id"></param>
		public void Remove(object id)
		{
			try
			{
				_connection.Delete<TEntity>(id);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// 刪除 entity
		/// </summary>
		/// <param name="entity"></param>
		public void Remove(TEntity entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			try
			{
				_connection.Delete(entity);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// 批次刪除
		/// </summary>
		/// <param name="entities"></param>
		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			foreach (var entity in entities)
			{
				Remove(entity);
			}
		}

		/// <summary>
		/// 取TEntity的TableName
		/// </summary>
		protected string GetTableNameMapper()
		{
			dynamic attributeTable = typeof(TEntity).GetCustomAttributes(false)
				.SingleOrDefault(attr => attr.GetType().Name == "TableAttribute");

			return attributeTable != null ? attributeTable.Name : typeof(TEntity).Name;
		}
	}
}
