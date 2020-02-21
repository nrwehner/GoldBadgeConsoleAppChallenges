using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Company_Outings_Console_App
{
    /*
     * Outing Class                                         DONE
     *  Constructors                                        DONE
 *      Type Prop (with enum)                               DONE
 *      Attendance Prop                                     DONE
 *      Date Prop                                           DONE
 *      CostPerPerson Prop - Calc only based on TotalCost   DONE
 *      TotalCost Prop                                      DONE
     * */
    public class Outing
    {
        public enum TypeOfOuting { Golf, Bowling, AmusementPark, Concert }
        public Outing() { }
        public Outing(TypeOfOuting type,int attendance,DateTime outingDate,double outingCost)
        {
            OutingType = type;
            OutingAttendance = attendance;
            OutingDate = outingDate;
            OutingCost = outingCost;
        }
        public TypeOfOuting OutingType { get; set; }
        public int OutingAttendance { get; set; }
        public DateTime OutingDate { get; set; }
        public double OutingCost { get; set; }
        public double CostPerPerson
        {
            get
            {
                return OutingCost / OutingAttendance;
            }
        }
    }
}
