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

        public String StudentCode { get; set; }
        public String Name { get; set; }
        public String ClassCode { get; set; }
        public DateTime DOB { get; set; }
        public String Gender { get; set; }
        public Image<Bgr, Byte> Image { get; set; }
        public int Absence { get; set; }


    }
}
