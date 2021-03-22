using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace IoC_Container
{
    //https://www.tutorialsteacher.com/ioc/ioc-container
    class Program
    {
        static void Main(string[] args)
        {
            //the Driver class depends on the ICar interface. So, when we instantiate the Driver class object, then we will have to pass an instance of a class which implements the ICar interface, such as the BMW, Audi or Ford class as shown below
            Driver driver = new Driver(new BMW());
            driver.RunCar();

            /*In the above example, we created and passed an object of BMW while creating an object of the Driver class. Thus, we injected the dependency of the Driver class manually. Now, we will use Unity container to understand different ways to register and resolve dependencies.
             In order to use Unity container, we first need to create an object of it. You can use any class which implements the IUnityContainer interface. Unity container includes the UnityContainer class in the Microsoft.Practices.Unity namespace that implements the IUnityContainer interface. If you need to extend the container, then you can create your own custom class and implement the IUnityContainer interface as per your need.
*/
            var container_1 = new UnityContainer();

            /*Next, we need to register type-mapping.
Before Unity resolves the dependencies, we need to register the type-mapping with the container, so that it can create the correct object for the given type. 
            Use the RegisterType() method to register a type mapping. Basically, it configures which class to instantiate for which interface or base class. 
            For example, if we want Unity container to create and supply an object of the BMW class whenever it needs to supply a dependency of the ICar interface, then we first need to register it as shown below.
*/
            IUnityContainer container = new UnityContainer();

            //Here, container.RegisterType<ICar, BMW>() requests Unity to create an object of the BMW class and inject it through a constructor whenever you need to inject an object of ICar.
            container.RegisterType<ICar, BMW>();

            /*So now, after registration, we can use the Resolve() method.
            Unity creates an object of the specified class and automatically injects the dependencies using the Resolve() method. We have registered BMW with ICar above. Now, we can instantiate the Driver class using Unity container without using the new keyword as shown below.*/
            //IUnityContainer container = new UnityContainer();
            //container.RegisterType<ICar, BMW>();// Map ICar with BMW 

            //Resolves dependencies and returns the Driver object 
            Driver drv = container.Resolve<Driver>();
            drv.RunCar();
            /*Unity container creates an object of the Driver class using the container.Resolve<driver>() method. 
             * The Driver class is a dependency of ICar. ? <=> ICar is dependend on Driver (wrong)
             * Correct: ICar is a dependency of Driver class
             * So, container.Resolve<Driver>() returns an object of the Driver class by automatically creating and injecting a BMW object in it. All this is behind the scene. The BMW object is created and injected because we register the BMW type with ICar.*/

            //Unity container will inject the last registered type if you register multiple mappings of the same type.
            container.RegisterType<ICar, BMW>();
            container.RegisterType<ICar, Audi>();

            Driver driver2 = container.Resolve<Driver>();
            driver2.RunCar(); 
            
            //IUnityContainer container = new UnityContainer();
            container.RegisterType<ICar, BMW>();
            container.RegisterType<ICar, Audi>("LuxuryCar");

            ICar bmw = container.Resolve<ICar>();  // returns the BMW object
            ICar audi = container.Resolve<ICar>("LuxuryCar"); // returns the Audi object

        }
    }

    /*IoC Container (a.k.a. DI Container) is a framework for implementing automatic dependency injection. It manages object creation and it's life-time, and also injects dependencies to the class.

The IoC container creates an object of the specified class and also injects all the dependency objects through a constructor, a property or a method at run time and disposes it at the appropriate time. This is done so that we don't have to create and manage objects manually.

    All the containers must provide easy support for the following DI lifecycle.
Register: The container must know which dependency to instantiate when it encounters a particular type. This process is called registration. Basically, it must include some way to register type-mapping.
Resolve: When using the IoC container, we don't need to create objects manually. The container does it for us. This is called resolution. The container must include some methods to resolve the specified type; the container creates an object of the specified type, injects the required dependencies if any and returns the object.
Dispose: The container must manage the lifetime of the dependent objects. Most IoC containers include different lifetimemanagers to manage an object's lifecycle and dispose it.

    Unity container is an open source IoC container for .NET applications supported by Microsoft. It is a lightweight and extensible IoC container.
    https://www.tutorialsteacher.com/ioc/unity-container
    */

    /*Unity Container: Register and Resolve
In the previous section, we installed Unity framework in our console project. Here, we will learn how to register type-mapping and resolve it using the unity container.
As we learned in the IoC container chapter, every container must provide a way to register and resolve dependencies. Unity container provides the RegisterType() and Resolve() methods for this.
    */
    /*We are going to use the following sample classes to demo the registration and resolution of dependencies throughout this chapter.
     * the Driver class depends on the ICar interface. So, when we instantiate the Driver class object, then we will have to pass an instance of a class which implements the ICar interface, such as the BMW, Audi or Ford class as shown below
    */
    public interface ICar
    {
        int Run();
    }

    public class BMW : ICar
    {
        private int _miles = 0;

        public int Run()
        {
            return ++_miles;
        }
    }

    public class Ford : ICar
    {
        private int _miles = 0;

        public int Run()
        {
            return ++_miles;
        }
    }

    public class Audi : ICar
    {
        private int _miles = 0;

        public int Run()
        {
            return ++_miles;
        }

    }
    public class Driver
    {
        private ICar _car = null;

        public Driver(ICar car)
        {
            _car = car;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
        }
    }
}
