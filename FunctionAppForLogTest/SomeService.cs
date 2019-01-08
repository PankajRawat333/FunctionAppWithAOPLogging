using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionAppForLogTest
{
    public class SomeService
    {
        public async Task DoSomething()
        {
            await Task.Delay(1000);
            throw new Exception("Exception from Service");
        }
    }
}