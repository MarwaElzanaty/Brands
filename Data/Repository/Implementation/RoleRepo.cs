using LocalBrands.Data;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;

namespace LocalBrands.Data.Repository.Implementation
{
    public class RoleRepo : IRoleRepo,IRepository<Role>
    {
        // Ref from context
        ApplicationDB context;

        // context injected 
        public RoleRepo(ApplicationDB context)
        {
            this.context = context;
        }
        // Crud Operations 
        public void Add(Role entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Role entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetAll()
        {
            throw new NotImplementedException();
        }

        public Role GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
