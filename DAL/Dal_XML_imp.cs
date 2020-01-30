using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DAL
{
    public static class Dal_XML_imp
    {
        private static string Path = @"..\..\..\xml\";
        static Dal_XML_imp()
        {

        }
        public static bool[,] GetDiary(XElement xElement)
        {
            bool[,] Diary = new bool[12, 31];
            XElement xmlDiary = xElement;

            for (int i = 1; i <= 12; i++)
            {
                for (int k = 1; k <= 31; k++)
                {

                    var Day = (from diary in xmlDiary.Elements()
                               let month = diary.Element("M" + i.ToString())                              
                               let day = month.Element("day" + k.ToString())
                               select day.Value).ToList()[0];
                    Diary[i - 1, k - 1] = bool.Parse(Day);
                }

            }

            return Diary;
        }
        public static XElement SetDiary(BE.HostingUnit hostingUnit)
        {
            List<XElement> xElementsMonth = new List<XElement>();
            List<XElement> days = new List<XElement>();

            
            for (int i = 1; i <= 12; i++)
            {
                for (int k = 1; k <= 31; k++)
                {
                    days.Add(new XElement("day" + k.ToString(), hostingUnit.Diary[i - 1, k - 1].ToString()));
                }
                xElementsMonth.Add(new XElement("M" + i.ToString(), days));
                days.Clear();
            }
            XElement Diary = new XElement("Diary", xElementsMonth);

            return Diary;

        }


        public static void AddGuestRequestToXml(BE.GuestRequest guestRequest)
        {
            XElement xmlElement = XElement.Load(Path + "guestRequest.xml");
            XElement guest_request_key = new XElement("guest_request_key", guestRequest.guest_request_key);
            XElement firstName = new XElement("firstName", guestRequest.firstName);
            XElement lastName = new XElement("lastName", guestRequest.FamilyName);
            XElement MailAddress = new XElement("MailAddress", guestRequest.MailAddress);
            XElement FhoneNumber = new XElement("FhoneNumber", guestRequest.FhoneNumber);
            XElement Status = new XElement("Status", guestRequest.Status);
            XElement RegistrationDate = new XElement("RegistrationDate", guestRequest.RegistrationDate);
            XElement EntryDate = new XElement("EntryDate", guestRequest.EntryDate);
            XElement ReleaseDate = new XElement("ReleaseDate", guestRequest.ReleaseDate);
            XElement Area = new XElement("Area", guestRequest.Area);
            XElement SubArea = new XElement("SubArea", guestRequest.Status);
            XElement Type = new XElement("Type", guestRequest.Type);
            XElement Adults = new XElement("Adults", guestRequest.Adults);
            XElement Children = new XElement("Children", guestRequest.Children);
            XElement Pool = new XElement("Pool", guestRequest.Pool);
            XElement Jacuzzi = new XElement("Jacuzzi", guestRequest.Jacuzzi);
            XElement Garden = new XElement("Garden", guestRequest.Garden);
            XElement ChildrensAttractions = new XElement("ChildrensAttractions", guestRequest.ChildrensAttractions);
            XElement ID_of_Guest = new XElement("ID_of_Guest", guestRequest.ID_of_Guest);
            XElement GuestRequest = new XElement("guestRequest", guest_request_key, firstName, lastName, MailAddress, FhoneNumber, Status,
                RegistrationDate, EntryDate, ReleaseDate, Area, SubArea, Type, Adults,
                Children, Pool, Jacuzzi, Garden, ChildrensAttractions, ID_of_Guest);
            xmlElement.Add(GuestRequest);
            xmlElement.Save(Path + "guestRequest.xml");
        }
        public static List<BE.GuestRequest> GetGuestRequestFromXml()
        {
            try

            {
                XElement guestRequests = XElement.Load(Path + "guestRequest.xml");

                var AllguestRequests = (from guest in guestRequests.Elements()
                                        select new BE.GuestRequest()
                                        {
                                            guest_request_key = long.Parse(guest.Element("firstName").Value),
                                            firstName = guest.Element("firstName").Value,
                                            FamilyName = guest.Element("FamilyName").Value,
                                            MailAddress = guest.Element("MailAddress").Value,
                                            FhoneNumber = guest.Element("FhoneNumber").Value,
                                            ID_of_Guest = guest.Element("ID_of_Guest").Value,
                                            Status = (BE.My_enum.Status)Enum.Parse(typeof(BE.My_enum.Status), guest.Element("Status").Value),
                                            RegistrationDate = DateTime.Parse(guest.Element("ID_of_Guest").Value),
                                            EntryDate = DateTime.Parse(guest.Element("EntryDate").Value),
                                            ReleaseDate = DateTime.Parse(guest.Element("ReleaseDate").Value),
                                            Area = (BE.My_enum.Area)Enum.Parse(typeof(BE.My_enum.Area), guest.Element("Area").Value),
                                            SubArea = guest.Element("SubArea").Value,
                                            Type = (BE.My_enum.Type)Enum.Parse(typeof(BE.My_enum.Type), guest.Element("Type").Value),
                                            Children = int.Parse(guest.Element("Children").Value),
                                            Adults = int.Parse(guest.Element("Adults").Value),
                                            Pool = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), guest.Element("Pool").Value),
                                            Jacuzzi = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), guest.Element("Jacuzzi").Value),
                                            Garden = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), guest.Element("Garden").Value),
                                            ChildrensAttractions = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), guest.Element("ChildrensAttractions").Value),
                                        }).ToList();
                return AllguestRequests.ToList();
            }
            catch
            {
                return null;
            }
        }

        public static BE.GuestRequest GetGuestRequestFromXml(int i)
        {
            try
            {
                XElement guestRequests = XElement.Load(Path + "guestRequest.xml");

                var AllguestRequests = (from guest in guestRequests.Elements()
                                        select new BE.GuestRequest()
                                        {
                                            guest_request_key = long.Parse(guest.Element("firstName").Value),
                                            firstName = guest.Element("firstName").Value,
                                            FamilyName = guest.Element("FamilyName").Value,
                                            MailAddress = guest.Element("MailAddress").Value,
                                            FhoneNumber = guest.Element("FhoneNumber").Value,
                                            ID_of_Guest = guest.Element("ID_of_Guest").Value,
                                            Status = (BE.My_enum.Status)Enum.Parse(typeof(BE.My_enum.Status), guest.Element("Status").Value),
                                            RegistrationDate = DateTime.Parse(guest.Element("ID_of_Guest").Value),
                                            EntryDate = DateTime.Parse(guest.Element("EntryDate").Value),
                                            ReleaseDate = DateTime.Parse(guest.Element("ReleaseDate").Value),
                                            Area = (BE.My_enum.Area)Enum.Parse(typeof(BE.My_enum.Area), guest.Element("Area").Value),
                                            SubArea = guest.Element("SubArea").Value,
                                            Type = (BE.My_enum.Type)Enum.Parse(typeof(BE.My_enum.Type), guest.Element("Type").Value),
                                            Children = int.Parse(guest.Element("Children").Value),
                                            Adults = int.Parse(guest.Element("Adults").Value),
                                            Pool = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), guest.Element("Pool").Value),
                                            Jacuzzi = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), guest.Element("Jacuzzi").Value),
                                            Garden = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), guest.Element("Garden").Value),
                                            ChildrensAttractions = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), guest.Element("ChildrensAttractions").Value),
                                        }).ToList();

                return AllguestRequests[i];

            }
            catch
            {
                return null;

            }
        }
        public static void AddGuestToXml(BE.MyGuest myGuest)
        {
            XElement xmlElement = XElement.Load(Path + "guest.xml");
            XElement FirstName = new XElement("FirstName", myGuest.FirstName);
            XElement LastName = new XElement("LastName", myGuest.LastName);
            XElement Id = new XElement("Id", myGuest.Id);
            XElement Password = new XElement("Password", myGuest.Password);
            XElement RegistrationDate = new XElement("RegistrationDate", myGuest.RegistrationDate);
            XElement guest = new XElement("myGuest", FirstName, LastName, Id, Password, RegistrationDate);
            xmlElement.Add(guest);
            xmlElement.Save(Path + "guest.xml");

        }
        public static List<BE.MyGuest> GetGuestFromXml()
        {
            try

            {
                XElement guests = XElement.Load(Path + "guest.xml");

                var Allguests = (from guest in guests.Elements()
                                 select new BE.MyGuest()
                                 {
                                     FirstName = guest.Element("FirstName").Value,
                                     LastName = guest.Element("LastName").Value,
                                     Id = guest.Element("Id").Value,
                                     Password = guest.Element("Password").Value,
                                 }).ToList();

                if (Allguests == null)
                {
                    throw new NotImplementedException("הלקוח לא נמצא");
                }

                return Allguests.ToList();
            }
            catch
            {
                return null;
            }
        }

        public static BE.MyGuest GetGuestFromXml(int i)
        {
            try

            {
                XElement MyGuest = XElement.Load(Path + "guest.xml");

                var AllMyHost = (from MyHost in MyGuest.Elements()
                                 select new BE.MyGuest()
                                 {
                                     FirstName = MyHost.Element("FirstName").Value,
                                     LastName = MyHost.Element("LastName").Value,
                                     Id = MyHost.Element("Id").Value,
                                     Password = MyHost.Element("Password").Value,

                                 }).ToList();
                return AllMyHost[i];
            }
            catch
            {
                throw new Exception("האורח לא קיים ");
            }
        }

        public static BE.MyGuest FindMyGuestToXml(string id)
        {
            try

            {
                XElement FindMyGuest = XElement.Load(Path + "guest.xml");


                var AllMyGuest = (from MyGuest in FindMyGuest.Elements()
                                  let nodes = MyGuest.Elements()
                                  where nodes.ToList().FirstOrDefault(nod => nod.Name == "Id").Value == id
                                  select new BE.MyGuest()
                                  {
                                      FirstName = MyGuest.Element("FirstName").Value,
                                      LastName = MyGuest.Element("LastName").Value,
                                      Id = MyGuest.Element("Id").Value,
                                      Password = MyGuest.Element("Password").Value,
                                  }).ToList();

                return AllMyGuest[0];
            }
            catch
            {
                return null;
            }
        }


        public static void AddMyHostToXml(BE.MyHost myHost)
        {
            XElement xmlElement = XElement.Load( Path +"hosts.xml");
            XElement FirstName_host = new XElement("FirstName_host", myHost.FirstName_host);
            XElement LastName_host = new XElement("LastName_host", myHost.LastName_host);
            XElement Id_host = new XElement("Id_host", myHost.Id_host);
            XElement Password_host = new XElement("Password_host", myHost.Password_host);
            XElement FhoneNumber = new XElement("FhoneNumber", myHost.FhoneNumber);
            XElement MailAddress = new XElement("MailAddress", myHost.MailAddress);
            XElement BankAccountNumber = new XElement("BankAccountNumber", myHost.BankAccountNumber);
            XElement BankAccuont = new XElement("BankAccuont", new XElement("BankName", myHost.BankAccuont.BankName),
                                                                               new XElement("BankNumber", myHost.BankAccuont.BankNumber),
                                                                               new XElement("BranchAddress", myHost.BankAccuont.BranchAddress),
                                                                               new XElement("BranchCity", myHost.BankAccuont.BranchCity),
                                                                               new XElement("BranchNumber", myHost.BankAccuont.BranchNumber));
            XElement CollectionClearance = new XElement("CollectionClearance", myHost.CollectionClearance);
            XElement host = new XElement("yHost", FirstName_host, LastName_host, Id_host, Password_host,
                FhoneNumber, MailAddress, BankAccountNumber, BankAccuont, CollectionClearance);
            xmlElement.Add(host);
            xmlElement.Save(Path + "hosts.xml");
        }
        public static List<BE.MyHost> GetMyHostFromXml()
        {
            try

            {
                XElement MyHosts = XElement.Load(@"..\..\..\xml\hosts.xml");

                var AllMyHost = (from MyHost in MyHosts.Elements()
                                 //let bankBranch = MyHost.Element("BankAccuont").Elements()
                                 select new BE.MyHost()
                                 {
                                     FirstName_host = MyHost.Element("FirstName_host").Value,
                                     LastName_host = MyHost.Element("LastName_host").Value,
                                     Id_host = MyHost.Element("Id_host").Value,
                                     Password_host = MyHost.Element("Password_host").Value,
                                     FhoneNumber = MyHost.Element("FhoneNumber").Value,
                                     MailAddress = MyHost.Element("MailAddress").Value,
                                     BankAccountNumber = int.Parse(MyHost.Element("BankAccountNumber").Value),
                                     CollectionClearance = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), MyHost.Element("CollectionClearance").Value),
                                     //(from MyHost in MyHosts.Elements() select MyHost).ToList()[0].Element("BankAccuont").Element("BankName").Value
                                     BankAccuont = new BE.BankBranch()
                                     {
                                         BankNumber = int.Parse(MyHost.Element("BankAccuont").Element("BankNumber").Value),
                                         BankName = MyHost.Element("BankAccuont").Element("BankName").Value,
                                         BranchNumber = int.Parse(MyHost.Element("BankAccuont").Element("BranchNumber").Value),
                                         BranchAddress = MyHost.Element("BankAccuont").Element("BranchAddress").Value,
                                         BranchCity = MyHost.Element("BankAccuont").Element("BranchCity").Value
                                         
                                     }


            }).ToList();
                return AllMyHost.ToList();
            }
            catch
            {
                return null;
            }
        }


    public static BE.MyHost GetMyHostFromXml(int i) // קבלה על ידי מיקום
        {
            try

            {
                XElement MyHosts = XElement.Load(Path + "hosts.xml");


                var AllMyHost = (from MyHost in MyHosts.Elements()
                                 select new BE.MyHost()
                                 {
                                     FirstName_host = MyHost.Element("FirstName_host").Value,
                                     LastName_host = MyHost.Element("LastName_host").Value,
                                     Id_host = MyHost.Element("Id_host").Value,
                                     Password_host = MyHost.Element("Password_host").Value,
                                     FhoneNumber = MyHost.Element("FhoneNumber").Value,
                                     MailAddress = MyHost.Element("MailAddress").Value,
                                     BankAccountNumber = int.Parse(MyHost.Element("BankAccountNumber").Value),
                                     CollectionClearance = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), MyHost.Element("CollectionClearance").Value),
                                     //(from MyHost in MyHosts.Elements() select MyHost).ToList()[0].Element("BankAccuont").Element("BankName").Value
                                     BankAccuont = new BE.BankBranch()
                                     {
                                         BankNumber = int.Parse(MyHost.Element("BankAccuont").Element("BankNumber").Value),
                                         BankName = MyHost.Element("BankAccuont").Element("BankName").Value,
                                         BranchNumber = int.Parse(MyHost.Element("BankAccuont").Element("BranchNumber").Value),
                                         BranchAddress = MyHost.Element("BankAccuont").Element("BranchAddress").Value,
                                         BranchCity = MyHost.Element("BankAccuont").Element("BranchCity").Value


                                     }


                                 }).ToList();

                return AllMyHost[i];
            }
            catch
            {
                return null;
            }
        }


        public static void AddHostingUnitToXml(BE.HostingUnit hostingUnit)
        {
            XElement xmlElement = XElement.Load(Path + "HostingUnit.xml");
            XElement hosting_unit_key = new XElement("hosting_unit_key", hostingUnit.hosting_unit_key);
            XElement Owner = new XElement("Owner", new XElement("FirstName", hostingUnit.Owner.FirstName_host),
                                                   new XElement("LastName_host", hostingUnit.Owner.LastName_host),
                                                   new XElement("Id_host", hostingUnit.Owner.Id_host),
                                                   new XElement("Password_host", hostingUnit.Owner.Password_host),
                                                   new XElement("FhoneNumber", hostingUnit.Owner.FhoneNumber),
                                                   new XElement("MailAddress", hostingUnit.Owner.MailAddress),
                                                   new XElement("BankAccountNumber", hostingUnit.Owner.BankAccountNumber),
                                                   new XElement("CollectionClearance", hostingUnit.Owner.CollectionClearance),
                                                   new XElement("BankAccuont", new XElement("BankName",  hostingUnit.Owner.BankAccuont.BankName),
                                                                               new XElement("BankNumber", hostingUnit.Owner.BankAccuont.BankNumber),
                                                                               new XElement("BranchAddress", hostingUnit.Owner.BankAccuont.BranchAddress),
                                                                               new XElement("BranchCity", hostingUnit.Owner.BankAccuont.BranchCity),
                                                                               new XElement("BranchNumber", hostingUnit.Owner.BankAccuont.BranchNumber)));  
            XElement HostingUnitName = new XElement("HostingUnitName", hostingUnit.HostingUnitName);
            XElement Diary = new XElement("Diary", SetDiary(hostingUnit));
            XElement price_Of_Night_To_Adult = new XElement("price_Of_Night_To_Adult", hostingUnit.price_Of_Night_To_Adult);
            XElement price_Of_Night_To_Child = new XElement("price_Of_Night_To_Child", hostingUnit.price_Of_Night_To_Child);
            XElement Type = new XElement("Type", hostingUnit.Type);
            XElement Adults = new XElement("Adults", hostingUnit.Adults);
            XElement Children = new XElement("Children", hostingUnit.Children);
            XElement Area = new XElement("Area", hostingUnit.Area);
            XElement SubArea = new XElement("SubArea", hostingUnit.SubArea);
            XElement ChildrensAttractions = new XElement("ChildrensAttractions", hostingUnit.ChildrensAttractions);
            XElement Garden = new XElement("Garden", hostingUnit.Garden);
            XElement Pool = new XElement("Pool", hostingUnit.Pool);
            XElement Jacuzzi = new XElement("Jacuzzi", hostingUnit.Jacuzzi);
            XElement hostingunit = new XElement("hostingUnit", hosting_unit_key, Owner, HostingUnitName, Diary, price_Of_Night_To_Adult, price_Of_Night_To_Child,
                Type, Adults, Children, Area, SubArea, ChildrensAttractions, Garden, Pool, Jacuzzi);
            xmlElement.Add(hostingunit);
            xmlElement.Save(Path + "HostingUnit.xml");

        }
        public static List<BE.HostingUnit> GetHostingUnitFromXml()
        {
            try
            {
                XElement HostingUnits = XElement.Load(Path +"HostingUnit.xml");

                var AllHostingUnit = (from HostingUnit in HostingUnits.Elements()
                                      select new BE.HostingUnit()
                                      {
                                          Owner = new BE.MyHost()
                                          {
                                              FirstName_host = HostingUnit.Element("Owner").Element("FirstName").Value,
                                              LastName_host = HostingUnit.Element("Owner").Element("LastName_host").Value,
                                              Id_host = HostingUnit.Element("Owner").Element("Id_host").Value,
                                              Password_host = HostingUnit.Element("Owner").Element("Password_host").Value,
                                              FhoneNumber = HostingUnit.Element("Owner").Element("FhoneNumber").Value,
                                              MailAddress = HostingUnit.Element("Owner").Element("MailAddress").Value,
                                              BankAccountNumber = int.Parse(HostingUnit.Element("Owner").Element("BankAccountNumber").Value),
                                              CollectionClearance = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), HostingUnit.Element("Owner").Element("CollectionClearance").Value),
                                              BankAccuont = new BE.BankBranch()
                                              {
                                                  BankNumber = int.Parse(HostingUnit.Element("Owner").Element("BankAccuont").Element("BankNumber").Value),
                                                  BankName = HostingUnit.Element("Owner").Element("BankAccuont").Element("BankName").Value,
                                                  BranchNumber = int.Parse(HostingUnit.Element("Owner").Element("BankAccuont").Element("BranchNumber").Value),
                                                  BranchAddress = HostingUnit.Element("Owner").Element("BankAccuont").Element("BranchAddress").Value,
                                                  BranchCity = HostingUnit.Element("Owner").Element("BankAccuont").Element("BranchCity").Value
                                              },

                                          },

                                          hosting_unit_key = long.Parse(HostingUnit.Element("hosting_unit_key").Value),
                                          Diary = GetDiary(HostingUnit.Element("Diary")),
                                          HostingUnitName = HostingUnit.Element("HostingUnitName").Value,
                                          price_Of_Night_To_Adult = int.Parse(HostingUnit.Element("price_Of_Night_To_Adult").Value),
                                          price_Of_Night_To_Child = int.Parse(HostingUnit.Element("price_Of_Night_To_Child").Value),
                                          Type = (BE.My_enum.Type)Enum.Parse(typeof(BE.My_enum.Type), HostingUnit.Element("Type").Value),
                                          Adults = int.Parse(HostingUnit.Element("Adults").Value),
                                          Children = int.Parse(HostingUnit.Element("Children").Value),
                                          Area = (BE.My_enum.Area)Enum.Parse(typeof(BE.My_enum.Area), HostingUnit.Element("Area").Value),
                                          SubArea = HostingUnit.Element("SubArea").Value,
                                          ChildrensAttractions = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), HostingUnit.Element("ChildrensAttractions").Value),
                                          Garden = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), HostingUnit.Element("Garden").Value),
                                          Pool = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), HostingUnit.Element("Pool").Value),
                                          Jacuzzi = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), HostingUnit.Element("Jacuzzi").Value),
                                      }).ToList();


                return AllHostingUnit.ToList();
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static BE.HostingUnit GetHostingUnitFromXml(int i) // קבלה על ידי מיקום
        {
            try

            {
                XElement HostingUnits = XElement.Load(Path + "HostingUnit.xml");

                var AllHostingUnit = (from HostingUnit in HostingUnits.Elements()
                                      select new BE.HostingUnit()
                                      {
                                          Owner = new BE.MyHost()
                                          {
                                              FirstName_host = HostingUnit.Element("FirstName_host").Value,
                                              LastName_host = HostingUnit.Element("LastName_host").Value,
                                              Id_host = HostingUnit.Element("Id_host").Value,
                                              Password_host = HostingUnit.Element("Password_host").Value,
                                              FhoneNumber = HostingUnit.Element("FhoneNumber").Value,
                                              MailAddress = HostingUnit.Element("MailAddress").Value,
                                              BankAccountNumber = int.Parse(HostingUnit.Element("BankAccountNumber").Value),
                                              CollectionClearance = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), HostingUnit.Element("CollectionClearance").Value),

                                              BankAccuont = new BE.BankBranch()
                                              {
                                                  BankNumber = int.Parse(HostingUnit.Elements("BankAccuont").ElementAt(0).Value),
                                                  BankName = HostingUnit.Elements("BankAccuont").ElementAt(1).Value,
                                                  BranchNumber = int.Parse(HostingUnit.Elements("BankAccuont").ElementAt(2).Value),
                                                  BranchAddress = HostingUnit.Elements("BankAccuont").ElementAt(3).Value,
                                                  BranchCity = HostingUnit.Elements("BankAccuont").ElementAt(4).Value,
                                              },
                                          },
                                          hosting_unit_key = long.Parse(HostingUnit.Element("hosting_unit_key").Value),
                                          HostingUnitName = HostingUnit.Element("HostingUnitName").Value,
                                          price_Of_Night_To_Adult = int.Parse(HostingUnit.Element("price_Of_Night_To_Adult").Value),
                                          price_Of_Night_To_Child = int.Parse(HostingUnit.Element("price_Of_Night_To_Child").Value),
                                          Type = (BE.My_enum.Type)Enum.Parse(typeof(BE.My_enum.Type), HostingUnit.Element("Type").Value),
                                          Adults = int.Parse(HostingUnit.Element("Adults").Value),
                                          Children = int.Parse(HostingUnit.Element("Children").Value),
                                          Area = (BE.My_enum.Area)Enum.Parse(typeof(BE.My_enum.Area), HostingUnit.Element("Area").Value),
                                          SubArea = HostingUnit.Element("SubArea").Value,
                                          ChildrensAttractions = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), HostingUnit.Element("ChildrensAttractions").Value),
                                          Garden = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), HostingUnit.Element("Garden").Value),
                                          Pool = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), HostingUnit.Element("Pool").Value),
                                          Jacuzzi = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), HostingUnit.Element("Jacuzzi").Value),
                                      }).ToList();



                return AllHostingUnit[i];
            }
            catch
            {
                return null;
            }

        }
        public static BE.HostingUnit GetName_GiveHostingUnitFromxml(string name)
        {
            try
            {
                XElement HostingUnits = XElement.Load(Path + "HostingUnit.xml");

                var AllHostingUnit = (from HostingUnit in HostingUnits.Elements()
                                      let nodes = HostingUnit.Elements()
                                      where (nodes.ToList().FirstOrDefault(nod => nod.Name == "HostingUnitName").Value) == name
                                      select new BE.HostingUnit()
                                      {
                                          Owner = new BE.MyHost()
                                          {
                                              FirstName_host = HostingUnit.Element("FirstName_host").Value,
                                              LastName_host = HostingUnit.Element("LastName_host").Value,
                                              Id_host = HostingUnit.Element("Id_host").Value,
                                              Password_host = HostingUnit.Element("Password_host").Value,
                                              FhoneNumber = HostingUnit.Element("FhoneNumber").Value,
                                              MailAddress = HostingUnit.Element("MailAddress").Value,
                                              BankAccountNumber = int.Parse(HostingUnit.Element("BankAccountNumber").Value),
                                              CollectionClearance = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), HostingUnit.Element("CollectionClearance").Value),

                                              BankAccuont = new BE.BankBranch()
                                              {
                                                  BankNumber = int.Parse(HostingUnit.Elements("BankAccuont").ElementAt(0).Value),
                                                  BankName = HostingUnit.Elements("BankAccuont").ElementAt(1).Value,
                                                  BranchNumber = int.Parse(HostingUnit.Elements("BankAccuont").ElementAt(2).Value),
                                                  BranchAddress = HostingUnit.Elements("BankAccuont").ElementAt(3).Value,
                                                  BranchCity = HostingUnit.Elements("BankAccuont").ElementAt(4).Value,
                                              },
                                          },
                                          hosting_unit_key = long.Parse(HostingUnit.Element("hosting_unit_key").Value),
                                          HostingUnitName = HostingUnit.Element("HostingUnitName").Value,
                                          price_Of_Night_To_Adult = int.Parse(HostingUnit.Element("price_Of_Night_To_Adult").Value),
                                          price_Of_Night_To_Child = int.Parse(HostingUnit.Element("price_Of_Night_To_Child").Value),
                                          Type = (BE.My_enum.Type)Enum.Parse(typeof(BE.My_enum.Type), HostingUnit.Element("Type").Value),
                                          Adults = int.Parse(HostingUnit.Element("Adults").Value),
                                          Children = int.Parse(HostingUnit.Element("Children").Value),
                                          Area = (BE.My_enum.Area)Enum.Parse(typeof(BE.My_enum.Area), HostingUnit.Element("Area").Value),
                                          SubArea = HostingUnit.Element("SubArea").Value,
                                          ChildrensAttractions = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), HostingUnit.Element("ChildrensAttractions").Value),
                                          Garden = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), HostingUnit.Element("Garden").Value),
                                          Pool = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), HostingUnit.Element("Pool").Value),
                                          Jacuzzi = (BE.My_enum.Yes_Or_No)Enum.Parse(typeof(BE.My_enum.Yes_Or_No), HostingUnit.Element("Jacuzzi").Value),
                                      }).ToList();

                return AllHostingUnit[0];
            }
            catch
            {
                return null;
            }
        }


        public static void RemoveHostingUnitToXml(long hosting_unit_key)
        {
            XElement HostingUnits = XElement.Load(Path + "HostingUnit.xml");
            ((from HostingUnit in HostingUnits.Elements()
              let nodes = HostingUnit.Elements()
              where long.Parse(nodes.ToList().FirstOrDefault(nod => nod.Name == "hosting_unit_key").Value) == hosting_unit_key
              select HostingUnit)).Remove();


            HostingUnits.Save( Path + "HostingUnit.xml");
        }
        public static void AddOrderToXml(BE.Order Order)
        {
            XElement xmlElement = XElement.Load(Path +"Order.xml");
            XElement Order_key = new XElement("Order_key", Order.Order_key);
            XElement HostingUnitKey = new XElement("HostingUnitKey", Order.HostingUnitKey);
            XElement GuestRequestKey = new XElement("GuestRequestKey", Order.GuestRequestKey);
            XElement Status = new XElement("Status", Order.Status);
            XElement CreateDate = new XElement("CreateDate", Order.CreateDate);
            XElement OrderDate = new XElement("OrderDate", Order.OrderDate);
            XElement Amount_to_pay = new XElement("Amount_to_pay", Order.Amount_to_pay);
            XElement order = new XElement("Order", Order_key, HostingUnitKey, GuestRequestKey, Status, CreateDate, OrderDate, Amount_to_pay);
            xmlElement.Add(order);

            xmlElement.Save(Path + "Order.xml");
        }

        public static List<BE.Order> GetOrderFromXml()
        {
            try
            {
                XElement Orders = XElement.Load(Path + "Order.xml");

                var AllOrder = (from order in Orders.Elements()
                                        select new BE.Order()
                                        {
                                            Order_key =long.Parse( order.Element("Order_key").Value),
                                            HostingUnitKey = long.Parse(order.Element("HostingUnitKey").Value),
                                            GuestRequestKey = long.Parse(order.Element("GuestRequestKey").Value),
                                            Status = (BE.My_enum.Status)Enum.Parse(typeof(BE.My_enum.Status), order.Element("Status").Value),
                                            CreateDate = DateTime.Parse(order.Element("CreateDate").Value),
                                            OrderDate = DateTime.Parse(order.Element("OrderDate").Value),
                                            Amount_to_pay = Double.Parse(order.Element("Amount_to_pay").Value),
                                        }).ToList();

                if (AllOrder == null)
                {
                    throw new NotImplementedException("ההזמנה לא נמצאה");
                }

                return AllOrder.ToList();
            }
            catch 
            {
                return null;
            }
        }

    }
}




    