using Business.Abstract.AbstractUoW;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountViewModel accountViewModel)
        {
            var senderValue = _accountService.GetById(accountViewModel.SenderId);
            var receiverValue = _accountService.GetById(accountViewModel.ReceiverId);

            senderValue.Balance -= accountViewModel.Amount;
            receiverValue.Balance += accountViewModel.Amount;

            List<Account> modiedAccounts = new List<Account>()
            {
                senderValue,
                receiverValue
            };

            _accountService.MultiUpdate(modiedAccounts);
            return View();
        }
    }
}
