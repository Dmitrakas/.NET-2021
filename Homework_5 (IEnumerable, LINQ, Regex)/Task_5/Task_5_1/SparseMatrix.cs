using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_5_1
{
    public class SparseMatrix : IEnumerable<long>
    {
        private readonly int _height;
        private readonly int _width;
        private readonly long _size;
        private int _version;
        private readonly Dictionary<long, long> _cells = new();

        public SparseMatrix(int height = 1, int width = 1)
        {
            if (height < 1 || width < 1)
            {
                throw new ArgumentException("Matrix width and height can't be less or equals 0!");
            }

            _height = height;
            _width = width;
            _size = width * height;
        }

        public long this[int i, int j]
        {
            get
            {
                ChechIndexes(i, j);
                _cells.TryGetValue(GetIndex(i, j), out var result);
                return result;
            }
            set
            {
                ChechIndexes(i, j);
                _version++;
                _cells[GetIndex(i, j)] = value;
            }
        }

        public override string ToString()
        {
            var result = string.Empty;
            for (var i = 0; i < _height; i++)
            {
                for (var j = 0; j < _width; j++)
                {
                    _cells.TryGetValue(GetIndex(i, j), out var res);
                    result += $"{res, -10} ";
                }

                result += Environment.NewLine;
            }

            return result;

        }

        public IEnumerable<(int, int, long)> GetNonzeroElements()
        {
            for (var j = 0; j < _width; j++)
            {
                for (var i = 0; i < _height; i++)
                {
                    _cells.TryGetValue(GetIndex(i, j), out var _cellValue);
                    if (_cellValue != 0)
                    {
                        yield return (i, j, _cellValue);
                    }
                }

            }
        }

        public int GetCount(int x)
        {
            var count = 0;
            foreach (var item in this)
            {
                if (item == x)
                {
                    count++;
                }
            }
            
            return count;
        }
        private long GetIndex(int i, int j)
        {
            return i * _width + j;
        }
        private void ChechIndexes(int i, int j)
        {
            if (i < 0 || j < 0 || i >= _height || j >= _width)
            {
                throw new ArgumentException("Invalid matrix indexes!");
            }
        }

        public IEnumerator<long> GetEnumerator() => new SparseMatrixEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class SparseMatrixEnumerator : IEnumerator<long>
        {
            private readonly SparseMatrix _sparseMatrix;
            private readonly int _capturedVersion;
            private int _position = -1;

            public SparseMatrixEnumerator(SparseMatrix sparseMatrix)
            {
                _sparseMatrix = sparseMatrix ?? throw new ArgumentNullException(nameof(sparseMatrix));
                _capturedVersion = sparseMatrix._version;
            }

            public long Current
            {
                get
                {
                    if (_capturedVersion != _sparseMatrix._version || _position >= _sparseMatrix._size)
                    {
                        throw new InvalidOperationException();
                    }

                    _sparseMatrix._cells.TryGetValue(_position, out var _cellValue);
                    return _cellValue;
                }
            }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (_capturedVersion != _sparseMatrix._version)
                {
                    throw new InvalidOperationException("Invalid operation!");
                }

                if (_position >= _sparseMatrix._size - 1)
                {
                    return false;
                }

                _position++;
                return true;
            }
            public void Reset() => _position = -1;

            public void Dispose() {}
        }
    }
}