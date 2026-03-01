namespace LocalBrands.Data.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        // crud operations
        // add   update   delete  select 

        public List<T> GetAll();
        public T GetById(int id);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public void DeleteById(int id);

        public void Save(); 

    }
}
