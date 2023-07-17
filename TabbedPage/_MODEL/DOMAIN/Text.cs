namespace PHOTEX.MODEL.DOMAIN
{
    public sealed class Text
    {
        //properties
        public string name { get; set; }
        public string fullpath { get; set; }
        public string path { get; set; }
        public int length { get; set; }
        public string content { get; set; }

        //constructors
        public Text(string name, string path, string content)
        {
            this.name = name;
            this.fullpath = Path.Combine(path, name);
            this.path = path;
            this.length = content.Length;
            this.content = content;
        }
        public Text(string content)
        {
            this.name = Path.GetRandomFileName();
            this.fullpath = Path.Combine(FileSystem.AppDataDirectory, name);
            this.path = FileSystem.AppDataDirectory;
            this.length = content.Length;
            this.content = content;
        }
    }
}
