using GameCore.Domain.Model;
using GameCore.Domain.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoogleGameSQLDb.Db
{
    class GoogleGameDb : IGameModelRepository
    {
        private GoogleGameDbContext _db;

        public GoogleGameDb(GoogleGameDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(GameModel gameModel)
        {
            await _db.Games.AddAsync(gameModel);
            return await _db.SaveChangesAsync();
        }

        public async Task<GameModel> Read(Guid id)
        {
            return await _db.Games.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<int> Update(GameModel gameModel)
        {
            _db.Games.Update(gameModel);
            return await _db.SaveChangesAsync();
      
        }
    }
}
