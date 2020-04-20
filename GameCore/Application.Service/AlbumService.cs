using GameCore.Domain.Model;
using GameCore.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Application.Service
{
    public class AlbumService
    {
        private readonly IAlbumAPI _albumAPI;

        public AlbumService(IAlbumAPI albumAPI)
        {
            _albumAPI = albumAPI;
        }

        public async Task<List<string>> GetAlbumNamesAsync()
        {
            return await _albumAPI.GetAlbumNamesAsync();
        }
        public async Task<List<PhotoModel>> GetAlbumAsync(string albumName)
        {

            return await _albumAPI.GetAlbumAsync(albumName);
        }

    }
}
