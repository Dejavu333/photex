using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PHOTEX.MODEL.DOMAIN;

namespace PHOTEX.MODEL.REPOSITORY
{
    public interface ITextRepository<T>
    {
        void save(T txt);
        IEnumerable<T> readAll();
    }
}
