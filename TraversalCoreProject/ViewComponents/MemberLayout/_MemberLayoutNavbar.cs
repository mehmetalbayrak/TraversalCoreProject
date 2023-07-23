using Dto.DTOs.AppUserDtos;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.MemberLayout
{
    public class _MemberLayoutNavbar : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _MemberLayoutNavbar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserListDto appUserListDto = new()
            {
                Name = values.Name,
                Surname = values.Surname,
                Email = values.Email,
                Image = values.Image,
                UserName = values.UserName
            };
            return View(appUserListDto);
        }
    }
}
