using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportEU.Core;

namespace Data
{
    public class GroupData : BaseEntityData, IEntityData
    {

        public string GroupName { get; set; }
        public int? MembersAmount { get; set; }
        public CoachData Coach { get; set; }
        public AthleteData Athlete { get; set; }
    }
}
