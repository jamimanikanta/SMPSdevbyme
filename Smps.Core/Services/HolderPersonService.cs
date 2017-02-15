using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smps.Core.BusinessObjects.Holder;
using Smps.Core.Interfaces.Holder;
using Smps.Core.Interfaces.Holder.Repositories;
namespace Smps.Core.Services
{
    class HolderPersonService : IHolderPerson
    {
        private IHolderpersonrepository IHP;
        public void releaseslottoday(HolderPerson HolderPerson)
        {

            IHP.releaseslottoday(HolderPerson);
            throw new NotImplementedException();
        }
    }
}
