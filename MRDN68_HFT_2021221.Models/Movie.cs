using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Models
{
    public enum AgeRating
    {
       GeneralAudiences, ParentalGuidanceSuggested, ParentsStronglyCautioned, Restricted, AdultsOnly
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
        public AgeRating Rating { get; set; }

        [NotMapped]
        public virtual Director Director { get; set; }

        public int DirectorId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Showtime> Showtimes { get; set; }

        public Movie()
        {
            Showtimes = new HashSet<Showtime>();
        }
    }
}
