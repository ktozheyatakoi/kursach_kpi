using System;
using AutoMapper;
using InventorySklad.Data;
using InventorySklad.Data.Item;
using InventorySklad.Data.Sklad;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class UnitHelper
    {
        public static DbContextOptions<InventorySkladContext> GetUnitTestDbOptions()
        {
            var options = new DbContextOptionsBuilder<InventorySkladContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new InventorySkladContext(options))
            {
                SeedData(context);
            }
            return options;
        }

        public static void SeedData(InventorySkladContext context)
        {
            context.Sklads.Add(new InventorySklad.Data.Sklad.SkladDto() { Id = 1, Location = "dwwqdwqdwqsads", CountOfItems = 1231312});
            context.Items.Add(new ItemDto() {Id = 1, Name = "ddqwdq3143wq", Count = 2131231, InvNumber = 332412, SkladId = 1});
            context.SaveChanges();
        }

        public static Mapper CreateMapperProfile()
        {
            var myProfile = new SkladDaoProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            return new Mapper(configuration);
        }
    }
}