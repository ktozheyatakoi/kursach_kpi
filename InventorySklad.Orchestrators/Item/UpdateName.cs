using System.ComponentModel.DataAnnotations;

namespace InventorySklad.Orchestrators.Item
{
    public class UpdateName
    {
        [Required]
        [MinLength(1)]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}