using DAL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using MyApplication.Controllers;
using MyApplication.Models.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Tests
{
    [TestFixture]
    public class AccountControllerTest
    {
        public class FakeUserManager : UserManager<User>
        {
            public FakeUserManager()
                : base(new Mock<IUserStore<User>>().Object,
                      new Mock<IOptions<IdentityOptions>>().Object,
                      new Mock<IPasswordHasher<User>>().Object,
                      new IUserValidator<User>[0],
                      new IPasswordValidator<User>[0],
                      new Mock<ILookupNormalizer>().Object,
                      new Mock<IdentityErrorDescriber>().Object,
                      new Mock<IServiceProvider>().Object,
                      new Mock<ILogger<UserManager<User>>>().Object)
            { }
        }

        public class FakeSignInManager : SignInManager<User>
        {
            public FakeSignInManager()
                : base(new FakeUserManager(),
                new Mock<IHttpContextAccessor>().Object,
                new Mock<IUserClaimsPrincipalFactory<User>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<ILogger<SignInManager<User>>>().Object,
                new Mock<IAuthenticationSchemeProvider>().Object)
            { }
        }

        AccountController controller;
        Mock<FakeUserManager> _userManagerMock;
        Mock<FakeSignInManager> _signInManagerMock;
        LoginViewModel loginModel;
        User user;


        [SetUp]
        public void Setup()
        {
            // Arrange
            _userManagerMock = new Mock<FakeUserManager>();
            _signInManagerMock = new Mock<FakeSignInManager>();

            loginModel = new LoginViewModel
            {
                Email = "SomeEmail",
                Password = "SomePassword"
            };

            user = new User
            {
                Id = "1"
            };

            controller = new AccountController(_userManagerMock.Object, _signInManagerMock.Object);
        }

        [Test]
        public async Task LoginErrorTest()
        {
            // Arrange
            _userManagerMock.Setup(m => m.FindByNameAsync(loginModel.Email)).ReturnsAsync(user);
            _userManagerMock.Setup(m => m.IsEmailConfirmedAsync(user)).ReturnsAsync(true);

            _signInManagerMock.Setup(m => m.PasswordSignInAsync(loginModel.Email, loginModel.Password, false, false))
                .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Failed);

            AccountController controll = new AccountController(_userManagerMock.Object, _signInManagerMock.Object);

            //Act
            var result = await controll.Login(loginModel);

            //Assert
            Assert.That(result, Is.TypeOf<ViewResult>());
            Assert.AreEqual(controll.ModelState
                .Values
                .First()
                .Errors[0]
                .ErrorMessage, "Неправильный логин и (или) пароль");
        }

        [Test]
        public async Task LoginTest()
        {
            // Arrange
            _userManagerMock.Setup(m => m.FindByNameAsync(loginModel.Email)).ReturnsAsync(user);
            _userManagerMock.Setup(m => m.IsEmailConfirmedAsync(user)).ReturnsAsync(true);

            _signInManagerMock.Setup(m => m.PasswordSignInAsync(loginModel.Email, loginModel.Password, false, false))
                .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

            AccountController controll = new AccountController(_userManagerMock.Object, _signInManagerMock.Object);

            // Act
            var result = await controll.Login(loginModel);

            // Assert
            Assert.AreEqual("Index", (result as RedirectToActionResult).ActionName);
        }

    }
}
