using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWars.Models
{
    public class PostEpisode
    {
        [ForeignKey(nameof(EpisodeName))]
        public string EpisodeName { get; set; }
        public virtual Post Post { get; set; }
        public Guid PostId { get; set; }
    }
}
