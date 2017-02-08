namespace Common.Interfaces.Helpers
{
    public interface IPasswordHelper
    {
         string Encrypt(string password);

         bool IsValid(string rawPassword, string hashedPassword);
    }
}