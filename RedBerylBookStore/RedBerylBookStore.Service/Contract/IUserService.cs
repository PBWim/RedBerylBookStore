namespace RedBerylBookStore.Service.Contract
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using ServiceModels;

    public interface IUserService
    {
        IQueryable<User> Get(bool isAll = false);

        Task<IdentityResult> Create(User user);

        Task<IdentityResult> Update(int userId, bool isActivated);

        Task<IdentityResult> Update(User user);

        Task<bool> SignIn(string email, string password);
    }
}