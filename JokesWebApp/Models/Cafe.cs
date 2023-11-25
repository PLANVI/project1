using System.ComponentModel.DataAnnotations.Schema;

namespace JokesWebApp.Models
{
    public class Cafe
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }


        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
