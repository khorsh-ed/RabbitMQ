using MicroRabbiit.Banking.Application.Interfaces;
using MicroRabbiit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbiit.Banking.Application.Services
{
    public class AccountServices : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;

        public AccountServices(IAccountRepository accountRepository ,IEventBus bus)
        {
            _accountRepository = accountRepository;
            _bus = bus;
        }


        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTranfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                accountTranfer.FromAccount,
                accountTranfer.ToAccount,
                accountTranfer.TransferAmount
                );

            _bus.SendCommand(createTransferCommand);
        }
    }
}
