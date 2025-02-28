using Infosys.CodeFirstCore.DataAccessLayer;

namespace Infosys.CodeFirstCore.ConsoleUI
{
    internal class Program
    {
        static QuickKartDBContext context;
        static QuickKartRepository repository;

        static Program()
        {
            context = new QuickKartDBContext();
            repository = new QuickKartRepository(context);
        }
        static void Main(string[] args)
        {
            QuickKartRepository repository = new QuickKartRepository(context);
            byte categoryId = 0;
            int returnResult = repository.AddCategoryDetailsUsingUSP("Electronics", out categoryId);
            if (returnResult > 0)
            {
                Console.WriteLine("Category details added successfully with CategoryId = " + categoryId);
            }
            else
            {
                Console.WriteLine("Some error occurred. Try again!");
            }
        }
    }
}
