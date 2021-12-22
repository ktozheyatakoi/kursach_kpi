using System.ComponentModel.DataAnnotations;

namespace InventorySklad.Orchestrators.Item
{
    public class Item
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Count { get; set; }
        [Required]
        public int InvNumber { get; set; }
        public int SkladId { get; set; }
    }
}