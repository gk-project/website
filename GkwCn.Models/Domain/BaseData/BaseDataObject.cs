using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Domains.BaseData
{
    public class BaseDataObject
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(19,MinimumLength=19)]
        [Column(TypeName="char")]
        public string OldId { get; set; }

        [Required]
        public DomainStatue Statue { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
