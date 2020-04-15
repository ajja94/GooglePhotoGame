using GameCore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Domain.Service
{
    public interface IGameModelRepository
    {
        Task<int> Create(GameModel gameModel);
        Task<GameModel> Read(Guid id);
        Task<int> Update(GameModel gameModel);
    }
}
