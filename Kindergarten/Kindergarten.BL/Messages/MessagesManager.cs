using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.BL.Edit;
using Kindergarten.BL.Query;
using Kindergarten.Data;
using Kindergarten.Domain.Entities;
using NHibernate.Linq;

namespace Kindergarten.BL.Messages
{
    public class DBMessagesManager : IMessanger
    {

        public void SendMessage(Person sender, string title, string body, List<Person> recipients)
        {
            var msg = new Message
            {
                Body = body,
                Sender = sender,
                Recipients = recipients,
                Title = title,
                SendTime = DateTime.Now
            };

            MessageEdit.Instance.Add(msg);
        }

        public List<Message> GetPersonMessages(Person recipient)
        {
            return new MessageQuery{Person = recipient}.GetByFilter().ToList();
        }
    }
}
