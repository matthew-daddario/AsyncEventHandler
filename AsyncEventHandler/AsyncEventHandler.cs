using System.Linq;
using System.Threading.Tasks;

namespace AsyncEventHandler
{
    public delegate Task AsyncEventHandler();

    public delegate Task AsyncEventHandler<in T>(T eventArgs);

    public static class AsyncEventHandlerExtensions
    {
        public static Task InvokeAndWaitAsync(this AsyncEventHandler eventHandler)
        {
            if (eventHandler == null) return Task.CompletedTask;

            var delegates = eventHandler.GetInvocationList().Cast<AsyncEventHandler>();
            var tasks = delegates.Select(it => it.Invoke());

            return Task.WhenAll(tasks);
        }

        public static Task InvokeAndWaitAsync<T>(this AsyncEventHandler<T> eventHandler, T eventArgs)
        {
            if (eventHandler == null) return Task.CompletedTask;

            var delegates = eventHandler.GetInvocationList().Cast<AsyncEventHandler<T>>();
            var tasks = delegates.Select(it => it.Invoke(eventArgs));

            return Task.WhenAll(tasks);
        }

        public static void InvokeAndWait(this AsyncEventHandler eventHandler) => InvokeAndWaitAsync(eventHandler).Wait();

        public static void InvokeAndWait<T>(this AsyncEventHandler<T> eventHandler, T eventArgs) => InvokeAndWaitAsync(eventHandler, eventArgs).Wait();
    }
}
