namespace SalessoftJsonTests.Model
{
    public class HelloWorld
    {
        public string? Hello { get; set; }
        public short? Integer16 { get; set; }
        public int? Integer32 { get; set; }
        public long? Integer64 { get; set; }
        public bool Boolean { get; set; }
        public bool? BooleanNull { get; set; } = null;
        public DateTime? DateTime { get; set; }
        public Guid? Guid { get; set; }
        public HelloWorld SubObject { get; set; } = null;
    }
}
