using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public static class Cloning
    {
        public static GuestRequest Clone(this GuestRequest original)
        {
            GuestRequest r = new GuestRequest
            {
                guest_request_key = original.guest_request_key,
                Status = original.Status,
                RegistrationDate = original.RegistrationDate,
                firstName = original.firstName,
                FamilyName = original.FamilyName,
                MailAddress = original.MailAddress,
                FhoneNumber = original.FhoneNumber,
                EntryDate = original.EntryDate,
                ReleaseDate = original.ReleaseDate,
                Area = original.Area,
                SubArea = original.SubArea,
                Type = original.Type,
                Adults = original.Adults,
                Children = original.Children,
                Pool = original.Pool,
                Jacuzzi = original.Jacuzzi,
                Garden = original.Garden,
                ChildrensAttractions = original.ChildrensAttractions,
                
            };
            return r;
        }
        
        public static BankBranch Clone(this BankBranch original)
        {
            BankBranch b = new BankBranch
            {
                BankNumber = original.BankNumber,
                BankName = original.BankName,
                BranchNumber = original.BranchNumber,
                BranchAddress = original.BranchAddress,
                BranchCity = original.BranchCity,
            };
            return b;
        }
        public static Order Clone(this Order original)
        {
            Order o = new Order
            {
                Order_key= original.Order_key,
                Status = original.Status,
                CreateDate = original.CreateDate,
                OrderDate = original.OrderDate,
                Amount_to_pay = original.Amount_to_pay,
            };
            return o;
        }
        public static HostingUnit Clone(this HostingUnit original)
        {

            HostingUnit h = new HostingUnit
            {
                hosting_unit_key= original.hosting_unit_key,
                Owner = original.Owner.Clone(),
                Diary = original.Diary,
                HostingUnitName = original.HostingUnitName,
                Type = original.Type,
                Adults = original.Adults,
                Children = original.Children,
                Area = original.Area,
                SubArea = original.SubArea,
                ChildrensAttractions = original.ChildrensAttractions,
                Garden = original.Garden,
                Pool = original.Pool,
                Jacuzzi = original.Jacuzzi,
            };
            return h;
        }
        public static MyHost Clone(this MyHost original)
        {
            MyHost t = new MyHost
            {

                BankAccuont = original.BankAccuont.Clone(),
                FirstName_host = original.FirstName_host,
                LastName_host = original.LastName_host,
                Id_host = original.Id_host,
                Password_host = original.Password_host,
                FhoneNumber = original.FhoneNumber,
                MailAddress = original.MailAddress,
                BankAccountNumber = original.BankAccountNumber,
                CollectionClearance = original.CollectionClearance,
            };
            return t;
        }
        public static MyGuest Clone(this MyGuest original)
        {
            MyGuest targets = new MyGuest
            {
                FirstName = original.FirstName,
                LastName = original.LastName,
                Id = original.Id,
                Password = original.Password
            };
            return targets;
        }    
    }
}