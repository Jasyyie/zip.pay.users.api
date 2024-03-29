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
    public class UserService : IUserService

    {
        private IUserRepository _userRepository;
        private IAccountService _accountService;
        public UserService(IUserRepository userRepository, IAccountService accountService)
        {
            _userRepository = userRepository;
            _accountService = accountService;
        }
        public async Task Create(User user)
        {
            var emailCheck = await Find(user.Email);
            if (emailCheck == null)
            {
                //todo: implement automapper
                var request = new Zip.Pay.Users.Repository.Model.User()
                {
                    Name = user.Name,
                    Email = user.Email,
                    MonthlySalary = user.MonthlySalary,
                    MonthlyExpense = user.MonthlyExpense
                };
                await _userRepository.Add(request);
                user.Id = request.Id;

                var account = new Zip.Pay.Users.Model.Account()
                {
                    User = user
                };

                await _accountService.Create(account);

            }
        }

        public async Task<List<User>> Find(string email)
        {
            var listUser = await _userRepository.Find(l => l.Email == email);

            var response = listUser.Select(u => new Zip.Pay.Users.Model.User() { Id = u.Id, Name = u.Name, MonthlySalary = u.MonthlySalary, MonthlyExpense = u.MonthlyExpense }).ToList();

            return response;

        }

        public async Task<List<User>> Get()
        {
            // Error: System.Text.Json.ThrowHelper.ThrowInvalidOperationException_SerializerCycleDetected(int maxDepth)
            // Dotnet Framework 3 Issue while converting IQureable to List
            var listUser = await _userRepository.GetAll();
            var response = listUser?.Select(u => new Zip.Pay.Users.Model.User() { Id = u.Id, Name = u.Name, MonthlySalary = u.MonthlySalary, MonthlyExpense = u.MonthlyExpense }).ToList();
            return response;
        }
    }
}