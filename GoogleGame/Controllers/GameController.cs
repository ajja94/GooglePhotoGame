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

        [HttpGet("{gameId:guid}")]
        public async Task<GameViewModel> Read(Guid gameId)
        {
            //var guid = new Guid(gameId);
            var game = await _gameService.Read(gameId);
            return MapToViewModel(game);
        }
        [HttpGet("{album}")]
        public async Task<GameViewModel> Start(string album)
        {
            var game = await _gameService.StartGame(album);
            return MapToViewModel(game);
        }

        //Guid gameId, Coordinates coordinates
        [HttpPut("{gameId}")]
        public async Task<GameViewModel> Play(Guid gameId, Coordinates coordinates)
        {
            //var guid = new Guid(gameId);
            var game = await _gameService.Play(gameId, coordinates);
            return MapToViewModel(game);
        }

       
        private static GameViewModel MapToViewModel(GameModel game)
        {
            // Finnes ferdige pakker for dette, f.eks. AutoMapper (NuGet)
            return new GameViewModel(game);
        }

        [HttpGet]
        public async Task<GameViewModel> ShowScore(Guid gameId, int poeng)
        {
            var game = await _gameService.ShowScore(gameId, poeng);
            return MapToViewModel(game);
        }
    }
}

