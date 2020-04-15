using GameCore.Application.Service;
using GameCore.Domain.Model;
using GoogleGame.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GoogleGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;

        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<GameViewModel> Start()
        {
            var game = await _gameService.StartGame();
            return MapToViewModel(game);
        }

        [HttpGet("{gameId}")]
        public async Task<GameViewModel> Read(string gameId)
        {
            var guid = new Guid(gameId);
            var game = await _gameService.Read(guid);
            return MapToViewModel(game);
        }

        [HttpPut]
        public async Task<GameViewModel> Play(PlayViewModel play)
        {
            var guid = new Guid(play.GameId);
            var game = await _gameService.Play(guid);
            return MapToViewModel(game);
        }
        [HttpPut]

        private static GameViewModel MapToViewModel(GameModel game)
        {
            // Finnes ferdige pakker for dette, f.eks. AutoMapper (NuGet)
            return new GameViewModel( game.Id , game.poeng);
        }
    }
}

