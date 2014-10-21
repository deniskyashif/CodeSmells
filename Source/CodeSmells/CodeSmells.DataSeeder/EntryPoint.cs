namespace CodeSmells.DataSeeder
{
    using System;
    using FileSniffing;
    using CodeSmells.Models;
    using CodeSmells.Data;
    using DataGenerators;

    class EntryPoint
    {
        static Random randomProvider=new Random();

        //TODO: Extract some constants

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
            fileSniffer.MaxFileName = 100;
            Console.WriteLine("Started file sniffing...");
            fileSniffer.Sniff();
            Console.WriteLine("File sniffing finished!");
        }

        static void ExtractSnippetsFromFiles()
        {
            SnippetExtractor snippetExtractor = new SnippetExtractor("smellyFiles.txt", "snippets.txt", randomProvider);
            Console.WriteLine("Started extracting snippets...");
            snippetExtractor.SnippetMinLength = 100;
            snippetExtractor.ExtractSnippets();
            Console.WriteLine("Snippet extracting finished!");
        }

        static CodeSmellsData codeSmellsData = new CodeSmellsData();

        static void GenerateFakeUsers()
        {
            Console.WriteLine("Generating fake users...");
            UserGenerator userGenerator = new UserGenerator(codeSmellsData);
            userGenerator.Generate();
            Console.WriteLine("Fake users generated!");
        }

        /*static void GenerateFakePosts()
        { 
            
        }*/

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("CodeSmells data seeder");
                Console.WriteLine("- - -");
                //First: Sniff for code files.
                //SniffForCodeFiles();
                //Second: Extract code snippets.
                //ExtractSnippetsFromFiles();
                //Third: Generate some users.
                GenerateFakeUsers();
                //Get required info and generate posts
                //GenerateFakePosts()

            }
            catch (Exception boom) 
            {
                Console.WriteLine("[!] Ups, something went wrong! "+boom.Message);
            }
        }
    }
}
