using System.Collections.Generic;
using UnitOfWorks;

namespace IRepository.IRepositories
{
	public interface IGenericRepository<TEntity, TKey>: IDapperDBContext where TEntity : class
	{
		/// <summary>
		/// 取得單筆
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		TEntity Get(TKey id);

		/// <summary>
		/// 取得全部
		/// </summary>
		/// <returns></returns>
		IEnumerable<TEntity> GetAll();

		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="entity"></param>
		void Add(TEntity entity);

		/// <summary>
		/// 批次新增
		/// </summary>
		/// <param name="entities"></param>
		void AddRange(IEnumerable<TEntity> entities);

		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="entity"></param>
		void Update(TEntity entity);

		/// <summary>
		/// 刪除
		/// </summary>
		/// <param name="id"></param>
		void Remove(object id);

		/// <summary>
		/// 刪除 entity
		/// </summary>
		/// <param name="entity"></param>
		void Remove(TEntity entity);

		void RemoveRange(IEnumerable<TEntity> entities);
	}
}
