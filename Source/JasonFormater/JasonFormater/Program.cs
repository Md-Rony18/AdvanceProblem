
namespace JasonFormater
{
    public class MainClass
    {
        public static void Main(string[] agrs)
        {
            Course course = new Course()
            {
                Fees = 30000,
                Title = "Asp.net",
                Teacher = new Instructor
                {
                    Name = "Jalal Uddin",
                    Email = "jalal@gmail.com",
                    PhoneNumbers = new List<Phone>
                    {
                        new Phone()
                        {
                            Number = "01796136070",
                            Extension = "GP",
                            CountryCode = "+880",
                        },
                        new Phone()
                        {
                            Number = "01796136070",
                            Extension = "BL",
                            CountryCode = "+880",
                        }
                    },
                    PermanentAddress = new Address()
                    {
                        City = "Bogura",
                        Street = "SantaharRoad",
                        Country = "Bangladesh",
                    },
                    PresentAddress = new Address()
                    {
                        City = "Bogura",
                        Street = "SantharRoad",
                        Country = "Bangladesh",
                    }
                },
                Tests = new List<AdmissionTest>
                {
                    new AdmissionTest()
                    {
                        TestFees=100,
                        StartDateTime=DateTime.Now,
                        EndDateTime=DateTime.Now,
                    }
                },
                Topics = new List<Topic>
                {
                    new Topic()
                    {
                        Description="Description",
                        Sessions=new List<Session>()
                        {
                            new Session()
                            {
                                DurationInHour=60,
                                LearningObjective="LearningObjective",
                            }
                        },
                        Title="Reflection",
                    }
                },
            };
            string jason = JsonFormate.Convert<Course>(course);
            Console.WriteLine("{"+"\n" + jason +"}");
        }
        

    }
}