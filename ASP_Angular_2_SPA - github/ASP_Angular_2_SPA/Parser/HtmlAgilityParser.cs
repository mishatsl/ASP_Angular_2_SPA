using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ASP_Angular_2_SPA.Models;
using HtmlAgilityPack;

namespace ASP_Angular_2_SPA.Parser
{
    public class HtmlAgilityParser : IParser
    {
        private HtmlDocument htmlDoc;
        private HtmlWeb web;
        private IEnumerable<HtmlNode> htmlNodes;
        //public string ErrorMessege = null;
        private int status;
        public string url { get; set; }
        public string ErrorMessege { get; set; }

        public IEnumerable<NodeInfo> getNodesInfo(string nodeName, int startIndex, int endIndex)
        {
            if (string.IsNullOrEmpty(ErrorMessege))
            {
                if (startIndex > endIndex || string.IsNullOrEmpty(nodeName))
                {
                    return null;
                }
                //IEnumerable<NodeInfo> nodeInfos;
                nodeName = nodeName.ToLower();

                if (nodeName.ToLower() == "internalahref")
                {
                    htmlNodes = htmlDoc.DocumentNode.SelectNodes("//a").Where(n => (!string.IsNullOrEmpty(n.GetAttributeValue("href", "").ToAbsoluteUrl(url))) && Uri.Compare(new Uri(url), new Uri(n.GetAttributeValue("href", "").ToAbsoluteUrl(url)), UriComponents.Host, UriFormat.SafeUnescaped, StringComparison.CurrentCulture) == 0);
                }
                else if (nodeName.ToLower() == "externalahref")
                {
                    htmlNodes = htmlDoc.DocumentNode.SelectNodes("//a").Where(n => (!string.IsNullOrEmpty(n.GetAttributeValue("href", "").ToAbsoluteUrl(url))) && Uri.Compare(new Uri(url), new Uri(n.GetAttributeValue("href", "").ToAbsoluteUrl(url)), UriComponents.Host, UriFormat.SafeUnescaped, StringComparison.CurrentCulture) != 0);
                }
                else if (nodeName.ToLower() == "description")
                {
                    htmlNodes = htmlDoc.DocumentNode.SelectNodes("//meta");
                    if (htmlNodes != null)
                    {
                        htmlNodes = htmlNodes.Where(n => n.GetAttributeValue("name", "").ToLower().Contains("description"));
                    }
                }
                else
                {
                    htmlNodes = htmlDoc.DocumentNode.SelectNodes("//" + nodeName);
                }
                if (htmlNodes != null)
                {
                    return CreateNodeInfo(htmlNodes.OrderBy(n => n.Line), startIndex, endIndex, nodeName);
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public int nodesCount(string nodeName)
        {
           
            //IEnumerable<NodeInfo> nodeInfos;
            nodeName = nodeName.ToLower();

            if (nodeName.ToLower() == "internalahref")
            {
                htmlNodes = htmlDoc.DocumentNode.SelectNodes("//a").Where(n => (!string.IsNullOrEmpty(n.GetAttributeValue("href", "").ToAbsoluteUrl(url))) && Uri.Compare(new Uri(url), new Uri(n.GetAttributeValue("href", "").ToAbsoluteUrl(url)), UriComponents.Host, UriFormat.SafeUnescaped, StringComparison.CurrentCulture) == 0);
            }
            else if (nodeName.ToLower() == "externalahref")
            {
                htmlNodes = htmlDoc.DocumentNode.SelectNodes("//a").Where(n => (!string.IsNullOrEmpty(n.GetAttributeValue("href", "").ToAbsoluteUrl(url))) && Uri.Compare(new Uri(url), new Uri(n.GetAttributeValue("href", "").ToAbsoluteUrl(url)), UriComponents.Host, UriFormat.SafeUnescaped, StringComparison.CurrentCulture) != 0);
            }
            else if(nodeName.ToLower() == "description")
            {
                htmlNodes = htmlDoc.DocumentNode.SelectNodes("//meta");
                if(htmlNodes != null)
                {
                    htmlNodes = htmlNodes.Where(n => n.GetAttributeValue("name", "").ToLower().Contains("description"));
                }
            }
            else
            {
                htmlNodes = htmlDoc.DocumentNode.SelectNodes("//" + nodeName);
            }

            if (htmlNodes != null)
            {
                return htmlNodes.Count();
            }
            return -1;
        }


        public ParsingInfo GetParsingInfo(int startIndex, int endIndex)
        {
            ParsingInfo parsingInfo;
            if (string.IsNullOrEmpty(ErrorMessege))
            {
                List<NodeInfo> NodesInfoList = new List<NodeInfo>();
                IEnumerable<NodeInfo> tempArr;
                List<string> tagNames = new List<string> { "title", "description", "h1", "img", "internalAHREF", "externalAHREF" };
                foreach (string tName in tagNames)
                {
                    tempArr = getNodesInfo(tName, startIndex, endIndex);
                    if (tempArr != null)
                    {
                        NodesInfoList.AddRange(tempArr);
                    }
                }
                //NodesInfoList.AddRange(getNodesInfo("title", startIndex, endIndex));
                //NodesInfoList.AddRange(getNodesInfo("description", startIndex, endIndex));
                //NodesInfoList.AddRange(getNodesInfo("h1", startIndex, endIndex));
                //NodesInfoList.AddRange(getNodesInfo("img", startIndex, endIndex));
                //NodesInfoList.AddRange(getNodesInfo("internalAHREF", startIndex, endIndex));
                //NodesInfoList.AddRange(getNodesInfo("externalAHREF", startIndex, endIndex));


                 parsingInfo = new ParsingInfo
                {
                    NodesInfoList = NodesInfoList,
                    //Titles = CreateNodeInfo(Title, 1, paramSize),
                    //Descriptions = CreateNodeInfo(Description, 1, paramSize),
                    //h1s = CreateNodeInfo(h1, 1, paramSize),
                    //images = CreateNodeInfo(images, 1, paramSize),
                    //InternalAHREFS = CreateNodeInfo(InternalAHREFS, 1, paramSize),
                    //ExternalAHREFS = CreateNodeInfo(ExternalAHREFS, 1, paramSize),
                    ResponseTime = ResponseTime(url),
                    ServerResponce = ServerResponce(url),
                    TitleCount = nodesCount("title"),
                    DescriptionCount = nodesCount("description"),
                    h1Count = nodesCount("h1"),
                    imagesCount = nodesCount("img"),
                    InternalAHREFSCount = nodesCount("internalAHREF"),
                    ExternalAHREFSCount = nodesCount("externalAHREF"),
                    url = url
                };
            }
            else
            {
                parsingInfo = new ParsingInfo
                {
                    parsingName = ErrorMessege,
                    ServerResponce = status
                };
            }

            return parsingInfo;
        }

        public void parse()
        {
            if (!string.IsNullOrEmpty(url))
            {
                try
                {
                    web = new HtmlWeb();
                    htmlDoc = web.Load(url);
                }
                catch(Exception ex)
                {
                   // status = (int)ex.Status;
                    ErrorMessege = ex.Message;
                }
               
            }
            
        }

        public string ResponseTime(string Uri)
        {
           
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Uri);
                System.Diagnostics.Stopwatch timer = new Stopwatch();
                timer.Start();
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                 response = ex.Response as HttpWebResponse;
                if (response != null)
                {
                    status = (int)response.StatusCode;
                }
                ErrorMessege = ex.Message;                
            }
            finally
            {
                timer.Stop();             
            }

            TimeSpan timeTaken = timer.Elapsed;
            return $"hours: {timeTaken.Hours} min: {timeTaken.Minutes} sec:{timeTaken.Seconds} Milliseconds: {timeTaken.Milliseconds}";

        }

    

        public int ServerResponce(string Uri)
        {
        HttpWebResponse response;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Uri);
            request.Method = "GET";
            response = (HttpWebResponse)request.GetResponse();
            int status = (int)response.StatusCode;
            return status;
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;                
                status = (int)response.StatusCode;
                ErrorMessege = ex.Message;
            }
            return status;
        }

        private List<NodeInfo> CreateNodeInfo(IEnumerable<HtmlNode> nodes, int startIndex, int endIndex, string NodeName)
        {

            if (nodes.Count() > 0)
            {
                List<NodeInfo> nodeInfos = new List<NodeInfo>();
                nodes = nodes.Skip(startIndex).Take(endIndex - startIndex - 1).ToList();
                foreach (var node in nodes)
                {
                    nodeInfos.Add(new NodeInfo { Index = ++startIndex, Name = NodeName, outerHtml = node.OuterHtml, Content = node.InnerHtml });
                }
                return nodeInfos;
            }
            else
            {
                return null;
            }
        }
    }

    public static class UrlClass
    {
        public static string ToAbsoluteUrl(this string relativeUrl, string Url)
        {



            if (string.IsNullOrEmpty(relativeUrl))
                return Url;
            else if (relativeUrl.StartsWith("/"))
            {
                var url = new Uri(Url);
                var port = url.Port != 80 ? (":" + url.Port) : String.Empty;

                return String.Format("{0}://{1}{2}{3}",
                    url.Scheme, url.Host, port, relativeUrl);
            }
            else if (relativeUrl.StartsWith("http"))
                return relativeUrl;
            else
                return null;

        }
    }
}
