using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace listasligadas
{
    public class DoublyLinkedList<T>

    {
        private DoubleNode<T>? _head;
        private DoubleNode<T>? _tail;
        public DoublyLinkedList()
        {
            _tail = null;
            _head = null;

        }
        public void InsertAtBeginning(T data)
        {
            var newNode = new DoubleNode<T>(data);
            if (_head == null) // empty list 
            {
                _head = newNode;
                _tail = newNode;
            }
            else // non-empty list
            {
                newNode.Next = _head;
                _head.Prev = newNode;
                _head = newNode;
            }
        }
        public void InsertAtEnd(T data)
        {
            var newNode = new DoubleNode<T>(data);
            if (_tail == null) // empty list
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                newNode.Prev = _tail;
                _tail = newNode;
            }
        }

        //Prins the list from head to tail 
        public string Getforward()
        {
            var output = string.Empty;
            var current = _head;
            while (current != null)
            {
                output += $"{current.Data} <=> ";
                current = current.Next;
            }
            return output.Substring(0, output.Length - 5);
        }

        // Prints the list from tail to head
        public string GetBackward()
        {
            var output = string.Empty;
            var current = _tail;
            while (current != null)
            {
                output += $"{current.Data} <=> ";
                current = current.Prev;
            }
            return output.Substring(0, output.Length - 5);
        }
        public void Remove(T data)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Data!.Equals(data))
                {
                    if (current.Prev != null)
                    {  
                        current.Prev.Next = current.Next;
                    }
                    else
                    {
                        _head = current.Next; // Remove head
                    }

                    if (current.Next != null)
                    {
                        current.Next.Prev = current.Prev;
                    }
                    else
                    {
                        _tail = current.Prev; // Remove tail
                    }

                    break;
                }
                current =current.Next;
        }