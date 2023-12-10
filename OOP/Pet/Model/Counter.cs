
namespace Pet.Model
{
    public class ICounter : IDisposable
    {
        private int Counter = 0;
        private bool _disposedValue;

        ~ICounter() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                }
                _disposedValue = true;
            }
        }

        public void add()
        {
            Counter++;
        }

        public int getCount() 
        { 
            return Counter; 
        }

    }
}
