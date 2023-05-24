using ServerAppHelpDesk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAppHelpDesk.DataBase.Models
{
    public class Tickets : IEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// Заголовок заявки.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Описание заявки.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Приоритет заявки.
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// Статус заявки.
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Дата создания заявки.
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Дата последнего изменения заявки.
        /// </summary>
        public DateTime LastUpdateDate { get; set; }
        /// <summary>
        /// ID автора (клиента).
        /// </summary>
        public int ClientId { get; set; }
        /// <summary>
        /// ID ответственного сотрудника.
        /// </summary>
        public int AssignedTo { get; set; }

        public Clients Client { get; set; }
        public Specialists AssignedSpecialist { get; set; }
        public ICollection<Messages> Messages { get; set; }
    }
}
