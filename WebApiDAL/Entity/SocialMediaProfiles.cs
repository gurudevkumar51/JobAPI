using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDAL.Entity
{
    public class SocialMediaProfiles
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string SocialMedia { get; set; }
        public string ProfileURL { get; set; }
    }
}
