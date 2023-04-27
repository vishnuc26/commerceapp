using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Razarpagescrud.Models
{
    public class Category
    {
        public int Id { get; set; }

       
        [DisplayName("Category name")]

        public string Name { get; set; }

        public int DisplayOrder { get; set; }


        
    }
}
