// ��������� ������

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalWebApiHelpDesk;
using MinimalWebApiHelpDesk.Interfaces;
using MinimalWebApiHelpDesk.Models;

using ServerAppHelpDesk.DataBase;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

// ����������� ������������ �� ����� appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false);
/*
builder.Services.AddDbContext<DataStoreDbContext>((provider, options) =>
{
    // ������ ������ ����������� �� IConfiguration
    var config = provider.GetService<IConfiguration>();
    options.UseSqlServer(config.GetConnectionString("DataStoreDbContext"));
});
*/


//builder.Services.AddPersistance(builder.Configuration);

var _dataStore = new DataStore(builder.Configuration);

//var _dataStore = builder.Services.AddPersistance(builder.Configuration);

var app = builder.Build();

// ���������� ���������������� ����������� ������
app.UseDefaultFiles();
app.UseStaticFiles();


// �������� ������ �����������.
app.MapPost("/api/specialist/create", async (HttpContext http) =>
{
    try
    {
        var json = await http.Request.ReadFromJsonAsync<Users>();
        var sotr = await _dataStore.GetFirstFilteredAsync<TypeUser>(x => x.Type=="���������");
        json.TypeUser = sotr.Id;

        await _dataStore.AddAsync<Users>(json);
        return Results.Ok();
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"������ ������ JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"��������� ������: {ex.Message}");
    }
});

// �������� ������������
app.MapGet("/api/specialists/get", async () =>
{
    try
    {
        var _type = await _dataStore.GetFirstFilteredAsync<TypeUser>(x => x.Type == "���������");
        var specialists = await _dataStore.GetAllFilteredAsync<Users>(x => x.TypeUser == _type.Id);

        if (specialists == null)
        {
            return Results.NotFound("����������� �� �������");
        }

        return Results.Ok(JsonSerializer.Serialize(specialists));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"������ ������ JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"��������� ������: {ex.Message}");
    }


});

// �������� ������ �������.
app.MapPost("/api/client/create", async (HttpContext http) =>
{
    try
    {
        var json = await http.Request.ReadFromJsonAsync<Users>();
        var sotr = await _dataStore.GetFirstFilteredAsync<TypeUser>(x => x.Type == "������");
        json.TypeUser = sotr.Id;

        await _dataStore.AddAsync<Users>(json);
        return Results.Ok();
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"������ ������ JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"��������� ������: {ex.Message}");
    }
});

// �������� ������.
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
        return Results.BadRequest($"������ ������ JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"��������� ������: {ex.Message}");
    }
});

// �������� ���� ������.
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
        return Results.BadRequest($"������ ������ JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"��������� ������: {ex.Message}");
    }
});

// ����������� ������������
app.MapPost("/api/users/signin", async (HttpContext http) =>
{
    try
    {
        var json = await http.Request.ReadFromJsonAsync<LoginModel>();
        var user = await _dataStore.GetFirstFilteredAsync<Users>(x => x.Login == json.Login && x.Password == json.Password);
        if(user == null)
        {
            return Results.NotFound("����� ��� ������ �� ������");
        }

        //var tUser = await _dataStore.GetFirstFilteredAsync<TypeUser>(x => x.Id == user.TypeUser);

        var locUser = new Users
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            TypeUser = user.TypeUser,
            Login = user.Login,
            Password = user.Password,
            Phone = user.Phone
        };
        return Results.Ok(JsonSerializer.Serialize(locUser));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"������ ������ JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"��������� ������: {ex.Message}");
    }
});

// �������� ��������.
app.MapGet("/api/clients/get", async () =>
{
    try
    {
        var _type = await _dataStore.GetFirstFilteredAsync<TypeUser>(x => x.Type == "������");
        var specialists = await _dataStore.GetAllFilteredAsync<Users>(x => x.TypeUser == _type.Id);

        if (specialists == null)
        {
            return Results.NotFound("����������� �� �������");
        }

        return Results.Ok(JsonSerializer.Serialize(specialists));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"������ ������ JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"��������� ������: {ex.Message}");
    }


});

// �������� ���� ������.
app.MapGet("/api/typeticket/get", async () =>
{
    try
    {
        var specialists = await _dataStore.GetAllAsync<TypeTicket>();

        if (specialists == null)
        {
            return Results.NotFound("����������� �� �������");
        }

        return Results.Ok(JsonSerializer.Serialize(specialists));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"������ ������ JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"��������� ������: {ex.Message}");
    }


});

// �������� ���������� ������.
app.MapGet("/api/tickets/actual/get", async () =>
{
    try
    {

        var tickets = await _dataStore.GetAllFilteredAsync<Tickets>(x => x.Status == "��������" || x.Status == "� ������");

        if (tickets == null)
        {
            return Results.NotFound("������ �� �������");
        }

        return Results.Ok(JsonSerializer.Serialize(tickets));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"������ ������ JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"��������� ������: {ex.Message}");
    }
});

// �������� ������ ������������.
app.MapPost("/api/user/tickets/get", async (HttpContext http) =>
{
    try
    {
        var json = await http.Request.ReadFromJsonAsync<Users>();

        var tickets = await _dataStore.GetAllFilteredAsync<Tickets>(x => x.ClientId == json.Id);

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        return Results.Ok(JsonSerializer.Serialize(tickets.ToList(), options));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        Console.WriteLine(ex.Message);
        return Results.BadRequest($"������ ������ JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return Results.BadRequest($"��������� ������: {ex.Message}");
    }


});

// �������� ������ �� id.
app.MapPost("/api/tickets/getbyid", async (HttpContext http) =>
{
    try
    {
        var json = await http.Request.ReadFromJsonAsync<int>();

        var ticket = await _dataStore.GetFirstFilteredAsync<Tickets>(x => x.Id == json);

        return Results.Ok(JsonSerializer.Serialize(ticket));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        Console.WriteLine(ex.Message);
        return Results.BadRequest($"������ ������ JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return Results.BadRequest($"��������� ������: {ex.Message}");
    }
});

// ��������� ������.
app.MapPost("/api/ticket/update", async (HttpContext http) =>
{
    try
    {
        var json = await http.Request.ReadFromJsonAsync<Tickets>();
        await _dataStore.UpdateAsync<Tickets>(json);
        return Results.Ok();
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        return Results.BadRequest($"������ ������ JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"��������� ������: {ex.Message}");
    }
});



// �������� ������������ �� id.
app.MapPost("/api/user/getbyid", async (HttpContext http) =>
{
    try
    {
        var json = await http.Request.ReadFromJsonAsync<int>();

        var user = await _dataStore.GetFirstFilteredAsync<Users>(x => x.Id == json);

        return Results.Ok(JsonSerializer.Serialize(user));
    }
    catch (Newtonsoft.Json.JsonReaderException ex)
    {
        Console.WriteLine(ex.Message);
        return Results.BadRequest($"������ ������ JSON: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return Results.BadRequest($"��������� ������: {ex.Message}");
    }
});

app.Run();

Console.ReadKey();