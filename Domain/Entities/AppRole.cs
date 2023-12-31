﻿using Dapper;
using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    [Table("role")]
    public class AppRol : AbstractEntity<int>
    {
        public string name { get; set; }

        public string description { get; set; }

        public List<AppUser> Users { get; set; }
    }
}
