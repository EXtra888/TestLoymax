using Loymax.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLoymax.Models;
using TestLoymaxApi.DataTest;
using Xunit;

namespace TestLoymaxApi.Repository
{
    public class TransactionRepositoryTest : IClassFixture<TestDatabaseFixture>
    {
        public TestDatabaseFixture Fixture { get; }

        public TransactionRepositoryTest(TestDatabaseFixture fixture) => Fixture = fixture;

        [Fact]
        public async Task TransactionRepositore_CreateTransaction()
        {
            //Arrange
            var tran = new Transaction
            {
                Amount = 2000,
                TransactionTypeId = 1,
                UserId = 1
            };
            using var context = await Fixture.CreateContext();
            var controller = new TransactionRepository(context);
            //Act
            await controller.CreateTransaction(tran);

            //Assert
            Assert.NotNull(await context.Transactions.SingleAsync(t => t.Id == tran.Id));
        }
        [Fact]
        public async Task TransactionRepositore_CreateTransactionNew()
        {
            //Arrange
            var tran = new Transaction
            {
                Amount = -500,
                TransactionTypeId = 2,
                UserId = 1
            };
            using var context = await Fixture.CreateContext();
            var controller = new TransactionRepository(context);
            //Act
            await controller.CreateTransaction(tran);

            //Assert
            Assert.NotNull(await context.Transactions.SingleOrDefaultAsync(t => t.Id == tran.Id));
        }
    }
}
