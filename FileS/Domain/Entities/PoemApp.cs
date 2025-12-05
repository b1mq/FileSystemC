using System.Text.Json;

namespace FileS.Domain.Entities
{
    public  class PoemManager
    {
        private List<Poem> Poems { get; set; }
        private int Id { get; set; }
        public PoemManager()
        {
            Poems = new List<Poem>();
            Id = 1;
        }
        public void RemovePoem(int id)
        {
            Poems.Remove(Poems[id]);
        }
        public void RemovePoem(Poem poem)
        {
            try
            {
                Poems.Remove(poem);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }

        }
        public void AddPoem(Poem poem)
        {
            Poems.Add(poem);
        }
        public void AddPoem(string name, string autor, int year, string description)
        {
            var poem = new Poem(name, autor, year, description);
            Poems.Add(poem);
        }
        public void DisplayAllPoems()
        {
            foreach (var poem in Poems)
            {
                Console.WriteLine(poem);
            }
        }
        public override string ToString()
        {
            return $"Count of Poems {Poems.Count}";
        }
        public Poem? SearchPoem(string name)
        {
            foreach (var poem in Poems)
            {
                if (poem.Name == name)
                {
                    return poem;
                }
            }
            return null;
        }
        public void DisplayNameOfPoems()
        {
            foreach(var poem in Poems)
            {
                Console.WriteLine(poem.Name);
            }
        }
        public void DisplayNameOfAutors()
        {
            foreach (var poem in Poems)
            {
                Console.WriteLine(poem.Autor);
            }
        }
        public void DisplayPoemWithAutor(string name)
        {
            var poem = Poems.FirstOrDefault(p => p.Autor == name);
            Console.WriteLine(poem);
        }
        public void DisplayPoemWithName(string name)
        {
            var poem = Poems.FirstOrDefault(p => p.Name == name);
            Console.WriteLine(poem);
        }
        public void DisplayPoemWithYear(int year, string directory, string filename)
        {
            var poem = Poems.Where(p => p.Year == year);
            string path = Path.Combine(directory, filename + ".json");
            File.WriteAllText(path, JsonSerializer.Serialize(poem));
        }
        public void DisplayPoemWithAutor(string name, string directory, string filename)
        {
            var poem = Poems.Where(p => p.Autor == name);
            string path = Path.Combine(directory, filename + ".json");
            File.WriteAllText(path, JsonSerializer.Serialize(poem));
        }
        public void DisplayPoemWithLength(int length, string directory, string filename)
        {
            var poem = Poems.Where(p => p.Description.Length == length );
            string path = Path.Combine(directory, filename + ".json");
            File.WriteAllText(path, JsonSerializer.Serialize(poem));
        }
        public void DisplayPoemWithName(string name,string directory,string filename)
        {
            var poem = Poems.Where(p => p.Name == name);
            string path = Path.Combine(directory, filename + ".json");
            File.WriteAllText(path,JsonSerializer.Serialize(poem));
        }
        public void SafePoemsInFile(string directory, string filename)
        {
            if (Directory.Exists(directory))
            {
                string path = Path.Combine(directory, filename + ".json");
                File.WriteAllText(path, JsonSerializer.Serialize(Poems, new JsonSerializerOptions { WriteIndented = true }));
            }
        }
        public void LoadPoemsFromJson(string directory,string filename)
        {
            if (Directory.Exists(directory))
            {
                string path = Path.Combine(directory, filename + ".json");
                try
                {
                    string json = File.ReadAllText(path);
                    Poems = JsonSerializer.Deserialize<List<Poem>>(json);
                }
                catch (JsonException ex )
                {

                    throw new JsonException("Something is wrong - ", ex);
                }
            }
        }
    }
}
