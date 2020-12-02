using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male,

        [Display(Name = "Female")]
        Female
    }

    public enum MaritalStatus
    {
        Unspecified,
        Single,
        Married
    }

    public enum ContactType
    {
        Phone,
        Email,
        Address,
        Website
    }

    public enum ContactCategory
    {
        Personal,
        Work,
        Residence,
        Other
    }

    public enum IdentifierType
    {
        PID,
        DL,
        EMPNO,
        BARCODE,
        OTHER
    }

    public enum Language
    {
        En,
        Ar
    }

    public enum ActivePage
    {
        Dashboard,
        Doctors,
        InPatients,
        OutPatients,
        Employees,
        Departments
    }
}
