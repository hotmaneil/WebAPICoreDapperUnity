using IRepository;
using UnitOfWorks;

namespace MySQLRepository
{
	public class DapperUnitOfWorkFactory: IDapperUnitOfWorkFactory
	{
		private readonly DapperDBContext _context;

		public DapperUnitOfWorkFactory(DapperDBContext context)
		{
			_context = context;
		}

		/// <summary>
		/// 建立交易機制
		/// </summary>
		/// <returns></returns>
		public IUnitOfWork Create()
		{
			return new UnitOfWork(_context);
		}
	}
}
