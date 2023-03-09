using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOMIOD.Models
{
    [Table("Applications")]
    public class Application
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Index(IsUnique = true)]
        public string name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime creation_dt { get; set; }
    }
}

