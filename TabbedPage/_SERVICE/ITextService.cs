using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHOTEX.SERVICE
{
    public interface ITextService<T>
    {
        IEnumerable<T> allTexts();
        
        Task saveTextLocally(T p_text);

        void copyText(T p_text);
    } 

   
}
