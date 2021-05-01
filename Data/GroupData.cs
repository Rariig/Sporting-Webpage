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

        public int CoachId { get; set; }
        public int AthleteId { get; set; }
        public CoachData Coach { get; set; }
        public ICollection<AthleteData> Athlete { get; set; }
    }
}
