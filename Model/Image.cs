namespace E_ComMIniProj.Model
{
    public class Image
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public byte[]? Data { get; set; }
        public string? ContentType { get; set; }
    }
}
