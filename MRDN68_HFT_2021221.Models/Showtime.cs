using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Models
{
    [Table("showtimes")]
    public class Showtime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [MaxLength(40)]
        public string City { get; set; }

        [MaxLength(30)]
        [Required]
        public string CinemaName { get; set; }

        [Required]
        public int Room { get; set; }

        [NotMapped]
        public virtual Movie Movie { get; set; }

        public int MovieId { get; set; }

    }
}
