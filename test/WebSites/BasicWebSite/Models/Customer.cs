using System.ComponentModel.DataAnnotations;

namespace BasicWebSite
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}