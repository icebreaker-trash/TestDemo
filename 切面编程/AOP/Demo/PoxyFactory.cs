using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Demo
{
    public class PoxyFactory<T> where T:class,new ()
    {
        private static ProxyGenerator proxyGenerator;

        static PoxyFactory()
        {
            proxyGenerator = new ProxyGenerator();
        }

        public static T GetPoxyInstance(IInterceptor interceptor)
        {
            return proxyGenerator.CreateClassProxy<T>(interceptor);
        }


    }
}
