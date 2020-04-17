using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    // take an example this is a service interface.
    public interface IEmployee
    {
        int GetEmployee(int id);
    }
    // we implemented the interface 
    public class EmployeeDetails : IEmployee
    {
        public int GetEmployee(int id)
        {
            Console.WriteLine(id);
            return id;
        }
    }

    /*
     While calling the service in the web application, and to have seperation of concern(IOC inversion of control) DI, we use constructor injection to 
     inject the dependency into the class or web application.
     So by this way testing can be easily done, to test the api, the tester can implement the own default method implementation by using interface and the same 
     can be passed in web application call and can evaluate the output.
     */
    public class DependencyInjectionServiceCallInClientWeb
    {
        IEmployee _employee;

        public DependencyInjectionServiceCallInClientWeb(IEmployee employee)
        {
            _employee = employee;
        }
        public void test()
        {
            var employee = new EmployeeDetails();
            employee.GetEmployee(10);
        }
        

    }
}
