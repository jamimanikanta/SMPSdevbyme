using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smps.Core.Interfaces.Holder
{
    using Smps.Core.BusinessObjects.Holder;
    public interface IHolderPerson
    {
        void releaseslottoday(HolderPerson HolderPerson);
    }
}
