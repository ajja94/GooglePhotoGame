using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Model
{
    class GameModel
    {
        public Guid Id { get; set; }

        public GameModel()
        {
        }

        public GameModel(Guid id)
        {
            Id = id;

        }
    }
}
