using Fitness.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;

namespace Fitness.Controllers
{
    internal class CoursesController
    {
        /// <summary>
        /// GET Course
        /// </summary>
        /// <returns></returns>
        public static List<Course> GetCourse()
        {
            using (HttpClient client = new HttpClient())
            {
               
                string url = $"{Manager.RootUrl}Course";
                Console.WriteLine(url);
                HttpResponseMessage response = client.GetAsync(url).Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<Course>>(content.Result);
                return answer;
            }
        }
        /// <summary>
        /// POST Course
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public static bool PostCourse(Course record)
        {
            string jsonStr = JsonConvert.SerializeObject(record);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonStr);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            using (HttpClient client = new HttpClient())
            {
                string url = $"{Manager.RootUrl}Course";
                Console.WriteLine(url);
                HttpResponseMessage response = client.PostAsync(url, byteContent).Result;
                return response.IsSuccessStatusCode;
            }
        }
        /// <summary>
        /// GET Course on id
        /// </summary>
        /// <returns></returns>
        public static List<Course> GetCourseId(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{Manager.RootUrl}Course/{id}";
                Console.WriteLine(url);
                HttpResponseMessage response = client.GetAsync(url).Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<Course>>(content.Result);
                return answer;
            }
        }
        /// <summary>
        /// DELETE Course
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns></returns>
        public static bool DeleteCourse(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{Manager.RootUrl}Course/{id}";
                HttpResponseMessage response = client.DeleteAsync($"url").Result;
                return response.IsSuccessStatusCode;
            }
        }
    }
}
