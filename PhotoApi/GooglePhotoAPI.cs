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
    class GooglePhotoAPI
    {
        static void Main(string[] args)
        {
            var data = Test().Result;
            SkrivUtInformasjon(data.Albums);


        }

        public static async Task<AlbumData> Test()
        {
            var clientSecrets = new ClientSecrets
            {
                ClientId = "7874296725-7nd4ai7o7u4596faj0tr0cqvkd3hdvq0.apps.googleusercontent.com",
                ClientSecret = "UZMgHy_CdwuYpp7Y_iTVo_4P"
            };
            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                clientSecrets,
                new[] { "https://www.googleapis.com/auth/photoslibrary" },
                "user",
                CancellationToken.None
            );
            var accessToken = await credential.GetAccessTokenForRequestAsync();
            var client = new RestClient("https://photoslibrary.googleapis.com");
            client.Authenticator = new JwtAuthenticator(accessToken);
            var request = new RestRequest("/v1/albums", DataFormat.Json);
            var response = client.Get(request);

            var data = JsonConvert.DeserializeObject<AlbumData>(response.Content);
            return data;

        }

        public static void SkrivUtInformasjon(Album[] data)
        {

            foreach (var album in data)
            {
                Console.WriteLine(album.Title + "\n");
            }
            Console.ReadLine();

        }
    }
}

