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


    }
}
