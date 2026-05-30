namespace Demo.Presentation.ServiceLifeTime
{
    public interface ITransient
    {
        string GetGuid();
    }
    public class Transient : ITransient
    {
        private Guid guid;
        public Transient()
        {
            guid = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return guid.ToString();
        }
    }
}
