using System;


namespace ERPWebServis.Model
{
    public partial class EMPLOYEES
    {
        public bool EMPLOYEE_STATUS { get; set; }
        public int EMPLOYEE_ID { get; set; }
        public Nullable<int> EMPAPP_ID { get; set; }
        public string MEMBER_CODE { get; set; }
        public string EMPLOYEE_USERNAME { get; set; }
        public string EMPLOYEE_PASSWORD { get; set; }
        public string EMPLOYEE_NO { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string EMPLOYEE_SURNAME { get; set; }
        public string TASK { get; set; }
        public string EMPLOYEE_EMAIL { get; set; }
        public Nullable<int> IMCAT_ID { get; set; }
        public string IM { get; set; }
        public Nullable<int> IMCAT2_ID { get; set; }
        public string IM2 { get; set; }
        public string DIRECT_TELCODE { get; set; }
        public string DIRECT_TEL { get; set; }
        public string EXTENSION { get; set; }
        public string MOBILCODE { get; set; }
        public string MOBILTEL { get; set; }
        public string CORBUS_TEL { get; set; }
        public string PHOTO { get; set; }
        public Nullable<bool> IS_AGENDA_OPEN { get; set; }
        public Nullable<int> PERIOD_ID { get; set; }
        public Nullable<int> COMPANY_ID { get; set; }
        public Nullable<bool> IS_IP_CONTROL { get; set; }
        public string IP_ADDRESS { get; set; }
        public string COMPUTER_NAME { get; set; }
        public Nullable<System.DateTime> GROUP_STARTDATE { get; set; }
        public string DYNAMIC_HIERARCHY { get; set; }
        public string DYNAMIC_HIERARCHY_ADD { get; set; }
        public string HIERARCHY { get; set; }
        public string OZEL_KOD { get; set; }
        public Nullable<System.DateTime> RECORD_DATE { get; set; }
        public Nullable<int> RECORD_EMP { get; set; }
        public string RECORD_IP { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public Nullable<int> UPDATE_EMP { get; set; }
        public string UPDATE_IP { get; set; }
        public string OZEL_KOD2 { get; set; }
        public Nullable<System.DateTime> KIDEM_DATE { get; set; }
        public Nullable<System.DateTime> IZIN_DATE { get; set; }
        public Nullable<int> IN_COMPANY_REASON_ID { get; set; }
        public Nullable<bool> IS_CRITICAL { get; set; }
        public Nullable<int> PHOTO_SERVER_ID { get; set; }
        public Nullable<System.DateTime> EXPIRY_DATE { get; set; }
        public Nullable<int> EMPLOYEE_STAGE { get; set; }
        public string BIOGRAPHY { get; set; }
        public string WET_SIGNATURE { get; set; }
        public Nullable<int> PER_ASSIGN_ID { get; set; }
        public Nullable<bool> IS_ACC_INFO { get; set; }
        public Nullable<double> IZIN_DAYS { get; set; }
        public string ActiveDirectoryId { get; set; }
        public Nullable<System.Guid> ActiveDirectoryUID { get; set; }
    }

}
