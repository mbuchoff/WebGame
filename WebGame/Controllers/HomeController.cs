using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebGame.Models;

namespace WebGame.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Random random;
        private readonly GameModel game;

        public HomeController(ILogger<HomeController> logger, Random random, GameModel game)
        {
            _logger = logger;
            this.random = random;
            this.game = game;
        }

        public IActionResult Room()
        {
            var roomId = random.Next(0, int.MaxValue);
            this.game.Rooms.Add(new RoomModel()
            {
                Id = roomId,
            });

            return View(new RoomViewModel()
            {
                RoomId = roomId,
                QrSuffix = $"Home/{nameof(Player)}?roomId={roomId}",
                PregameUrl = PregameUrl(roomId),
            });
        }

        private Uri PregameUrl(int roomId)
        {
            return new Uri(Request.Scheme + "://" + Request.Host + $"/Home/{nameof(PregameInfo)}?roomId={roomId}");
        }

        public string PregameInfo(int roomId)
        {
            return JsonConvert.SerializeObject(
                game.Rooms.First(r => r.Id == roomId),
                Formatting.Indented);
        }

        public AddPlayerResponseModel AddPlayer(int roomId, string playerName)
        {
            var r = this.game.Rooms.Where(r => r.Id == roomId).First();
            bool isFirst = (r.Players.Count == 0);
            var player = new PlayerModel()
            {
                Id = random.Next(0, int.MaxValue),
                Name = playerName
            };
            r.Players.Add(player);
            return new AddPlayerResponseModel
            {
                PlayerId = player.Id,
                IsFirst = isFirst
            };
        }

        public IActionResult Player(int roomId)
        {
            return View(new PlayerViewModel()
            {
                RoomId = roomId,
                PregameUrl = PregameUrl(roomId),
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult BeginGame(int roomId)
        {
            game.Rooms.First(r => r.Id == roomId).GameStarted = true;
            return View("GameStarted");
        }

        public IActionResult GameStarted()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
