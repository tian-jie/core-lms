using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreLMS.Web.Areas.Admin.Models
{
    public class RouteViewModel
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Name { get; set; }
        public string Method { get; set; }
        public string Template { get; set; }

    }
}
