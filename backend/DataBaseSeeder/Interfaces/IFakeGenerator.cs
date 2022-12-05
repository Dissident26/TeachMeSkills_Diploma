namespace DataBaseSeeder.Interfaces
{
    internal interface IFakeGenerator<T>
    {
        public List<T> Generate(int amount);
        public T Generate();
    }
}
