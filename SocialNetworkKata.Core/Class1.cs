namespace SocialNetworkKata.Core
{
    public interface IUnitOfWork
    {
        public void PrintMessage();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public void PrintMessage()
        {
            Console.WriteLine("interface injected.");
        }
    }
}