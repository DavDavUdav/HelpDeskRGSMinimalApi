using System.Runtime.Serialization;

namespace MinimalWebApiHelpDesk.Models
{
    public class TypeUser : Entity
    {
        public string Type { get; set; }

        [IgnoreDataMember]
        public ICollection<Users> Users { get; set; }
    }
}
