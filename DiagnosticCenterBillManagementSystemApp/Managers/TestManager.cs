using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemApp.Getways;
using DiagnosticCenterBillManagementSystemApp.Models;

namespace DiagnosticCenterBillManagementSystemApp.Managers
{
    public class TestManager
    {
        private TestGetway _testGetway= new TestGetway();


        public int Save(Test aTest)
        {
            return _testGetway.Save(aTest);
        }


        public int Update(int id, Test aTest)
        {
            return _testGetway.Update(id, aTest);
        }

        public int Delete(int id)
        {
            return _testGetway.Delete(id);
        }

        public List<Test> GeAll()
        {
            return _testGetway.GeAll();
        }


        //public Test GeTestByName(string name)
        //{
        //    return _testGetway.GeTestByName(name);
        //}

        public Test GeTestByNameAndType(string name, int testTypeId)
        {
            return _testGetway.GetTestByNameAndType(name, testTypeId);
        }

        //unique

        public bool IsNameExitst(string name, int testTypeId)
        {
            bool IsNameExitst = false;
            var aTest = GeTestByNameAndType(name, testTypeId);
            if (aTest != null)
            {
                IsNameExitst = true;
            }
            return IsNameExitst;
        }


        internal object GetTestByNameAndType(string testName)
        {
            throw new NotImplementedException();
        }

        internal object GetTestByName(string testName)
        {
            throw new NotImplementedException();
        }
    }
}