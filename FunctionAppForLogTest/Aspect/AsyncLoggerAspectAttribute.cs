using ArxOne.MrAdvice.Advice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionAppForLogTest.Aspect
{
    public class AsyncLoggerAspectAttribute : Attribute, IMethodAsyncAdvice
    {
        public async Task Advise(MethodAsyncAdviceContext context)
        {
            //Logger initilizer here
            Console.WriteLine($"{context.TargetType.Name} started...");
            try
            {
                await context.ProceedAsync(); // this calls the original method
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine($"{context.TargetType.Name} completed...");
            }
        }
    }
}