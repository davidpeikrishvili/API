using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimeAPI.Models
{
    public class Theme
    {
        [Key]
        public int anime_info_id { get; set; }
        public string anime_theme { get; set; } = null!;
        public string anime_genres { get; set; } = null!;
        public string anime_studio { get; set; } = null!;
        public string original_title { get; set; } = null!;

    }
}
