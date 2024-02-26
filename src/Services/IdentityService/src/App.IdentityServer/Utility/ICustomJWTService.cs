namespace App.IdentityServer.Utility
{
    public interface ICustomJWTService
    {
        string GetToken(string UserName, string password);
    }
}
