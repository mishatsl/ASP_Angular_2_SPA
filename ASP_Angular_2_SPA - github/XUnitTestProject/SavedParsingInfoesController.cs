using ASP_Angular_2_SPA.Models;
using ASP_Angular_2_SPA.Repository;
using Moq;
using System.Collections.Generic;
using System.Linq;
//using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject
{
    public class SavedParsingInfoesControllerTest
    {
        [Fact]
        public void Can_GetParsingInfoSimplified()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(m => m.ParsingInfos).Returns(new List<ParsingInfo> {
                new ParsingInfo
                {
                DescriptionCount = 1,
                h1Count = 1,
                ExternalAHREFSCount = 1,
                InternalAHREFSCount = 1,
                NodesInfoList = new List<NodeInfo>
                        {
                new NodeInfo
                {
                    Name = "title",
                    Content = "title test",
                   Index = 1,
                   outerHtml = @"<title>title test</title>",
                   ParsingInfoId = 2
                },
                new NodeInfo
                {
                    Name = "img",
                    Content = "img test",
                   Index = 1,
                   outerHtml = @"<img />",
                   ParsingInfoId = 2
                },
                    new NodeInfo
                    {
                    Name = "h1",
                    Content = "h1 test",
                   Index = 1,
                   outerHtml = @"<h1>h1 test</h1>",
                   ParsingInfoId = 2
                },
                    new NodeInfo
                    {
                    Name = "InternalAHREFSCount",
                    Content = "InternalAHREFSCount test",
                   Index = 1,
                   outerHtml = @"<a>InternalAHREFSCount test</a>",
                   ParsingInfoId = 2
                },
                    new NodeInfo
                    {
                    Name = "ExternalAHREFSCount",
                    Content = "ExternalAHREFSCount test",
                   Index = 1,
                   outerHtml = @"<a>ExternalAHREFSCount test</a>",
                   ParsingInfoId = 2
                    }
                },
                imagesCount = 3,
                parsingName = "test",
                ServerResponce = 200,
                TitleCount = 1,
                url = "",
                ResponseTime = "500ms"
            } 
            });

        }
    }
}
