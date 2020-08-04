using System.Collections.Generic;
using System.Messaging;

namespace TaskHandler.QueueService
{
    public class MessageHandler : IMessageHandler
    {
        private const string privatePath = ".\\private$\\TasksQueue";
        private readonly MessageQueue _messageQueue;

        public MessageHandler()
        {
            _messageQueue = MessageQueue.Exists(privatePath) ? new MessageQueue(privatePath) : MessageQueue.Create(privatePath);
        }

        public void SendMessage(object obj, IMessageFormatter messageFormatter)
        {
            using (var msg = new Message(obj, messageFormatter))
            {
                _messageQueue.Send(msg);
            }
        }

        public Message[] ReceiveAll(IMessageFormatter messageFormatter)
        {
            _messageQueue.Formatter = messageFormatter;

            var messages = new List<Message>();

            using (var msgEnumerator = _messageQueue.GetMessageEnumerator2())
            {
                while (msgEnumerator.MoveNext())
                {
                    messages.Add(_messageQueue.ReceiveById(msgEnumerator.Current.Id));
                }
            }

            return messages.ToArray();
        }
    }
}
