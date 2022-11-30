using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolAut0mater.CoreService.MITs
{
    public static class CatalogNames
    {
        public const string YesNo /*                    */ = "YesNo";
        public const string Gender /*                   */ = "Gender";
        public const string Nationality /*              */ = "Nationality";
        public const string Cron /*                     */ = "Cron";
        public const string Currency /*                 */ = "Currency";
        public const string Department /*               */ = "Department";

        public static class Store
        {
            public const string ItemCategory /*         */ = "Store.ItemCategory";
            public const string ItemBrand /*            */ = "Store.ItemBrand";
            public const string ItemModel /*            */ = "Store.ItemModel";
        }

        public static class Staff
        {
            public const string Category /*             */ = "Staff.Category";
            public const string ManagementPosition /*   */ = "Staff.MgmtPosition";
            public const string Department /*           */ = "Staff.Department";
            public const string SchoolDivision /*       */ = "Staff.SchoolDivision";
            public const string EducationLevel /*       */ = "Staff.Education";
            public const string MaritialStatus /*       */ = "Staff.MaritialStatus";

            public static class LessonObservationOrWalk
            {
                public const string Subjects /*         */ = "Staff.LOW.Subjects";
                public const string GradeLevel /*       */ = "Staff.LOW.GradeLevel";
                public const string Period /*           */ = "Staff.LOW.Period";
                public const string Checklist /*        */ = "Staff.LOW.Checklist";
                public const string Types /*            */ = "Staff.LOW.Types";
                public const string Grading /*          */ = "Staff.LOW.Grading";
            }

            public static class PersonalGrowth
            {
                public const string Category /*         */ = "Staff.PeG.Category";
            }

            public static class ProfessionalGrowth
            {
                public const string ScoreType /*        */ = "Staff.PfG.ScoreType";
                public const string Score /*            */ = "Staff.PfG.Score";
            }
        }

        public static class Approval
        {
            public const string Type /*                 */ = "ApprovalType";
            public const string Request /*              */ = "ApprovalRequest";
            public const string Response /*             */ = "ApprovalResponse";
        }
    }
}
