using System;
using System.ComponentModel.DataAnnotations;

namespace DojoInfoCenter.Models
{
    public class MessageObject
    {
        [Key]
        public int MessageId {get;set;}
        
        [Required]
        public string MessageTxt { get; set; }

        public bool IsArchived { get; set; }

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public int UserId { get; set; }
        public UserObject Creator { get; set; }
        
        public int LocationId { get; set; }
        public LocationObject Location { get; set; }

    }
}