using System.ComponentModel.DataAnnotations;
using System;
namespace AnimeAPI.Models
{
    public class info
    {
        [Key]
        public int animeId { get; set; }
        public string anime_title { get; set; } = null!;
        public string anime_director { get; set; } = null!;
        public int anime_episodes { get; set; }
        public string anime_status { get; set; } = null!;
        
    }
}
