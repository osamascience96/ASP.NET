using Practice.CRUD;
using Practice.Database;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Movies");

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("1. View All Movies");
            Console.WriteLine("2. Create Movie");
            Console.WriteLine("3. Update Movie");
            Console.WriteLine("4. Delete Movie");
            Console.WriteLine("--------------------------------------");

            Console.Write("Select Option: ");
            int option = Int16.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Getting All Movies from Database....");
                    Console.WriteLine("-----------------------------------------");

                    Read read = new Read();
                    List < Dictionary<string, string> > movies = read.GetAllMovies();

                    if (movies.Count > 0)
                    {
                        foreach (var movie in movies)
                        {
                            Console.WriteLine("+++++++++++++++++++++++++++++++");
                            Console.WriteLine("Id: " + movie["id"]);
                            Console.WriteLine("Name: " + movie["name"]);
                            Console.WriteLine("Description: " + movie["description"]);
                            Console.WriteLine("Trailer: " + movie["trailer_link"]);
                            Console.WriteLine("+++++++++++++++++++++++++++++++");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Movies Found!");
                    }

                    Console.WriteLine("-----------------------------------------");

                    break;
                case 2:
                    Console.WriteLine("Create Movie in Database....");
                    Console.WriteLine("-----------------------------------------");

                    Console.Write("Name: ");
                    String name = Console.ReadLine();
                    
                    Console.Write("Description: ");
                    String description = Console.ReadLine();

                    Console.Write("Trailer Link: ");
                    String trailerLink = Console.ReadLine();

                    Create create = new Create();
                    create.Insert(name, description, trailerLink);
                    Console.WriteLine("-----------------------------------------");

                    Console.WriteLine("Data Created Successfully.");
                    break;
                case 3:
                    Console.WriteLine("Update Movie in Database.....");
                    Console.WriteLine("-----------------------------------------");

                    Read readObj = new Read();
                    List<Dictionary<string, string>> moviesList = readObj.GetAllMovies();

                    if (moviesList.Count > 0)
                    {
                        foreach (var movie in moviesList)
                        {
                            Console.WriteLine("+++++++++++++++++++++++++++++++");
                            Console.WriteLine("Id: " + movie["id"]);
                            Console.WriteLine("Name: " + movie["name"]);
                            Console.WriteLine("Description: " + movie["description"]);
                            Console.WriteLine("Trailer: " + movie["trailer_link"]);
                            Console.WriteLine("+++++++++++++++++++++++++++++++");
                        }
                        Console.Write("Please Enter Id of the Movie to Update: ");
                        int id = Int16.Parse(Console.ReadLine());

                        Dictionary<String, String> mov = readObj.GetMovieById(id);
                        Console.WriteLine("{**********************************************}");
                        Console.WriteLine("Id: " + mov["id"]);
                        Console.WriteLine("Name: " + mov["name"]);
                        Console.WriteLine("Description: " + mov["description"]);
                        Console.WriteLine("Trailer: " + mov["trailer_link"]);
                        Console.WriteLine("{**********************************************}");

                        Console.Write("Name: ");
                        String Name = Console.ReadLine();

                        Console.Write("Description: ");
                        String Description = Console.ReadLine();

                        Console.Write("Trailer Link: ");
                        String Trailer = Console.ReadLine();

                        Update update = new Update();
                        update.UpdateMovie(id, 
                            String.IsNullOrEmpty(Name) ? mov["name"] : Name,
                            String.IsNullOrEmpty(Description) ? mov["description"] : Description,
                            String.IsNullOrEmpty(Trailer) ? mov["trailer_link"] : Trailer);

                        Console.WriteLine("Data Updated Succesfully");
                    }
                    else
                    {
                        Console.WriteLine("No Movies Found!");
                    }

                    Console.WriteLine("-----------------------------------------");

                    break;
                case 4:
                    Console.WriteLine("Delete Movie in Database.....");
                    Console.WriteLine("-----------------------------------------");

                    Read readOnly = new Read();
                    List<Dictionary<string, string>> list = readOnly.GetAllMovies();

                    if(list.Count > 0)
                    {
                        foreach (var movie in list)
                        {
                            Console.WriteLine("+++++++++++++++++++++++++++++++");
                            Console.WriteLine("Id: " + movie["id"]);
                            Console.WriteLine("Name: " + movie["name"]);
                            Console.WriteLine("Description: " + movie["description"]);
                            Console.WriteLine("Trailer: " + movie["trailer_link"]);
                            Console.WriteLine("+++++++++++++++++++++++++++++++");
                        }

                        Console.WriteLine("{-----------------------------------------------------}");
                        Console.Write("Please Enter Id of the Movie to Delete: ");
                        int id = Int16.Parse(Console.ReadLine());

                        Dictionary<String, String> mov = readOnly.GetMovieById(id);
                        Console.WriteLine("{**********************************************}");
                        Console.WriteLine("Id: " + mov["id"]);
                        Console.WriteLine("Name: " + mov["name"]);
                        Console.WriteLine("Description: " + mov["description"]);
                        Console.WriteLine("Trailer: " + mov["trailer_link"]);
                        Console.WriteLine("{**********************************************}");

                        Delete delObj = new Delete();
                        delObj.del(id);

                        Console.WriteLine("{-----------------------------------------------------}");

                        Console.WriteLine("Record Deleted Successfully");
                    }
                    else
                    {
                        Console.WriteLine("No Records Found");
                    }

                    break;
                default:
                    Console.WriteLine("Please Select Valid Option");
                    break;
            }

        }
    }
}