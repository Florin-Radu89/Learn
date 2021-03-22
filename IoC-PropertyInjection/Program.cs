using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_PropertyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    //In the property injection, the dependency is provided through a public property
    /*CustomerBusinessLogic class includes the public property named DataAccess, where you can set an instance of a class that implements ICustomerDataAccess. 
     * So, CustomerService class creates and sets CustomerDataAccess class using this public property.*/
    public interface ICustomerDataAccess
    {
        string GetCustomerName(int id);
    }
    public class CustomerBusinessLogic  //client
    {
        public CustomerBusinessLogic()
        {
        }

        public string GetCustomerName(int id)
        {
            return DataAccess.GetCustomerName(id);
        }

        //In the property injection, the dependency is provided through a public property
        public ICustomerDataAccess DataAccess { get; set; }
    }

    public class CustomerService    //injector
    {
        CustomerBusinessLogic _customerBL;

        public CustomerService()
        {
            _customerBL = new CustomerBusinessLogic();
            _customerBL.DataAccess = new CustomerDataAccess();
        }

        public string GetCustomerName(int id)
        {
            return _customerBL.GetCustomerName(id);
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

}
