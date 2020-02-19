using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGame.Models
{
    public class AddPlayerResponseModel
    {
        public int PlayerId { get; set; }
        public bool IsFirst { get; set; }
    }
}
