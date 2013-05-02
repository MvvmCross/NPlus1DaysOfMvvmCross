namespace Books.Core.Services
{
    public class BookSearchItem
    {
        public string kind { get; set; }
        public string id { get; set; }
        public VolumeInfo volumeInfo { get; set; }

        public override string ToString()
        {
            return volumeInfo.title;
        }
    }
}