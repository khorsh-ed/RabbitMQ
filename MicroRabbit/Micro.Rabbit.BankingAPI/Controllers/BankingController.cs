using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroRabbiit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Micro.Rabbit.BankingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {

        private readonly IAccountService _accountservice;

        public BankingController(IAccountService accountservice)
        {
            _accountservice = accountservice;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return Ok(_accountservice.GetAccounts());
        }

    }
}
