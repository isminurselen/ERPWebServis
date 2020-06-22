using System;


namespace ERPWebServis.Model
{
    public partial class SETUP_CITY
    {
        public int CITY_ID { get; set; }
        public string CITY_NAME { get; set; }
        public string PHONE_CODE { get; set; }
        public string PLATE_CODE { get; set; }
        public Nullable<int> COUNTRY_ID { get; set; }
        public Nullable<System.DateTime> RECORD_DATE { get; set; }
        public Nullable<int> RECORD_EMP { get; set; }
        public string RECORD_IP { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public Nullable<int> UPDATE_EMP { get; set; }
        public string UPDATE_IP { get; set; }
        public Nullable<int> PRIORITY { get; set; }
    }
}
