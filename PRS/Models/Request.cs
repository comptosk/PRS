using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace PRS.Models {
    public class Request {

        public int Id { get; set; }
        [StringLength(80)]
        [Required]
        public string Description { get; set; }
        [StringLength(80)]
        [Required]
        public string Justification { get; set; }
        [StringLength(80)]
        public string RejectionReason { get; set; }
        [StringLength(30)]
        [Required]
        public string DeliveryMode { get; set; }
        [StringLength(30)]
        public string Status { get; set; } = "NEW";
        [Column(TypeName = "decimal(12,2)")]
        public decimal Total { get; set; }
        public int UserId { get; set; }

        public virtual IEnumerable<Requestline> Requestlines { get; set; }

        public Request() {}

    }
}
