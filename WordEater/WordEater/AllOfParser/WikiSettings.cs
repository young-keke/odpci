using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordEater.AllOfParser
{
    class WikiSettings:IParserSettings
    {
        public string BaseURL { get; set; } = "https://ru.wiktionary.org/w/index.php?title=%D0%9A%D0%B0%D1%82%D0%B5%D0%B3%D0%BE%D1%80%D0%B8%D1%8F:%D0%A1%D0%BB%D0%BE%D0%B2%D0%B0_%D0%B8%D0%B7_{Category}_%D0%B1%D1%83%D0%BA%D0%B2";
        public string Prefix { get; set; } = "ru&pagefrom={FirstWord}#mw-pages"; 
    }
}
