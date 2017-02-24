using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smps.Core.Interfaces.Holder1.Repositories
{

    using BusinessObjects.Holder1;
   public  interface IHolderPersonRepository
    {

       int releaseslot(HolderPerson HLD);
        

    }
}
