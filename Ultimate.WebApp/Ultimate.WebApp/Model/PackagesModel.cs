using System;
using Ultimate.WebApp.Model.Validations;
namespace Ultimate.WebApp.Model
{
    public class PackagesModel
    {
        public int id { get; set; }
        [RequiredAttr]
        public string name { get; set; }


        [RequiredAttr]
        public string foreignName { get; set; }

        [RequiredAttr]
        public string description { get; set; }


        [RequiredAttr]
        public string foreignDescription { get; set; }
        [RequiredAttr]
        public string status { get; set; } = "basic";
        
        public double disCount { get; set; }
        [RequiredAttr]
        public int periodId { get; set; }
        public virtual PeriodModel period { get; set; }
        public List<packageServicesModel> packageServices { set; get; } = new List<packageServicesModel>();

        //{
        //    get { return packageServices; }
        //    set {
        //        packageServices= value;
        //        tot=packageServices.Sum(x=>x.price);
        //    }
        //}
        public bool isShowDetails { set; get; }=false;
        public string lessMore { set; get; } = "m";
    }
}
