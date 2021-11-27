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
    [Table("directors")]
    public class Director
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(40)]
        [Required]
        public string Name { get; set; }

        [MaxLength(4)]
        [Required]
        public int BirthYear { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Movie> Movies { get; set; }
        // IEnumerable, ICollection, IList, IDictionary

        public Director()
        {
            Movies = new HashSet<Movie>();
        }
    }
        
}
