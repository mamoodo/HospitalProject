using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/*This is a custom model class to display the symptoms inside departments*/
/************************************************************************/
namespace features.Models
{
    public class DepartmentSymptoms
    {
        public Department department { get; set; }
        public List<Symptom> symptoms { get; set; }
    }
}