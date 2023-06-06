
using ClientAppHelpDesk.Models;
using ClientWebApiHelpDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HelpDeskClientUser
{
    public class AccessingToApi
    {
        public static string address = "https://localhost:7242";

        /// <summary>
        /// Новый тип заявки.
        /// </summary>
        /// <param name="typeTicket"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<bool> AddNewTipeTicketAsync(TypeTicket typeTicket)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonSerializer.Serialize(typeTicket), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"{address}/api/typeticket/create", content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    throw new Exception($"{response.StatusCode}, {response.RequestMessage}");
                }

            }
        }

        /// <summary>
        /// Создать специалиста.
        /// </summary>
        /// <param name="specialist"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<bool> AddNewSpecialistAsync(Users specialist)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonSerializer.Serialize(specialist), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"{address}/api/specialist/create", content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    throw new Exception($"{response.StatusCode}, {response.RequestMessage}");
                }

            }
        }

        /// <summary>
        /// Создать клиента.
        /// </summary>
        /// <param name="specialist"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<bool> AddNewClientAsync(Users specialist)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonSerializer.Serialize(specialist), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"{address}/api/client/create", content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    throw new Exception($"{response.StatusCode}, {response.RequestMessage}");
                }

            }
        }

        /// <summary>
        /// Отправка заявки.
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<bool> CreateTicketAsync(Tickets ticket)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonSerializer.Serialize(ticket), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"{address}/api/ticket/create", content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    throw new Exception($"{response.StatusCode}, {response.RequestMessage}");
                }

            }
        }

        /// <summary>
        /// Получить специалистов.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<List<Users>> GetAllSpecialists()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{address}/api/specialists/get");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    try
                    {
                        string jsonStringUnescaped = System.Text.RegularExpressions.Regex.Unescape(result.Substring(1, result.Length - 2));

                        List<Users> specialists = JsonSerializer.Deserialize<List<Users>>(jsonStringUnescaped);

                        //List<Specialists> specialists = JsonSerializer.Deserialize<List<Specialists>>(Regex.Unescape(result));
                        return specialists;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                    return JsonSerializer.Deserialize<List<Users>>(result); ;
                }
                else
                {
                    throw new Exception($"Status code: {response.RequestMessage}");
                }
                // 
            }
        }

        /// <summary>
        /// Получить клиентов.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<List<Users>> GetAllClients()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{address}/api/clients/get");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    try
                    {
                        string jsonStringUnescaped = System.Text.RegularExpressions.Regex.Unescape(result.Substring(1, result.Length - 2));

                        List<Users> specialists = JsonSerializer.Deserialize<List<Users>>(jsonStringUnescaped);

                        //List<Specialists> specialists = JsonSerializer.Deserialize<List<Specialists>>(Regex.Unescape(result));
                        return specialists;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                    return JsonSerializer.Deserialize<List<Users>>(result); ;
                }
                else
                {
                    throw new Exception($"Status code: {response.StatusCode}");
                }
                // 
            }
        }

        /// <summary>
        /// Получить типы заявок.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<List<TypeTicket>> GetAllTicketType()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{address}/api/typeticket/get");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    try
                    {
                        string jsonStringUnescaped = System.Text.RegularExpressions.Regex.Unescape(result.Substring(1, result.Length - 2));

                        List<TypeTicket> specialists = JsonSerializer.Deserialize<List<TypeTicket>>(jsonStringUnescaped);

                        //List<Specialists> specialists = JsonSerializer.Deserialize<List<Specialists>>(Regex.Unescape(result));
                        return specialists;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                    return JsonSerializer.Deserialize<List<TypeTicket>>(result); ;
                }
                else
                {
                    throw new Exception($"Status code: {response.StatusCode}");
                }
                // 
            }
        }

        /// <summary>
        /// Авторизация пользователя.
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<Users> UserAuthorization(LoginModel loginModel)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonSerializer.Serialize(loginModel), Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{address}/api/users/signin", content);
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        string jsonStringUnescaped = Regex.Unescape(result.Substring(1, result.Length - 2));

                        Users lUser = JsonSerializer.Deserialize<Users>(jsonStringUnescaped);
                        return lUser;
                    }
                    catch (Exception ex) 
                    { 
                        throw new Exception(ex.Message); 
                    }
                }
                else
                {
                    throw new Exception($"Status code: {response.RequestMessage}");
                }
                // 
            }
        }







        #region get








        #endregion get
        /*
            
                #region post

                /// <summary>
                /// Авторизация пользователя
                /// </summary>
                /// <returns>object Clients</returns>
                /// <exception cref="Exception"></exception>
                public static async Task<Clients> SignInClientAsync(string log, string pass)
                {
                    using (var client = new HttpClient())
                    {
                        var _loginModel = new LoginModel
                        {
                            Login = log,
                            Password = pass
                        };

                        // объект в json 
                        var content = new StringContent(JsonSerializer.Serialize(_loginModel), Encoding.UTF8, "application/json");

                        var response = await client.PostAsync($"{address}/api/client/signin", content);
                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsStringAsync();
                            return JsonSerializer.Deserialize<Clients>(result);
                        }
                        else
                        {
                            throw new Exception($"Status code: {response.StatusCode}");
                        }
                    }
                }

                /// <summary>
                /// Авторизация специалиста.
                /// </summary>
                /// <param name="log">логин</param>
                /// <param name="pass">пароль</param>
                /// <returns></returns>
                /// <exception cref="Exception"></exception>
                public static async Task<Specialists> SignInSpecialistAsync(string log, string pass)
                {
                    using (var httpClient = new HttpClient())
                    {
                        var _loginModel = new LoginModel
                        {
                            Login = log,
                            Password = pass
                        };

                        var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(_loginModel), System.Text.Encoding.UTF8, "application/json");

                        var responce = await httpClient.PostAsync($"{address}/api/specialist/signin", content);
                        if (responce.IsSuccessStatusCode)
                        {
                            var result = await responce.Content.ReadAsStringAsync();
                            return JsonSerializer.Deserialize<Specialists>(result);
                        }
                        else
                        {
                            throw new Exception($"Код ошибки: {responce.StatusCode},\n Сообщение: {responce.RequestMessage}");
                        }
                    }
                }
        */


        /*
                #endregion post

                #region put

                #endregion put


                #region delete

                /// <summary>
                /// Удаление клиента
                /// </summary>
                /// <param name="client"></param>
                /// <returns></returns>
                public static async Task<bool> DeleteClientAsync(Clients client)
                {
                    using(var httpClient = new HttpClient())
                    {
                        var content = new StringContent(JsonSerializer.Serialize<Clients>(client), Encoding.UTF8, "application.json");
                        var responce = await httpClient.PutAsync($"{address}/api/client/delete", content);
                        if (responce.IsSuccessStatusCode)
                        {
                            return true;
                        }
                        else throw new Exception($"{responce.StatusCode}, {responce.RequestMessage}");
                    }
                }

                /// <summary>
                /// Удаление специалиста.
                /// </summary>
                /// <param name="specialist"></param>
                /// <returns></returns>
                /// <exception cref="Exception"></exception>
                public static async Task<bool> DeleteSpecialistAsync(int id)
                {
                    using(var httpClient = new HttpClient())
                    {

                        var responce = await httpClient.PutAsJsonAsync($"{address}/api/specialist/delete?id={id}", id);
                        if (responce.IsSuccessStatusCode)
                        {
                            return true;
                        }
                        else throw new Exception( $"Код ошибки: {responce.StatusCode}\n Сообщение: {responce.RequestMessage}");
                    }

                }

                #endregion delete

                public static async Task<List<Clients>> GetClientsAsync()
                {
                    var httpClient = new HttpClient();
                    var responce = await httpClient.GetAsync($"{address}/api/users");
                    if (responce.IsSuccessStatusCode)
                    {
                        var content = await responce.Content.ReadAsStringAsync();
                        return JsonSerializer.Deserialize<List<Clients>>(content);
                    }
                    else
                    {
                        throw new Exception( $"Status code: {responce.StatusCode},\n Request message: {responce.RequestMessage}");
                    }
                }
                /**/

    }

    public class Person
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public int Age { get; set; }
    }
}
