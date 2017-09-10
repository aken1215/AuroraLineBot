using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AuroraLineAPI.Models
{
    public class EngageRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string AgentId { get; set; }

        public string CustomerId { get; set; }

        public bool IssusOpend { get; set; }

    }
}