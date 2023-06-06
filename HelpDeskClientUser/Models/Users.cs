using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using ClientAppHelpDesk.Models;


namespace ClientAppHelpDesk.Models

{
    public class Users : Entity
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Тип пользователя(специалист или клиент).
        /// </summary>
        public int TypeUser { get; set; }
        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Адрес эл. почты.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Номер телефона.
        /// </summary>
        public string Phone { get; set; }

    }
}
