using CinemaParadiso.Data;
using CinemaParadiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;

namespace CinemaParadiso.Repositories
{
    public class RepositoryCinephile : IRepositoryCinephile
    {        
        String uriApi;
        MediaTypeWithQualityHeaderValue headerJson;
        public String token { get; set; }
        public RepositoryCinephile()
        {            
            uriApi = "https://cinemaparadisoapiasr.azurewebsites.net/";
            headerJson = new MediaTypeWithQualityHeaderValue("application/json");            
        }
        public async Task<T> CallApi<T>(String peticion)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.uriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerJson);
                if (token != null)
                {
                    client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                }
                HttpResponseMessage response = await client.GetAsync(peticion);
                if (response.IsSuccessStatusCode)
                {
                    T datos = await response.Content.ReadAsAsync<T>();
                    return (T)Convert.ChangeType(datos, typeof(T));
                }
                else
                {
                    return default(T);
                }
            }
        }
        /// <summary>
        /// Checks if a login request is valid.
        /// </summary>
        /// <param name="user">String. User´s email.</param>
        /// <param name="password">String. User´s password.</param>
        /// <returns></returns>
        public async Task<String> Login(String user, String password)
        {            
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.uriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerJson);                                
                Login log = new Login(user, password);                
                String json = JsonConvert.SerializeObject(log);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("api/Auth/Login", content);
                if ((int)response.StatusCode != 200)
                    return null;
                else
                {
                    String data = await response.Content.ReadAsStringAsync();
                    var jObject = JObject.Parse(data);
                    return jObject.GetValue("response").ToString();                    
                    
                }
            }
        }
        public async Task<bool> CheckInList(int idMovie, String user)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.uriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerJson);
                if (token != null)
                {
                    client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                }
                HttpResponseMessage response = await client.GetAsync("api/List/CheckInList?idMovie=" + idMovie + "&user=" + user);
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                    return true;
                else if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))                
                    return false;                
                else if (response.StatusCode.Equals(HttpStatusCode.NotFound))                
                    return false;                
                else                
                    return false;                
            }
            //HttpStatusCode status = await CallApi<HttpStatusCode>("api/List/CheckInList?idMovie=" + idMovie + "&user=" + user);                            
        }
        public async Task AddMovieToList(int idMovie, String user)
        {
            Lists movie = new Lists();
            movie.IdMovie = idMovie;
            movie.UserEmail = user;
            //context.Lists.Add(movie);
            //context.SaveChanges();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.uriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerJson);
                if (token != null)
                {
                    client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                }
                String json = JsonConvert.SerializeObject(movie);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("api/List/AddMovieToList/", content);
            }
        }
        public async Task RemoveMovieFromList(int idMovie, String user)
        {
            Lists movie = new Lists();
            movie.IdMovie = idMovie;
            movie.UserEmail = user;
            //context.Lists.Remove(movie);
            //context.SaveChanges();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.uriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerJson);
                if (token != null)
                {
                    client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                }
                String json = JsonConvert.SerializeObject(movie);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("api/List/RemoveMovieFromList/", content);
            }
        }
        public async Task<List<Lists>> GetUserList(String user)
        {
            return await CallApi<List<Lists>>("api/List/GetUserList?user=" + user);
        }
        public async Task<Cinephile> GetUser(String user)
        {
            return await CallApi<Cinephile>("api/Cinephile/" + user);
        }
        public async Task RegisterUser(string email, string pass, string name, string lastName, int? age)
        {
            Cinephile newUser = new Cinephile();
            newUser.Email = email;
            newUser.Password = pass;
            newUser.Name = name;
            newUser.LastName = lastName;
            newUser.Age = age.GetValueOrDefault();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.uriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerJson);                
                String json = JsonConvert.SerializeObject(newUser);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("api/Cinephile/", content);                
            }
        }
    }
}
