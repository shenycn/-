using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 链表2
{
    /*知识点：虚拟头结点
     * 解释：当链表中只有一个元素时 它没有对应的头结点 所以有了虚拟头结点
     * head存放一个具体的元素，初始化时是null。引入虚拟头节点
     * 
     * 
     */

    internal class Program
    {
        #region 单链表（完善了插入和查找元素的功能）
        public class myLinked<T>
        {


           private class Node
            {
                public T Value;//传入的值
                public Node nodeNext;//钩子
                public Node head;//头结点
                public int size;//链表实际有多少个元素

                //初始化
             
                //传来了两个 
                public Node(T value, Node nodeNext)
                {
                    this.Value = value;
                    this.nodeNext = nodeNext;
                }
                //只有一个元素
                public Node(T value)
                {
                    this.Value = value;
                    
                }


                public String toString()
                {
                    return Value.ToString();

                }
                public int GetSize()
                {
                    return size;
                }
                //判断是否为空
                public Boolean isEmpty()
                {
                    return size == 0;
                }


                #region 方法实现：增、删、改、查
                //添加第一个元素
                public void addFirst(T Value)
                {
                    // 首先创建一个新的节点 此时next为空
                    Node node = new Node(Value);
                    // 头结点和羁绊都是自己
                    node.nodeNext = head;
                    head = node;
                    size++;
                }
                //添加指定位置的元素
                public void AddOne(int index, T value)
                {
                    //添加第一个元素/最后一个元素

                    //有index就要判断其合法性
                    if (index < 0 || index > size)
                    {
                        Console.WriteLine("输入不合法");

                    }
                    if (index == 0)
                    {
                        addFirst(value);
                    }
                    else
                    {
                        Node pre = head;//假设这是前一个节点的头结点
                        //就要用前一个节点的羁绊指向节点，用自己的羁绊指向下一个节点
                        for (int i = 0; i < index - 1; i++)
                        {
                            pre = pre.nodeNext;
                        }
                        pre.nodeNext = new Node(value, pre.nodeNext);
                        size++;
                    }
                    // 在链表的末尾添加一个新的元素e


                }
                //在最后添加元素
                public void addLast(T value)
                {
                    // 复用add()，只需要在size添加即可
                    AddOne(size, value);
                }
                // 删除链表中index位置元素 返回删除的元素
                public T RemoveAt(int index)
                {
                    if (index < 0 || index > size)
                    {
                        Console.WriteLine("输入不合法");

                    }
                    Node dummyHead = new Node(Value, null);
                    Node pre = dummyHead;
                    for (int i = 0; i < index - 1; i++)
                    {
                        pre = pre.nodeNext;
                    }
                    //移除元素就是将目标元素和下一个元素的羁绊切断，
                    //再将目标元素的上一个元素的羁绊与目标元素的下一个元素相连接
                    //再讲目标元素羁绊设置为空
                    Node removednode = pre.nodeNext;
                    pre.nodeNext = removednode.nodeNext;
                    removednode.nodeNext = null;
                    size--;
                    return removednode.Value;
                }
                // 删除第一个元素，返回删除的元素
                public T removeFrist()
                {
                    return RemoveAt(0);
                }
                // 从链表中删除元素
                public void Remove(T value)
                {
                    Node dummyHead = new Node(Value, null);
                    Node pre = dummyHead;
                    while (pre.nodeNext != null)
                    {
                        //让自己的下一个节点指向下一个元素的下一个节点=- = 就是跳过自己！！
                        if (pre.nodeNext.Value.Equals(value))
                            break;
                        pre = pre.nodeNext;
                    }

                    if (pre.nodeNext != null)
                    {
                        Node delNode = pre.nodeNext;
                        pre.nodeNext = delNode.nodeNext;
                        delNode.nodeNext = null;
                        size--;
                    }
                }

                //查找并获取指定位置元素 
                public T FindOne(int index)
                {
                    if (index < 0 || index > size)
                    {
                        Console.WriteLine("输入不合法");

                    }
                    Node dummyHead = new Node(Value, null);
                    Node findOne = dummyHead.nodeNext;
                    for(int i = 0; i < index; i++)
                    
                        findOne=findOne.nodeNext;
                        return findOne.Value;

                }

                #endregion

            }

           
        }



        #endregion
        static void Main(string[] args)
        {
            Console.WriteLine("----------");
            myLinked<int> no1 = new myLinked<int>();
            for(int i = 5; i < 5; i++)
            {
                object value = no1.addFrist(i);
                Console.WriteLine(no1);
            }    
            Console.WriteLine(no1);



            Console.ReadLine();
        }


    } 
}
