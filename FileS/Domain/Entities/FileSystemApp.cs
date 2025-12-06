namespace FileS.Domain.Entities
{
    public static class FileSystemApp
    {

        public static void CopyFiles(string original,string source)
        {

            try
            {
                File.Copy(original, source,true);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void MoveFiles(string original, string source)
        {

            try
            {
                if (File.Exists(source))
                {
                    File.Delete(source);
                }
                File.Move(original, source);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static bool CopyDirectory(string original,string source)
        {
            try
            {
                if (!Directory.Exists(original)) return false;
                Directory.CreateDirectory(source);
                string[] files = Directory.GetFiles(original);
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string destFile = Path.Combine(source, fileName);
                    File.Copy(file, destFile, true);
                }

           
                string[] subDirs = Directory.GetDirectories(original);
                foreach (string subDir in subDirs)
                {
                    string subDirName = Path.GetFileName(subDir);
                    string destSubDir = Path.Combine(source, subDirName);
                    CopyDirectory(subDir, destSubDir); 
                }

 
                return true;
            }
            catch 
            {
                return false;
            }


        }
        public static void ShowInfoInFile(string directory, string filename)
        {
            if(Directory.Exists(directory))
            {
                string path = Path.Combine(directory, filename + ".txt");
                if (File.Exists(path))
                {
                    var res = File.ReadAllText(path);
                    Console.WriteLine(res);
                }
                else
                {
                    Console.WriteLine("File is not exists");
                }
            }
            else
            {
                Console.WriteLine("Directory is not exists");
            }
        }
        public static void ShowInfoInFile(string source)
        {
            if (File.Exists(source))
            {
                var res = File.ReadAllText(source);
                Console.WriteLine(res);
            }else
            {
                Console.WriteLine("File is not exists");
            }
        }
        public static void SaveArrayNumbers(string directory, string filename,params int[] numbers)
        {
            if (Directory.Exists(directory))
            {
                string path = Path.Combine(directory, filename + ".txt");
                string content = string.Join(" ", numbers);
                File.WriteAllText(path,content );
            }
        }
        public static void SaveArrayNumbers(string source, params int[] numbers)
        {
            // расчет на то что source будет уже с файлом и .txt
            if (File.Exists(source))
            {
                string content = string.Join(" ", numbers);
                File.WriteAllText(source, content);
            }
        }
        public static int[] LoadArrayNumbersFromFile(string source)
        {
            if (File.Exists(source))
            {
                string read = File.ReadAllText(source);
                string trimmedRead = read.Trim();
                string[] numberStrings = trimmedRead.Split(
            new char[] { ' ', '\n', '\r', '\t', ',' },
            StringSplitOptions.RemoveEmptyEntries);
                int[] numbers = numberStrings.Select(int.Parse).ToArray();
                return numbers;
            }else
            {
                return new int[0];
            }

        }

        public static void GenerateNumbersAndSaveInFile(string directory,int X,int minvalue,int maxvalue)
        {
            int[] arr = new int[X];
            var rand = new Random();
            arr = Enumerable.Range(0, X)
                           .Select(_ => rand.Next(minvalue, maxvalue))
                           .ToArray();
            var evenNums = arr.Where(n => n % 2 == 0);
            string evencontent = string.Join(" ", evenNums);
            var oddNums = arr.Where(n => n % 2 != 0);
            string oddcontent = string.Join(" ", oddNums);
            string allcontent = string.Join(" ", arr);
            if (Directory.Exists(directory))
            {
                string allpath = Path.Combine(directory ,"All_Numbers.txt");
                string evenpath = Path.Combine(directory , "Even_Numbers.txt");
                string oddpath = Path.Combine(directory ,"Odd_Numbers.txt");
                if (File.Exists(allpath))
                {
                    File.Delete(allpath);

                }
                else if (File.Exists(evenpath))
                {
                    File.Delete(evenpath);

                }
                else if (File.Exists(oddpath))
                {
                    File.Delete(oddpath);

                }
                File.WriteAllText(oddpath, oddcontent);
                File.WriteAllText(evenpath, evencontent);
                File.WriteAllText(allpath, allcontent);

            }

        }

        public static  void FindWordInFile(string directory,string word)
        {
            if (File.Exists(directory))
            {
                var indices = File.ReadAllText(directory)
                .Split(null as char[], StringSplitOptions.RemoveEmptyEntries)
                .Select((w, i) => new { w, i })
                .Where(x => x.w.Equals(word, StringComparison.OrdinalIgnoreCase))
                .Select(x => x.i);

                if (indices.Any())
                    foreach (var i in indices)
                        Console.WriteLine($"Index of '{word}': {i}");
                else
                    Console.WriteLine($"'{word}' не найдено.");
            }

        }

        public static void FindFileInDirectory(string directory,string XYZ)
        {
            if (Directory.Exists(directory))
            {
                DirectoryInfo d = new DirectoryInfo(directory);
                var directors = d.GetDirectories();
                foreach (var director in directors)
                {
                    var directorfiles = director.GetFiles(XYZ);
                    string strindirector = "";
                    foreach (var df in directorfiles)
                    {
                        strindirector = strindirector + ", " + df.Name;
                    }
                    Console.WriteLine(strindirector);
                }
                var files = d.GetFiles(XYZ);
                string str = "";
                foreach (var f in files)
                {
                    str = str + ", " + f.Name;
                }
               Console.WriteLine(str);
            }
        }
        public static void DeleteFileInDirectory(string directory, string XYZ)
        {
            if (Directory.Exists(directory))
            {
                DirectoryInfo d = new DirectoryInfo(directory);
                var directors = d.GetDirectories();
                foreach (var director in directors)
                {
                    var directorfiles = director.GetFiles();
                    foreach (var df in directorfiles)
                    {
                        df.Delete();
                    }
                    director.Delete();

                }

                var files = d.GetFiles(XYZ);

                foreach (var f in files)
                {
                    f.Delete();
                }

            }
        }
        public static void ShowInfoInDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                Console.WriteLine(directory);
                DirectoryInfo d = new DirectoryInfo(directory);
                var directors = d.GetDirectories();
                foreach (var director in directors)
                {
                    Console.Write(director + " ");
                    var directorfiles = director.GetFiles();
                    string strindirector = "";
                    foreach (var df in directorfiles)
                    {
                        strindirector = strindirector + ", " + df.Name;
                    }
                    Console.WriteLine(strindirector);
                }
                var files = d.GetFiles();
                string str = "";
                foreach (var f in files)
                {
                    str = str + ", " + f.Name;
                }
                Console.WriteLine(str);
            }
        }
    }
}
