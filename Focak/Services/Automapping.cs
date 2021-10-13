using AutoMapper;
using Focak.Data;
using Focak.Models;

namespace Focak.Services
{
    public class Automapping:Profile
    {
        public Automapping()
        {
            CreateMap<CrawlQueue, CrawlQueueDto>().ReverseMap().ForMember(x=>x.Id, opt=>opt.Ignore());
        }
    }
}
