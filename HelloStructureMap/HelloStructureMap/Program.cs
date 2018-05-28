using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloStructureMap
{
    class Program
    {

        static void Main(string[] args)
        {
            // Configure and build a brand new
            // StructureMap Container object
            var container = new Container(_ =>
            {
                _.For<IFoo>().Use<Foo>();
                _.For<IBar>().Use<Bar>();
            });

            //// Now, resolve a new object instance of IFoo
            //container.GetInstance<IFoo>()
            //    // should be type Foo
            //    .ShouldBeOfType<Foo>()

            //    // and the IBar dependency too
            //    .Bar.ShouldBeOfType<Bar>();

            var containerScan = new Container(_ =>
            {
                _.Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                });
            });

            var foo = container.GetInstance<Foo>();
            var bar = foo.Bar;

            Console.WriteLine(foo);
            Console.WriteLine(bar);


        }
    }
}
