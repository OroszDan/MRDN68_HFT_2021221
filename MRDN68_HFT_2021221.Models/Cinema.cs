using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Models
{
    [Table("cinemas")]
    public class Cinema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(30)]
        [Required]
        public string City { get; set; }

        [NotMapped]
        public virtual ICollection<Movie> Movies { get; set; }
        // IEnumerable, ICollection, IList, IDictionary

        public Cinema()
        {
            Movies = new HashSet<Movie>();
        }
    }
}
