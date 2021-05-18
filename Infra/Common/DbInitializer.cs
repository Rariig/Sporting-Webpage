using System;
using System.Linq;
using SportEU.Data;

namespace SportEU.Infra.Common
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Athletes.Any()) return;

            var athletes = new AthleteData[] {
                new() {
                    FirstMidName = "Carson", LastName = "Alexander",
                    ValidFrom = DateTime.Parse("2010-09-01"),
                    Age = 22, Strength = 45
                },
                new() {
                    FirstMidName = "Meredith", LastName = "Alonso",
                    ValidFrom = DateTime.Parse("2012-09-01"),
                    Age = 16, Strength = 20
                },
                new() {
                    FirstMidName = "Arturo", LastName = "Anand",
                    ValidFrom = DateTime.Parse("2013-09-01"),
                    Age = 25, Strength = 89
                },
                new() {
                    FirstMidName = "Gytis", LastName = "Barzdukas",
                    ValidFrom = DateTime.Parse("2012-09-01"),
                    Age = 19, Strength = 90
                },
                new() {
                    FirstMidName = "Yan", LastName = "Li",
                    ValidFrom = DateTime.Parse("2012-09-01"),
                    Age = 56, Strength = 44
                },
                new() {
                    FirstMidName = "Peggy", LastName = "Justice",
                    ValidFrom = DateTime.Parse("2011-09-01"),
                    Age = 80, Strength = 30
                },
                new() {
                    FirstMidName = "Laura", LastName = "Norman",
                    ValidFrom = DateTime.Parse("2013-09-01"),
                    Age = 13, Strength = 10
                },
                new() {
                    FirstMidName = "Nino", LastName = "Olivetto",
                    ValidFrom = DateTime.Parse("2005-09-01"),
                    Age = 33, Strength = 67
                }
            };

            context.Athletes.AddRange(athletes);
            context.SaveChanges();

            var coaches = new CoachData[] {
                new() {
                    FirstMidName = "Kim", LastName = "Abercrombie",
                    ValidFrom = DateTime.Parse("1995-03-11"),
                    Age = 40, Salary = 1000, Speciality = "Iluuisutamine"
                },
                new() {
                    FirstMidName = "Fadi", LastName = "Fakhouri",
                    ValidFrom = DateTime.Parse("2002-07-06"),
                    Age = 35, Salary = 3000, Speciality = "Kehakultuur"
                },
                new() {
                    FirstMidName = "Roger", LastName = "Harui",
                    ValidFrom = DateTime.Parse("1998-07-01"),
                    Age = 30, Salary = 900, Speciality = "Jalgpall"
                },
                new() {
                    FirstMidName = "Candace", LastName = "Kapoor",
                    ValidFrom = DateTime.Parse("2001-01-15"),
                    Age = 60, Salary = 15000, Speciality = "Golf"
                },
                new() {
                    FirstMidName = "Roger", LastName = "Zheng",
                    ValidFrom = DateTime.Parse("2004-02-12"),
                    Age = 32, Salary = 2000, Speciality = "Odavise"
                }
            };

            context.Coaches.AddRange(coaches);
            context.SaveChanges();

            var groups = new GroupData[] {
                new() {
                    Name = "Odaviskajad"
                },
                new() {
                    Name = "Jalgpall algajatele"
                },
                new() {
                    Name = "Eesti parim eakate golfiklubi"
                },
                new() {
                    Name = "Uisutreeningud"
                },
                new() {
                    Name = "Jõusaal"
                }
            };

            context.Groups.AddRange(groups);
            context.SaveChanges();


            var groupAthletes = new GroupAssignmentData[] {
                new() {
                    GroupId = groups.Single(c => c.Name == "Uisutreeningud").Id,
                    AthleteId = athletes.Single(i => i.LastName == "Anand").Id
                },
                new() {
                    GroupId = groups.Single(c => c.Name == "Jalgpall algajatele").Id,
                    AthleteId = athletes.Single(i => i.LastName == "Anand").Id
                },
                new() {
                    GroupId = groups.Single(c => c.Name == "Eesti parim eakate golfiklubi").Id,
                    AthleteId = athletes.Single(i => i.LastName == "Justice").Id
                },
                new() {
                    GroupId = groups.Single(c => c.Name == "Jõusaal").Id,
                    AthleteId = athletes.Single(i => i.LastName == "Barzdukas").Id
                },
                new() {
                    GroupId = groups.Single(c => c.Name == "Jõusaal").Id,
                    AthleteId = athletes.Single(i => i.LastName == "Norman").Id
                },
                new() {
                    GroupId = groups.Single(c => c.Name == "Odaviskajad").Id,
                    AthleteId = athletes.Single(i => i.LastName == "Alonso").Id
                },
                new() {
                    GroupId = groups.Single(c => c.Name == "Eesti parim eakate golfiklubi").Id,
                    AthleteId = athletes.Single(i => i.LastName == "Li").Id
                },
                new() {
                    GroupId = groups.Single(c => c.Name == "Odaviskajad").Id,
                    AthleteId = athletes.Single(i => i.LastName == "Olivetto").Id
                },
            };

            context.GroupAssignments.AddRange(groupAthletes);
            context.SaveChanges();
        }
    }
}
