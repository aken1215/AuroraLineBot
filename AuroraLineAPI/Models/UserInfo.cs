using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuroraLineAPI.Models
{
    public class UserInfo
    {
        [Key]
        public string LineID { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }

        public string EMail { get; set; }

        public string ServiceDPT { get; set; }

        public int Status { get; set; }
    }


}