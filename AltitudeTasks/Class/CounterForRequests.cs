using AltitudeTasks.Interfaces;

namespace AltitudeTasks.Class
{
    public class CounterForRequests: ICounterForRequests
    {
        private int counter = 0;
        private readonly object locker = new object();

        public int GetCounter()
        {
            lock (locker)
            {
                return counter;
            }
        }

        public void IncrementCounter()
        {
            lock (locker)
            {
                counter++;
            }
        }
    }
}
