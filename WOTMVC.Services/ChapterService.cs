using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTMVC.Data;
using WOTMVC.Models.ChapterMods;

namespace WOTMVC.Services
{
    public class ChapterService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        private readonly Guid _userId;
        public ChapterService(Guid userId)
        {
            _userId = userId;
        }
        public bool ChapterCreate(ChapterCreate model)
        {
            var entity = new Chapter()
            {
                OwnerId = _userId,
                BookId = model.BookId,
                ChapNum = model.ChapNum,
                ChapTitle = model.ChapTitle,
                PageCount = model.PageCount,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Chapters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ChapterListItem> GetChaps()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Chapters.Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ChapterListItem
                        {
                            ChapterId = e.ChapterId,
                            ChapNum = e.ChapNum,
                            ChapTitle = e.ChapTitle,
                            PageCount = e.PageCount
                            //BookId = e.BookId,
                        }
                    );
                return query.ToArray();
            }
        }
    }
}
