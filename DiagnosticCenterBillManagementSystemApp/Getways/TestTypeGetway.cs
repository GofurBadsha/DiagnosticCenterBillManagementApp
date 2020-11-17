using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemApp.Models;
using StudentManagementSystem.Getways;

namespace DiagnosticCenterBillManagementSystemApp.Getways
{
    public class TestTypeGetway
    {
        private Getway _getway=new Getway();

        public int Save(TestType testType)
        {
            string query = "INSERT INTO TestType (Name) VALUES ('"+testType.Name+"');";
            return _getway.ExecuteNoneQuery(query, _getway.ConnectionString());
        }

        public int Update(TestType testType, int id )
        {
            string query = "UPDATE TestType SET Name='" + testType.Name + "' WHERE Id='" + id + "'";
            return _getway.ExecuteNoneQuery(query, _getway.ConnectionString());
        }

        public int Delete(int id)
        {
            string query = "UPDATE TestType SET IsDeleted='" + true + "' WHERE Id ='" + id + "'";
            return _getway.ExecuteNoneQuery(query, _getway.ConnectionString());
        }

        public List<TestType> GetAll()
        {
            var typList = new List<TestType>();

            var Serial = 1;

            string query = "SELECT * FROM testType WHERE IsDeleted IS NULL Order By Name";
            var reader = _getway.Reader(query, _getway.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var testType = new TestType();
                    testType.Id = Convert.ToInt32(reader["Id"]);
                    testType.Serial = Serial;
                    testType.Name = reader["Name"].ToString();

                    typList.Add(testType);

                    Serial++;
                }
            }
            reader.Close();

            return typList;
        }


        public TestType GetBytypeName(string name)
        {
            TestType testType = null;

            string query = "SELECT * FROM TestType WHERE Name='" + name + "' AND IsDeleted IS NULL";
            var reader = _getway.Reader(query, _getway.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                testType=new TestType();
                testType.Id = Convert.ToInt32((reader["Id"]));
                testType.Serial = 1;
                testType.Name = reader["Name"].ToString();
            }

            reader.Close();
            return testType;

        }
    }
}