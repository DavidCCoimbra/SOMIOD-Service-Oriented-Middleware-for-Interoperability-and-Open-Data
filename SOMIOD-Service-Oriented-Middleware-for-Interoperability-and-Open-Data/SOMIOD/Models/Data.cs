using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOMIOD.Models
{
    [Table("Data")]
    public class Data
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string content { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime creation_dt { get; set; }
        public int parent { get; set; }
    }
}
