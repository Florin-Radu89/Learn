using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    /*https://www.tutorialsteacher.com/ioc/inversion-of-control
     * the Main() function of the program class controls the flow of a program. It takes the user's input for the first name and last name. It saves the data, and continues or exits the console, depending upon the user's input. So here, the flow is controlled through the Main() function.*/
    class Program
    {
        static void Main(string[] args)
        {
            bool continueExecution = true;
            do
            {
                Console.Write("Enter First Name:");
                var firstName = Console.ReadLine();

                Console.Write("Enter Last Name:");
                var lastName = Console.ReadLine();

                Console.Write("Do you want to save it? Y/N: ");

                var wantToSave = Console.ReadLine();

                if (wantToSave.ToUpper() == "Y")
                    SaveToDB(firstName, lastName);

                Console.Write("Do you want to exit? Y/N: ");

                var wantToExit = Console.ReadLine();

                if (wantToExit.ToUpper() == "Y")
                    continueExecution = false;

            } while (continueExecution);


        }

        private static void SaveToDB(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }
    }

    #region 1: example of dependency
    /*Class A cannot complete its task without class B and so you can say that "Class A is dependent on class B" or "class B is a dependency of class A".
     */
    public class A
    {
        B b;

        public A()
        {
            b = new B();
        }

        public void Task1()
        {
            // do something here..
            b.SomeMethod();
            // do something here..
        }

    }
    public class B
    {

        public void SomeMethod()
        {
            //doing something..
        }
    }
    #endregion 1

    #region 2
    /* The IoC principle suggests to invert the control. This means to delegate the control to another class. In other words, invert the dependency creation control from class A to another class, as shown below.
     */
    public class A1
    {
        B b;

        public A1()
        {
            b = Factory.GetObjectOfB();
        }

        public void Task1()
        {
            // do something here..
            b.SomeMethod();
            // do something here..
        }
    }

    public class Factory
    {
        public static B GetObjectOfB()
        {
            return new B();
        }
    }
    #endregion 2

    #region 3 : 
    //the CustomerBusinessLogic class depends on the DataAccess class. It creates an object of the DataAccess class to get the customer data
    public class CustomerBusinessLogic
    {
        DataAccess _dataAccess;

        public CustomerBusinessLogic()
        {
            _dataAccess = new DataAccess();
        }

        public string GetCustomerName(int id)
        {
            return _dataAccess.GetCustomerName(id);
        }
    }

    public class DataAccess
    {
        public DataAccess()
        {
        }

        public string GetCustomerName(int id)
        {
            return "Dummy Customer Name"; // get it from DB in real app
        }
    }
    //Let's use the Factory pattern to implement IoC in the above example, as the first step towards attaining loosely coupled classes. First, create a simple Factory class which returns an object of the DataAccess class as shown below
    public class DataAccessFactory
    {
        public static DataAccess GetDataAccessObj()
        {
            return new DataAccess();
        }
    }
    public class CustomerBusinessLogic1
    {

        public CustomerBusinessLogic1()
        {
        }

        //the CustomerBusinessLogic class uses the DataAccessFactory.GetCustomerDataAccessObj() method to get an object of the DataAccess class instead of creating it using the new keyword. Thus, we have inverted the control of creating an object of a dependent class from the CustomerBusinessLogic class to the DataAccessFactory class.
        //This is a simple implementation of IoC and the first step towards achieving fully loose coupled design. As mentioned in the previous chapter, we will not achieve complete loosely coupled classes by only using IoC. Along with IoC, we also need to use DIP, Strategy pattern, and DI (Dependency Injection).
        public string GetCustomerName(int id)
        {
            DataAccess _dataAccess = DataAccessFactory.GetDataAccessObj();

            return _dataAccess.GetCustomerName(id);
        }
    }

    #endregion 3

    #region 4
    //use DIP, Strategy pattern, and DI (Dependency Injection).
    //Thus, we have implemented DIP in our example where a high-level module (CustomerBusinessLogic) and low-level module (CustomerDataAccess) are dependent on an abstraction (ICustomerDataAccess). Also, the abstraction (ICustomerDataAccess) does not depend on details (CustomerDataAccess), but the details depend on the abstraction.
    public interface ICustomerDataAccess
    {
        string GetCustomerName(int id);
    }

    public class CustomerDataAccess4 : ICustomerDataAccess
    {
        public CustomerDataAccess4()
        {
        }

        public string GetCustomerName(int id)
        {
            return "Dummy Customer Name";
        }
    }

    public class DataAccessFactory4
    {
        public static ICustomerDataAccess GetCustomerDataAccessObj()
        {
            return new CustomerDataAccess4();
        }
    }

    public class CustomerBusinessLogic4
    {
        ICustomerDataAccess _custDataAccess;

        public CustomerBusinessLogic4()
        {
            //TODO: The problem with this example is that we used DataAccessFactory inside the CustomerBusinessLogic class
            _custDataAccess = DataAccessFactory4.GetCustomerDataAccessObj();
        }

        public string GetCustomerName(int id)
        {
            return _custDataAccess.GetCustomerName(id);
        }
    }
    //the CustomerBusinessLogic and CustomerDataAccess classes are now loosely coupled classes because CustomerBusinessLogic does not depend on the concrete DataAccess class, instead it includes a reference of the ICustomerDataAccess interface. So now, we can easily use another class which implements ICustomerDataAccess with a different implementation.
    //Still, we have not achieved fully loosely coupled classes because the CustomerBusinessLogic class includes a factory class to get the reference of ICustomerDataAccess. This is where the Dependency Injection pattern helps us. In the next chapter, we will learn how to use the Dependency Injection (DI) and the Strategy pattern using the above example.
    #endregion 4

    #region 5 : Dependency Injection pattern https://www.tutorialsteacher.com/ioc/dependency-injection
    //In the previous chapter, related to DIP, we created and used abstraction to make the classes loosely coupled.
    //The problem with the above example is that we used DataAccessFactory inside the CustomerBusinessLogic class. So, suppose there is another implementation of ICustomerDataAccess and we want to use that new class inside CustomerBusinessLogic. Then, we need to change the source code of the CustomerBusinessLogic class as well. The Dependency injection pattern solves this problem by injecting dependent objects via a constructor, a property, or an interface.
    //Here, we are going to implement Dependency Injection and strategy pattern together to move the dependency object creation completely out of the class. 
    //Dependency Injection (DI) is a design pattern used to implement IoC. It allows the creation of dependent objects outside of a class and provides those objects to a class through different ways. Using DI, we move the creation and binding of the dependent objects outside of the class that depends on them.

    /* The Dependency Injection pattern involves 3 types of classes.
    Client Class: The client class (dependent class) is a class which depends on the service class
    Service Class: The service class (dependency) is a class that provides service to the client class.
    Injector Class: The injector class injects the service class object into the client class.
    The injector class creates an object of the service class, and injects that object to a client object. In this way, the DI pattern separates the responsibility of creating an object of the service class out of the client class.
    The injector class injects dependencies broadly in three ways: through a constructor, through a property, or through a method.

Constructor Injection: In the constructor injection, the injector supplies the service (dependency) through the client class constructor.

Property Injection: In the property injection (aka the Setter Injection), the injector supplies the dependency through a public property of the client class.

Method Injection: In this type of injection, the client class implements an interface which declares the method(s) to supply the dependency and the injector uses this interface to supply the dependency to the client class.
    */
    //the CustomerService class becomes the injector class, which sets an object of the service class (CustomerDataAccess) to the client class (CustomerBusinessLogic) either through a constructor, a property, or a method to achieve loose coupling.


    #endregion 5 : Dependency Injection pattern
    //IoC-ConstructorInjection
}
