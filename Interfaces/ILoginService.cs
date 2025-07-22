namespace EcommerceApi.Interfaces
{
    public interface ILoginService
    {
        Task<string> AuthenticateAsync(string username, string password);
    }
}
