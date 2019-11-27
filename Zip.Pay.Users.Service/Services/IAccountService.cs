
using System;
using Zip.Pay.Users.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Zip.Pay.Users.Service.Services
{
    public interface IAccountService
    {
        Task Create(Account account);
        Task<List<Account>> Get();
    }
}
