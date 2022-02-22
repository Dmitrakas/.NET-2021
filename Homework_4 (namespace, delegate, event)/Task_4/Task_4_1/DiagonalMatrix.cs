using System;

namespace Task_4_1
{
    public class DiagonalMatrix<T> 
    {
        private readonly T[] _data;

        public int Size => _data.Length;

        public T this[int i, int j]
        {
            get => IsCorrect(i) && i == j ? _data[i] : default;
            set
            {
                if (IsCorrect(i) && i == j && !Equals(_data[i], value))
                {
                    OnElementChanged(new ElementChangedEventArgs<T>(i, _data[i], value));
                    _data[i] = value;
                }
            }
        }

        public DiagonalMatrix(int size = 0)
        {
            if (size < 0)
            {
                throw new ArgumentException("Size can't be less than 0!");
            }

            _data = new T[size];
        }

        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

        protected virtual void OnElementChanged(ElementChangedEventArgs<T> e)
        {
            ElementChanged?.Invoke(this, e);
        }

        private bool IsCorrect(int i)
        {
            if (i >= 0 && i < Size)
            {
                return true;
            }

            throw new IndexOutOfRangeException("Index can't be negative or more than matrix size!");
        }

        public override string ToString()
        {
            var result = string.Empty;
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    if (this[i, j] == null)
                    {
                        result += "null ";
                    }

                    result += $"{this[i, j]} ";
                }

                result += Environment.NewLine;
            }

            return result;
        }
    }
}