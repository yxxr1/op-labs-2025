namespace LabLibrary
{
    // интерфейс для коммуникации между объктами классов
    public interface ICommunicaion
    {
        // имя участника коммуникации
        string Name { get; }
        // функция для принятия сообщения объектом
        void ReceiveMessage(ICommunicaion sender, string message);
    }
}
