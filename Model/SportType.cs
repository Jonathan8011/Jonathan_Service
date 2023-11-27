using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class SportType:BaseEntity
    {
        protected string name;

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
    [CollectionDataContract]
    public class SportTypeList : List<SportType>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public SportTypeList() { }
        //המרה אוסף גנרי לרשימת משתמשים
        public SportTypeList(IEnumerable<SportType> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת משתמשים

        public SportTypeList(IEnumerable<BaseEntity> list)
            : base(list.Cast<SportType>().ToList()) { }
    }
}
