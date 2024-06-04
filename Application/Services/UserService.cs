using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;
public class UserService: IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly RoleManager<Role> _roleManager;
    public UserService(UserManager<User> userManager,
        SignInManager<User> signInManager,
        RoleManager<Role> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }
}
