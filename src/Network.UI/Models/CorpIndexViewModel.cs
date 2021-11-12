using System.Collections.Generic;
using Network.Tester.Models;

namespace Network.UI.Models
{
    public class CorpIndexViewModel
    {
        public CorpIndexViewModel(IList<Corp> corps)
        {
            Corps = corps;
        }

        public IList<Corp> Corps { get; }
    }
}
