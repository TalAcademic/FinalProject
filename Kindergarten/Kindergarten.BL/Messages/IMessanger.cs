using System.Collections.Generic;
using Kindergarten.Domain.Entities;

namespace Kindergarten.BL.Messages
{
    public interface IMessanger
    {
        void SendMessage(Person sender, string title, string body, List<Person> recipients);
        List<Message> GetPersonMessages(Person recipient);
    }
}
