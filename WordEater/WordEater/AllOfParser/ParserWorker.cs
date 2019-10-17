using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordEater.AllOfParser
{
    class ParserWorker<T> where T: class
    {
        readonly List<string> FirstWords;
        IParser<T> parser;
        IParserSettings parserSettings;
        HtmlLoader loader;
        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;

        #region Properties
        public IParser<T> Parser
        {
            get { return parser; }
            set { parser = value; }
        }
        public IParserSettings ParserSettings
        {
            get { return parserSettings; }
            set { parserSettings = value; loader = new HtmlLoader(value, Category); }
        }
        public bool IsActive { get; private set; }
        public int Category { get; private set; }
        #endregion

        public ParserWorker(IParser<T> parser, int category, List<string> firstWords)
        {
            this.parser = parser;
            Category = category;
            FirstWords = firstWords;
            
        }
        public ParserWorker(IParser<T> parser, IParserSettings parserSetting, int category, List<string> firstWords) : this(parser, category, firstWords)
        {
            this.parserSettings = parserSetting;
            //Category = category;
            //FirstWords = new List<string>();

        }
        public void Start()
        {
            IsActive = true;
            Worker();
        }
        public void Abort()
        {
            IsActive = false;
        }
        private async void Worker()
        {
            for (int i = 0; i < FirstWords.Count; i++)
            {
                if (!IsActive)
                {
                    OnCompleted?.Invoke(this);
                    return;
                }
                var source = await loader.GetSourceByPage(FirstWords[i]);
                var domParser = new HtmlParser();
                var document = await domParser.ParseDocumentAsync(source);
                var result = parser.Parse(document);
                OnNewData?.Invoke(this, result);
            }
            OnCompleted?.Invoke(this);
            IsActive = false;
        }
    }
}
