// начальные данные

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalWebApiHelpDesk.Models;

using ServerAppHelpDesk.DataBase;
using System.Text.Json;
using System.Text.RegularExpressions;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

// Подключаем функциональность статических файлов
app.UseDefaultFiles();
app.UseStaticFiles();

DataStore _dataStore = new DataStore();
DataStoreDbContext _dataStoreDbContext = new DataStoreDbContext();

// Создание нового специалиста.
app.MapPost("/api/specialist/create", async (HttpContext http) =>
{
    try
    {
        var json = await http.Request.ReadFromJsonAsync<Users>();
        var sotr = await _dataStore.GetFirstFilteredAsync<TypeUser>(x => x.Type=="Сотрудник");
        json.TypeUser = sotr.Id;

        await _dataStore.AddAsync<Users>(json);
        return Results.Ok();
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }
});

// Создание нового клиента.
app.MapPost("/api/client/create", async (HttpContext http) =>
{
    try
    {
        var json = await http.Request.ReadFromJsonAsync<Users>();
        var sotr = await _dataStore.GetFirstFilteredAsync<TypeUser>(x => x.Type == "Клиент");
        json.TypeUser = sotr.Id;

        await _dataStore.AddAsync<Users>(json);
        return Results.Ok();
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }
});

// Создание заявки.
app.MapPost("/api/ticket/create", async (HttpContext http) =>
{
    try
    {
        var json = await http.Request.ReadFromJsonAsync<Tickets>();
        await _dataStore.AddAsync<Tickets>(json);
        return Results.Ok();
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }
});

// Создание типа заявки.
app.MapPost("/api/typeticket/create", async (HttpContext http) =>
{
    try
    {
        var json = await http.Request.ReadFromJsonAsync<TypeTicket>();
        await _dataStore.AddAsync<TypeTicket>(json);
        return Results.Ok();
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }
});

// Авторизация пользователя
app.MapPost("/api/users/signin", async (HttpContext http) =>
{
    try
    {
        var json = await http.Request.ReadFromJsonAsync<LoginModel>();
        var user = await _dataStore.GetFirstFilteredAsync<Users>(x => x.Login == json.Login && x.Password == json.Password);
        if(user == null)
        {
            return Results.NotFound("Логин или пароль не верный");
        }

        var tUser = await _dataStore.GetFirstFilteredAsync<TypeUser>(x => x.Id == user.TypeUser);

        var locUser = new LocalUser
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            TypeUser = tUser.Type,
            Login = user.Login,
            Password = user.Password,
            Phone = user.Phone
        };
        return Results.Ok(JsonSerializer.Serialize(locUser));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }
});

// Получить специалистов
app.MapGet("/api/specialists/get", async () =>
{
    try
    {
        var _type = await _dataStore.GetFirstFilteredAsync<TypeUser>(x => x.Type == "Сотрудник");
        var specialists = await _dataStore.GetAllFilteredAsync<Users>(x => x.TypeUser == _type.Id);

        if (specialists == null)
        {
            return Results.NotFound("Специалисты не найдены");
        }

        return Results.Ok(JsonSerializer.Serialize(specialists));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }


});

// Получить клиентов.
app.MapGet("/api/clients/get", async () =>
{
    try
    {
        var _type = await _dataStore.GetFirstFilteredAsync<TypeUser>(x => x.Type == "Клиент");
        var specialists = await _dataStore.GetAllFilteredAsync<Users>(x => x.TypeUser == _type.Id);

        if (specialists == null)
        {
            return Results.NotFound("Специалисты не найдены");
        }

        return Results.Ok(JsonSerializer.Serialize(specialists));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }


});

app.MapGet("/api/typeticket/get", async () =>
{
    try
    {
        var specialists = await _dataStore.GetAllAsync<TypeTicket>();

        if (specialists == null)
        {
            return Results.NotFound("Специалисты не найдены");
        }

        return Results.Ok(JsonSerializer.Serialize(specialists));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }


});

app.Run();

