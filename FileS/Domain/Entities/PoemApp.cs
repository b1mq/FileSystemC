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
        //public void SafePoemsInFile(string directory, string filename)
        //{
        //    if (Directory.Exists(directory))
        //    {
        //        string path = Path.Combine(directory, $"{filename}.txt");
        //        File.Create(path).Close();

        //        var lines = Poems.Select(poem => poem.ToString());
        //        File.WriteAllLines(path, lines);
        //    }
        //}
        public void SafePoemsInFile(string directory, string filename)
        {
            if (Directory.Exists(directory))
            {
                if (!File.Exists(@$"{directory}\{filename}.txt"))
                {
                    File.Create(@$"{directory}\{filename}.txt");
                }
                string path = @$"{directory}\{filename}.txt";

                    var lines = Poems.Select(poem => poem.ToString());
                    File.WriteAllLines(path, lines);
            }
        }
        public void LoadPoemsFromFile(string path)
        {
            try
            {
                foreach (var item in File.ReadLines(path)) 
                {
                    
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
