using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAC.Utils.Abstractions;

namespace TAC.Utils.TestModels
{
    public class TestTranslate : ITranslate
    {
        private readonly Dictionary<string, string> _terms;
        private readonly string _fixed;
        public TestTranslate(string term)
        {
            _fixed = term;
        }
        public TestTranslate(Dictionary<string,string> terms)
        {
            _terms = terms;
        }
        public string Text(string key)
        {
            if (_fixed != null) return _fixed;
            return _terms[key];
        }
    }
}
