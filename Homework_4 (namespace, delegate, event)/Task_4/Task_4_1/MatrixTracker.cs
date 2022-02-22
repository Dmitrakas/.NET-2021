namespace Task_4_1
{
    internal class MatrixTracker<T>
    {
        public bool IsReady { get; private set; } 
        private ElementChangedEventArgs<T> _element;
        private readonly DiagonalMatrix<T> _matrix;
        private MatrixTracker<T> _matrixTracker;

        public MatrixTracker(DiagonalMatrix<T> diagonalMatrix)
        {
            if (diagonalMatrix == null) return;

            diagonalMatrix.ElementChanged += SaveEventArgs;
            _matrix = diagonalMatrix;
        }

        public void Undo()
        {
            if (_element != null && !_matrixTracker.IsReady)
            {
                _matrix[_element.Index, _element.Index] = _element.Old;
                IsReady = false;
            }
            else
            {
                _matrixTracker?.Undo();
            }
        }

        private void SaveEventArgs(object sender, ElementChangedEventArgs<T> element)
        {
            IsReady = true;
            _element = element;
            _matrix.ElementChanged -= SaveEventArgs;
            _matrixTracker = new MatrixTracker<T>(_matrix);
        }
    }
}