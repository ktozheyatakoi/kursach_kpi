using System.ComponentModel.DataAnnotations;

namespace InventorySklad.Orchestrators.Sklad
{
    public class Sklad
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int CountOfItems { get; set; }
    }
}