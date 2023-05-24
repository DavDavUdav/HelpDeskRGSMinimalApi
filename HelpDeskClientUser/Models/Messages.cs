using ServerAppHelpDesk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientAppHelpDesk.DataBase.Models
{
    public class Messages : IEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// Текст сообщения.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// ID отправителя
        /// </summary>
        public int AuthorId { get; set; }
        /// <summary>
        /// ID тикета
        /// </summary>
        public int TicketId { get; set; }
        
        public Specialists Specialist { get; set; }
        public Clients Author { get; set; }
        public Tickets Ticket { get; set; }
    }
}
