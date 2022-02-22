public interface IStack<T> where T : struct
{
    void Push(T item);
    T Pop();
    bool IsEmpty();
}