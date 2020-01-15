using ConnectionFactory.Connection;
using Dapper;
using IRepository.IRepositories;
using Microsoft.Extensions.Options;
using Sunstige.DataModels;

namespace MySQLRepository.Repositories
{
	public class SystemUserRepository : GenericRepository<SystemUser, int>, ISystemUserRepository
	{
		private string TableName => GetTableNameMapper();

		public SystemUserRepository(IOptions<DapperDBContextOptions> optionsAccessor): base(optionsAccessor)
		{
			SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
		}
	}
}
