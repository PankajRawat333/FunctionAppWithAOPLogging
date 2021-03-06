﻿using ArxOne.MrAdvice.Advice;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace FunctionAppForLogTest.Aspect
{
    public class LoggerAspectAttribute : Attribute, IMethodAdvice
    {
        public void Advise(MethodAdviceContext context)
        {
            //Logger initilizer here
            Console.WriteLine($"{context.TargetType.Name} started...");

            try
            {
                context.Proceed(); // this calls the original method
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