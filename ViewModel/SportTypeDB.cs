using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class SportTypeDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
           return new SportType();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            SportType sportType = entity as SportType;
            sportType.ID = int.Parse(reader["id"].ToString());
            sportType.Name = reader["name"].ToString();
            return sportType;
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            SportType sportType = entity as SportType;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id", sportType.ID);
            command.Parameters.AddWithValue("@name", sportType.Name);
        }

        public SportTypeList SelectAll()
        {
            command.CommandText = "SELECT * FROM TblSportType";
            SportTypeList list = new SportTypeList(ExecuteCommand());
            return list;
        }
        public SportType SelectById(int id)
        {
            command.CommandText = "SELECT * FROM TblSportType WHERE id=" + id;
            SportTypeList list = new SportTypeList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }

        public int Insert(SportType sportType)
        {
            command.CommandText = "INSERT INTO TblSportType (@name) VALUES (@name)";
            LoadParameters(sportType);
            return ExecuteCRUD();
        }
        public int Update(SportType sportType)
        {
            command.CommandText = "UPDATE TblSportType SET name = @name WHERE (id = @id)";
            LoadParameters(sportType);
            return ExecuteCRUD();
        }
        public int Delete(SportType sportType)
        {
            command.CommandText = "DELETE FROM TblSportType WHERE (id = @id) ";
            LoadParameters(sportType);
            return ExecuteCRUD();
        }
    }
}
