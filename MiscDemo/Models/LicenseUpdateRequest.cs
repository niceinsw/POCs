using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiscDemo.Models
{
    public class LicenseUpdateRequest
    {
        public string Serial { get; set; }
        public string Key { get; set; }
        public dynamic Data { get; set; }
    }
}