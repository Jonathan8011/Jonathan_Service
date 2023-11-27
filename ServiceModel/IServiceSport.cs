using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel
{
    [ServiceContract]
    public interface IServiceSport
    {
        #region SportType
        [OperationContract] SportTypeList GetAllSportType();
        [OperationContract] int InsertSportType(SportType sportType);
        [OperationContract] int UpdateSportType(SportType sportType);
        [OperationContract] int DeleteSportType(SportType sportType);
        #endregion
        #region Workout
        [OperationContract] WorkOutList GetAllWorkout();
        [OperationContract] int InsertWorkout(WorkOut workOut);
        [OperationContract] int UpdateWorkout(WorkOut workOut);
        [OperationContract] int DeleteWorkout(WorkOut workOut);
        #endregion
        #region User
        [OperationContract] UserList GetAllUser();
        [OperationContract] User LogIn(User user);
        [OperationContract] int InsertUser(User user);
        [OperationContract] int UpdateUser(User user);
        [OperationContract] int DeleteUser(User user);
        #endregion
        #region Comments
        [OperationContract] CommentList GetAllComments();
        [OperationContract] int InsertComments(Comments comments);
        [OperationContract] int UpdateComments(Comments comments);
        [OperationContract] int DeleteComments(Comments comments);
        #endregion
    }
}
