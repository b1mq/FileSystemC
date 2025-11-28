using FileS.Domain.Entities;

var PoemM = new PoemManager();

void GeneratePoems()
{
    string[] poets = new string[]
{
    "William Shakespeare",
    "William Wordsworth",
    "Emily Dickinson",
    "Robert Frost",
    "T.S. Eliot"
};
    string[] poems = new string[]
    {
    "Sonnet 18",
    "Daffodils",
    "Because I Could Not Stop for Death",
    "The Road Not Taken",
    "The Love Song of J. Alfred Prufrock"
    };
    int[] years = new int[]
    {
    1609,
    1807,
    1863,
    1916,
    1915
    };
    Random rand = new Random();
    for (int i = 0; i < poets.Length; i++)
    {
        string poet = poets[rand.Next(0, poets.Length)];
        string poms = poems[rand.Next(0, poems.Length)];
        int year = years[rand.Next(0, years.Length)];
        PoemM.AddPoem(poet,poms,year,"0");
    }
    PoemM.SafePoemsInFile(@"C:/Users/Admin/Desktop/MyPoem", "MYPoem");
}
GeneratePoems();