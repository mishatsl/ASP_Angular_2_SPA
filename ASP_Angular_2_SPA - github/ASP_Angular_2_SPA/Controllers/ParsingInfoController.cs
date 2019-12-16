using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP_Angular_2_SPA.Models;
using HtmlAgilityPack;
using System.Text;
using System.Net;
using System.Diagnostics;
using ASP_Angular_2_SPA.Parser;
using System.ComponentModel.DataAnnotations;

namespace ASP_Angular_2_SPA.Controllers
{
    [Produces("application/json")]
    [Route("api/ParsingInfo/[action]")]
    public class ParsingInfoController : Controller
    {
        IParser parser;

        public ParsingInfoController(IParser p)
        {
            this.parser = p;
        }
        // GET: api/ParsingInfo
        [HttpGet]
        public IActionResult Get(
            [Url][Required] string url)
        {
            //HtmlWeb web = new HtmlWeb();

            //var htmlDoc = web.Load(url);
            //int paramSize = 9;

            ////var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");

            ////Uri uri = new Uri(@"https://netpeaksoftware.com/");
            ////string url2 = htmlDoc.DocumentNode.SelectNodes("//a").Where(n => n.XPath == "/html[1]/body[1]/nav[1]/div[1]/div[2]/ul[1]/li[1]/a[1]").FirstOrDefault().GetAttributeValue("href", "");

            ////Uri uri2 = new Uri(url2.ToAbsoluteUrl(url));
            ////int compRes = Uri.Compare(uri, uri2, UriComponents.Host, UriFormat.SafeUnescaped, StringComparison.CurrentCulture);


            //var Title = htmlDoc.DocumentNode.SelectNodes("//title");

            //var Description = htmlDoc.DocumentNode.SelectNodes("//meta").Where(n => n.GetAttributeValue("name", "").ToLower().Contains("description"));

            ////IEnumerable<HtmlNode> d = Description.Where(n => n.GetAttributeValue("name", "") == "description");

            ////d = Description.Where(n => n.GetAttributeValue("name", "").ToLower().Contains("description"));


            //var h1 = htmlDoc.DocumentNode.SelectNodes("//h1");
            //var images = htmlDoc.DocumentNode.SelectNodes("//img");
            //var InternalAHREFS = htmlDoc.DocumentNode.SelectNodes("//a").Where(n => (!string.IsNullOrEmpty(n.GetAttributeValue("href", "").ToAbsoluteUrl(url))) && Uri.Compare(new Uri(url), new Uri(n.GetAttributeValue("href", "").ToAbsoluteUrl(url)), UriComponents.Host, UriFormat.SafeUnescaped, StringComparison.CurrentCulture) == 0);
            //var ExternalAHREFS = htmlDoc.DocumentNode.SelectNodes("//a").Where(n => (!string.IsNullOrEmpty(n.GetAttributeValue("href", "").ToAbsoluteUrl(url))) && Uri.Compare(new Uri(url), new Uri(n.GetAttributeValue("href", "").ToAbsoluteUrl(url)), UriComponents.Host, UriFormat.SafeUnescaped, StringComparison.CurrentCulture) != 0);
            ////ParsingInfo parsingInfo =  new ParsingInfo {
            ////    Titles = CreateNodeInfo(Title, 1, paramSize),
            ////    Descriptions = CreateNodeInfo(Description, 1, paramSize),
            ////    h1s = CreateNodeInfo(h1, 1, paramSize),
            ////    images = CreateNodeInfo(images, 1, paramSize),
            ////    InternalAHREFS = CreateNodeInfo(InternalAHREFS, 1, paramSize),
            ////    ExternalAHREFS = CreateNodeInfo(ExternalAHREFS, 1, paramSize),
            ////    ResponseTime = ResponseTime(url),
            ////    ServerResponce = ServerResponce(url),
            ////    TitleCount = Title.Count(),
            ////    DescriptionCount = Description.Count(),
            ////    h1Count = h1.Count(),
            ////    imagesCount = images.Count(),
            ////    InternalAHREFSCount = InternalAHREFS.Count(),
            ////    ExternalAHREFSCount = ExternalAHREFS.Count()
            ////};
            //List<NodeInfo> NodesInfoList = new List<NodeInfo>();


            //NodesInfoList.AddRange(CreateNodeInfo(Title, 1, paramSize,"title"));
            //NodesInfoList.AddRange(CreateNodeInfo(Description, 1, paramSize, "description"));
            //NodesInfoList.AddRange(CreateNodeInfo(h1, 1, paramSize,"h1"));
            //NodesInfoList.AddRange(CreateNodeInfo(images, 1, paramSize,"img"));
            //NodesInfoList.AddRange(CreateNodeInfo(InternalAHREFS, 1, paramSize, "internalAHREF"));
            //NodesInfoList.AddRange(CreateNodeInfo(ExternalAHREFS, 1, paramSize, "externalAHREF"));


            //ParsingInfo parsingInfo = new ParsingInfo
            //{
            //    NodesInfoList = NodesInfoList,
            //    //Titles = CreateNodeInfo(Title, 1, paramSize),
            //    //Descriptions = CreateNodeInfo(Description, 1, paramSize),
            //    //h1s = CreateNodeInfo(h1, 1, paramSize),
            //    //images = CreateNodeInfo(images, 1, paramSize),
            //    //InternalAHREFS = CreateNodeInfo(InternalAHREFS, 1, paramSize),
            //    //ExternalAHREFS = CreateNodeInfo(ExternalAHREFS, 1, paramSize),
            //    ResponseTime = ResponseTime(url),
            //    ServerResponce = ServerResponce(url),
            //    TitleCount = Title.Count(),
            //    DescriptionCount = Description.Count(),
            //    h1Count = h1.Count(),
            //    imagesCount = images.Count(),
            //    InternalAHREFSCount = InternalAHREFS.Count(),
            //    ExternalAHREFSCount = ExternalAHREFS.Count(),
            //    url = url
            //};
            if(ModelState.IsValid)
            {
                parser.url = url;
                parser.parse();
                if(string.IsNullOrEmpty(parser.ErrorMessege))
                {
                    return Ok(parser.GetParsingInfo(0, 9));
                }
                return BadRequest(parser.ErrorMessege);
            }
            return BadRequest();
        }

