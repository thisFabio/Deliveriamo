using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveriamoRepository.Entity
{
    public class BusinessType
    {
        public int Id { get; set; }
        [Required]
        public string BusinessTypeName { get; set; }
        public string BusinessTypeDescription { get; set; }

    }
}
