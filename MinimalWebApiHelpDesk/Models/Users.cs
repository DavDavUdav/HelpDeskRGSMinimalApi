using System.Runtime.Serialization;

namespace MinimalWebApiHelpDesk.Models
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

        [IgnoreDataMember]
        public TypeUser tUser { get; set; }

        [IgnoreDataMember]
        public ICollection<Tickets> ClientTickets { get; set; }
        [IgnoreDataMember]
        public ICollection<Tickets> SpecialistTickets { get; set; }
    }
}
