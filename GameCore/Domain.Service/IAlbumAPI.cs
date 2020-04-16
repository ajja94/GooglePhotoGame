using GameCore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Domain.Service
{
    public interface IAlbumAPI
    {
        Task<List<string>> GetAlbumNamesAsync();
        Task<List<PhotoModel>> GetAlbumAsync(string albumName);
    }
}
