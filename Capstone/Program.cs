using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using Capstone.Inventory;
using Capstone.TransactionLogging;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the dependencies
            IInventorySource inventorySource = new InventoryFileDAL("vendingmachine.csv");
            ITransactionLogger transactionLogger = new TransactionFileLog("transactions.txt");

            // IInventorySource inventorySource = new InventorySqlDAL("connectionstring");

            VendingMachine vm;

            try
            {                                
                // Inject the dependency into the class using the constructor
                vm = new VendingMachine(inventorySource, transactionLogger);
            }
            catch
            {
                Console.WriteLine();
                Console.WriteLine("An error occurred starting the vending machine. The program is going to exit.");
                return;
            }

            // Start the CLI and run the menu
            VendingMachineCLI cli = new VendingMachineCLI(vm);
            cli.Run();
        }
    }
}
