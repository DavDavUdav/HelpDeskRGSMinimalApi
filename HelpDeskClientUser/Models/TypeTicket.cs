namespace ClientAppHelpDesk.Models
{
    public class TypeTicket : Entity
    {
        public string NameType { get; set; } 

        public ICollection<Tickets> Tickets { get; set; }
    }
}
