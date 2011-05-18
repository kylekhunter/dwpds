namespace nothinbutdotnetstore.specs
{
    public class StubGateway
    {
       static public T GetStub<T>() where T: new()
        {
            return new T();
        }
    }
}