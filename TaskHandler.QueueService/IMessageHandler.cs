using System.Messaging;

namespace TaskHandler.QueueService
{
    public interface IMessageHandler
    {
        /// <summary>
        /// Прочитать все сообщения из очереди
        /// </summary>
        /// <param name="messageFormatter"> Формат десериализации </param>
        /// <returns></returns>
        Message[] ReceiveAll(IMessageFormatter messageFormatter);

        /// <summary>
        /// Отправить сообщение в очередь
        /// </summary>
        /// <param name="obj"> Объект </param>
        /// <param name="messageFormatter"> Формат сериалзации </param>
        void SendMessage(object obj, IMessageFormatter messageFormatter);
    }
}