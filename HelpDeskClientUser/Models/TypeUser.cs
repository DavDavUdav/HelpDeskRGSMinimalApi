using System.Runtime.Serialization;
using ClientAppHelpDesk.Models;

namespace ClientAppHelpDesk.Models
{
    public class TypeUser : Entity
    {
        public string Type { get; set; }

        [IgnoreDataMember]
        public ICollection<Users> Users { get; set; }
    }
}
