namespace LabLibrary
{
    // интерфейс для коммуникации между объектами классов
    public interface ICommunication
    {
        // имя участника коммуникации
        string Name { get; }
        List<string> ReceivedMessages { get; }
        // функция для принятия сообщения объектом
        void ReceiveMessage(ICommunication sender, string message);
    }
}
