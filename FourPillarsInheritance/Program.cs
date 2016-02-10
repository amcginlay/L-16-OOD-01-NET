using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillarsInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            //Base class
            UserController userController = new UserController();
            userController.Login("John.Smith", "secret");
            //userController.SetPermissions("John.Smith");
            //inherits from userController so gets its methods
            AdminController adminController = new AdminController();
            adminController.Login("Jane.Doe", "pass123");
            adminController.SetPermissions("Jane.Doe");
            //inherits from adminController so get its methods and all the methods inherited from userController
            SuperAdminController superAdminController = new SuperAdminController();
            superAdminController.Login("Joe.Bloggs", "password");
            superAdminController.SetPermissions("Joe.Bloggs");

            Admin admin = new Admin();
            admin.name = "Jane.Doe";
            admin.role = "admin";
            Seller seller = new Seller();
            seller.name = "John.Smith";
            seller.role = "Seller";
            //User user = new User(); // Oooops, no can do!

            // IDatabaseConnection connection = new IDatabaseConnection(); // Not possible!
            IDatabaseConnection connection = new MicrosoftDbConnection();

            Console.ReadLine();
        }
    }
}
