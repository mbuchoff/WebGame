using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGame.Models
{
    public class RoomViewModel : PageModel
    {
        public System.Uri QrUrl { get; set; }
        public System.Uri RoomInfoUrl { get; set; }
    }
}
