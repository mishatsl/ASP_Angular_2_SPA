using ASP_Angular_2_SPA.Controllers;
using ASP_Angular_2_SPA.Models;
using ASP_Angular_2_SPA.Parser;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject
{
    public class ParsingInfoControllerTest
    {
        [Fact]
        public void Can_Get_ParsingInfo()
        {
            var mock = new Mock<IParser>();
            mock.Setup(mbox => mbox.GetParsingInfo(0,9)).Returns(
                new ParsingInfo {
                DescriptionCount = 1,
                h1Count = 1,
                ExternalAHREFSCount = 1,
                InternalAHREFSCount = 1,
                NodesInfoList = new List<NodeInfo>
            
            {
                new NodeInfo{
                    Name = "title",
                    Content = "title test",
                   Index = 1,
                   outerHtml = @"<title>title test</title>",
                   ParsingInfoId = 2
                },
                new NodeInfo{
                    Name = "img",
                    Content = "img test",
                   Index = 1,
                   outerHtml = @"<img />",
                   ParsingInfoId = 2
                },new NodeInfo{
                    Name = "h1",
                    Content = "h1 test",
                   Index = 1,
                   outerHtml = @"<h1>h1 test</h1>",
                   ParsingInfoId = 2
                },new NodeInfo{
                    Name = "InternalAHREFSCount",
                    Content = "InternalAHREFSCount test",
                   Index = 1,
                   outerHtml = @"<a>InternalAHREFSCount test</a>",
                   ParsingInfoId = 2
                }
                ,new NodeInfo{
                    Name = "ExternalAHREFSCount",
                    Content = "ExternalAHREFSCount test",
                   Index = 1,
                   outerHtml = @"<a>ExternalAHREFSCount test</a>",
                   ParsingInfoId = 2
                },
            },
                imagesCount = 3,
                parsingName = "test",
                ServerResponce = 200,
                TitleCount = 1,
                url = "",
                ResponseTime = "500ms"
            });


            ParsingInfoController parsingInfoController = new ParsingInfoController(mock.Object);

            var result = parsingInfoController.Get(@"http://test.com");

            var ActionResult = Assert.IsType<OkObjectResult>(result);

            Assert.True(((result as OkObjectResult).Value as ParsingInfo).NodesInfoList.Count() == 5);
            Assert.True(((result as OkObjectResult).Value as ParsingInfo).ExternalAHREFSCount == 1);
            Assert.True(((result as OkObjectResult).Value as ParsingInfo).ResponseTime == "500ms");
            Assert.True(((result as OkObjectResult).Value as ParsingInfo).ServerResponce == 200);

            // var model = Assert.IsAssignableFrom<ParsingInfo>((ActionResult as OkObjectResult).ExecuteResult.model);
        }
    }
}
