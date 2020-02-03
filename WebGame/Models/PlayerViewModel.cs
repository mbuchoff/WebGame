using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGame.Models
{
    public class PlayerViewModel
    {
        public PlayerModel Player { get; set; }
        public int RoomId { get; set; }
        public Uri RoomInfoUrl { get; set; }
        public bool First { get; internal set; }
    }
}
