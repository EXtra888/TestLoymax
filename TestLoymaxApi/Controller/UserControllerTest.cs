using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Loymax.Data;
using Loymax.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Loymax.Controllers;
using Moq;
using Loymax.Repository;
using Loymax.Dto;
using Microsoft.EntityFrameworkCore;

namespace TestLoymaxApi.Controller
{
    public class UserControllerTest
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        
        public UserControllerTest()
        {
            _mapper = A.Fake<IMapper>();
            _userRepository = A.Fake<IUserRepository>();
        }

        [Fact]
        public async Task UserController_GetBalans_ReturnOK()
        {
            //Arrange
            int id = 1;
            var controller = new UserController(_mapper, _userRepository);

            //Act
            //Mock
            var result = await controller.GetBalanceUser(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async Task UserController_CreateUser_ReturnOK()
        {
            //Arrange
            var user = new UserDto
            {
                Surname = "Иванов",
                Name = "Иван",
                Patronymic = "Иванович",
                DateBirth = new DateTime(2022, 08, 28)
            };
            var controller = new UserController(_mapper, _userRepository);

            //Act
            var result = await controller.RegisterUser(user);

            Assert.NotNull(result);
        }
    }
}
