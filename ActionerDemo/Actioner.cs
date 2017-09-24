using System.Threading;
using System.Threading.Tasks;

namespace ActionerDemo
{
    public class Actioner
    {
        //Singleton instance of semaphore with a total and inital capcity of one
        //Only one thread at a time can access this 
        private static readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1,1);
        
        //Async method does not block any other thread 
        public async void DoAction(Task task)
        {
            //Asynchronously queue here until the sempahore's count is 0 
            await _semaphoreSlim.WaitAsync();

            try //Count = 1
            {
               //Awaits the task synchronously to ensure tasks run one at a time
               await Task.Run(() => task.RunSynchronously()); 
            }
            finally //Ensure release using finally clause
            {
                _semaphoreSlim.Release(); //Count = 0
            }
        }
    }
}
