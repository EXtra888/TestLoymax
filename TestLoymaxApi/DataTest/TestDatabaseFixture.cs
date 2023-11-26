using Loymax.Data;
using Loymax.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLoymaxApi.DataTest
{
    public class TestDatabaseFixture 
    {
        private const string ConnectionString = @"Data Source=WIN-ATPAD866R0P;Initial Catalog=Loymax;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Encrypt=True";
        //private static readonly object _lock = new();
        //private static bool _databaseInitialized;


        //v2
        public async Task<ApplicationContext> CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlServer(ConnectionString)
                .Options;
            var databaseContext = new ApplicationContext(options);
            databaseContext.Database.EnsureCreated();
            if(await databaseContext.Users.CountAsync() <= 50)
            {
               var list = GenerationUser();
               databaseContext.AddRange(list);
               await databaseContext.SaveChangesAsync();
            }
            return databaseContext;
        }

        public List<User> GenerationUser()
        {
            List<User> listUser = new List<User>();
           
            for (int i = 1; i <= 50; i++)
            {
                listUser.Add(new User
                {
                    Surname = Faker.Name.Last(),
                    Name = Faker.Name.First(),
                    Patronymic = Faker.Name.Middle(),
                    DateBirth = GenererateRandomDate()
                });
            }
            return listUser;
        }

        public DateTime GenererateRandomDate()
        {
            Random rnd = new Random();
            int year = rnd.Next(1980, 2023);
            int month = rnd.Next(1, 12);
            int day = DateTime.DaysInMonth(year, month);
            int Day = rnd.Next(1, day);
            DateTime dt = new DateTime(year, month, Day);
            return dt;
        }

        //v1
        //public ApplicationContext CreateContext()
        //=> new ApplicationContext(
        //    new DbContextOptionsBuilder<ApplicationContext>()
        //        .UseSqlServer(ConnectionString)
        //        .Options);
    }
}
