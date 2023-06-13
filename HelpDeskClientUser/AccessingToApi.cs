
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
        /// Получить клиента.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<Users> GetUserByIdAsync(int id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var content = new StringContent(JsonSerializer.Serialize(id), Encoding.UTF8, "application/json");

                    var response = await client.PostAsync($"{address}/api/user/getbyid", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        string jsonStringUnescaped = System.Text.RegularExpressions.Regex.Unescape(result.Substring(1, result.Length - 2));

                        Users tickets = JsonSerializer.Deserialize<Users>(jsonStringUnescaped);
                        return tickets;
                    }
                    else
                    {
                        throw new Exception($"Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Users user = new();
                    return user;
                }
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
        /// Получить актуальные заявки.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<List<Tickets>> GetActualTicketsAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{address}/api/tickets/actual/get");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    try
                    {
                        string jsonStringUnescaped = System.Text.RegularExpressions.Regex.Unescape(result.Substring(1, result.Length - 2));

                        List<Tickets> specialists = JsonSerializer.Deserialize<List<Tickets>>(jsonStringUnescaped);

                        //List<Specialists> specialists = JsonSerializer.Deserialize<List<Specialists>>(Regex.Unescape(result));
                        return specialists;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                    return JsonSerializer.Deserialize<List<Tickets>>(result); ;
                }
                else
                {
                    throw new Exception($"Status code: {response.StatusCode}");
                }
                // 
            }
        }

        /// <summary>
        /// Получить заявки от пользователя по id пользователя.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<List<Tickets>> GetUserTicketsAsync(Users user)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

                    var response = await client.PostAsync($"{address}/api/user/tickets/get", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                    
                        string jsonStringUnescaped = System.Text.RegularExpressions.Regex.Unescape(result.Substring(1, result.Length - 2));

                        //List<Tickets> tickets = JsonSerializer.Deserialize<List<Tickets>>(jsonStringUnescaped);
                        var options = new JsonSerializerOptions
                        {
                            ReferenceHandler = ReferenceHandler.Preserve
                        };
                        List<Tickets> tickets = JsonSerializer.Deserialize<List<Tickets>>(jsonStringUnescaped, options);

                        //List<Tickets> tickets = JsonSerializer.Deserialize<List<Tickets>>(Regex.Unescape(result));
                        return tickets;


                        //return JsonSerializer.Deserialize<List<Tickets>>(result);
                    }
                    else
                    {
                        throw new Exception($"Status code: {response.StatusCode}");
                    }

                }
                catch (Exception ex) 
                { 
                    MessageBox.Show(ex.Message);
                    List<Tickets> ltickets = new();
                    return ltickets; 
                }
            }
        }

        /// <summary>
        /// Получить заявку по id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<Tickets> GetUserTicketsByIdAsync(int id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var content = new StringContent(JsonSerializer.Serialize(id), Encoding.UTF8, "application/json");

                    var response = await client.PostAsync($"{address}/api/tickets/getbyid", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        string jsonStringUnescaped = System.Text.RegularExpressions.Regex.Unescape(result.Substring(1, result.Length - 2));
                        
                        Tickets tickets = JsonSerializer.Deserialize<Tickets>(jsonStringUnescaped);
                        return tickets;
                    }
                    else
                    {
                        throw new Exception($"Status code: {response.StatusCode}");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Tickets ltickets = new();
                    return ltickets;
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



        //todo: дописать изменение данных заявки.
        /// <summary>
        /// Изменение заявки.
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<bool> UpdateTicketAsync(Tickets ticket)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonSerializer.Serialize(ticket), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"{address}/api/ticket/update", content);
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


    }

    public class Person
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public int Age { get; set; }
    }
}
