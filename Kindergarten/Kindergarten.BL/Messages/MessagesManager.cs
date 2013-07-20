﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.Domain.Entities;

namespace Kindergarten.BL.Messages
{
    public class MessagesManager
    {
        private static MessagesManager _instance;

        public static MessagesManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MessagesManager();
                }
                return Instance;
            }

        }

        private MessagesManager(){}

        public void SendMessage(Person sender, string title, string body, List<Person> recipients)
        {
            Message msg = new Message(){Body = body,Sender = sender,Recipients = recipients,Title = title, SendTime = DateTime.Now};
            SessionFactoryHelper.CurrentSession.Save(msg);
        }
    }
}
