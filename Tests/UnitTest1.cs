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
    [TestFixture]
    public class UnitTest1
    {
        private HttpClient _client;
        private WebFactory _factory;
        private const string RequestUrl = "/SkladControllers/";

        [SetUp]
        public void SetUp()
        {
            _factory = new WebFactory();
            _client = _factory.CreateClient();
        }
        [Test]
        public async Task SkladController_GetById_ReturnsSkladModel()
        {
            var httpResponse = await _client.GetAsync(RequestUrl + 1);
            
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var Sklad = JsonConvert.DeserializeObject<InventorySklad.Orchestrators.Sklad.Sklad>(stringResponse);
            
            Assert.AreEqual(1, Sklad.Id);
            Assert.AreEqual("dwwqdwqdwqsads", Sklad.Location);
            Assert.AreEqual(1231312, Sklad.CountOfItems);
        }
        [Test]
        public async Task SkladController_Add_AddsSkladToDatabase()
        {
            var sklad = new InventorySklad.Orchestrators.Sklad.Sklad(){Location = "qfwklvnsda",  CountOfItems = 11};
            var content = new StringContent(JsonConvert.SerializeObject(sklad), Encoding.UTF8, "application/json");
            var httpResponse = await _client.PostAsync(RequestUrl + 1, content);

            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var SkladInResponse = JsonConvert.DeserializeObject<InventorySklad.Orchestrators.Sklad.Sklad>(stringResponse);

            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<InventorySkladContext>();
                if (context != null)
                {
                    var databaseSklad = await context.Sklads.FindAsync(SkladInResponse.Id);
                    Assert.AreEqual(databaseSklad.Id, SkladInResponse.Id);
                    Assert.AreEqual(databaseSklad.CountOfItems, SkladInResponse.CountOfItems);
                    Assert.AreEqual(databaseSklad.Location, SkladInResponse.Location);
                }
            }
        }
        [Test]
        public async Task SkladController_Update_UpdatesSkladInDatabase()
        {
            var Sklad = new InventorySklad.Orchestrators.Sklad.Sklad{Id = 1, CountOfItems = 1843, Location = "ihogoyfyi"};
            var content = new StringContent(JsonConvert.SerializeObject(Sklad), Encoding.UTF8, "application/json");
            var httpResponse = await _client.PatchAsync($"/SkladControllers/{Sklad.Id}", content);

            httpResponse.EnsureSuccessStatusCode();
            
            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<InventorySkladContext>();
                if (context != null)
                {
                    var databaseSklad = await context.Sklads.FindAsync(Sklad.Id);
                    Assert.AreEqual(Sklad.Id, databaseSklad.Id);
                }
            }
        }
        [Test]
        public async Task BanksController_DeleteById_DeletesBankFromDatabase()
        {
            var SkladId = 1;
            var httpResponse = await _client.DeleteAsync(RequestUrl + SkladId);

            httpResponse.EnsureSuccessStatusCode();
            
            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<InventorySkladContext>();
                
                Assert.AreEqual(0, context.Sklads.Count());
            }
        }
    }
}