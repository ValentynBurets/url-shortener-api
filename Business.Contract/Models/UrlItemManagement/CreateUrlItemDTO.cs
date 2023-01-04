using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract.Models.UrlItemManagement
{
    public class CreateUrlItemDTO
    {
        public string Url { get; set; }
        public string ShortUrl { get; set; }
    }
}
