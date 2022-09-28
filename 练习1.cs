using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static 泛型约束.Program;

namespace 泛型约束
{
    internal class Program
    {
        #region 练习题1
        /*
         * 单例模式 ：通过单例模式的方法创建的类在当前进程中只有一个实例
         * 一是某个类只能有一个实例；二是它必须在内部创建实例；三是它必须自行向整个系统提供这个实例。
           * 唯一性 全局性
         */
        #region 普通单例模式
        public class Test1
        {
            private static Test1 test = new Test1();//私有
            
            public static Test1 Gettest //这个方法是用于外部调用得到实例的
            {
                get //设置只写属性
                {

                    return test;
                }
            }

        }
        public class Test6
        {
            private static Test6 test6 = null;//私有

            public static Test6 Gettest //这个方法是用于外部调用得到实例的
            {
                get //设置只写属性
                {
                    if (test6 == null)
                    {
                        Console.WriteLine("Test6 Gettest"+DateTime.Now);
                        test6 = new Test6();
                    }    
                    return test6;
                }
            }

        }
        #endregion
        #region 用泛型实现一个单例模式基类
        public class Test3<T> where T : new()
        {
            public int value = 55;
            private static T Value = new T();
            public static T Value1
            {
                get

                { return Value; }
            }
        }

        #endregion

        //单例模式的使用
        public class Test2 : Test3<Test2>
        {
            public int value = 55;
            public static Test2 m = new Test2();
        }

        public class Test4 : Test3<Test4>
        {
            public static Test2 n = new Test2();
            public static Test4 m = new Test4();
        }

        public class Teat5 : Test1
            {
            public static Teat5 m = new Teat5();
            
                } 
            #endregion
            
        
        
        static void Main(string[] args)
            {
            Test2.Value1.value=10;
            Console.WriteLine(Test2.Value1.value = 10);
            Console.WriteLine(Test4.Value1.value = 55);

            Test6 test6=Test6.Gettest;//结果是被实例化了一次


            Console.ReadLine();
            }
        }
    }

