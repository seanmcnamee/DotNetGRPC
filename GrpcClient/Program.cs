using System.Text;
using Grpc.Net.Client;
using GrpcClient;


Console.WriteLine("Hello!");



// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7257");
var greeterClient = new Greeter.GreeterClient(channel);
var moviesClient = new Movies.MoviesClient(channel);

await GetNameAndSayHello(greeterClient);
await ShowGenresAndSearchMovies(moviesClient);
await ShowSingleMovieResult(moviesClient);


Console.WriteLine("Press any key to exit...");
Console.ReadKey();


static async Task GetNameAndSayHello(Greeter.GreeterClient greeterClient)
{
    var messageName = GetConsoleInput("\nWhat is your name?", (value) => !string.IsNullOrWhiteSpace(value));
    var reply = await greeterClient.SayHelloAsync(
        new HelloRequest { Name = messageName });

    Console.WriteLine("Greeting: " + reply.Message);
}

static async Task ShowGenresAndSearchMovies(Movies.MoviesClient moviesClient)
{
    var genreListQuestion = new StringBuilder("\nWhich of the following genres do you want to see movies for?\n");
    foreach (var movieGenre in Enum.GetValues<Genre>())
    {
        genreListQuestion.Append($"\t{(int)movieGenre}: {movieGenre}\n");
    }

    var chosenGenreString = GetConsoleInput(genreListQuestion.ToString(), value => Enum.TryParse<Genre>(value, out _));
    Enum.TryParse<Genre>(chosenGenreString, out var chosenGenre);

    var movieGenreList = await moviesClient.GetGenreInfoListAsync(new MovieInfoListRequest() { Genre = chosenGenre });

    var maxLengths = new int[] { 3, 38, 16, 61 };
    var alignment = $"{{0,-{maxLengths[0]}}}{{1,-{maxLengths[1]}}}{{2,-{maxLengths[2]}}}{{3,-{maxLengths[3]}}}\n";
    var genreListResult = new StringBuilder($"\nMovies associated with {chosenGenre}:\n");

    genreListResult.Append(string.Format($"{alignment}\n", "Id", "Name", "Genre", "Description"));

    foreach (var movie in movieGenreList.MoviesList)
    {
        genreListResult.Append(
            string.Format(alignment,
                GetTruncatedString(movie.Id.ToString(), maxLengths[0]),
                GetTruncatedString(movie.Name, maxLengths[1]),
                GetTruncatedString(movie.Genre.ToString(), maxLengths[2]),
                GetTruncatedString(movie.Description, maxLengths[3])
                ));
    }
    Console.WriteLine(genreListResult);
}

static async Task ShowSingleMovieResult(Movies.MoviesClient moviesClient)
{
    var chosenGenreString = GetConsoleInput("\nWhat movie id do you want more information on?", value => int.TryParse(value, out _));
    int.TryParse(chosenGenreString, out var chosenMovieId);

    var movieInfo = await moviesClient.GetInfoAsync(new MovieInfoRequest() { Id = chosenMovieId });

    const string alignment = "{0,-15}{1}\n";
    var movieInfoResult = new StringBuilder($"\nMovie associated with id {chosenMovieId}:\n");

    movieInfoResult.Append(
        string.Format(alignment,
            "Id", movieInfo.Id));
    movieInfoResult.Append(
        string.Format(alignment, 
            "Name", movieInfo.Name));
    movieInfoResult.Append(
        string.Format(alignment,
            "Genre", movieInfo.Genre));
    movieInfoResult.Append($"Description\n{movieInfo.Description}\n");

    Console.WriteLine(movieInfoResult);
}

static string? GetConsoleInput(string userMessage, Func<string?, bool> isValidInputFunc)
{
    do
    {
        Console.WriteLine(userMessage);
        var consoleInput = Console.ReadLine();
        if (isValidInputFunc(consoleInput))
        {
            return consoleInput;
        }
        else
        {
            Console.WriteLine("Invalid! Please try again.\n");
        }

    } while (true);
}

static string GetTruncatedString(string value, int maxLength)
{
    return value.Remove(Math.Min(value.Length, maxLength));
}