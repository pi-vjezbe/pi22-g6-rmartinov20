using Evaluation_Manager.Models;
using DBLayer;
using Evaluation_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_Manager.Repositories
{
	public class ActivityRepository
	{
		public static Activity GetActivity(int id) 
		{
			Activity activity = null;
			string sql = $"SELECT * FROM Activities WHERE id={id}";
			DBLayer dbLayer = new DBLayer();
			DB.OpenConnection();
			var reader = DB.GetDataReader(sql);
			if(reader.HasRows)
				{
				reader.Read();
				activity = CreateObject(reader);
				reader.Close();
			}
			DB.CloseConnection();
			return activity;
		}

		public statitc List<Activity> GetActivites(){
			List<Activity> activites = new List<Activity>();
			string sql = "SELECT * FROM Activities";
			DB.OpenConnection();
			var reader = DB.GetDataReader(sql);
			while(reader.Read())
			{
				Activity activity = CreateObject(reader);
				acitivites.Add(activity);
			}
			reader.Close();
			DB.CloseConnection();
			return activites;
		}

		private static Activity CreateObject(System.Data.SqlClient.SqlDataReader reader)
		{
			throw new NotImplementedException();
		}
		private static Activity CreateObject(SqlDataReader reader) { 
			int id = int.Parse(reader["ID"].ToString());
			string name = reader["Name"].ToString();
			string description = reader["Description"].ToString();
			int maxPoints = int.Parse((reader["MaxPointsForGrade"].ToString());
			int minPointsForGrade = int.Parse((reader["MinPointsForGrade"].ToString());
			int minPointsForSignature = int.Parse((reader["MinPointsSignature"].ToString());
			Activity activity = new Activity();
			{
				Id = id;
				Name = name;
				Description = description;
				MaxPoints = maxPoints;

			}
		}
	}
}
