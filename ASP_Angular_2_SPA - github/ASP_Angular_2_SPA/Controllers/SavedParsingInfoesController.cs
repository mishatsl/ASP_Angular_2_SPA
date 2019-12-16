using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Angular_2_SPA.Models;
using ASP_Angular_2_SPA.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_Angular_2_SPA.Controllers
{
    [Produces("application/json")]
    [Route("api/SavedParsingInfoes/[action]")]
    public class SavedParsingInfoesController : Controller
    {
       // ParsingInfoContext ParsingInfoContext;
        IRepository repository;
        List<ParsingInfo> ParsingInfos;
        List<ParsingInfoSimplified> parsingInfoSimplifieds = new List<ParsingInfoSimplified>();
       // int count;

        public SavedParsingInfoesController(/*ParsingInfoContext ParsingInfoContext,*/ IRepository repo)
        {
           // this.ParsingInfoContext = ParsingInfoContext;
           // count = ParsingInfoContext.ParsingInfos.Count();
            repository = repo;
        }
        // GET: api/SavedParsingInfoes
        [HttpGet]
        public IActionResult GetParsingInfoSimplified(int page = 1)
        {
           
                PagingInfo pagingInfo = new PagingInfo
                {
                    currentPage = page,
                    maxSize = 3,
                    totalItems = repository.ParsingInfos.Count()
                };
                ParsingInfos = repository.ParsingInfos.Skip((pagingInfo.currentPage - 1) * pagingInfo.maxSize).Take(pagingInfo.maxSize).ToList();
            if (ParsingInfos != null)
            {
                for (int i = 0; i < ParsingInfos.Count(); i++)
                {
                    parsingInfoSimplifieds.Add(new ParsingInfoSimplified
                    {
                        ParsingInfoSimplifiedId = ParsingInfos[i].Id,
                        parsingInfoSName = ParsingInfos[i].parsingName,
                        url = ParsingInfos[i].url
                    });
                }
                return Ok(new ParsingListViewModel
                {
                    pagingInfo = pagingInfo,
                    parsingInfoSimplifieds = parsingInfoSimplifieds
                });
            }
            return NotFound();
        }

        // GET: api/SavedParsingInfoes/5
        [HttpGet]
        public ParsingInfo GetParsingInfo(int id)
        {
            ParsingInfo parsingInfo = repository.GetParsingInfo(id);// ParsingInfoContext.ParsingInfos.Include(p => p.NodesInfoList).FirstOrDefault(p => p.Id == id);
            return parsingInfo;
        }
        
        // POST: api/SavedParsingInfoes
        [HttpPost]
        public IActionResult Post([FromBody]ParsingInfo parsingInfo)
        {
            if (ModelState.IsValid)
            {
                repository.SaveParsingInfo(parsingInfo);
                //ParsingInfoContext.ParsingInfos.Add(parsingInfo);
                //ParsingInfoContext.SaveChanges();
                return Ok(parsingInfo);
            }
            return BadRequest(ModelState);
        }

       


        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ParsingInfo parsingInfo = repository.DeleteParsingInfo(id);//ParsingInfoContext.ParsingInfos.Include(p => p.NodesInfoList).FirstOrDefault(p => p.Id == id);
            if(parsingInfo != null)
            {
                //ParsingInfoContext.Remove(parsingInfo);
                //ParsingInfoContext.SaveChanges();
                return Ok(parsingInfo);
            }
            return NotFound();
        }

       
    }
}
