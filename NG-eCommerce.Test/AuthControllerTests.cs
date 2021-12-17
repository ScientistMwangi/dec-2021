using AutoMapper;
using EcommerceCore.DataLayer;
using EcommerceCore.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using NG_Ecommerce.Controllers;
using NG_Ecommerce.Helpers;
using NG_Ecommerce.Models;
using NG_Ecommerce.Models.Responses;
using System;
using System.Collections.Generic;
using Xunit;

namespace NG_eCommerce.Test
{
    public class AuthControllerTests
    {


        private readonly Mock<EcommerceDbContext> _context;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<UserManager<AppUser>> _userManager;
        private readonly Mock<RoleManager<Role> >_roleManager;
        private readonly Mock<IOptionsSnapshot<JwtSettings>> _jwtSettings;
        private readonly AuthController _controller;
        
        private readonly Mock<IUserStore<AppUser>> user;
        private readonly Mock<IRoleStore<Role>> role;

        public AuthControllerTests()
        {
            _context = new Mock<EcommerceDbContext>();
            _mapper = new Mock<IMapper>();
             user = new Mock<IUserStore<AppUser>>();
            role = new Mock<IRoleStore<Role>>();
            _userManager = new Mock<UserManager<AppUser>>(user.Object, null, null, null, null, null, null, null, null);
            _roleManager = new Mock<RoleManager<Role>>(role.Object, null, null, null, null);
            var jwtSettingsOptions = new JwtSettings { ExpirationInDays = 30, Issuer = "https://localhost:44379", Secret = "veryVerySuperSecretKey" };
            _jwtSettings = new Mock<IOptionsSnapshot<JwtSettings>>();
            _jwtSettings.Setup(m => m.Value).Returns(jwtSettingsOptions);
            _controller = new AuthController(_context.Object, _mapper.Object, _userManager.Object, _roleManager.Object, _jwtSettings.Object);
        }

        [Fact]
        public void TestUserLogin()
        {
            // Arrange
            var request = new UserDto { Email = "kibuika@gmail.com", Password = "AdMIN554@" };
            var user = new AppUser { UserName = request.Email, EmailConfirmed = true };
            _userManager.Setup( t =>  t.FindByNameAsync(request.Email).Result).Returns( user);

            _userManager.Setup(t => t.CheckPasswordAsync(user, request.Password).Result).Returns(true);

            _userManager.Setup(t => t.FindByNameAsync(user.Email).Result).Returns(user);

            _userManager.Setup(t => t.GetRolesAsync(user).Result).Returns(new List<string> { "Admin"});

            //Act

            var response = _controller.SignIn(request).Result as ObjectResult;
            var loginResponse = (LoginResponse)response.Value;

            //Assert
            Assert.Equal(response.StatusCode, 200);
            Assert.Equal(loginResponse.Success, true);
            Assert.Equal(loginResponse.Username, request.Email);
            Assert.Equal(loginResponse.Role, "Admin");

        }
    }
}
