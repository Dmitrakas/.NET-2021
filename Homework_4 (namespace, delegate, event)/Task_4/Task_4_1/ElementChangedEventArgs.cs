using System;

namespace Task_4_1
{
    public class ElementChangedEventArgs<T> : EventArgs
    {
        public T Old { get; }
        public T New { get; }
        public int Index { get; }

        public ElementChangedEventArgs(int index, T old, T @new) => (Index, Old, New) = (index, old, @new);
    }
}