        // GET: api/ParsingInfo/5
        [HttpGet]
        public IActionResult UploadData([Url][Required] string url, string nodeName = "", int startIndex = 9, int endIndex = 18)
        {
            if(ModelState.IsValid)
            {
                parser.url = url;
                parser.parse();

                return Ok(parser.getNodesInfo(nodeName, startIndex, endIndex));

            }
            return BadRequest();
        }

        // POST: api/ParsingInfo
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ParsingInfo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private List<NodeInfo> CreateNodeInfo(IEnumerable<HtmlNode> nodes, int part, int paramSize,string NodeName)
        {
            
            if (nodes.Count() > 0)
            {
                List<NodeInfo> nodeInfos = new List<NodeInfo>();
                nodes = nodes.Skip((part - 1) * paramSize).Take(paramSize);
                foreach (var node in nodes)
                    nodeInfos.Add( new NodeInfo { Name = NodeName, outerHtml = node.OuterHtml, Content = node.InnerHtml });
                return nodeInfos;
            }
            else
            {
                return null;
            }
        }

        private string ResponseTime(string Uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Uri);
            System.Diagnostics.Stopwatch timer = new Stopwatch();
            timer.Start();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.Close();
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            return $"hours: {timeTaken.Hours} min: {timeTaken.Minutes} sec:{timeTaken.Seconds} Milliseconds: {timeTaken.Milliseconds}";
        }

        private int ServerResponce(string Uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Uri);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            int status = (int)response.StatusCode;
            return  status;
        }

       


    }

    public static class  UrlClass {
         public static string ToAbsoluteUrl(this string relativeUrl, string Url)
            {



            if (string.IsNullOrEmpty(relativeUrl))
                return Url;
            else if(relativeUrl.StartsWith("/"))
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
