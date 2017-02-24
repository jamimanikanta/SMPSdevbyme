using Smps.Core.Interfaces.Seeker;
using Smps.Core.Interfaces.Seeker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smps.Core.Services
{
   public class SeekerService : ISeekerService
    {
        private ISeekerRep ISR;

        public SeekerService(ISeekerRep ISR)
        {
            this.ISR = ISR;


        }

        public string RequestForSlot(int EmpNo)
 {


            try
            {
                return ISR.RequestForSlot(EmpNo);

            }
            catch(Exception ex)
            {

                throw ex;


            }

           
        }
    }
}
