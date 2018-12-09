using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_task
{
    class Program
    {

        static void Main(string[] args)
        {
            Bilist<Student> list_my = new Bilist<Student>(); 

            int curr_key;
            do
            {
                Console.WriteLine("Choose the action. ");
                Console.WriteLine("1 Add start element in bidirectional list");
                Console.WriteLine("2 Add end element in bidirectional list");
                Console.WriteLine("3 Delete element from bidirectional list by index");
                Console.WriteLine("4 amount of elements in bidirectional list ");
                Console.WriteLine("5 print  list");
                Console.WriteLine("6 Set of default list");
                Console.WriteLine("7 Getting new list begginig from the last element of origin");
                Console.WriteLine("8 Searching of elements");
                Console.WriteLine("9 Get  element at position (indexator) ");

                curr_key = Convert.ToInt16(Console.ReadLine());
                switch (curr_key)
                {
                    case 1:
                        {
                            try
                            {
                                Student ns = new Student();
                                list_my.add_element_start(ns);
                                list_my.output();
                                ns.fill();
                            }

                            catch (ArgumentNullException)
                            {
                                Console.WriteLine(" You entered unexisted member of class ");
                            }
                            break;
                        }
                    case 2:
                        {
                            try
                            {
                                Student ns = new Student();
                                ns.fill();
                                list_my.add_element_end(ns);
                                list_my.output();
                            }
                            catch (ArgumentNullException)
                            {
                                Console.WriteLine(" You entered unexisted member of class ");
                            }
                        } break;
                    case 3:                     
                        {
                            try
                            {
                                long p;
                                Console.WriteLine("Choose the position of deleting element ");
                                p = Convert.ToInt64(Console.ReadLine());
                                list_my.remove_elements_at(p);
                                list_my.output();
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Your written position is out of range !! Enter the position in range , please");
                            }
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine(list_my.getAmount_of_elements());
                        }
                        break;
                    case 5:
                        list_my.output();
                        break;
                    case 6:
                        {
                            Student s = new Student(Names.BAD_BOY, 2, false);
                            list_my.add_element_start(s);
                            s = new Student(Names.BAD_BOY, 6, false);
                            list_my.add_element_start(s);
                            s = new Student(Names.MAD_GIRL, 5, true);
                            list_my.add_element_start(s);
                            s = new Student(Names.NICE_GIRL, 2, false);
                            list_my.add_element_start(s);
                            s = new Student(Names.MAD_GIRL, 1, true);
                            list_my.add_element_start(s);
                            s = new Student(Names.MAD_GIRL, 2, true);
                            list_my.add_element_start(s);
                            s = new Student(Names.NICE_BOY, 4, false);
                            list_my.add_element_start(s);

                            list_my.output();


                        }
                        break;

                    case 7:
                        {
                            Console.WriteLine("How much elements would you like to copy ?");
                            int quantity_element = Convert.ToInt32(Console.ReadLine());
                            Bilist<Student> modern_list = list_my.new_List_from_end(quantity_element);
                            if (modern_list != null)
                                modern_list.output();
                        }
                        break;

                    case 8:
                        {
                            Student origin_student = new Student(Names.UNKNOWN, 2, true);

                            Bilist<Student> modern_list = list_my.return_list_of_clones_by_criteria(origin_student);
                            if (modern_list != null)
                                modern_list.output();

                        }
                        break;

                    case 9:
                        {
                            try
                            {
                                Console.WriteLine("At what position would you like to return data ? ");
                                long index = Convert.ToInt32(Console.ReadLine());
                                Student g = list_my[index];
                                Console.WriteLine(g.ToString());
                            }

                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Your written position is out of range !! Enter the position in range of 10, please");
                            }


                        } break;


                }



            } while (curr_key != 0);
        }
    }
}
