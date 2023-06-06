using ClientAppHelpDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAppHelpDesk.Models
{
    public class LocalUser : Entity
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
        public string TypeUser { get; set; }
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
