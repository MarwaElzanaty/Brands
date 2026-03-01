using LocalBrands.Data;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;

namespace LocalBrands.Data.Repository.Implementation
{
    public class UserRepo : IUserRepo,IRepository<ApplicationUser>
    {
        // Ref from context
        ApplicationDB context;

        // context injected 
        public UserRepo(ApplicationDB context)
        {
            this.context = context;
        }
        // crud operations
        public void Add(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
