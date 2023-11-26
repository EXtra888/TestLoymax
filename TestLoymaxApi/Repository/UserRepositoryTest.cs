using Loymax.Data;
using Loymax.Dto;
using Loymax.Interfaces;
using Loymax.Models;
using Loymax.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLoymaxApi.DataTest;
using Xunit;

namespace TestLoymaxApi.Repository
{
    public class UserRepositoryTest : IClassFixture<TestDatabaseFixture>
    {
        public TestDatabaseFixture Fixture { get; }

        public UserRepositoryTest(TestDatabaseFixture fixture)
        => Fixture = fixture;

        //[Fact]
        public async Task UserController_CreateAsync()
        {
            //Arrange
            var user = new User
            {
                Surname = "Иванов",
                Name = "Иван",
                Patronymic = "Иванович",
                DateBirth = new DateTime(2022, 08, 28)
            };
            using var context = await Fixture.CreateContext();
            var controller = new UserRepository(context);

            //Act
            var result = await controller.CreateAsync(user);

            //Assert
            Assert.NotNull(await context.Users.SingleOrDefaultAsync(u => u.Name == user.Name && u.Id == user.Id ));
        }
    }
}
