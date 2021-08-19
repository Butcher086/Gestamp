using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestamp.API.Models
{
    public interface IGestampDbSettings
    {
        string SalesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string Container { get; set; }
        string DatabaseName { get; set; }
        string User { get; set; }
        string Password { get; set; }
    }
}
