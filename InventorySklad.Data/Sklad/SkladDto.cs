using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySklad.Data.Sklad
{
    public class SkladDto
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("location")]
        [MinLength (1)]
        [MaxLength(100)]
        public string Location { get; set; }
        [Column("count_of_items")]
        public int CountOfItems { get; set; }
        public virtual ICollection<Core.Item.Item> Items { get; set; }
    }
}