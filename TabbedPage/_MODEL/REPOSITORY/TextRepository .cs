using PHOTEX.MODEL.DOMAIN;

namespace PHOTEX.MODEL.REPOSITORY
{
    public class TextRepository : ITextRepository<Text>
    {

        public void save(Text txt)
        {
            // Write the text to the file.
            File.WriteAllText(txt.fullpath, txt.content);
        }

        public IEnumerable<Text> readAll()
        {
            // Read every file in the directory
            string[] files = Directory.GetFiles(FileSystem.AppDataDirectory);
            List<Text> texts = new List<Text>();
            foreach (string file in files)
            {
                // Read the contents of the file
                string content = File.ReadAllText(file);
                // Create a new Text object
                Text txt = new Text(Path.GetFileName(file),Path.GetDirectoryName(file), content);
                // Add the Text object to the list
                texts.Add(txt);
            }
            return texts;
        }
    }
}