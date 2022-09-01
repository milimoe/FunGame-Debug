﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunGame.Core.Api.Model.Entity
{
    public class ActiveItem : Item
    {
        public ActiveSkill? Skill { get; set; } = null;

        public ActiveItem()
        {
            Active = true;
        }
    }
}