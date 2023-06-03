using MinimalWebApiHelpDesk.Models;
using ServerAppHelpDesk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MinimalWebApiHelpDesk.Models
{
    public class Specialists : Entity
    {
        //public int Id { get; set; }
        /// <summary>
        /// Имя специалиста.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия специалиста.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Логин специалиста.
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль специалиста.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Адрес эл. почты специалиста
        /// </summary>
        public string Email { get; set; }

        [IgnoreDataMember]
        public ICollection<Tickets>? AssignedTickets { get; set; }
    }
}
