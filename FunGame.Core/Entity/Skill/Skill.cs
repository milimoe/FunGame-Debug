using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milimoe.FunGame.Core.Entity
{
    public abstract class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Describe { get; set; } = "";
        public char Key { get; set; }
        public bool Active { get; set; }
        public bool Enable { get; set; }
    }
}
