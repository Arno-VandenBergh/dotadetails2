using DotaDetails.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DotaDetails.DAL
{
    class PlayerApiRepository
    {
        private static readonly HttpClient _client = new HttpClient();
        public string GetPlayerNameById(string id)
        {
            Player player = new Player(id);
            string apiString = string.Format("https://api.opendota.com/api/players/{0}", id);


            HttpResponseMessage response = _client.Send(new HttpRequestMessage(HttpMethod.Get, apiString));
            using (var reader = new StreamReader(response.Content.ReadAsStream()))
            {
                var jdoc = JsonSerializer.Deserialize<JsonDocument>(reader.ReadToEnd());
                player.Name = jdoc.RootElement.GetProperty("profile").GetProperty("personaname").GetString();
            }

            return player.Name;
        }

        public List<Game> GetGamesByPlayerId(string id1,string id2)
        {
            List<Game> games = new List<Game>();
            string apiString = string.Format("https://api.opendota.com/api/players/{0}/matches?included_account_id={1}", id1,id2);


            HttpResponseMessage response = _client.Send(new HttpRequestMessage(HttpMethod.Get, apiString));
            using (var reader = new StreamReader(response.Content.ReadAsStream()))
            {
                var jdoc = JsonSerializer.Deserialize<JsonDocument>(reader.ReadToEnd());
                Game game = new Game();
                Debug.WriteLine(jdoc.RootElement.GetProperty("start_time").GetString());
            }
            return games;
        }
        //public List<Game> GetGamesByPlayerId(string id)
        //{
            
        //}
    }
}
