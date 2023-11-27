using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)//מכניסים את הנתונים למשתמש
        {
            User user = entity as User;
            user.ID = int.Parse(reader["id"].ToString());
            user.UserName = reader["username"].ToString();
            user.Password = reader["password"].ToString();
            user.FirstName = reader["firstname"].ToString();
            user.LastName = reader["lastname"].ToString();
            user.BDay = DateTime.Parse(reader["bDay"].ToString());
            user.Gender = bool.Parse(reader["gender"].ToString());
            user.PhoneNum = int.Parse(reader["phoneNum"].ToString());
            user.Email = reader["email"].ToString();
            user.IsManager = bool.Parse(reader["ismanager"].ToString());
            return user;
        }

        protected override BaseEntity NewEntity()
        {
            return new User();
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            User user= entity as User;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id",user.ID);
            command.Parameters.AddWithValue("@username", user.UserName);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@firstname", user.FirstName);
            command.Parameters.AddWithValue("@lastname", user.LastName);
            command.Parameters.AddWithValue("@bDay", user.BDay);
            command.Parameters.AddWithValue("@gender", user.Gender);
            command.Parameters.AddWithValue("@phoneNum", user.PhoneNum);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@ismanager", user.IsManager);
        }
        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblUser";
            UserList list = new UserList(ExecuteCommand());
            return list;
        }
        public User SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tblUser WHERE id=" + id;
            UserList list = new UserList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }

        public int Insert(User user)
        {
            command.CommandText = "INSERT INTO TblUser (username,[password], firstname, lastname, bDay, gender, phoneNum, email, ismanager) VALUES (@username,@password, @firstname, @lastname, @bDay, @gender, @phoneNum, @email, @ismanager";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public int Update(User user)
        {
            command.CommandText = "UPDATE TblUser SET username = @username, [password] = @password, firstname = @firstname, lastname = @lastname, bDay = @bDay, gender = @gender, phoneNum = @phoneNum, email = @email, ismanager = @ismanager WHERE (id = @id)";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public int Delete(User user)
        {
            command.CommandText = "DELETE FROM TblUser WHERE (id = @id) ";
            LoadParameters(user);
            return ExecuteCRUD();
        }

        public User Login(User user)
        {
            command.CommandText = string.Format($"SELECT * FROM TblUser "
                + $"WHERE (username = '{user.UserName}') AND ([password] = '{user.Password}')");
            UserList list = new UserList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }

    }
}
