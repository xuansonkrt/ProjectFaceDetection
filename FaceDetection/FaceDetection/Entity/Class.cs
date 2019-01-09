using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetection.Entity
{
    public class Class
    {
        private String classCode;
        private String className;
        private String classTypeCode;
        public Class()
        {
            this.classCode = "";
            this.className = "";
            this.classTypeCode = "";
        } 
        public Class(String classCode, String className, String classTypeCode)
        {
            this.classCode = classCode;
            this.className = className;
            this.classTypeCode = classTypeCode;
        }
        public String ClassCode
        {
            get { return this.classCode; }
            set { this.classCode = value; }
        }
        public String ClassName
        {
            get { return this.className; }
            set { this.className = value; }
        }
        public String ClassTypeCode
        {
            get { return this.classTypeCode; }
            set { this.classTypeCode = value; }
        }
        public String toString()
        {
            return classCode + " " + className + " " + classTypeCode;
        }

    }
}
