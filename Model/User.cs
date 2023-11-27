using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class User : BaseEntity
    {
        protected string username;// שם משתמש
        protected string password;//סיסמה
        protected string firstname;//שם פרטי
        protected string lastname;//שם משפחה
        protected DateTime bDay;// תאריך לידה
        protected bool gender;//מגדר
        protected int phoneNum;//מספר טלפון
        protected string email;// אימייל
        protected bool ismanager;// האם הוא מנהל

        [DataMember]
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        [DataMember]
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }
        [DataMember]
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }
        [DataMember]
        public DateTime BDay
        {
            get { return bDay; }
            set { bDay = value; }
        }
        [DataMember]
        public bool Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        [DataMember]
        public int PhoneNum
        {
            get { return phoneNum; }
            set { phoneNum = value; }
        }
        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        [DataMember]
        public bool IsManager
        {
            get { return ismanager; }
            set { ismanager = value; }
        }
    }
    [CollectionDataContract]
    public class UserList : List<User>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public UserList() { }
        //המרה אוסף גנרי לרשימת משתמשים
        public UserList(IEnumerable<User> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת משתמשים
        public UserList(IEnumerable<BaseEntity> list)
            : base(list.Cast<User>().ToList()) { }
    }
}
