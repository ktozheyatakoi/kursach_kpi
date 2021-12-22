using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventorySklad.Data.Sklad;

namespace InventorySklad.Data.Item
{
    public class ItemDto
    {
        [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("count")]
        public int Count { get; set; }
        [Column("inventory_number")]
        public int InvNumber { get; set; }
        [ForeignKey("Sklad")] 
        [Column("sklad_id")]
        public int SkladId { get; set; }
        public SkladDto SkladDto { get; set; }
    }
}