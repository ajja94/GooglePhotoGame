using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Domain.Model
{
    public class BaseModel
    {
        public Guid Id { get; set; }

        public BaseModel()
        {
            Id = Guid.NewGuid();
        }

        public BaseModel(Guid id)
        {
            Id = id;
        }
    }
}
