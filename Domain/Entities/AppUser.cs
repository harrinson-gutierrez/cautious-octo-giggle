using Dapper;
using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    [Table("app_user")]
    public class AppUser : AbstractEntity<int>
    {
        public string name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public bool email_confirmed { get; set; }
        public bool enabled { get; set; }
        public string password_hash { get; set; }
        public string security_stamp { get; set; }
        public string instagram { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string profile_image { get; set; }

        public List<AppRol> Roles { get; set; }
        public AppUser()
        {
            Roles = new List<AppRol>();
        }
    }
}
