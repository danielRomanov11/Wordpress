using Library.WordPress.Models;
using System;

namespace CLI.WordPress
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to WordPress!");
            List<Blog?> blogPosts = new List<Blog?>();
            bool cont = true;
            do
            {
                Console.WriteLine("C. Create a Blog Post");
                Console.WriteLine("R. List all Blog Posts");
                Console.WriteLine("U. Update a Blog Post");
                Console.WriteLine("D. Delete a Blog Post");
                Console.WriteLine("Q. Quit");

                var userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "C":
                    case "c":
                        var blog = new Blog();
                        blog.Title = Console.ReadLine();
                        blog.Content = Console.ReadLine();
                        var maxId = -1;
                        if (blogPosts.Any())
                        {
                            maxId = blogPosts.Select(b => b?.Id ?? -1).Max();

                        }
                        else {
                            maxId = 0;
                        }
                            blog.Id = ++maxId;
                        blogPosts.Add(blog);
                        break;
                    case "R": 
                    case "r":
                        foreach(var b in blogPosts)
                        {
                            Console.WriteLine(b);
                        }
                        break;
                    case "U": 
                    case "u":
                        {
                            blogPosts.ForEach(Console.WriteLine);
                            Console.WriteLine("Blog to Update (Id):");

                            //get selection
                            var selection = Console.ReadLine();
                            //selection is int
                            if (int.TryParse(selection ?? "0", out int intSelection))
                            {

                                //get object to update
                                var blogToUpdate = blogPosts
                                    //dont consider nulls
                                    .Where(b => b != null)
                                    //find by id
                                    .FirstOrDefault(b => (b?.Id ?? -1) == intSelection);
                                //update from list
                                if (blogToUpdate != null)
                                {
                                    blogToUpdate.Title = Console.ReadLine();
                                    blogToUpdate.Content = Console.ReadLine();
                                }
                            }
                                break;         
                        }
                    case "D": 
                    case "d":
                        {
                            //display blogs
                            blogPosts.ForEach(Console.WriteLine);
                            Console.WriteLine("Blog to Delete (Id):");

                            //get selection
                            var selection = Console.ReadLine();
                            //selection is int
                            if (int.TryParse(selection ?? "0", out int intSelection))
                            {

                                //deletion
                                var blogToDelete = blogPosts
                                    //dont consider nulls
                                    .Where(b => b != null)
                                    //find by id
                                    .FirstOrDefault(b => (b?.Id ?? -1) == intSelection);
                                //rmove from list
                                blogPosts.Remove(blogToDelete);
                            }
                            break;
                        }
                    case "Q": 
                    case "q":
                        cont = false;
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }

            } while (cont);
        }
    }
}