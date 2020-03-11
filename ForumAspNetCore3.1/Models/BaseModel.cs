using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ForumAspNetCore3._1.Models
{
   
    [DataContract]
    public abstract class BaseModel
    {

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    }
    
}
