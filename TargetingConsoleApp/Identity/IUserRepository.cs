namespace TargetingConsoleApp.Identity
{
    interface IUserRepository
    {
        Task<User> GetUser(string id);
    }
}
