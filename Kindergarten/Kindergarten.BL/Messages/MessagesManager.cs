﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.Data;
using Kindergarten.Domain.Entities;
using NHibernate.Linq;

namespace Kindergarten.BL.Messages
{
    public class DBMessagesManager: IMessanger
    {

        public void SendMessage(Person sender, string title, string body, List<Person> recipients)
        {
            Message msg = new Message(){Body = body,Sender = sender,Recipients = recipients,Title = title, SendTime = DateTime.Now};
            SessionFactoryHelper.CurrentSession.Save(msg);
        }

        public List<Message> GetPersonMessages (Person recipient)
        {
            return SessionFactoryHelper.CurrentSession.Query<Message>().Where(c=>c.Recipients.Contains(recipient)).ToList();
        }
    }

    public interface IMessanger
    {
        void SendMessage(Person sender, string title, string body, List<Person> recipients);
        List<Message> GetPersonMessages(Person recipient);  
    }
}
