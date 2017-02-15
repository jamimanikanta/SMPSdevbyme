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
  public  class HolderPersonCls : IHolderPerson1
    {


        private Holderpersonrep1 Rep;
        public HolderPersonCls(Holderpersonrep1 holderPerson)
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
        public void releaseslot(HolderPerson1 HLD)
        {

            Rep.releaseslot(HLD);

            throw new NotImplementedException();
        }
    }
}
