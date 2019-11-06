using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DibawinWebsite.Repository.Extension
{
    public interface IEntityEx<TName>
    {
        TName Name { get; set; }
    }
}