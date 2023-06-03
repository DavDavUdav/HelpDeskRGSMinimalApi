﻿using MinimalWebApiHelpDesk.Models;
using ServerAppHelpDesk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalWebApiHelpDesk.Models
{
    public class Tickets : Entity
    {
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
        public string Priority { get; set; }
        /// <summary>
        /// Статус заявки.
        /// </summary>
        public string Status { get; set; }
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

        /// <summary>
        /// Клиент.
        /// </summary>
        public Users Client { get; set; }
        /// <summary>
        /// Сотрудник.
        /// </summary>
        public Users Specialist { get; set; }
        /// <summary>
        /// Тип заявки.
        /// </summary>
        public TypeTicket TypeTicket { get; set; }
    }
}
