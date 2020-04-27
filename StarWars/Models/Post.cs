using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarWars.Models
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Planet { get; set; }
        public virtual List<PostEpisode> Episodes { get; set; }
        public virtual List<PostFriend> Friends { get; set; }
    }
}
