using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private readonly int _interval;
        private readonly Stopwatch _stopwatch;
        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }
        protected override void OnBefore(IInvocation _)
        {
            _stopwatch.Start();
        }
        protected override void OnAfter(IInvocation invocation)
        {
            double totalSeconds = _stopwatch.Elapsed.TotalSeconds;
            //if our service lasts more than we expected then take action
            if (totalSeconds > _interval)
            {
                Debug.WriteLine($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name} takes {totalSeconds} seconds");
            }
            _stopwatch.Reset();
        }
    }
}
