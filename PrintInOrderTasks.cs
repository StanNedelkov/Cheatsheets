namespace LeetCoteTests
{
    using System.Threading;

    public class Foo
    {

        private SemaphoreSlim firstEvent = new SemaphoreSlim(0, 1);
        private SemaphoreSlim secondEvent = new SemaphoreSlim(0, 1);

        public Foo()
        {

        }

        public void First(Action printFirst)
        {
            printFirst();
            firstEvent.Release();
        }

        public void Second(Action printSecond)
        {
            firstEvent.Wait();
            printSecond();
            secondEvent.Release();
        }

        public void Third(Action printThird)
        {
            secondEvent.Wait();
            printThird();
        }
    }
}
