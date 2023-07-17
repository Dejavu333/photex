
namespace PHOTEX.MODEL.DOMAIN
{
    public sealed class Photo
    {
        //properties
        public string name { get; set; }
        public string path { get; set; }
        public string fullpath { get; set; }

        //constructors
        public Photo(string p_name, string p_path)
        {
            this.name = p_name;
            this.path = p_path;
            this.fullpath = Path.Combine(p_path, p_name);
        }
    }
}
