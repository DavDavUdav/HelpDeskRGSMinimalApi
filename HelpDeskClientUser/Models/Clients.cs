using ServerAppHelpDesk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientAppHelpDesk.DataBase.Models
{
    public class Clients : IEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// Имя клиента.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия клиента.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Адрес эл. почты клиента.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Номер телефона клиента.
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Дата регистрации клиента.
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Дата последней активности клиента.
        /// </summary>
        public DateTime LastActivityDate { get; set; }

        public ICollection<Tickets> Tickets { get; set; }
    }
}
