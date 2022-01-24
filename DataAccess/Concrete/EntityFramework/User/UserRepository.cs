using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ShoppingContext context) : base(context)
        {
        }
    }
}
