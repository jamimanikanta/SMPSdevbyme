using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smps.Core.Interfaces.Seeker.Repositories
{
   public interface ISeekerRep
    {
        string RequestForSlot(int EmpNo);

    }
}
