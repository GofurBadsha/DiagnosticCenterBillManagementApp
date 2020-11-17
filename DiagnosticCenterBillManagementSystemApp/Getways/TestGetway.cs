using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using DiagnosticCenterBillManagementSystemApp.Models;
using StudentManagementSystem.Getways;
using WebGrease;

namespace DiagnosticCenterBillManagementSystemApp.Getways
{
    public class TestGetway
    {
        private Getway _getways = new Getway();

        public int Save(Test aTest)
        {
            string query = "INSERT INTO Tests(Name, Fee, TestTypeId) VALUES ('" + aTest.Name + "', '" + aTest.Fee +
                           "', '" + aTest.TestTypeId + ");";

            return _getways.ExecuteNoneQuery(query, _getways.ConnectionString());
        }

        public int Update(int id, Test aTest)
        {
            string query = "UPDATE Tests SET Name ='" + aTest.Name + "', Fee ='" + aTest.Fee + "', TestTypeId='" + aTest.TestTypeId + "' WHERE Id='" + id + "'";
            return _getways.ExecuteNoneQuery(query, _getways.ConnectionString());
        }

        public int Delete(int id)
        {
            string query = "DELETE FROM Tests WHERE Id='" + id + "'";

            return _getways.ExecuteNoneQuery(query, _getways.ConnectionString());
        }

        public List<Test> GeAll()
        {
            var serial = 1;
            var testList = new List<Test>();

            string query = "SELECT ts.Id, ts.Name, ts.Fee, ts.TestTypeId, ty.Name AS TestTypeName FROM Test ts INNER JOIN TestTypes ty ON ts.TestTypeId=ty.Id WHERE ts.IsDeleted IS NULL";
            var reader = _getways.Reader(query, _getways.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var aTest = new Test();
                    aTest.Id = Convert.ToInt32(reader["Id"]);
                    aTest.Serial = serial;
                    aTest.Name = reader["Name"].ToString();
                    aTest.Fee = Convert.ToDecimal(reader["Fee"]);
                    aTest.TestTypeId = Convert.ToInt32(reader["TestTypeId"]);
                    aTest.TestTypeName = reader["TestTypeName"].ToString();

                    testList.Add(aTest);
                    serial++;
                }
            }
            reader.Close(); 

            return testList;
        }

        public Test GetTestByName(string name)
        {
            Test aTest = null;

            string query = "SELET * FROM Tests WHERE Name='" + name + "' AND IsDeleted IS NULL";
            var reader = _getways.Reader(query, _getways.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                aTest = new Test();
                aTest.Id = Convert.ToInt32(reader["Id"]);
                aTest.Serial = 1;
                aTest.Name = reader["Name"].ToString();
                aTest.Fee = Convert.ToDecimal(reader["Fee"]);
                aTest.TestTypeId = Convert.ToInt32(reader["TestTypeId"]);
            }
            reader.Close();
            return aTest;
        }
        

        public Test GetTestByNameAndType(string name, int testTypeId)
        {
            Test aTest = null;

            string query = "SELET * FROM Tests WHERE Name='" + name + "' AND TestTypeId='"+testTypeId+"' AND IsDeleted IS NULL";
            var reader = _getways.Reader(query, _getways.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read(); 
                aTest = new Test();
                aTest.Id = Convert.ToInt32(reader["Id"]);
                aTest.Serial = 1;
                aTest.Name = reader["Name"].ToString();
                aTest.Fee = Convert.ToDecimal(reader["Fee"]);
                aTest.TestTypeId = Convert.ToInt32(reader["TestTypeId"]);
            }
            reader.Close();

            return aTest;
        }

    }
}