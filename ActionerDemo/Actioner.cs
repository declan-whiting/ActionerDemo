using System.Threading;
using System.Threading.Tasks;

namespace ActionerDemo
{
    public class Actioner
    {
        private static readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1,1);
 
        public async void DoAction(Task task)
        {
            await _semaphoreSlim.WaitAsync();

            try
            {
               await Task.Run(() => task.RunSynchronously());
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }
    }
}
