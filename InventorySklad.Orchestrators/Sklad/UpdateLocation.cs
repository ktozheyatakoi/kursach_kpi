using System.ComponentModel.DataAnnotations;

namespace InventorySklad.Orchestrators.Sklad
{
    public class UpdateLocation
    {
        [Required]
        [MinLength(1)]
        [MaxLength(30)]
        public string Location { get; set; }
    }
}