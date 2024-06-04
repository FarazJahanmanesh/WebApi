using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Application.Api.Controllers.V1;
public class UserController : BaseController
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
	{
        _userService = userService;
    }
}
