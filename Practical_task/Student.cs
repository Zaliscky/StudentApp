using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Practical_task
{
    public enum Names { BAD_BOY, NICE_BOY, NICE_GIRL, MAD_GIRL, UNKNOWN };

   public enum CompareResult { GREATER_THAN, ARE_EQUAL, LESS_THAN };

   class Student : IComparable, ICloneable // Implements interface 
    {
        private Names name;
        private byte course;
        private bool army { get; set; }
        // IComparable defines method for comparing type, which realized by class or value type in order to sort it's objects
        // Icloneable Supports coping, with the help of which we create new object class with the same value as we have in existing object  

    public Names getName()
    { return this.name; }

    public byte getCourse()
    { return this.course; }

   

    public void setName(Names new_name)
    { this.name = new_name; }

    public void setCoure(byte new_course)
    { this.course = new_course; }


    public Student(Names _name, byte _course, bool _army)
    {
        this.name = _name;
        this.course = _course;
        this.army = _army;

    }

    public void fill()  // fill all fields of single object
    {
        Console.WriteLine("Input Student's name :");
        this.name =  convert_string_to_names( Console.ReadLine());
        Console.WriteLine("Student's course :" );
        string s = Console.ReadLine(); // var 1 with temporary storage
        this.course = Convert.ToByte(s);
        Console.WriteLine("Student's army :");
        this.army = Convert.ToBoolean(Console.ReadLine()); // var 2 immidiately calling with result of console reading
    }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

   public override string ToString()                  // analog << operator in C++
    {
        string retval = "Student's name :" + convert_names_to_string(this.name) + "\n" +
                        " Student's course :" + this.course + "\n" +
                        " Student's army :" + this.army + "\n" ;
        return retval;
    }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

 public static string convert_names_to_string(Names N)
{
    switch (N)
{
    case Names.BAD_BOY:
        return "BAD_BOY";

    case Names.NICE_BOY:
            return "NICE_BOY";

        case Names.NICE_GIRL:
            return "NICE_GIRL";

        case Names.MAD_GIRL:
            return "MAD_GIRL";
        default :
            return "UNKNOWN";
}
}
 //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
public static Names convert_string_to_names (string S)
 {
     if (S == "BAD_BOY")
         return Names.BAD_BOY;

     else if (S == "NICE_BOY")
         return Names.NICE_BOY;


     else if (S == "NICE_GIRL")
         return Names.NICE_GIRL;

     else if (S == "MAD_GIRL")
         return Names.MAD_GIRL;


     else return Names.UNKNOWN;

 }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
public Student()
{
    this.army = false;
    this.course = 0;
    this.name = Names.UNKNOWN;
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

public CompareResult cmpByName(Student b)
{ 
    string aa = convert_names_to_string(this.name);
    string bb = convert_names_to_string(b.name);

    if (aa.CompareTo(bb) == 1)
        return CompareResult.GREATER_THAN;
    else if (aa.CompareTo(bb) == -1)
        return CompareResult.LESS_THAN;
    else
        return CompareResult.ARE_EQUAL;

}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

public CompareResult cmpByCourse(Student b)
{
    if (this.course > b.course)
        return CompareResult.GREATER_THAN;

    else if (this.course == b.course)
        return CompareResult.ARE_EQUAL;

    else return CompareResult.LESS_THAN;

}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
public bool cmpArmy (Student b)
{
    return (!(this.army ^ b.army));
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
public int CompareTo(System.Object b)
{
    Student point = b as Student;
    CompareResult c = this.cmpByCourse(point);
    bool a = this.cmpArmy(point);

    if (a && (c == CompareResult.ARE_EQUAL))
        return 0;
    else
        return 1;
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
public Object Clone()
{
    Student temp = new Student();
   
    temp.army = this.army;
    temp.course = this.course;
    temp.name = this.name;

    return temp;
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////    
public override int GetHashCode()
{
    Student point = this as Student;

    int result = point.name.GetHashCode() + point.course.GetHashCode() + point.army.GetHashCode();

    return result; // base.GetHashCode();
}
       
 }
}
