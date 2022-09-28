using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 泛型约束2
{
    /*
     * 利用泛型知识点，仿造ArrayList实现一个不确定数组类型的类
     * 实现增删查改方法
     */
    internal class Program
    {
        #region 练习2
        class ArrayList<T> 
        {
            public T[] array;

            public int count;//当前存储的数
            public ArrayList()
            {
                count = 0;
                array = new T[30];
            }
            public void AddFun(T value)
            {
               if (count >= array.Length)
                {
                     T[] newArray = new T[Capacity*2];
                    for(int i = 0; i < newArray.Length; i++)
                    {
                        newArray[i] = array[i];
                    }
                }
               array[count] = value; 
                count++;
            }
            //移除元素
            public void RemoveFun(T value)
            {
               int indexs = -1;

                for(int i = 0; i < count; i++)
                {
                    //不确定传进来的类型
                    //知识点：Equals
                    if (array[i].Equals(value))
                    {
                        indexs = i;
                        break;
                    }
                    if (indexs != -1)
                    {
                        for (; indexs < count - 1; indexs--)
                        {
                            //替换原来的数组
                            array[i] = array[indexs+1];
                        }
                        array[count - 1] = default(T);//将最后一个元素设为空房间
                        
                        count--;
                    }
                }

            }


            public void RemoveAt(int index)
            {
                if (index < 0 || index >= Count)
                {
                    Console.WriteLine("索引不合法");
                    return;
                }

                {
                    for (; index < count - 1; index++)
                    {
                        //替换原来的数组
                        array[index] = array[index + 1];
                    }
                    array[count - 1] = default(T);//将最后一个元素设为空房间

                    count--;
                }
            }
            public T this[int index]
            {
                get {
                    if (index < 0 || index >= Count)
                    {
                        Console.WriteLine("索引不合法");
                        return default(T);
                    }
                    return array[index]; }
                set { 
                     if (index < 0 || index >= Count)
                {
                    Console.WriteLine("索引不合法");
                    return;
                }
                    array[index] = value; }
            }


              public int  Capacity //获取容量
            {
                get { return array.Length; }
            }
              public int Count //得到具体存储多少值
                { get { return count; } }
               }
        #endregion

        static void Main(string[] args)
        {

            ArrayList <int> array = new ArrayList<int>();
            Console.WriteLine(array.Count);
            Console.WriteLine(array.Capacity);
            Console.WriteLine("-------------");
            array.AddFun(15);
            array.AddFun(20);
            array.AddFun(25);
            array.AddFun(35);
            array.AddFun(39);
            array.RemoveFun(10);
            Console.WriteLine(array.Count);
            Console.WriteLine(array.Capacity);
            Console.WriteLine("-------------");
            Console.WriteLine(array[3]);
            array.RemoveAt(2);
            Console.WriteLine(array.Count);

            ArrayList<string> array1 = new ArrayList<string>();

            Console.ReadLine();
        }
    }
}
