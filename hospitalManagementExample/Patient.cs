using System;
using System.Collections.Generic;
using System.Text;

namespace hospitalManagementExample
{
    /*public enum PatientStatus
    {
        //by default tthey are assigned integer values starting at 0 
        Admitted, //0

        Discharged, //1

        ICU // 2
    }


    usually done if its smaller application 
*/



class Patient
    {

        public int id { get; set; }

        public string name { get; set; }

        public int age { get; set; }

        public string disease { get; set; }

        public PatientStatus status { get; set; }
    }


}
