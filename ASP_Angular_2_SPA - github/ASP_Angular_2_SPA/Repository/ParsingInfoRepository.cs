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

        public IEnumerable<ParsingInfo> ParsingInfos { get { return ParsingInfoContext.ParsingInfos; } }

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
            //ParsingInfo parsingInfo = ParsingInfoContext.ParsingInfos.Include(p => p.NodesInfoList).FirstOrDefault(p => p.Id == id);
            Microsoft.Data.SqlClient.SqlParameter param = new Microsoft.Data.SqlClient.SqlParameter("@Id");
            ParsingInfo parsingInfo = ParsingInfoContext.ParsingInfos.FromSqlRaw("GetParsingInfoById @Id", param);
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
