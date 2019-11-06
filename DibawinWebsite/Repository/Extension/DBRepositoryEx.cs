using DibawinWebsite.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DibawinWebsite.Repository.Extension
{
    public class DBRepositoryEx<TDbContext, TEntity, TName> : IRepository<TEntity, TName>
        where TDbContext : MyDBContext
        where TEntity : class, IEntityEx<TName>
    {
        TDbContext _db;
        public DBRepositoryEx(TDbContext db)
        {
            _db = db;
        }
        public List<TEntity> FindAlikeByName(TName name)
        {
            var Result = _db.Set<TEntity>().Where(x => x.Name.ToString().Contains(name.ToString())).ToList();
            return Result;
        }

        public List<TEntity> FindExactName(TName name)
        {
            var Result = _db.Set<TEntity>().Where(x => x.Name.ToString().ToLower() == name.ToString().ToLower()).ToList();
            return Result;
        }
    }
}
