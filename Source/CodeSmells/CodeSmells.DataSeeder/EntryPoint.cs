namespace CodeSmells.DataSeeder
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using FileSniffing;
    using CodeSmells.Models;
    using CodeSmells.Data;
    using DataGenerators;

    class EntryPoint
    {
        static Random randomProvider=new Random();

        static string[] categories = new string[] {"PHP", "JS", "HTML", "CS", "CSS"};

        static Dictionary<string, List<string>> snippets = new Dictionary<string, List<string>>();

        //TODO: Major refactoring
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

        static void GenerateFakePosts()
        { 
            //List<Post> posts=new List<Post>();
            //load snippets
            //snippets.A
            foreach (string categ in categories)
            {
                snippets.Add(categ.ToLower(),new List<string>());
            }

            using (StreamReader snippetsReader = new StreamReader("snippets.txt")) 
            {
                string line = "";
                //assign language to post title
                string currentKey = "";
                string currentSnippet = "";
                while ((line = snippetsReader.ReadLine()) != null)
                {
                    string trimmedLine = line.Trim();
                    if (snippets.ContainsKey(trimmedLine)) 
                    {
                        if (currentKey != "" && currentSnippet != "")
                        {
                            snippets[currentKey].Add(currentSnippet);
                            currentKey = "";
                            currentSnippet="";
                        }
                        //
                        currentKey = trimmedLine;
                    }
                    else if (currentKey != "")
                    {
                        currentSnippet += trimmedLine;
                    }
                }            
            }
            //assign snippets to post titles
            //load users and assign random user to a post
            User[] users = codeSmellsData.Users.All().ToArray();
            //load post titles
            using(StreamReader postTitlesReader = new StreamReader("postTitles.txt"))
            {
                string phrase = "";
                //assign language to post title
                while ((phrase = postTitlesReader.ReadLine()) != null)
                {
                    string category = categories[randomProvider.Next(0, categories.Length - 1)];
                    string catToLower = category.ToLower();
                    string snippet = snippets[catToLower][randomProvider.Next(0, snippets[catToLower].Count - 1)];
                    //create post objects 
                    codeSmellsData.Posts.Add(new Post() { 
                        Title=String.Format(phrase,category),
                        //Author=users[randomProvider.Next(0,users.Length-1)],
                        AuthorId = users[randomProvider.Next(0, users.Length - 1)].Id,
                        Body=snippet
                    });
                    snippets[catToLower].Remove(snippet);
                }                
            }
            //save post objects
            codeSmellsData.SaveChanges();
        }

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
                //GenerateFakeUsers();
                //Get required info and generate posts
                GenerateFakePosts();

            }
            catch (Exception boom) 
            {
                Console.WriteLine("[!] Ups, something went wrong! "+boom.Message);
            }
        }
    }
}