/*
// Получение клиента по ID.
app.MapGet("/api/client/{id}/get", async (int id) =>
{
    try
    {
        var client = await _dataStore.GetFirstFilteredAsync<Clients>(x => x.Id == id);
        if (client==null)
        {
            return Results.NotFound("Клиент не найден");
        }
        return Results.Ok(System.Text.Json.JsonSerializer.Serialize<Clients>(client));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }

    
});

// Получение всех специалистов.
app.MapGet("/api/specialists/get", async () =>
{
    try
    {
        var specialists = await _dataStore.GetAllAsync<Specialists>();

        if (specialists == null)
        {
            return Results.NotFound("Специалисты не найдены");
        }

        return Results.Ok(JsonSerializer.Serialize(specialists));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }

    
});

// Получить специалиста по ID.
app.MapGet("/api/specialist/{id}/get", async (int id) =>
{
    try
    {
        var specialist = await _dataStore.GetFirstFilteredAsync<Specialists>(x => x.Id == id);

        if (specialist==null)
        {
            return Results.NotFound("Специалист не найден");
        }
        return Results.Ok(JsonSerializer.Serialize<Specialists>(specialist));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }

    
});



// Получить все заявки.
app.MapGet("/api/tickets/all/get", async () =>
{
    try
    {
        var tickets = await _dataStore.GetAllAsync<Tickets>();

        if (tickets==null)
        {
            return Results.NotFound("Заявок нет");
        }
        return Results.Ok(JsonSerializer.Serialize(tickets));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }

    
});

// Получить открытые заявки.
app.MapGet("/api/tickets/get/open", async () =>
{
    try
    {
        var tickets = await _dataStore.GetAllFilteredAsync<Tickets>(x => x.Status == "Открыта");

        if (tickets == null)
        {
            return Results.NotFound("Заявок нет");
        }
        return Results.Ok(JsonSerializer.Serialize(tickets));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }

    
});

// Получить заявки в работе.
app.MapGet("/api/tickets/get/inWork", async () =>
{
    try
    {
        var tickets = await _dataStore.GetAllFilteredAsync<Tickets>(x => x.Status == "В работе");

        if (tickets == null)
        {
            return Results.NotFound("Заявок нет");
        }
        return Results.Ok(JsonSerializer.Serialize(tickets));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }

    
});

// Получить выполненные заявки.
app.MapGet("/api/tickets/get/complete", async () =>
{
    try
    {
        var tickets = await _dataStore.GetAllFilteredAsync<Tickets>(x => x.Status == "Выполнена");

        if (tickets == null)
        {
            return Results.NotFound("Заявок нет");
        }

        return Results.Ok(JsonSerializer.Serialize(tickets));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }

    
});

// Получить отклоненныйе заявки.
app.MapGet("/api/tickets/get/rejected", async () =>
{
    try
    {
        var tickets = await _dataStore.GetAllFilteredAsync<Tickets>(x => x.Status == "Отклонена");

        if (tickets == null)
        {
            return Results.NotFound("Заявок нет");
        }

        return Results.Ok(JsonSerializer.Serialize(tickets));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }

    
});

// Получить типы заявок.
app.MapGet("/api/typeticket/get", async () =>
{
    try
    {
        var tickets = await _dataStore.GetAllAsync<TypeTicket>();

        if (tickets == null)
        {
            return Results.NotFound("Типов заявок нет");
        }

        return Results.Ok(JsonSerializer.Serialize(tickets));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }


});

#endregion get

// POST: создать новый ресурс.
#region post


// Создание нового клиента
app.MapPost("/api/client/create", async (HttpContext http) =>
{
    try
    {
        var client = await http.Request.ReadFromJsonAsync<Clients>();
        await _dataStore.AddAsync<Clients>(client);
        return Results.Ok();
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }
});

// Получение клиента по log pass.
app.MapPost("/api/client/signin", async (HttpContext http) =>
{
    try
    {
        var loginpass = await http.Request.ReadFromJsonAsync<LoginModel>();


        var client = await _dataStore.GetFirstFilteredAsync<Clients>(x => x.Login == loginpass.Login && x.Password == loginpass.Password);
        if (client == null)
        {
            return Results.NotFound("Клиент не найден");
        }
        return Results.Ok(System.Text.Json.JsonSerializer.Serialize<Clients>(client));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }


});


// Создание нового специалиста
app.MapPost("/api/specialist/create", async (HttpContext http) =>
{
    try
    {
        var json = await http.Request.ReadFromJsonAsync<Specialists>();
        await _dataStore.AddAsync<Specialists>(json);
        return Results.Ok();
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }
});

// Получение специалиста по log pass.
app.MapPost("/api/specialist/signin", async (HttpContext http) =>
{
    try
    {
        var loginpass = await http.Request.ReadFromJsonAsync<LoginModel>();


        var client = await _dataStore.GetFirstFilteredAsync<Specialists>(x => x.Login == loginpass.Login && x.Password == loginpass.Password);
        if (client == null)
        {
            return Results.NotFound("Специалист не найден");
        }
        return Results.Ok(System.Text.Json.JsonSerializer.Serialize<Specialists>(client));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }


});


// Создание заявки
app.MapPost("/api/ticket/create", async (HttpContext http) =>
{
    try
    {
        var json = await http.Request.ReadFromJsonAsync<Tickets>();
        await _dataStore.AddAsync<Tickets>(json);
        return Results.Ok();
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }
});

// Добавление нового типа заявки
app.MapPost("/api/typeticket/create", async (HttpContext http) =>
{
    try
    {
        var json = await http.Request.ReadFromJsonAsync<TypeTicket>();
        await _dataStore.AddAsync<TypeTicket>(json);
        return Results.Ok();
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }
});

#endregion post

// PUT: обновить существующий ресурс
#region put
// Обновить заявку, данные клиента, данные специалиста

// Обновление данных заявки
app.MapPut("/api/ticket/update", async (HttpContext http) =>
{
    try
    {
        var json = await http.Request.ReadFromJsonAsync<Tickets>();
        await _dataStore.UpdateAsync<Tickets>(json);
        return Results.Ok();
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }
});

// Обновление данных специалистов
app.MapPut("/api/specialist/update", async (HttpContext http) =>
{
    try
    {
        var json = await http.Request.ReadFromJsonAsync<Specialists>();
        await _dataStore.UpdateAsync<Specialists>(json);
        return Results.Ok();
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }
});

// Обновить данные клиента
app.MapPut("/api/client/update", async (HttpContext http) =>
{
    try
    {
        var json = await http.Request.ReadFromJsonAsync<Clients>();
        await _dataStore.UpdateAsync<Clients>(json);
        return Results.Ok();
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }
});

//todo Обновление данных типа заявки
#endregion put

// DELETE: Удалить ресурс
#region delete

// Удаление заявки
app.MapPut("/api/ticket/delete", async (int id) =>
{
    try
    {
        
        await _dataStore.DeleteAsync<Tickets>(id);
        return Results.Ok();
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }
});

// Удаление данных специалиста
app.MapPut("/api/specialist/delete", async (int id) =>
{
    try
    {
        
        await _dataStore.DeleteAsync<Specialists>(id);
        return Results.Ok();
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }
});

// Удаление данных клиента.
app.MapPut("/api/client/delete", async (int id) =>
{
    try
    {
        
        await _dataStore.DeleteAsync<Clients>(id);
        return Results.Ok();
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"Ошибка чтения JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Произошла ошибка: {ex.Message}");
    }
});

//todo Удаление данных типа заявки
#endregion delete
*/



