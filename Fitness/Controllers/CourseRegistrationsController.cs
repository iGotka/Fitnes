using Fitness.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Controllers
{
    internal class CourseRegistrationsController
    {
        /// <summary>
        /// GET CourseRegistration
        /// </summary>
        /// <returns></returns>
        public static List<CourseRegistration> GetCourseRegistration()
        {
            using (HttpClient client = new HttpClient())
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                string url = $"{Manager.RootUrl}CourseRegistration";
                Console.WriteLine(url);
                HttpResponseMessage response = client.GetAsync(url).Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<CourseRegistration>>(content.Result);
                return answer;
            }
        }
        /// <summary>
        /// POST CourseRegistration
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public static bool PostCourseRegistration(CourseRegistration record)
        {
            string jsonStr = JsonConvert.SerializeObject(record);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonStr);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            using (HttpClient client = new HttpClient())
            {
                string url = $"{Manager.RootUrl}CourseRegistration";
                Console.WriteLine(url);
                HttpResponseMessage response = client.PostAsync(url, byteContent).Result;
                return response.IsSuccessStatusCode;
            }
        }
        /// <summary>
        /// GET CourseRegistration on id
        /// </summary>
        /// <returns></returns>
        public static List<CourseRegistration> GetCourseRegistrationId(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{Manager.RootUrl}CourseRegistration/{id}";
                Console.WriteLine(url);
                HttpResponseMessage response = client.GetAsync(url).Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<CourseRegistration>>(content.Result);
                return answer;
            }
        }
        /// <summary>
        /// DELETE CourseRegistration
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns></returns>
        public static bool DeleteCourseRegistration(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{Manager.RootUrl}CourseRegistration/{id}";
                HttpResponseMessage response = client.DeleteAsync($"url").Result;
                return response.IsSuccessStatusCode;
            }
        }
    }
}
