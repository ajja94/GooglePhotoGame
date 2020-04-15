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

namespace PhotoApi
{
    public class GooglePhotoAPI
    {
        private JwtAuthenticator token;
        public async Task<AlbumData> Test()
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
            var client = new RestClient("https://photoslibrary.googleapis.com");
            token = new JwtAuthenticator(accessToken);
            client.Authenticator = token;
            var request = new RestRequest("/v1/albums", DataFormat.Json);
            var response = client.Get(request);
            // var request2 = new RestRequest("/v1/albums/Larvik", DataFormat.)

            var data = JsonConvert.DeserializeObject<AlbumData>(response.Content);

            return data;

        }

        public void SkrivUtInformasjon(Album[] data)
        {

            foreach (var album in data)
            {
                Console.WriteLine(album.Title + "\n");
                Console.WriteLine(album.ProductUrl + "\n");
            }
            Console.ReadLine();

        }

        public string GetDataPhoto(Album[] data)
        {
            var photodata = "";

            foreach (var album in data)
            {
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
                var photos = JsonConvert.DeserializeObject<PictureAlbum>(response.Content);
            }

            return photodata;
        }

        //public static string SendInformation(Album[] data)
        //{
        //   List<string> urlListe = new List<string>;

        //    foreach (var album in data)
        //    {
        //      album.ProductUrl

        //    }


        //}
    }
}
