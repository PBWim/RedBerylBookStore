namespace RedBerylBookStore.Data.Contract
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using BO = ServiceModels;

    public interface IUserRepository
    {
        IQueryable<BO.User> Get(bool isAll);

        Task<IdentityResult> Create(BO.User user);

        Task<IdentityResult> Update(int userId, bool isActivated);

        Task<IdentityResult> Update(BO.User user);

        Task<bool> SignIn(string email, string password);
    }
}