using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methlab4
{

    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }




    class Program
    {
        static void Main(string[] args)
        {

            //            Реализовать методы для работы с данной структурой
            
            // -добавление элемента в очередь с начала
            //- добавление элемента в очередь с конца
            //- удаление искомого элемента из очереди
            // -удаление элемента из начала очереди
            // -удаление элемента с конца очереди
            // -печать элементов очереди


            DoublyNode<string> First=null, Last=null;
            

            bool run = true; 

            string buf, buf2="";

            Console.WriteLine("Commands: search, addfront, addlast, delfind, delfront, dellast, print, exit ");

            while (run == true)
            {
                buf = Console.ReadLine();

                if (buf.StartsWith("search")) { buf2 = buf.Substring(7); buf = "search"; }
                if (buf.StartsWith("addfront")) { buf2 = buf.Substring(9); buf = "addfront"; }
                if (buf.StartsWith("addlast")) { buf2 = buf.Substring(8); buf = "addlast"; }
                if (buf.StartsWith("delfind")) { buf2 = buf.Substring(8); buf = "delfind"; }

                switch (buf)
                {
                    case "search":// - Поиск заданного элемента в двухсторонней очереди.Результат – номера позиций очереди где был найден искомый элемент

                            int[] nums=search(First, buf2);

                            

                            
                            foreach(int num in nums) Console.WriteLine("{0} ",num);
                            

                        break;
                    case "addfront":
          
                        addfront(ref First, ref Last, buf2);

                        Console.WriteLine("OK ");

                        break;
                    case "addlast":

                        addlast(ref Last, ref First, buf2);

                        Console.WriteLine("OK ");

                        break;
                    case "delfind":

                        if (First!=null)
                        {
                            delfind(ref First,ref Last, buf2);
                            Console.WriteLine("OK ");
                        }

                        break;
                    case "delfront":

                        if (First!=null)
                        {
                            delfront(ref First, ref Last);
                            Console.WriteLine("OK ");
                        }

                        break;

                    case "dellast":

                        if (Last!=null)
                        {
                            dellast(ref Last, ref First);
                            Console.WriteLine("OK ");
                        }

                        break;

                    case "print":

                        if (First != null)
                        {
                            print(First);
                            
                        }

                        break;

                    case "exit":
                        Console.WriteLine("Bye");
                        run = false;
                        break;

                }
            }
        }



        public static int[] search(DoublyNode<string> first, string elem)
        {

            DoublyNode<string> cur = first;
            int[] nums = new int[0]; int ctr = 0;

            while (cur != null)
            {
                ctr++;
                if (cur.Data == elem) { Array.Resize(ref nums,nums.Length+1); nums[nums.Length - 1] = ctr; }
                cur = cur.Next;
            }

            return nums;

        }

        public static void addfront(ref DoublyNode<string> first, ref DoublyNode<string> last, string elem)
        {

            DoublyNode<string> cur= new DoublyNode<string>(elem);
            if (first == null) { first = cur; last = cur; }
            else
            {
                cur.Next = first;
                first.Previous = cur;
                first = cur;
            }

            return;

        }

        public static void addlast(ref DoublyNode<string> last, ref DoublyNode<string> first, string elem)
        {

            DoublyNode<string> cur = new DoublyNode<string>(elem);

            if (last == null) { last = cur; first = cur; }
            else
            {
                cur.Previous = last;
                last.Next = cur;

                last = cur;
            }

            return;

        }

        public static void delfind(ref DoublyNode<string> first, ref DoublyNode<string> last, string elem)
        {

            DoublyNode<string> cur = first;

            while (cur != null)
            {
                if (cur.Data == elem)
                {
                    if (cur.Next == null && cur.Previous == null)
                    {
                        cur = null;
                    }
                    else if (cur.Next == null)
                    {

                        
                        dellast(ref last,ref first);

                    }
                    else if (cur.Previous == null) 
                    {
                        delfront(ref first,ref last);
                        
                    }
                    else
                    {
                        cur.Previous.Next = cur.Next;
                        cur.Next.Previous = cur.Previous;
                        cur = cur.Previous;
                    }
                }
                cur = cur.Next;
            }


                
            return;

        }

        public static void delfront(ref DoublyNode<string> first, ref DoublyNode<string> last)
        {

            first = first.Next;
            if (first != null) first.Previous = null;
            else last = null;

            return;

        }

        public static void dellast(ref DoublyNode<string> last, ref DoublyNode<string> first)
        {

            last = last.Previous;
            if (last != null) last.Next = null;
            else first = null;

            return;

        }

        public static void print( DoublyNode<string> first)
        {

            DoublyNode<string> cur = first;

            while (cur != null)
            {
                Console.WriteLine("{0} ",cur.Data);

                cur = cur.Next;
            }

            return;

        }

    }
}
