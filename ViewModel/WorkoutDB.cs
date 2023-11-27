using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class WorkoutDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new WorkOut();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)//מכניסים את הנתונים לאימון
        {
            WorkOut workOut = entity as WorkOut;
            workOut.ID = int.Parse(reader["id"].ToString());
            workOut.SpotType = reader["spotType"].ToString();
            workOut.Duration = double.Parse(reader["duration"].ToString());
            workOut.Distance = double.Parse(reader["distance"].ToString());
            workOut.AvgPace = double.Parse(reader["avgPace"].ToString());
            workOut.Calories = double.Parse(reader["calories"].ToString());
            workOut.WorkoutDate = DateTime.Parse(reader["workoutDate"].ToString());
            workOut.Description = reader["description"].ToString();
            UserDB userDB=new UserDB();
            workOut.User = userDB.SelectById(int.Parse(reader["userid"].ToString()));
            return workOut;
        }     

        protected override void LoadParameters(BaseEntity entity)
        {
            WorkOut workOut = entity as WorkOut;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id", workOut.ID);
            command.Parameters.AddWithValue("@userid", workOut.User.ID);
            command.Parameters.AddWithValue("@spotType", workOut.SpotType);
            command.Parameters.AddWithValue("@duration", workOut.Duration);
            command.Parameters.AddWithValue("@distance", workOut.Distance);
            command.Parameters.AddWithValue("@avgPace", workOut.AvgPace);
            command.Parameters.AddWithValue("@calories", workOut.Calories);
            command.Parameters.AddWithValue("@workoutDate", workOut.WorkoutDate);
            command.Parameters.AddWithValue("@description", workOut.Description);
        }

        public WorkOutList SelectAll()
        {
            command.CommandText = "SELECT * FROM TblWorkOut";
            WorkOutList list = new WorkOutList(ExecuteCommand());
            return list;
        }
        public WorkOut SelectById(int id)
        {
            command.CommandText = "SELECT * FROM TblWorkOut WHERE id=" + id;
            WorkOutList list = new WorkOutList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }

        public int Insert(WorkOut workOut)
        {
            command.CommandText = "NSERT INTO TblWorkOut (userId, spotType, duration, distance, avgPace, calories, workoutDate, description) VALUES (@userid, @spotType, @duration, @distance, @avgPace, @calories, @workoutDate, @description)";
            LoadParameters(workOut);
            return ExecuteCRUD();
        }
        public int Update(WorkOut workOut)
        {
            command.CommandText = "UPDATE TblWorkOut SET userId = @userid, spotType = @spotType, duration = @duration, distance = @distance, avgPace = @avgPace, calories = @calories, workoutDate = @workoutDate, description =@description WHERE (id = @id)";
            LoadParameters(workOut);
            return ExecuteCRUD();
        }
        public int Delete(WorkOut workOut)
        {
            command.CommandText = "DELETE FROM TblWorkOut WHERE (id = @id) ";
            LoadParameters(workOut);
            return ExecuteCRUD();
        }

    }
}
