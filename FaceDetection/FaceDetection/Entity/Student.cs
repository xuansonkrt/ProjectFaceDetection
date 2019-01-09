using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetection.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class Student
    {
        String studentCode;
        String name;
        String classCode;
        DateTime DoB;
        String gender;
        Image<Bgr, Byte> image;
        int absence;
        public Student()
        {
            this.studentCode = "";
            this.name = "";
            this.classCode = "";
            this.DoB = DateTime.Now;
            this.gender = "";
            this.image = null;
            this.absence = 0;
        }
        public Student(String studentCode, String name, String classCode, DateTime DoB
                            , String gender, Image<Bgr, Byte> image, int absence)
        {
            this.studentCode = studentCode;
            this.name = name;
            this.classCode = classCode;
            this.DoB = DoB;
            this.gender = gender;
            this.image = image;
            this.absence = absence;
        }

        public String StudentCode
        {
            get { return this.studentCode; }
            set { this.studentCode = value; }
        }
        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public String ClassCode
        {
            get { return this.classCode; }
            set { this.classCode = value; }
        }
        public DateTime DOB
        {
            get { return this.DoB; }
            set { this.DoB = value; }
        }
        public String Gender
        {
            get { return this.gender; }
            set { this.gender = value; }
        }
        public Image<Bgr, Byte> Image
        {
            get { return this.image; }
            set { this.image = value; }
        }
        public int Absence
        {
            get { return this.absence; }
            set { this.absence = value; }
        }


    }
}
