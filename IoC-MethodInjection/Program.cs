using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_MethodInjection
{
    class Program
    {
        static void Main(string[] args)
        {
        }

    }

    //In the method injection, dependencies are provided through methods. This method can be a class method or an interface method. The following example demonstrates the method injection using an interface based method.
    /*the CustomerBusinessLogic class implements the IDataAccessDependency interface, which includes the SetDependency() mehtod. So, the injector class CustomerService will now use this method to inject the dependent class (CustomerDataAccess) to the client class.*/
    public interface ICustomerDataAccess
    {
        string GetCustomerName(int id);
    }
    //demonstrates the method injection using an interface based method.
    interface IDataAccessDependency
    {
        void SetDependency(ICustomerDataAccess customerDataAccess);
    }

    public class CustomerBusinessLogic : IDataAccessDependency  //client
    {
        ICustomerDataAccess _dataAccess;

        public CustomerBusinessLogic()
        {
        }

        public string GetCustomerName(int id)
        {
            return _dataAccess.GetCustomerName(id);
        }

        public void SetDependency(ICustomerDataAccess customerDataAccess)
        {
            _dataAccess = customerDataAccess;
        }
    }

    public class CustomerService    //injector
    {
        CustomerBusinessLogic _customerBL;

        public CustomerService()
        {
            _customerBL = new CustomerBusinessLogic();
            ((IDataAccessDependency)_customerBL).SetDependency(new CustomerDataAccess());
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

    /*So far, we have used several principles and patterns to achieve loosely coupled classes. In professional projects, there are many dependent classes and implementing these patterns is time consuming. Here the IoC Container (aka the DI container) helps us. Learn about the IoC Container in the next chapter.
*/

}
