namespace Services.Interfaces
{
    internal interface IToEntityMapper<T>
    {
        public T MapToEntity();
    }
}
