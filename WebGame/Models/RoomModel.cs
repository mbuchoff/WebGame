using System.Collections.Generic;

namespace WebGame.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public List<PlayerModel> Players { get; } = new List<PlayerModel>();
        public bool GameStarted { get; set; }
    }
}