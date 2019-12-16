using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Angular_2_SPA.Models
{
    public class ParsingInfo
    {
        public int Id { set; get; }
        public string url { set; get; }
        public string parsingName { set; get; }
 //       public List<NodeInfo> Titles { set; get; }
 //       public List<NodeInfo> Descriptions { set; get; }
        public int ServerResponce { set; get; }
        public string ResponseTime { set; get; }
 //       public List<NodeInfo> h1s { set; get; }
 //       public List<NodeInfo> images { set; get; }
 //       public List<NodeInfo> InternalAHREFS { set; get; }
 //       public List<NodeInfo> ExternalAHREFS { set; get; }
        public int TitleCount { set; get; }
        public int DescriptionCount { set; get; }
        public int h1Count { set; get; }
        public int imagesCount { set; get; }
        public int InternalAHREFSCount { set; get; }
        public int ExternalAHREFSCount { set; get; }
        // **********************************************************************
        public List<NodeInfo> NodesInfoList { set; get; }
    }

    public class NodeInfo
    {
        public int Id { set; get; }
        public int Index { set; get; }
        public string Name { set; get; }
        public string outerHtml { set; get; }
        public string Content { set; get; }
        public int ParsingInfoId { get; set; }
        public ParsingInfo ParsingInfo { get; set; }
    }
}
