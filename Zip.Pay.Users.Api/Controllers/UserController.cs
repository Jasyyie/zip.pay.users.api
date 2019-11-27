using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zip.Pay.Users.Model;
using Zip.Pay.Users.Service.Services;

namespace Zip.Pay.Users.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{email}")]
        public IActionResult Find(string email)
        {
            try
            {
                var response = _userService.Find(email);
                return Ok(response);
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
                var response = _userService.Get();
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                // todo: exception logging & handling
            }
            return new BadRequestResult();
        }

        /// <summary>
        /// Get trolley total
        /// </summary>
        /// <param name="sortOption">High | Low | Ascending | Descending | Recommended</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User user)
        {
            try
            {
                await _userService.Create(user);

                return Ok(user.Id);

            }
            catch (System.Exception ex)
            {
                // todo: exception logging & handling
            }

            return new BadRequestResult();
        }
    }
}
