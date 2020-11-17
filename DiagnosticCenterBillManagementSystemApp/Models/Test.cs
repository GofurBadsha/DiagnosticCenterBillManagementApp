using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystemApp.Models
{
    public class Test
    {
        public int Id { get; set; }
        public int Serial { get; set; }
        public string Name { get; set; }
        public decimal Fee { get; set; }
        public int  TestTypeId { get; set; }
        public string TestTypeName { get; set; }
        public bool IsDeleted { get; set; }
    }
}