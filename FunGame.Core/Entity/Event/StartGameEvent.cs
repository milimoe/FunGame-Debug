﻿using Milimoe.FunGame.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milimoe.FunGame.Core.Entity.Event
{
    public class StartGameEvent : IStartGameEvent
    {
        public event IEvent.BeforeEvent? BeforeStartGameEvent;
        public event IEvent.AfterEvent? AfterStartGameEvent;
        public event IEvent.SucceedEvent? SucceedStartGameEvent;
        public event IEvent.FailedEvent? FailedStartGameEvent;

        public virtual Enum.EventResult OnBeforeStartGameEvent(GeneralEventArgs e)
        {
            if (BeforeStartGameEvent != null)
            {
                return BeforeStartGameEvent(this, e);
            }

            return Enum.EventResult.Fail;
        }

        public virtual Enum.EventResult OnAfterStartGameEvent(GeneralEventArgs e)
        {
            if (AfterStartGameEvent != null)
            {
                return AfterStartGameEvent(this, e);
            }

            return Enum.EventResult.Fail;
        }

        public virtual Enum.EventResult OnSucceedStartGameEvent(GeneralEventArgs e)
        {
            if (SucceedStartGameEvent != null)
            {
                return SucceedStartGameEvent(this, e);
            }

            return Enum.EventResult.Fail;
        }

        public virtual Enum.EventResult OnFailedStartGameEvent(GeneralEventArgs e)
        {
            if (FailedStartGameEvent != null)
            {
                return FailedStartGameEvent(this, e);
            }

            return Enum.EventResult.Fail;
        }
    }
}
