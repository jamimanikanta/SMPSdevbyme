using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smps.Core.Interfaces.Seeker
{
    public interface ISeekerService
    {
        string RequestForSlot(int EmpNo);
    }
}
