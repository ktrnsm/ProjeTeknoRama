using Project.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.SingletonPattern
{
    //The Singleton pattern is a software design pattern that ensures that a class has only one instance, while providing a global point of access to that instance for the entire system. It is used to control the number of instances of a class that can be created, and to ensure that there is only one instance of a class available in the system, making it easier to manage resources and state throughout the system. The Singleton pattern can be implemented by creating a private constructor, making the class non-inheritable, and providing a static method that returns the instance of the class.

    public class DBTool
    {
        // private constructor ensures that no instances of this class can be created from outside this class

        DBTool() { }
       

        // static field to hold the single instance of this class

        static MyContext _dbInstance;

        // static property to access the single instance of this class

        public static MyContext DBInstance
        {
            // this property accessor returns the single instance of this class, creating a new instance if necessary

            get
            {
                // check if an instance of this class has already been created

                if (_dbInstance == null)
                    // if not, create a new instance

                    _dbInstance = new MyContext();

                // return the single instance of this class

                return _dbInstance;
            }
        }
    }
}
