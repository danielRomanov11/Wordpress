using Library.Wordpress.Models;
namespace CLI.Wordpress
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Wordpress!");
            List<Blog?> blogposts = new List<string?>();
            
            do
            {
                Console.WriteLine("C. Create a Blogpost");
                Console.WriteLine("R. List all Blogposts");
                Console.WriteLine("U. Update a Blogpost");
                Console.WriteLine("D. Delete a Blogpost");
                Console.WriteLine("Q. Exit");

                var userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "C":
                    case "c":
                        var blog = new Blog();
                        blogposts.Add(Console.ReadLine() ?? string.Empty);
                        break;
                    case "R":
                    case "r":
                        foreach(var b in blogposts){
                            //question mark makes dot ops null
                            Console.WriteLine($"({b?.Length}) {b}");
                        }
                        
                        break;
                    case "U":
                    case "u":

                        break;
                    case "D":
                    case "d":

                        break;
                    case "q":
                    case "Q":

                        break;
                    default: 
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }

            } while (true);
        }
    }
}
