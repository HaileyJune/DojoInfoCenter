using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DojoInfoCenter.Models
{
    public class LocationObject
    {
        [Key]
        public int LocationId {get;set;}
        
        [Required]
        public string LocationName { get; set; }

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public List<MessageObject> Messages { get; set; }
    }
}