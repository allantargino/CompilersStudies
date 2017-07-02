using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNumbers
{
    [DebuggerDisplay("{Code}: {Symbol}")]
    public class Token
    {
        public TokenCode Code { get; set; }
        public string Symbol { get; set; }
    }
}
