using System;
using Zip.Pay.Users.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Zip.Pay.Users.Service.Services
{
    public interface IUserService
    {
        Task Create(User user);
        Task<List<User>> Get();
        Task<List<User>> Find(string email);

    }
}
