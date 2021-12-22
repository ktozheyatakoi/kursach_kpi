namespace InventorySklad.Core.Item
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int InvNumber { get; set; }
        public int SkladId { get; set; }
    }
}