
namespace Pet.Model
{
    public class ICounter : IDisposable
    {
        private static int counter = 0;
        private static bool disposedStatus;
        public ICounter()
        {
            if (disposedStatus) { throw new Exception("Объект уже создан."); }
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposedStatus == false)
            {
                disposedStatus = true;
            }
            if (disposing)
            {
                disposedStatus = false;
            }
        }

        public void add()
        {
            if (disposedStatus)
            {
                counter++;
            }
            else { throw new Exception("Нельзя получить доступ к закрытому объекту."); }
        }

        public int getCount()
        {
            return counter;
        }

    }
}
