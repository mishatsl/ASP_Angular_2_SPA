using ASP_Angular_2_SPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Angular_2_SPA.Parser
{
    public interface IParser
    {
        void parse();
        string ErrorMessege { get; set; }
        string url { set; get; }
        IEnumerable<NodeInfo> getNodesInfo(string nodeName, int startIndex, int endIndex);
        string ResponseTime(string Uri);
        int ServerResponce(string Uri);
        ParsingInfo GetParsingInfo(int startIndex,int endIndex);
        int nodesCount(string nodeName);
    }
}
