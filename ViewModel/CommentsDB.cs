using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ViewModel
{
    public class CommentsDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Comments();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Comments comments = entity as Comments;
            comments.ID = int.Parse(reader["id"].ToString());
            comments.Comment = reader["comment"].ToString();
            comments.Like = bool.Parse(reader["like"].ToString());

            WorkoutDB workoutDB = new WorkoutDB();
            comments.WorkOutId = workoutDB.SelectById(int.Parse(reader["workOut"].ToString()));
            UserDB userDB = new UserDB();
            comments.User = userDB.SelectById(int.Parse(reader["user"].ToString()));
            return comments;
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Comments comments = entity as Comments;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id", comments.ID);
            command.Parameters.AddWithValue("@workOut", comments.WorkOutId.ID);
            command.Parameters.AddWithValue("@user", comments.User.ID);
            command.Parameters.AddWithValue("@comment", comments.Comment);
            command.Parameters.AddWithValue("@like", comments.Like);
        }

        public CommentList SelectAll()
        {
            command.CommandText = "SELECT * FROM TblComments";
            CommentList list = new CommentList(ExecuteCommand());
            return list;
        }

        public Comments SelectByID(int id)
        {
            command.CommandText = "SELECT * FROM TblComments WHERE id=" + id;
            CommentList list = new CommentList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }

        public int Insert(Comments comments)
        {
            command.CommandText = "INSERT INTO TblComments(WorkOutID, [user], comment, like) VALUES(@workOut, @user, @comment, @like)";
            LoadParameters(comments);
            return ExecuteCRUD();
        }
        public int Update(Comments comments)
        {
            command.CommandText = "UPDATE TblComments SET WorkOutID = @workOut, [user] = @user, comment = @comment, [like] =@like WHERE (Id = @id)";
            LoadParameters(comments);
            return ExecuteCRUD();
        }
        public int Delete(Comments comments)
        {
            command.CommandText = "DELETE FROM TblComments WHERE (id = @id) ";
            LoadParameters(comments);
            return ExecuteCRUD();
        }
    }
}
