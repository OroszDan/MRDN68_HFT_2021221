using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Models
{
    public enum Rating
    {
       General_Audiences, Parental_Guidance_Suggested, Parents_Strongly_Cautioned,Restricted, Adults_Only
    }
    [Table("movies")]
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(4)]
        public int? Year { get; set; }

        [Required]
        public Rating Rating { get; set; }

        [NotMapped]
        public virtual Director Director { get; set; }

        public int DirectorId { get; set; }
    }
}
