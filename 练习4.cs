using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace l链表
{
    //待完善
    #region 实现单向链表

    //链表节点
    class SYLinkedNode<T>
    {
        public T Value;
        public SYLinkedNode<T> nextNode;//钩子 
        public SYLinkedNode(T value)
        {
            this.Value = value;
        }
    }

    //单向链表类管理节点
    class SYLinkdedlist<T>
    {
        public SYLinkedNode<T> head;//默认为空
        public SYLinkedNode<T> tail;
        public int Count =0;//链表数据个数 初始0
        //增加元素
        public void Add(T value)
        {
            SYLinkedNode<T> node =new SYLinkedNode<T>(value);
            if (head == null)
            {
                head = node;
                tail = node;
            }
            //尾结点等于下一个的头结点
            else
            {
               tail.nextNode = node;
               tail=node;
            }
            Count ++;
        }
        //移除元素
        public void Remove(T value)
        {
            if(head == null)
            {
                return;
            }
            //判断移除的是否是头结点
            if (head.Value.Equals(value))
            {
                head=head.nextNode;
                //如果头结点是唯一的节点 那尾结点也要清空
                if (head == null)
                {
                    tail=null;
                }
                return;

            }
            SYLinkedNode<T> node = head;//临时节点存放头结点
            while(node.nextNode != null)
            {
                if (node.nextNode.Value.Equals(value))
                {
                    //让自己的下一个节点指向下一个元素的下一个节点=- = 就是跳过自己！！

                    node.nextNode = node.nextNode.nextNode;
                    break;
                }
            }

        }

    }

    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            SYLinkdedlist<int> no1 = new SYLinkdedlist<int>();
            no1.Add(1);
            no1.Add(22);
            no1.Add(3);
            no1.Add(4);
            no1.Add(1);
            SYLinkedNode<int> node = no1.head;
            while(node != null)
            {
                Console.WriteLine(node.Value);
                node=node.nextNode;
            }
            no1.Remove(2);
            node = no1.head;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.nextNode;
            }
            Console.WriteLine(no1);
            Console.ReadLine();

        }
    }
}
