using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Zip.Pay.Users.Repository.Context;
using Zip.Pay.Users.Repository.Model;

namespace Zip.Pay.Users.Repository.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(ZipPayUserDbContext dbContext) : base(dbContext) { }
    }
}