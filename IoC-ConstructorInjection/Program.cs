using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_ConstructorInjection
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    //https://www.tutorialsteacher.com/ioc/dependency-injection
    //the CustomerService class becomes the injector class, which sets an object of the service class (CustomerDataAccess) to the client class (CustomerBusinessLogic) either through a constructor, a property, or a method to achieve loose coupling
    //Constructor Injection: In the constructor injection, the injector supplies the service(dependency) through the client class constructor.

    //Consider the following example where we have implemented DI using the constructor.
    public interface ICustomerDataAccess
    {
        string GetCustomerName(int id);
    }

    public class CustomerBusinessLogic  //client
    {
        ICustomerDataAccess _dataAccess;

        //DONE: In the constructor injection, the injector supplies the service(dependency) through the client class constructor.
        public CustomerBusinessLogic(ICustomerDataAccess custDataAccess)
        {
            _dataAccess = custDataAccess;
        }

        public CustomerBusinessLogic()
        {
            _dataAccess = new CustomerDataAccess();
        }

        public string ProcessCustomerData(int id)
        {
            return _dataAccess.GetCustomerName(id);
        }
    }

    public class CustomerDataAccess : ICustomerDataAccess   //service
    {
        public CustomerDataAccess()
        {
        }

        public string GetCustomerName(int id)
        {
            //get the customer name from the db in real application        
            return "Dummy Customer Name";
        }
    }

    //In the above example, CustomerBusinessLogic includes the constructor with one parameter of type ICustomerDataAccess. 
    //Now, the calling class must inject an object of ICustomerDataAccess.
    public class CustomerService    //injector
    {
        CustomerBusinessLogic _customerBL;

        public CustomerService()
        {
            _customerBL = new CustomerBusinessLogic(new CustomerDataAccess());
        }

        public string GetCustomerName(int id)
        {
            //return _customerBL.GetCustomerName(id);   ORIGINAL BUT WRONG
            return _customerBL.ProcessCustomerData(id);
        }
    }
    /*the CustomerService class creates and injects the CustomerDataAccess object into the CustomerBusinessLogic class. Thus, the CustomerBusinessLogic class doesn't need to create an object of CustomerDataAccess using the new keyword or using factory class. The calling class (CustomerService) creates and sets the appropriate DataAccess class to the CustomerBusinessLogic class. In this way, the CustomerBusinessLogic and CustomerDataAccess classes become "more" loosely coupled classes.

Property Injection
*/

}
