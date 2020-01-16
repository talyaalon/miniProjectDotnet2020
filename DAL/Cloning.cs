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
            GuestRequest target = new GuestRequest(original.Status, original.RegistrationDate, original.PrivateName, original.FamilyName, original.MailAddress, original.FhoneNumber, original.EntryDate, original.ReleaseDate, original.Area, original.SubArea, original.Type, original.Adults, original.Children, original.Pool, original.Jacuzzi, original.Garden, original.ChildrensAttractions);
            target.guest_request_key = original.guest_request_key;
            return target;
        }
        public static BankBranch Clone(this BankBranch original)
        {
            BankBranch target = new BankBranch(original.BankNumber, original.BankName, original.BranchNumber, original.BranchAddress, original.BranchCity);
            //target.id = original.id
            return target;
        }
        public static Order Clone(this Order original)
        {
            Order target = new Order(original.HostingUnitKey, original.GuestRequestKey, original.Status, original.CreateDate , original.OrderDate,  original.Amount_to_pay);
            target.Order_key = original.Order_key;
            return target;
        }
        public static HostingUnit Clone(this HostingUnit original)
        {
            HostingUnit targets = new HostingUnit(original.Owner, original.Diary, original.HostingUnitName);
            targets.hosting_unit_key = original.hosting_unit_key;
            return targets;
        }
    }
}