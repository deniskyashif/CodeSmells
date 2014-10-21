namespace CodeSmells.DataSeeder.DataSeeding
{
    using System;
    using System.IO;

    public class SnippetExtractor
    {
        public string FilenamesDumpFile { get; private set; }

        public SnippetExtractor(string filenamesDumpFile)
        {
            this.FilenamesDumpFile = filenamesDumpFile;
        }

        public void ExtractSnippets(int numberOfSnippetsToExtract)
        {
            try
            {
                using (StreamReader filenamesDumpFile = new StreamReader(FilenamesDumpFile))
                {
                    
                }
            }
            catch (IOException IOboom)
            {
                throw new Exception("An IO error occurred. " + IOboom.Message);
            }
            catch (Exception boom)
            {
                throw new Exception("A generic error occured. " + boom.Message);
            }
        }
    }
}
