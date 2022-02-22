public static class StackExtension
{
    public static IStack<T> Reverse<T>(this IStack<T> stack) where T : struct
    {
        var reversed = new Stack<T>();

        if (stack == null)
        {
            return reversed;
        }

        var aux = new Stack<T>();
        while (!stack.IsEmpty())
        {
            var item = stack.Pop();
            reversed.Push(item);
            aux.Push(item);
        }

        while (!aux.IsEmpty())
        {
            stack.Push(aux.Pop());
        }

        return reversed;
    }
}