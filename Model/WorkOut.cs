using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class WorkOut: BaseEntity
    {
        protected User user;//סוג ספורט
        protected string spotType;//סוג ספורט
        protected double duration;//זמן שניות
        protected double distance;//מרחק מטר
        protected double avgPace;//קצב ממוצע 
        protected double calories;//קלוריות
        protected DateTime workoutDate; // תאריך הפעילות
        protected string description; // תאריך הפעילות

        [DataMember]
        public User User { 
            get { return user; }
            set { user = value; } 
        }
        [DataMember]
        public string SpotType
        {
            get { return spotType; }
            set { spotType = value; }
        }
        [DataMember]
        public double Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        [DataMember]
        public double Distance
        {
            get { return distance; }
            set { distance = value; }
        }
        [DataMember]
        public double AvgPace
        {
            get { return avgPace; }
            set { avgPace = value; }
        }
        [DataMember]
        public double Calories
        {
            get { return calories; }
            set { calories = value; }
        }
        [DataMember]
        public DateTime WorkoutDate
        {
            get { return workoutDate; }
            set { workoutDate = value; }
        }
        [DataMember]    
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
    [CollectionDataContract]
    public class WorkOutList : List<WorkOut>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public WorkOutList() { }
        //המרה אוסף גנרי לרשימת משתמשים
        public WorkOutList(IEnumerable<WorkOut> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת משתמשים
        public WorkOutList(IEnumerable<BaseEntity> list)
            : base(list.Cast<WorkOut>().ToList()) { }
    }

}
