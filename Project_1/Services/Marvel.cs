using Project_1.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Project_1.Services
{
    public class Marvel
    {
        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {

                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }

        public static long UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalSeconds;
        }

        public static string CalculateMd5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            var sb = new StringBuilder();
            foreach (byte t in hash)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }

        public static Character getAvengers(int avengerId)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://gateway.marvel.com");

            string ApiPublicKey = "82812cb7eac29f55a0be279c9e767d00";
            string ApiPrivateKey = "82008425937e6080fef29553add0a8b992feef2b";
            string ts = UnixTimeNow().ToString(CultureInfo.InvariantCulture);

            // md5 digest
            string hashInput = ts + ApiPrivateKey + ApiPublicKey;
            string hash = CalculateMd5Hash(hashInput).ToLower();

            var request = new RestRequest();

            request.AddParameter("characterId", avengerId, ParameterType.UrlSegment);
            request.AddParameter("ts", ts);
            request.AddParameter("apikey", ApiPublicKey);
            request.AddParameter("hash", hash);

            request.Resource = "/v1/public/characters/{characterId}";

            IRestResponse<CharacterResult> response = client.Execute<CharacterResult>(request);

            Character character = null;

            if (response.Data.Data.Results.Count() > 0)
            {
                character = response.Data.Data.Results[0];
            }

            return character;
        }

        public static Character searchAvengers(string characterName)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://gateway.marvel.com");

            string ApiPublicKey = "82812cb7eac29f55a0be279c9e767d00";
            string ApiPrivateKey = "82008425937e6080fef29553add0a8b992feef2b";
            string ts = UnixTimeNow().ToString(CultureInfo.InvariantCulture);

            // md5 digest
            string hashInput = ts + ApiPrivateKey + ApiPublicKey;
            string hash = CalculateMd5Hash(hashInput).ToLower();

            var request = new RestRequest();

            request.AddParameter("name", characterName);
            request.AddParameter("ts", ts);
            request.AddParameter("apikey", ApiPublicKey);
            request.AddParameter("hash", hash);

            request.Resource = "/v1/public/characters";

            IRestResponse<CharacterResult> response = client.Execute<CharacterResult>(request);

            Character character = null;

            if (response.Data.Data.Results.Count() > 0)
            {
                 character = response.Data.Data.Results[0];
            }

            return character;
        }
    }

}