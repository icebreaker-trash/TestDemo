using Castle.DynamicProxy;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Xunit;

namespace Demo
{
    public class MyClass : IMyClass
    {
        public virtual void MyMethod()
        {
            Debug.WriteLine("My Mehod");
        }
    }

    public class TestIntercept : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Debug.WriteLine(invocation.ReturnValue);
            invocation.Proceed();
            Debug.WriteLine("222");
        }
    }
    
    public class Test_tests
    {
        [Fact]
        
        public void tests()
        {
            TestIntercept t = new TestIntercept();
            var pg = PoxyFactory<MyClass>.GetPoxyInstance(t);
            pg.MyMethod(); 
        }
    } 
}
