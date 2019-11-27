using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zip.Pay.Users.Model;
using Zip.Pay.Users.Repository.Repositories;

namespace Zip.Pay.Users.Service.Services
{
    /// <summary>
    /// Get User 
    /// </summary>
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

        }

        public async Task Create(Account account)
        {
            var request = new Zip.Pay.Users.Repository.Model.Account()
            {
                Id = account.Id,
                UserId = account.User.Id,
                Credit = 1000,
            };

            if (account.User.MonthlyExpense - account.User.MonthlySalary >= 1000)
            {
                await _accountRepository.Add(request);
            }

            account.Id = request.Id;
        }

        public async Task<List<Account>> Get()
        {
            var listUser = await _accountRepository.GetAll();
            var response = listUser.Select(u => new Zip.Pay.Users.Model.Account()
            {
                Id = u.Id,
                User = new User()
                {
                    Id = u.User.Id,
                    Email = u.User.Email,
                    MonthlySalary = u.User.MonthlySalary,
                    MonthlyExpense = u.User.MonthlyExpense

                }
            }).ToList();
            return response;
        }
    }
}