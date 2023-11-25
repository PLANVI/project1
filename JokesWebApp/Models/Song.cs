using System.ComponentModel.DataAnnotations.Schema;

namespace JokesWebApp.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Singer { get; set; }

        public string SongName { get; set; }

        public string SongDescription { get; set; }

        public string YouTubeUrl { get; set; }
        public string SongText { get; set; }

        public string Material { get; set; }

        public string Image { get; set; }


        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
