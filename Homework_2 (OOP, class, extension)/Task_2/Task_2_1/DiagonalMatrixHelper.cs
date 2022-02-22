public static class DiagonalMatrixHelper
{
    public static DiagonalMatrix Add(this DiagonalMatrix a, DiagonalMatrix b)
    {
        a ??= new DiagonalMatrix();
        b ??= new DiagonalMatrix();

        if (a.Size < b.Size)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }

        var data = new int[a.Size];
        for (var i = 0; i < b.Size; i++)
        {
            data[i] = a[i, i] + b[i, i];
        }

        for (var i = b.Size; i < a.Size; i++)
        {
            data[i] = a[i, i];
        }

        return new DiagonalMatrix(data);
    }
}