//app.MapGet("/api/users", () => users);
/*
List<Person> users = new List<Person>
{
    new() { Id = Guid.NewGuid().ToString(), Name = "Tom", Age = 37 },
    new() { Id = Guid.NewGuid().ToString(), Name = "Bob", Age = 41 },
    new() { Id = Guid.NewGuid().ToString(), Name = "Sam", Age = 24 }
};
*/
/*
app.MapGet("/api/users/{id}", (string id) =>
{
    // получаем пользователя по id
    Person? user = users.FirstOrDefault(u => u.Id == id);
    // если не найден, отправляем статусный код и сообщение об ошибке
    if (user == null) return Results.NotFound(new { message = "Пользователь не найден" });

    // если пользователь найден, отправляем его
    return Results.Json(user);
});

app.MapDelete("/api/users/{id}", (string id) =>
{
    // получаем пользователя по id
    Person? user = users.FirstOrDefault(u => u.Id == id);

    // если не найден, отправляем статусный код и сообщение об ошибке
    if (user == null) return Results.NotFound(new { message = "Пользователь не найден" });

    // если пользователь найден, удаляем его
    users.Remove(user);
    return Results.Json(user);
});

app.MapPost("/api/users", (Person user) => {

    // устанавливаем id для нового пользователя
    user.Id = Guid.NewGuid().ToString();
    // добавляем пользователя в список
    users.Add(user);
    return user;
});

app.MapPut("/api/users", (Person userData) => {

    // получаем пользователя по id
    var user = users.FirstOrDefault(u => u.Id == userData.Id);
    // если не найден, отправляем статусный код и сообщение об ошибке
    if (user == null) return Results.NotFound(new { message = "Пользователь не найден" });
    // если пользователь найден, изменяем его данные и отправляем обратно клиенту

    user.Age = userData.Age;
    user.Name = userData.Name;
    return Results.Json(user);
});

app.Run();

public class Person
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public int Age { get; set; }
}


/*
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
*/