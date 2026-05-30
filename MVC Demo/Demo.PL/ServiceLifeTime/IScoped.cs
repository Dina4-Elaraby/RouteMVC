namespace Demo.Presentation.ServiceLifeTime
{
    public interface IScoped
    {
        string GetGuid();
    }
    public class Scoped : IScoped
    {
        private Guid guid;
        public Scoped()
        {
            guid = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return guid.ToString();
        }
    }
}
