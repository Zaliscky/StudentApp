using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_task
{
    class Bilist<T> : IEnumerator<T>  where T : IComparable, ICloneable 
    {
        private long amount_of_elements;
        private Bidilist_elements<T> start ;
        private Bidilist_elements<T> end ;
        // IComparable defines method for comparing type, which realized by class or value type in order to sort it's objects
        // Icloneable Supports coping, with the help of which we create new object class with the same value as we have in existing object   
        public Bilist() // default constructor
        {
            this.amount_of_elements = 0;
            this.start = null;
            this.end = null;
        
        }

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // automatic properties GET
        public long getAmount_of_elements()
        { return this.amount_of_elements; }

        public Bidilist_elements<T> getStart()
        { return this.start; }

        public Bidilist_elements<T> getEnd()
        { return this.end; }


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Add element to the begin of list
        public void add_element_start(T new_value)
        {

            Bidilist_elements<T> new_elem = new Bidilist_elements<T>(new_value);  


            switch (this.amount_of_elements)
            {
                case 0:
                    this.start = new_elem;
                    this.end = new_elem;
                    break;

                case 1:
                    new_elem.setNext(this.start);
                    this.start.setPrev(new_elem);
                    this.start = new_elem;
                    break;

                default:
                    new_elem.setNext(this.start);
                    this.start.setPrev(new_elem);
                    this.start = new_elem;

                    break;
            }
            this.amount_of_elements++;
        }

  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 /// Add element to the end of list

        public void add_element_end(T new_value)
        {
            Bidilist_elements<T> new_elem = new Bidilist_elements<T>(new_value);
            switch (this.amount_of_elements)
            {
                case 0:
                    this.start = new_elem;
                    this.end = new_elem;
                    break;

                case 1:
                    new_elem.setPrev(this.end);
                    this.end.setNext(new_elem);
                    this.end = new_elem;
                    break;

                default:
                    new_elem.setPrev(this.end);
                    this.end.setNext(new_elem);
                    this.end = new_elem;
                    break;
            }

            this.amount_of_elements++;
        }

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//// Deleting element from the n-position

        public void remove_elements_at(long pos)
        {
            if ((pos < 0) || (pos > this.amount_of_elements))
                throw new IndexOutOfRangeException();
                //return;

            // Check if we exceeds bounds of array

            else
            {
                Bidilist_elements<T> wp = this.start;
                for (long i = 0; i < pos; i++)
                {
                    wp = wp.getNext();
                }
                if (wp != this.start)
                    wp.getPrev().setNext(wp.getNext());
                if (wp != this.end)
                    wp.getNext().setPrev(wp.getPrev());

                if (wp == this.start)
                    this.start = this.start.getNext();
                if (wp == this.end)
                    this.end = this.end.getPrev();

                this.amount_of_elements--;
            }
        }

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Deleting element which have same parameters
        public void remove_elements_like(T origin) 
        {
            Bidilist_elements<T> wp = this.start;
            long counter = 0;
            while (wp != null)
            {
                if (wp.getData().CompareTo(origin) == 0)
                    break;
                wp = wp.getNext();
                counter++;
            }

            if (wp != null)  // we have finished finding with result
                this.remove_elements_at(counter);

        }


 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 /// This method copy elements which satisfies parameters  
        public Bilist<T> return_list_of_clones_by_criteria(T origin)
        {
            Bilist<T> cloned_list = new Bilist<T>();

            Bidilist_elements<T> wp = this.start;
            
            while (wp != null)
            {
                if (wp.getData().CompareTo(origin) == 0)
                {
                    T clo = (T) wp.getData().Clone();
                    cloned_list.add_element_end(clo);
                
                }
                wp = wp.getNext();
            }

            return cloned_list;
        }


  // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Method of getting new list, starting from the last element
        public Bilist<T> new_List_from_end(long N)
        {
            Bilist<T> reverse_list = new Bilist<T>();
            if (N > this.amount_of_elements)
                return null;

            Bidilist_elements<T> WP = this.end;
            for (long i = 0; i < N; i++ )
            {
                   T clo = (T) WP.getData().Clone();
                    reverse_list.add_element_start(clo);
                    WP = WP.getPrev();
            }
                return reverse_list;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //ITERATION
     /*   public void iteration()
        {
            ArrayList <Integer> list 
            foreach (int x in list)
            {
                System.Out.print(this.name;)
            }
        }
        */

      /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      //INDEXATOR


         public T this[long i]
          {
              get
              {
                  return GetDataAt ( i);

              }
              set { T element = GetDataAt(i);
                  element = value; }
          }
       

        private T GetDataAt (long i)
        {
            if ((i < 0) || (i > this.amount_of_elements))
                throw new IndexOutOfRangeException();
                //   return default(T);

            else
            {
                Bidilist_elements<T> wp = this.start;
                for (long k = 0; k < i; k++)
                {
                    wp = wp.getNext();
                }
                return wp.getData();
            }
        }

/// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 //Display the result

        public void output()
        {

            Bidilist_elements<T> curr_elem = this.start;
            while (curr_elem != null)
            {
                Console.WriteLine("Your current element data: {0}", curr_elem.getData());

                curr_elem = curr_elem.getNext();
            }
        }

        private int iter_pos = -1;

        public bool MoveNext()
        {
            iter_pos++;
            return (iter_pos < this.amount_of_elements);
        }

        public void Reset()
        {
            iter_pos = -1;
        }

        
        object IEnumerator<T>.Current
        {
            get { return (object) this[iter_pos]; }
        }
        
        // IEnumerator<T>
        public T Current
        {
            get
            {
                try
                {
                    return  this[iter_pos];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

    /*    public IEnumerator<T> GetEnumerator()
        {
            int i = 0;
            while (i < this.amount_of_elements)
                yield return (); // yield return развернется компилятором в скрытый класс, который реализует IEnumerator, как в предыдущем примере.
        }
     * 
     * */
      /*  IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }*/


        public void Dispose()
        {
        }
    } // for class
} //  for namespace
