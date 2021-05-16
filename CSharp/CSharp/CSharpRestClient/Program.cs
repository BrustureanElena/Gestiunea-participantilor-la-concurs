using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CSharpRestClient
{
    class MainClass
    {
        static HttpClient client = new HttpClient();

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RunAsync().Wait();
        }


        static async Task RunAsync()
        {
          
            Console.WriteLine("Caut proba cu ID-ul 1");
            Proba proba1 = await FindOne("http://localhost:8080/probe/1");
            Console.WriteLine(proba1.ToString());
            Console.WriteLine();

            Console.WriteLine("Afisez toate probele");
            foreach (Proba proba in await FindAll("http://localhost:8080/probe/"))
            {
                Console.WriteLine(proba.ToString());
            }
            Console.WriteLine();
/*
            Console.WriteLine("Adaug o proba");
            Proba proba2 = new Proba();
            proba2.Denumire = "desenCS";
            proba2.VarstaMin = 50;
            proba2.VarstaMax = 70;
            Proba proba3 = await Add("http://localhost:8080/probe/", proba2);
            Console.WriteLine(proba3.ToString());
            Console.WriteLine();
*/
            Console.WriteLine("O actualizez");
            Proba proba4 = new Proba();
            proba4.ID = 8; proba4.Denumire = "desenUp";
            proba4.VarstaMin = 9;
            proba4.VarstaMax = 15;
            Proba proba5 = await Update("http://localhost:8080/probe/8", proba4);
            Console.WriteLine("Am actualizat! Proba este: " + proba5.ToString());
            Console.WriteLine();

         /*   Console.WriteLine("O sterg");
            await client.DeleteAsync("http://localhost:8080/probe/13");
            Console.WriteLine("Am sters!");
            Console.WriteLine();*/

            Console.WriteLine("Probele sunt");
            foreach (Proba proba in await FindAll("http://localhost:8080/probe/"))
            {
                Console.WriteLine(proba.ToString());
            }

            Console.Read();
            
        }

        static async Task<String> GetTextAsync(string path)
        {
            String product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsStringAsync();
            }
            return product;
        }


        static async Task<Proba> GetProbaAsync(string path)
        {
            Proba product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Proba>();
            }
            return product;
        }
        
        static async Task<Proba> FindOne(string path)
        {
            Proba proba = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                proba = await response.Content.ReadAsAsync<Proba>();
            }
            return proba;
        }

        static async Task<Proba[]> FindAll(string path)
        {
            Proba[] probe = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                probe = await response.Content.ReadAsAsync<Proba[]>();
            }
            return probe;
        }

        static async Task<Proba> Add(string path, Proba proba)
        {
            Proba result = null;
            HttpResponseMessage response = await client.PostAsJsonAsync<Proba>(path, proba);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<Proba>();
            }
            return result;
        }

        static async Task<Proba> Update(string path, Proba proba)
        {
            Proba result = null;
            HttpResponseMessage response = await client.PutAsJsonAsync<Proba>(path, proba);
            if (response.IsSuccessStatusCode)
            {
                result = await FindOne("http://localhost:8080/probe/8");
            }
            return result;
        }

    }

    public class Proba
    {
       
        [JsonProperty("denumire")]
        public String Denumire{ get; set; }
        
        [JsonProperty("varstaMin")]
        public int VarstaMin { get; set; }
        [JsonProperty("varstaMax")]
        public int VarstaMax { get; set; }
        [JsonProperty("id")]
        public long ID { get; set; }
        public override string ToString()
        {
            return string.Format("[Proba: Denumire={0}, VarstaMin={1}, VarstaMax={2}, ID={3}]", Denumire,VarstaMin,VarstaMax,ID);
        }
		
    }
	
	
}