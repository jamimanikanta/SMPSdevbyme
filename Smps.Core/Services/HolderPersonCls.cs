using Smps.Core.Interfaces.Holder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smps.Core.BusinessObjects.Holder1;
using Smps.Core.Interfaces.Holder1.Repositories;
namespace Smps.Core.Services
{
  public  class HolderPerson : IHolderPerson
    {


        private IHolderPersonRepository Rep;
        public HolderPerson(IHolderPersonRepository holderPerson)
        {
            try
            {
                //Storing the object instance.
                this.Rep = holderPerson;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int releaseslot(BusinessObjects.Holder1.HolderPerson HLD)
        {
            try
            {

               return  Rep.releaseslot(HLD);

            }
            catch (Exception)
            {

                throw new NotImplementedException();

            }



        }
    }
}
