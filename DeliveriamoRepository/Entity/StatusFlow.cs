using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DeliveriamoRepository.Entity
{
    public class StatusFlow
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
        [ForeignKey("NextStatusId")]
        public virtual Status NextStatus { get; set; }

        [ForeignKey("CanceledStatusId")]
        public virtual Status CanceledStatus { get; set; }
        


    }
}
