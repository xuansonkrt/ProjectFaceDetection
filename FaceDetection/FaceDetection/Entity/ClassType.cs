using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetection.Entity
{
    class ClassType
    {
        private String classTypeCode;
        private String classTypeName;
        public ClassType()
        {

        }
        public ClassType(String classTypeCode, String classTypeName)
        {
            this.classTypeCode = classTypeCode;
            this.classTypeName = classTypeName;
        }
        public String ClassTypeCode { get; set; }
        public String ClassTypeName { get; set; }
    }
}
