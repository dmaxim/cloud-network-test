using System.Collections.Generic;
using Network.Tester.Models;

namespace Network.UI.Models
{
    public class WineryIndexModel
    {
        public WineryIndexModel(IList<Winery> wineries)
        {
            Wineries = wineries;
        }
        
        public IList<Winery> Wineries { get; }
        
    }
}