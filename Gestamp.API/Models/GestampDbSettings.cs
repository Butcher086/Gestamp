using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestamp.API.Models
{
    public class GestampDbSettings : IGestampDbSettings
    {
        public string SalesCollectionName { get; set; }        
        public string Container { get; set; }
        public string DatabaseName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(User) || string.IsNullOrEmpty(Password))
                    return $@"mongodb://27017:27017"; return $@"mongodb://{User}:{Password}@27017:27017";
            }
            set
            { }
        }
    }
}
