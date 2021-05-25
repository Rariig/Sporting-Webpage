using System;
using System.IO;
using SportEU.Data;
using SportEU.Domain.Repos;
using SportEU.Pages.Common;
using SportEU.Aids;
using SportEU.Domain;
using SportEU.Facade;
using SportEU.Infra;

namespace SportEU.Pages
{
    public class CoachesPage : ViewPage<Coach, CoachView>
    {
        public override string PageTitle => "Coaches";

        public CoachesPage(ApplicationDbContext c) : this(new CoachesRepo(c), c) { }

        protected internal CoachesPage(ICoachesRepo r, ApplicationDbContext c = null) : base(r, c) { }

        protected internal override CoachView toViewModel(Coach c)
        {
            if (isNull(c)) return null;
            var v = Copy.Members(c.Data, new CoachView());
            v.FullName = c.FullName;
            v.Salary = c.Salary;
            v.Speciality = c.Speciality;
            v.PhoneNumber = c.PhoneNumber;
            var photo = Convert.ToBase64String(c.Data.Photo ?? Array.Empty<byte>(), 0, c.Data.Photo?.Length ?? 0);
            v.PhotoAsString = "data:image/jpg;base64," + photo;
            return v;
        }

        protected internal override Coach toEntity(CoachView v)
        {
            var d = Copy.Members(v, new CoachData());
            if (string.IsNullOrEmpty(v.Photo?.FileName)) return new Coach(d);
            var stream = new MemoryStream();
            v.Photo?.CopyTo(stream);
            if (stream.Length < 2097152) d.Photo = stream.ToArray();
            return new Coach(d);
        }
    }
}
