
using System;
using Dapper;
using DataModel.Entities;

namespace Sunstige.DataModels
{
	public class SystemUser: DataChangelLogModel
	{
		//[Key]            
        public virtual int ID { get; set; }

		public string Code { get; set; }

		public virtual string Name { get; set; }

        public virtual string Password { get; set; }

        public virtual string Token { get; set; }

		public virtual DateTime TokenExpirationTime { get; set; }

		public bool IsEnabled { get; set; }
	}

}