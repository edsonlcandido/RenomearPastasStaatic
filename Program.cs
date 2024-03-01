namespace RenomearPastasStaatic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rootDirectory = @"D:\docker\www.ezt_staatic"; // Substitua pelo caminho do seu diretório raiz

            ProcessDirectory(rootDirectory);

            Console.WriteLine("Concluído! Pressione qualquer tecla para sair.");
            Console.ReadKey();
        }

        static void ProcessDirectory(string targetDirectory)
        {
            string[] subDirectories = Directory.GetDirectories(targetDirectory);

            foreach (string subDirectory in subDirectories)
            {
                ProcessDirectory(subDirectory);

                if (subDirectory.EndsWith(".html"))
                {
                    string newDirectoryName = subDirectory + "_";
                    string[] files = Directory.GetFiles(subDirectory, "index.html");

                    if (files.Length > 0)
                    {
                        string newFileName = Path.Combine(Path.GetDirectoryName(subDirectory), Path.GetFileName(subDirectory));
                        string newDirectoryPath = Path.Combine(Path.GetDirectoryName(subDirectory), newDirectoryName);

                        Directory.Move(subDirectory, newDirectoryPath);
                        string[] newFiles = Directory.GetFiles(newDirectoryPath, "index.html");
                        File.Move(newFiles[0], newFileName);
                        //remove o diretório vazio
                        Directory.Delete(newDirectoryPath);
                    }
                }
            }
        }
    }
}
