namespace NMC.Services
{
    public interface IBarcodeGen
    {
        string Generate(int idInpatient, string room = "");
    }
}