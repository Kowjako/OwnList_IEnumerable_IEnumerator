using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            NewList mylist = new NewList();
            for (int i = 0; i < 10; i++)
            {
                object tmp = Console.ReadLine();
                mylist.AddElement(tmp);
            }
            foreach(object x in mylist) {
                Console.Write(x);
            }
            Console.ReadKey();
        }
    }
    class MyListNonGenericEnumerator : IEnumerator<string>
    {
        int position = -1;
        string[] arr = null;
        public MyListNonGenericEnumerator(string[] obj)
        {
            arr = obj;
        }
        public string Current
        {
            get
            {
                if (position == -1 || position >= arr.Length)
                    throw new InvalidOperationException();
                return arr[position];
            }
        }
        object IEnumerator.Current => new NotImplementedException();

        public bool MoveNext()
        {
            if (position < arr.Length - 1)
            {
                position++;
                return true;
            }
            else return false;
        }
        public void Reset()
        {
            position = -1;
        }
        public void Dispose() { }
    }
    class MyListEnumerator : IEnumerator
    {
        object[] array = null;
        public MyListEnumerator(object[] array)
        {
            this.array = array; 
        }
        int position = -1;
        public object Current
        {
            get
            {
                if (position == -1 || position >= array.Length)
                    throw new InvalidOperationException();
                return array[position];
            }
        }
        public bool MoveNext()
        {
            if (position < array.Length - 1)
            {
                position++;
                return true;
            }
            else return false;
        }
        public void Reset()
        {
            position = -1;
        }
    }
    class NewList : IEnumerable
    {
        public static int index = 0;
        object[] array = new object[1];
        public void AddElement(object x)
        {
            array[index] = x; 
            index++;
            Array.Resize(ref array, array.Length + 1);
        }

        public IEnumerator GetEnumerator()
        {
            return new MyListEnumerator(array);
        }
    }
}
