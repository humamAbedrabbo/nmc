using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Models
{
    public abstract class Entity<T>
    {
        public T Id { get; set; }
    }

    public class Party : Entity<int>
    {
        public string DisplayName { get; set; }
        public string DisplayNameAlt { get; set; }
        public List<PartyContact> Contacts { get; set; } = new();
        public List<PartyIdentifier> Identifiers { get; set; } = new();
        public List<PartyRole> Roles { get; set; } = new();
    }

    public class Person : Party
    {
        public string FirstName { get; set; }
        public string FirstNameAlt { get; set; }
        public string LastName { get; set; }
        public string LastNameAlt { get; set; }
        public string FatherName { get; set; }
        public string FatherNameAlt { get; set; }
        public string MotherName { get; set; }
        public string MotherNameAlt { get; set; }
        public Gender Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public DateTime BirthDate { get; set; }
        public int NumOfDependents { get; set; }
    }

    public class PartyContact : Entity<int>
    {
        public int PartyId { get; set; }
        public Party Party { get; set; }
        public ContactType Type { get; set; }
        public ContactCategory Category { get; set; }
        public string Value { get; set; }
        public string Note { get; set; }
    }

    public class Organization : Party
    {
        public bool IsExternal { get; set; }
        public bool IsFormal { get; set; }
    }

    public class PartyIdentifier : Entity<int>
    {
        public int PartyId { get; set; }
        public Party Party { get; set; }
        public IdentifierType Type { get; set; }
        public string Value { get; set; }
        public string Note { get; set; }
    }

    public class PartyRole : Entity<int>
    {
        public int PartyId { get; set; }
        public Party Party { get; set; }
        public string RoleTypeId { get; set; }
        public RoleType RoleType { get; set; }
        public DateTime From { get; set; } = DateTime.Now;
        public DateTime? Thru { get; set; }
    }

    public class RoleType : Entity<string>
    {
        public string Name { get; set; }
    }

}
