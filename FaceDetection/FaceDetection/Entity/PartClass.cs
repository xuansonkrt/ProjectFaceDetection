using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetection.Entity
{
    class PartClass
    {
        private String classCode;
        private String className;
        private String classTypeCode;
        public PartClass()
        {

        }
        public PartClass(String classCode, String className, String classTypeCode)
        {
            this.classCode = classCode;
            this.className = className;
            this.classTypeCode = classTypeCode;
        }
        public String ClassCode { get; set; }
        public String ClassName { get; set; }
        public String ClassTypeCode { get; set; }
    }
}
