using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGame.Models
{
    public class IndexModel : PageModel
    {
        public string externalId { get; set; }
        public string thing1 { get; set; }
        public string thing2 { get; set; }
    }
}
