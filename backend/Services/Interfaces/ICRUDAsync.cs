namespace Services.Interfaces
{
    public interface ICRUDAsync<TModel>
    {
        public Task<TModel> Create(TModel model);
        public Task<TModel> Get(int id);
        public Task<List<TModel>> Get(int[] ids);
        public Task<List<TModel>> GetList();
        public Task<TModel> Update(TModel newModel);
        public Task<TModel> Delete(int id);
    }
}
