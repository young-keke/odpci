using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordEater.AllOfParser
{
    interface IParserSettings
    {
        string BaseURL { get; set; }
        string Prefix { get; set; }
    }
}
