using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Models
{
    [Table("directors")]
    public class Director
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(10)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int BirthYear { get; set; }

        [NotMapped]
        public virtual ICollection<Movie> Movies { get; set; }
        // IEnumerable, ICollection, IList, IDictionary

        public Director()
        {
            Movies = new HashSet<Movie>();
        }
    }
        
}
