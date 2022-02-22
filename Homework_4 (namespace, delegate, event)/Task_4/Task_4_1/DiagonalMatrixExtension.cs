using System;

namespace Task_4_1
{
    public static class DiagonalMatrixExtension
    {
        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> a, DiagonalMatrix<T> b,
            Func<T, T, T> addition) 
        {
            a ??= new DiagonalMatrix<T>();
            b ??= new DiagonalMatrix<T>();

            if (a.Size < b.Size)
            {
                (a, b) = (b, a);
            }

            var c = new DiagonalMatrix<T>(a.Size);

            for (var i = 0; i < b.Size; i++)
            {
                c[i, i] = addition(a[i, i], b[i, i]);
            }

            for (var i = b.Size; i < a.Size; i++)
            {
                c[i, i] = a[i, i];
            }

            return c;
        }
    }
}