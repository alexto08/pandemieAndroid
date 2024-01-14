﻿using Newtonsoft.Json;
using pandemieAndroid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandemieAndroid.Data
{
    public class StocNecesarRestService : StocNecesarIRestService
    {
        HttpClient client;

        //se va modifica ulterior cu ip-ul si portul corespunzator
        string RestUrl = "https://192.168.1.203:45457/api/stocnecesars/{0}";
        public List<StocNecesar> Items { get; private set; }
        public StocNecesarRestService()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };
            client = new HttpClient(httpClientHandler);
        }
        public async Task<List<StocNecesar>> RefreshDataAsync()
        {
            Items = new List<StocNecesar>();
            Uri uri = new Uri(string.Format(RestUrl, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<StocNecesar>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Items;
        }
        public async Task SaveStocNecesarAsync(StocNecesar item, bool isNewItem = true)
        {
            Uri uri = new Uri(string.Format(RestUrl, string.Empty));
            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8,
               "application/json");
                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"\tTodoItem successfully saved.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
        public async Task DeleteStocNecesarAsync(int id)
        {
            Uri uri = new Uri(string.Format(RestUrl, id));
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"\tTodoItem successfully deleted.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }


    }
}

