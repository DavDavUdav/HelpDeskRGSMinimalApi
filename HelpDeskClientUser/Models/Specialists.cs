using ServerAppHelpDesk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientAppHelpDesk.DataBase.Models
{
    public class Specialists : IEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// Имя специалиста.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия специалиста.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Адрес эл. почты специалиста
        /// </summary>
        public string Email { get; set; }

        public ICollection<Tickets> AssignedTickets { get; set; }
    }
}
