namespace LabLibrary
{
    public interface ICommunicaion
    {
        string Name { get; }
        void ReceiveMessage(ICommunicaion sender, string message);
    }
}
