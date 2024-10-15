namespace DataMatrix.Repositories
{
    public interface IRepository<T>
    {
        public Task<int> Add(T data);
        public Task<int> Update(T data);
        public Task<int> Delete(int Id);
        public Task<List<T>> GetAll();
        //public Task<T> GetById(int id);
        //public Task<T> GetByName(string name);
    }
}
