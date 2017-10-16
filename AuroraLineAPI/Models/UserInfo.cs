using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AuroraLineAPI.Models
{
    public class UserInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SNO { get; set; }

        public string LineID { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }

        public int Status { get; set; }
    }


}