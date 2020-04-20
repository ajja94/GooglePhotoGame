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
        private readonly IAlbumAPI _albumAPI;

        public GameService(IGameModelRepository repository, IAlbumAPI albumAPI)
        {
            _repository = repository;
            _albumAPI = albumAPI;
        }

        public async Task<GameModel> Play(Guid gameId, Coordinates coordinates)
        {
            var gameModel = await _repository.Read(gameId);
            gameModel.Play(gameId,coordinates);
            //var hasPlayed = gameModel.Play();
            //gameModel.aTimer = gameTimer;
            await _repository.Update(gameModel);
            return gameModel;
        }

        public async Task<GameModel> StartGame(string album)
        {
            var gameModel = new GameModel();
            gameModel.AddGameAlbum(await _albumAPI.GetAlbumAsync(album));
            await _repository.Create(gameModel);
            return gameModel;
        }

        public async Task<GameModel> Read(Guid gameId)
        {
            return await _repository.Read(gameId);
        }

        public async Task <GameModel> ShowScore(Guid gameId, int poeng)
        {
            var gameModel = await _repository.Read(gameId);
            gameModel.ShowScore(gameId, poeng);
            return gameModel;
        }
    }
}
