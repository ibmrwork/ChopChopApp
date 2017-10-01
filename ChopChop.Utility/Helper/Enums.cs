using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChopChop.Utility
{
    public class Enums
    {
        public enum WeakDays : int {
            Monday=1,
            Tuesday=2,
            Wednesday=3,
            Thrusday=4,
            Friday=5,
           
        }
        public enum WeakEnd : int
        {
            Saturday = 6,
            Sunday = 7
        }
       
        public enum Frequency : int
        {
            Monthly = 1,
            Quartrly = 2,
            [EnumDisplayName(DisplayName = "Half Yearly")]
            HalfYearly = 3,
            Yearly = 4
        }

        public enum UserTypes : int
        {
            Admin = 1,
            Vendor = 2,
            Customer = 3
        }

        public enum JobStatus : int
        {
            Open = 1,
            Awarded = 2,
            PendingProposal = 3
        }
        public enum OrderStatus : int
        {
            Open = 1,
            Awarded = 4,
            PendingProposal = 3,
            Submitted=2
            
        }
        public enum JobCategory : int
        {
            Contract = 1,
            SubContract = 2
        }

        public enum ProposalStatus : int
        {
            Active = 1,
            Submitted = 2,
            Completed = 3,
            Accepted=4,
            Rejected=5
        }

        public enum Race : int
        {
            Black = 1,
            Asian = 2,
            Hispanic = 3,
            [EnumDisplayName(DisplayName = "American Indian")]
            AmericanIndian = 4,
            Other = 5
        }

        public enum GeographicAreaServed : int
        {
            [EnumDisplayName(DisplayName = "North East")]
            Northeast = 1,
            [EnumDisplayName(DisplayName = "South East")]
            Southeast = 2,
            [EnumDisplayName(DisplayName = "Mid West")]
            Midwest = 3,
            [EnumDisplayName(DisplayName = "South West")]
            Southwest = 4,
            West = 5,
            Other = 6
        }

        public enum TimeZoneUS : int
        {
            [EnumDisplayName(DisplayName = "Samoa Time Zone")]
            SamoaTimeZone = 1,

            [EnumDisplayName(DisplayName = "Hawaii–Aleutian Time Zone")]
            HawaiiAleutianTimeZone = 2,

            [EnumDisplayName(DisplayName = "Alaska Time Zone")]
            AlaskaTimeZone = 3,

            [EnumDisplayName(DisplayName = "Pacific Time Zone")]
            PacificTimeZone = 4,

            [EnumDisplayName(DisplayName = "Mountain Time Zone")]
            MountainTimeZone = 5,

            [EnumDisplayName(DisplayName = "Central Time Zone")]
            CentralTimeZone = 6,

            [EnumDisplayName(DisplayName = "Eastern Time Zone")]
            EasternTimeZone = 7,

            [EnumDisplayName(DisplayName = "Atlantic Time Zone (Puerto Rico)")]
            AtlanticTimeZone = 8,

            [EnumDisplayName(DisplayName = "Chamorro Time Zone (Guam, Northern Mariana Islands)")]
            ChamorroTimeZone = 9,
        }
    }
}
