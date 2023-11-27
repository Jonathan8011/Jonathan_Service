using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ServiceModel
{
    public class SportService : IServiceSport
    {
        #region SportType
        public SportTypeList GetAllSportType()
        {
            SportTypeDB sportTypeDB = new SportTypeDB();
            SportTypeList list = sportTypeDB.SelectAll();
            return list;

        }
        public int InsertSportType(SportType sportType)
        {
            SportTypeDB sportTypeDB = new SportTypeDB();
            return sportTypeDB.Insert(sportType);
        }
        public int UpdateSportType(SportType sportType)
        {
            SportTypeDB sportTypeDB = new SportTypeDB();
            return sportTypeDB.Update(sportType);
        }
        public int DeleteSportType(SportType sportType)
        {
            SportTypeDB sportTypeDB = new SportTypeDB();
            return sportTypeDB.Delete(sportType);
        }
        #endregion
        #region Workout
        public WorkOutList GetAllWorkout()
        {
            WorkoutDB workoutDB = new WorkoutDB();
            WorkOutList workoutList = workoutDB.SelectAll();
            return workoutList;
        }
        public int InsertWorkout(WorkOut workOut)
        {
            WorkoutDB workoutDB = new WorkoutDB();
            return workoutDB.Insert(workOut);
        }
        public int UpdateWorkout(WorkOut workOut)
        {
            WorkoutDB workoutDB = new WorkoutDB();
            return workoutDB.Update(workOut);
        }
        public int DeleteWorkout(WorkOut workOut)
        {
            WorkoutDB workoutDB = new WorkoutDB();
            return workoutDB.Delete(workOut);
        }
        #endregion
        #region User
        public UserList GetAllUser()
        {
            UserDB userDB = new UserDB();
            UserList list = userDB.SelectAll();
            return list;
        }
        public User LogIn(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.Login(user);
        }
        public int InsertUser(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.Insert(user);
        }
        public int UpdateUser(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.Update(user);
        }
        public int DeleteUser(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.Delete(user);
        }
        #endregion
        #region Comments
        public CommentList GetAllComments()
        {
            CommentsDB commentsDB = new CommentsDB();
            CommentList list = commentsDB.SelectAll();
            return list;
        }
        public int InsertComments(Comments comments)
        {
            CommentsDB commentsDB = new CommentsDB();
            return commentsDB.Insert(comments);
        }
        public int UpdateComments(Comments comments)
        {
            CommentsDB commentsDB = new CommentsDB();
            return commentsDB.Update(comments);
        }
        public int DeleteComments(Comments comments)
        {
            CommentsDB commentsDB = new CommentsDB();
            return commentsDB.Delete(comments);
        }
        #endregion
    }
}
