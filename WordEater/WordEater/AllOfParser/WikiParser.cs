using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace WordEater.AllOfParser
{
    class WikiParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument doc)
        {
            var divs = doc.QuerySelectorAll("div").Where(x => x.ClassName != null && x.ClassName.Contains("mw-category-group"));
            List<object> items = new List<object>();
            List<string> Words = new List<string>();
            foreach (var item in divs)
            {
                //items.Add(item.QuerySelectorAll("a").Where(x => x.TextContent != null));
                var listik = item.QuerySelectorAll("a").Where(x => x.TextContent != null).ToList();
                items.AddRange(listik);
            }
            foreach (var i in items)
            {
                Words.Add(((IElement)i).TextContent);
            }

            return Words.ToArray();
        }
    }
}
