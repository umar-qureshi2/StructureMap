using GenFu;
using StructureMap;
using StructureMap.Attributes;
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
            PlayWithStructureMap();
            PlayWithGenFu();

        }

        private static void PlayWithGenFu()
        {
            A.Configure<Customer>().Fill(x => x.LastName, "Senior");
            var customers = A.ListOf<Customer>(10);
            customers.ForEach(x => Console.WriteLine(x));
        }

        private static void PlayWithStructureMap()
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

            var foo = container.GetInstance<Foo>();// The IFoo version is not working, need to check why it doesn't work .ShouldBeOfType<Foo>();
            var bar = foo.Bar;

            Console.WriteLine(foo);
            Console.WriteLine(bar);
        }
    }
}
