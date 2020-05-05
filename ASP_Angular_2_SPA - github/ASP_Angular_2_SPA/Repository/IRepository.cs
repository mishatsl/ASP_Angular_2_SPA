using ASP_Angular_2_SPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Angular_2_SPA.Repository
{
    public interface IRepository
    {
        IQueryable<ParsingInfo> ParsingInfos  { get; }
        ParsingInfo GetParsingInfo(int id);
        void SaveParsingInfo(ParsingInfo parsingInfo);
        ParsingInfo DeleteParsingInfo(int id);

    }
}
