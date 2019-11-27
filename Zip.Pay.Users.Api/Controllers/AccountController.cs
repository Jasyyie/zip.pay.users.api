using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zip.Pay.Users.Model;
using Zip.Pay.Users.Service.Services;

namespace Zip.Pay.Accounts.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        /// <summary>
        /// Get trolley total
        /// </summary>
        /// <param name="sortOption">High | Low | Ascending | Descending | Recommended</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Account account)
        {
            try
            {
                await _accountService.Create(account);

                return Ok(account.Id);

            }
            catch (System.Exception ex)
            {
                // todo: exception logging & handling
            }

            return new BadRequestResult();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var response = _accountService.Get();
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                // todo: exception logging & handling
            }
            return new BadRequestResult();
        }


    }
}
