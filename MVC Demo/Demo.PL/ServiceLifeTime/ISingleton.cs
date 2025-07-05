namespace Demo.Presentation.ServiceLifeTime
{
    public interface ISingleton
    {
        //signature for method
        string GetGuid();
    }
    public class Singleton:ISingleton
    {
        private Guid guid;
        public Singleton()
        {
            guid = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return guid.ToString();
        }
    }
}
