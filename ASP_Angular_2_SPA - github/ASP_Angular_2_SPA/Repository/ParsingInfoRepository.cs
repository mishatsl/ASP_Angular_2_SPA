using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Angular_2_SPA.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_Angular_2_SPA.Repository
{
    public class ParsingInfoRepository : IRepository
    {
        ParsingInfoContext ParsingInfoContext;
        public ParsingInfoRepository(ParsingInfoContext parsingInfoContext)
        {
            ParsingInfoContext = parsingInfoContext;
        }

        public IQueryable<ParsingInfo> ParsingInfos { get { return ParsingInfoContext.ParsingInfos.AsNoTracking(); } }

        public ParsingInfo DeleteParsingInfo(int id)
        {
            ParsingInfo parsingInfo = ParsingInfoContext.ParsingInfos.Include(p => p.NodesInfoList).FirstOrDefault(p => p.Id == id);
            if (parsingInfo != null)
            {
                ParsingInfoContext.Remove(parsingInfo);
                ParsingInfoContext.SaveChanges();              
            }
            return parsingInfo;
        }

        public ParsingInfo GetParsingInfo(int id)
        {
            ParsingInfo parsingInfo = ParsingInfoContext.ParsingInfos.AsNoTracking().Include(p => p.NodesInfoList).FirstOrDefault(p => p.Id == id);
            return parsingInfo;
        }

        //public IEnumerable<PagingInfo> GetParsingInfos()
        //{
        //    return ParsingInfoContext.ParsingInfos;
        //}

        public void SaveParsingInfo(ParsingInfo parsingInfo)
        {
            ParsingInfoContext.ParsingInfos.Add(parsingInfo);
            ParsingInfoContext.SaveChanges();
        }
    }
}
