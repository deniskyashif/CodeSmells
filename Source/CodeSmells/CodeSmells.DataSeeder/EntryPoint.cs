namespace CodeSmells.DataSeeder
{
    using System;
    using FileSniffing;

    class EntryPoint
    {
        static void SniffForCodeFiles() 
        {
            //Sniff folders for code! 
            string[] smellyDirs = new string[]{
                     @"E:\xampp\htdocs\",
                     @"E:\GitHub\personal\personal\TelerikAcademy\"
                };
            //specify extensions
            string[] allowedExtensions = new string[] { "*.php", "*.js", "*.html", "*.cs", "*.css" };
            CodeFileSniffer fileSniffer = new CodeFileSniffer(smellyDirs, allowedExtensions, "smellyFiles.txt");
            Console.WriteLine("Started file sniffing...");
            fileSniffer.Sniff();
            Console.WriteLine("File sniffing finished!");
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("CodeSmells data seeder v1.0");
                Console.WriteLine("- - -");
                //First: Sniff for code files.
                //SniffForCodeFiles();
                //Second: Extract code snippets.
            }
            catch (Exception boom) 
            {
                Console.WriteLine("[!] Ups, something went wrong! "+boom.Message);
            }
        }
    }
}
