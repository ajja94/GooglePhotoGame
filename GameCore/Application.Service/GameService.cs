using GameCore.Domain.Model;
using GameCore.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Application.Service
{
    public class GameService
    {
        private readonly IGameModelRepository _repository;

        public GameService(IGameModelRepository repository)
        {
            _repository = repository;
        }

        public async Task<GameModel> Play(Guid gameId, Coordinates coordinates)
        {
            var gameModel = await _repository.Read(gameId);
            gameModel.Play(coordinates);
            //var hasPlayed = gameModel.Play();
           // gameModel.aTimer = gameTimer;
            await _repository.Update(gameModel);
            return gameModel;
        }

        public async Task<GameModel> StartGame()
        {
            var gameModel = new GameModel();
            await _repository.Create(gameModel);
            return gameModel;
        }

        public async Task<GameModel> Read(Guid gameId)
        {
            return await _repository.Read(gameId);
        }
    }
}
