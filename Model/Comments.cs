using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Comments:BaseEntity
    {
        protected WorkOut workOut; //id של הפוסט שמגיבים לו
        protected User user; // שם המשתמש של מי שמגיב
        protected string comment; // התגובה שמגיבים
        protected bool like;// האם עשה לייק

        [DataMember]
        public WorkOut WorkOutId
        {
            get { return workOut; }
            set { workOut = value; }
        }
        [DataMember]
        public User User
        {
            get { return user; }
            set { user = value; }
        }
        [DataMember]
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        [DataMember]
        public bool Like
        {
            get { return like; }
            set { like = value; }
        }
    }
    [CollectionDataContract]
    public class CommentList : List<Comments>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public CommentList() { }
        //המרה אוסף גנרי לרשימת משתמשים
        public CommentList(IEnumerable<Comments> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת משתמשים
        public CommentList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Comments>().ToList()) { }
    }
}
