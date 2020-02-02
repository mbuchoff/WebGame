using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGame.Models
{
    public class IndexModel : PageModel
    {
        public string ExternalId { get; set; }
        public string Thing1 { get; set; }
    }
}
