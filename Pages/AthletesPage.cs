using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportEU.Aids;
using SportEU.Data;
using SportEU.Domain;
using SportEU.Domain.Common;
using SportEU.Domain.Repos;
using SportEU.Facade;
using SportEU.Infra;
using SportEU.Pages.Common;

namespace SportEU.Pages
{
    public class AthletesPage : ViewPage<Athlete,AthleteView>
    {
        public override string PageTitle => "Athletes";

        public AthletesPage(ApplicationDbContext c) : this(new AthletesRepo(c), c) { }

        protected internal AthletesPage(IAthletesRepo r, ApplicationDbContext c = null) : base(r, c) { }

        public SelectList Groups
        {
            get
            {
                var l = new GetRepo().Instance<IGroupsRepo>().Get();
                return new SelectList(l, "Id", "Name", Item?.AthleteGroups);
            }
        }

        public bool IsAssigned(SelectListItem item)
            => Item?.AthleteGroups?
                .FirstOrDefault(x =>
                    x.GroupId == item.Value) is not null;

        protected internal override AthleteView toViewModel(Athlete a)
        {
            if (isNull(a)) return null;
            var v = Copy.Members(a.Data, new AthleteView());
            //v.FullName = a.FullName;
            var photo = Convert.ToBase64String(a.Data.Photo ?? Array.Empty<byte>(), 0, a.Data.Photo?.Length ?? 0);
            v.PhotoAsString = "data:image/jpg;base64," + photo;
            v.AthleteGroups = new List<GroupAssignmentView>();
            if (a.GroupAssignments is null) return v;
            v.AthleteGroups.AddRange(a.GroupAssignments.Select(toGroupAssignmentView).ToList());
            return v;
        }

        internal static GroupAssignmentView toGroupAssignmentView(GroupAssignment g)
            => new() { GroupId = g.Group.Id, Name = g.Group.Name };

        protected internal override Athlete toEntity(AthleteView v)
        {
            var d = Copy.Members(v, new AthleteData());
            var obj = new Athlete(d);
            //if (string.IsNullOrEmpty(v.Photo?.FileName)) return obj;
            var stream = new MemoryStream();
            v.Photo?.CopyTo(stream);
            if (stream.Length < 2097152) d.Photo = stream.ToArray();
            if (v?.AthleteGroups is null) return obj;
            foreach (var c in v.AthleteGroups) obj.AddGroup(c?.GroupId);
            return obj;
        }

        
        protected internal override void doBeforeCreate(AthleteView v, string[] selectedGroups = null)
        { //see teeb valesti siin, selectedgroups ei tohiks 0 kohe olla. peaks näitama valitud gruppe. Pidin panema BasePages nime vastavaks nendel async meetoditel, nüüd toimib.
            //TODO composite key viga parandada tickboxiga eemaldamises. praegu on commented out repos.
            if (isNull(v)) return;
            var assignments = new List<GroupAssignmentView>();
            foreach (var group in selectedGroups ?? Array.Empty<string>())
            {
                var groupToAdd = new GroupAssignmentView
                {
                    GroupId = group
                };
                assignments.Add(groupToAdd);
            }

            v.AthleteGroups = assignments;
        }
        protected internal override void doBeforeEdit(AthleteView v, string[] selectedGroups = null)
            => doBeforeCreate(v, selectedGroups);
    } 
}
