using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Fitness.Models;

namespace Fitness.Controllers
{
    internal class TrainersController
    {
        /// <summary>
        /// GET Trainer
        /// </summary>
        /// <returns></returns>
        public static List<Trainer> GetTrainers()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{Manager.RootUrl}Trainer";
                Console.WriteLine(url);
                HttpResponseMessage response = client.GetAsync(url).Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<Trainer>>(content.Result);
                return answer;
            }
        }
        /// <summary>
        /// POST Trainer
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public static bool PostTrainers(Trainer record)
        {
            string jsonStr = JsonConvert.SerializeObject(record);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonStr);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            using (HttpClient client = new HttpClient())
            {
                string url = $"{Manager.RootUrl}Trainer";
                Console.WriteLine(url);
                HttpResponseMessage response = client.PostAsync(url, byteContent).Result;
                return response.IsSuccessStatusCode;
            }
        }
        /// <summary>
        /// GET Trainer on id
        /// </summary>
        /// <returns></returns>
        public static List<Trainer> GetTrainersId(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{Manager.RootUrl}Trainer/{id}";
                Console.WriteLine(url);
                HttpResponseMessage response = client.GetAsync(url).Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<Trainer>>(content.Result);
                return answer;
            }
        }
        /// <summary>
        /// DELETE Trainer
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns></returns>
        public static bool DeleteTrainer(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{Manager.RootUrl}Trainer/{id}";
                HttpResponseMessage response = client.DeleteAsync($"url").Result;
                return response.IsSuccessStatusCode;
            }
        }
    }
}
