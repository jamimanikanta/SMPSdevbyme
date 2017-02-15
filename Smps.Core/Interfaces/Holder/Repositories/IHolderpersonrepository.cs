using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smps.Core.Interfaces.Holder.Repositories
{
    using Smps.Core.BusinessObjects.Holder;
   public interface IHolderpersonrepository
    {
        
        void releaseslottoday(HolderPerson HolderPerson);


    }
}
