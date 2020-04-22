using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
//using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization;
using GameCore.Domain.Service;
using GameCore.Domain.Model;

namespace PhotoApi
{
    public class GooglePhotoAPI : IAlbumAPI
    {
        private JwtAuthenticator token;

        private async Task Authenticate()
        {
            var clientSecrets = new ClientSecrets
            {
                ClientId = "7874296725-7nd4ai7o7u4596faj0tr0cqvkd3hdvq0.apps.googleusercontent.com",
                ClientSecret = "UZMgHy_CdwuYpp7Y_iTVo_4P"
            };
            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                clientSecrets,
                new[] { "https://www.googleapis.com/auth/photoslibrary.sharing" },
                "user",
                CancellationToken.None
            );
            var accessToken = await credential.GetAccessTokenForRequestAsync();
            token = new JwtAuthenticator(accessToken);

        }

        private async Task<AlbumData> FetchAlbums()
        {
            if (token == null) await Authenticate();
            var client = new RestClient("https://photoslibrary.googleapis.com");
            client.Authenticator = token;
            var request = new RestRequest("/v1/albums", DataFormat.Json);
            var response = client.Get(request);
            // var request2 = new RestRequest("/v1/albums/Larvik", DataFormat.)

            var data = JsonConvert.DeserializeObject<AlbumData>(response.Content);

            return data;

        }

        //private void SkrivUtInformasjon(Album[] data)
        //{

        //    foreach (var album in data)
        //    {
        //        Console.WriteLine(album.Title + "\n");
        //        Console.WriteLine(album.ProductUrl + "\n");
        //    }
        //    Console.ReadLine();

        //}

        private async Task<PictureAlbum> GetAlbumPhotos(Album album)
        {
            if (token == null) await Authenticate();
            //  photodata = album.MediaItemsCount[1].ToString();

            var client = new RestClient("https://photoslibrary.googleapis.com");
            client.Authenticator = token;
            var request = new RestRequest($"/v1/mediaItems:search", DataFormat.Json);
            var albumRequest = new AlbumRequest()
            {
                pageSize = "100",
                albumId = album.Id
            };
            var json = JsonConvert.SerializeObject(albumRequest);
            request.AddJsonBody(json);
            var response = client.Post(request);
            var test = response.Content;
            var photos = JsonConvert.DeserializeObject<PictureAlbum>(response.Content);
            return photos;
        }

        public async Task<List<string>> GetAlbumNamesAsync()
        {
            var data = await FetchAlbums();
            var albums = data.Albums;
            var list = new List<string>();
            foreach (var album in albums)
            {
                list.Add(album.Title);
            }
            return list;
        }

        public async Task<List<PhotoModel>> GetAlbumAsync(string albumName)
        {
            var data = await FetchAlbums();
            var albums = data.Albums;
            foreach (var album in albums)
            {
                if (album.Title != albumName) continue;
                var photoAlbum = await GetAlbumPhotos(album);
                var list = new List<PhotoModel>();
                foreach (var photo in photoAlbum.mediaItems)
                {
                    var item = new PhotoModel();
                    item.Id = photo.id;
                    item.Url = photo.baseUrl;
                    item.AddCoordinatesAsString(photo.filename.Replace(".jfif", "").Replace(".png", "").Replace(".jpg", "").Replace(".jpeg", ""));
                    list.Add(item);
                }

                return list;
            }
            return null;
        }
    }
}
