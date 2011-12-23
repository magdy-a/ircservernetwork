﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCServer1.Entities.Commands
{
    public abstract class IRCCommandBase
    {
        public IRCCommandBase(string[] parameters)
        {
        }

        public abstract string ExecuteCommand(Session session);
    }
}
