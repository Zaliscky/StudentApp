using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_task
{

    class Bidilist_elements<T>    // vuzol spisku
    {
        private Bidilist_elements <T> next = null;
        private T link_to_data ;
        private Bidilist_elements <T> prev = null;


        public T getData()
        { return this.link_to_data; }
        public  Bidilist_elements<T> getNext()
        { return this.next; }

        public  Bidilist_elements<T> getPrev()
        { return this.prev; }

       

        public void setData( T new_data)
        { this.link_to_data = new_data; }

        public void setNext(Bidilist_elements<T> new_el1)
        { this.next = new_el1; }

        public void setPrev (Bidilist_elements<T> new_el2)
        { this.prev = new_el2; }


        public Bidilist_elements(T new_data)
    {
        this.prev = null;
        this.next = null;
        this.link_to_data = new_data;

    }
        public Bidilist_elements()
        {
            this.prev = null;
            this.next = null;
            this.link_to_data = default(T); // call default constructor for variable of type T 

        }







    }




}
