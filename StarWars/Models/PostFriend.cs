using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWars.Models
{
    public class PostFriend
    {
        [ForeignKey(nameof(FriendName))]
        public string FriendName { get; set; }
        public virtual Post Post { get; set; }
        public Guid PostId { get; set; }
    }
}
