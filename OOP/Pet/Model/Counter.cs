
namespace Pet.Model
{
    public class ICounter : IDisposable
    {
        private static int counter = 0;

        public ICounter() { }

        public void add() 
        {
            counter++;
        }

        void IDisposable.Dispose() 
        { 
        
        }
        public void Dispose() { }

        public int getCount() 
        { 
            return counter; 
        }

    }
}
