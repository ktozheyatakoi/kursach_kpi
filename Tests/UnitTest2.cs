using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using InventorySklad.Data;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Tests
{
    public class UnitTest2
    {
        private HttpClient _Item;
        private WebFactory _factory;
        private const string RequestUrl = "/api/Item/InventorySklads/Item/";

        [SetUp]
        public void SetUp()
        {
            _factory = new WebFactory();
            _Item = _factory.CreateClient();
        }
        [Test]
        public async Task ItemController_GetById_ReturnsItemModel()
        {
            var httpResponse = await _Item.GetAsync($"/ItemControllers/sklads/sklads/{1}");
            
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var Item = JsonConvert.DeserializeObject<InventorySklad.Orchestrators.Item.Item>(stringResponse);
            
            Assert.AreEqual(1, Item.Id);
            Assert.AreEqual("ddqwdq3143wq", Item.Name);
            Assert.AreEqual(2131231, Item.Count);
            Assert.AreEqual(332412, Item.InvNumber);
        }
        [Test]
        public async Task ItemController_Add_AddsItemToDatabase()
        {
            var item = new InventorySklad.Orchestrators.Item.Item(){ Name = "ddqqfewfwwq", Count = 2131231, InvNumber = 332412};
            var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            var httpResponse = await _Item.PostAsync($"/ItemControllers/sklads/{2}/sklads", content);

            
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var ItemInResponse = JsonConvert.DeserializeObject<InventorySklad.Orchestrators.Item.Item>(stringResponse);

            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<InventorySkladContext>();
                var databaseItem = await context.Items.FindAsync(ItemInResponse.Id);
                Assert.AreEqual(databaseItem.Id, ItemInResponse.Id);
                Assert.AreEqual(databaseItem.Name, ItemInResponse.Name);
                Assert.AreEqual(databaseItem.Count, ItemInResponse.Count);
                Assert.AreEqual(databaseItem.InvNumber, ItemInResponse.InvNumber);
            }
        }
        [Test]
        public async Task ItemController_Update_UpdatesItemInDatabase()
        {
            var item = new InventorySklad.Orchestrators.Item.Item(){Id = 1, Name = "18fewfw43"};
            var content = new StringContent(await JsonConvert.SerializeObjectAsync(item), Encoding.UTF8, "application/json");
            var httpResponse = await _Item.PatchAsync($"/ItemControllers/{item.Id}", content);

            httpResponse.EnsureSuccessStatusCode();
            
            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<InventorySkladContext>();
                var databaseItem = await context.Items.FindAsync(item.Id);
                Assert.AreEqual(item.Name, databaseItem.Name);
            }
        }

        [Test]
        public async Task BooksController_DeleteById_DeletesBookFromDatabase()
        {
            var ItemId = 1;
            var httpResponse = await _Item.DeleteAsync("/ItemControllers/" + ItemId);

            httpResponse.EnsureSuccessStatusCode();

            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<InventorySkladContext>();

                Assert.AreEqual(1, context.Items.Count());
            }
        }
    }
}