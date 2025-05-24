using System;
using System.Collections.Generic;
using System.Linq;

namespace listasligadas
{
    public class DoublyLinkedList<T>
    {
        private DoubleNode<T>? _head;
        private DoubleNode<T>? _tail;

        public DoublyLinkedList()
        {
            _head = null;
            _tail = null;
        }

        public void InsertAtBeginning(T data)
        {
            var newNode = new DoubleNode<T>(data);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head.Prev = newNode;
                _head = newNode;
            }
        }

        public void InsertAtEnd(T data)
        {
            var newNode = new DoubleNode<T>(data);
            if (_tail == null)
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

        public void InsertOrdered(T data)
        {
            var newNode = new DoubleNode<T>(data);
            if (_head == null || Comparer<T>.Default.Compare(data!, _head.Data!) < 0)
            {
                InsertAtBeginning(data);
                return;
            }

            var current = _head;
            while (current!.Next != null && Comparer<T>.Default.Compare(current.Next.Data!, data!) < 0)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            newNode.Prev = current;

            if (current.Next != null)
                current.Next.Prev = newNode;
            else
                _tail = newNode;

            current.Next = newNode;
        }

        public string Getforward()
        {
            var output = string.Empty;
            var current = _head;
            while (current != null)
            {
                output += $"{current.Data} <=> ";
                current = current.Next;
            }
            return output.Length > 5 ? output.Substring(0, output.Length - 5) : string.Empty;
        }

        public string GetBackward()
        {
            var output = string.Empty;
            var current = _tail;
            while (current != null)
            {
                output += $"{current.Data} <=> ";
                current = current.Prev;
            }
            return output.Length > 5 ? output.Substring(0, output.Length - 5) : string.Empty;
        }

        public void SortDescending()
        {
            List<T> elements = new List<T>();
            var current = _head;
            while (current != null)
            {
                if (current.Data != null)
                    elements.Add(current.Data);
                current = current.Next;
            }

            elements.Sort((a, b) => Comparer<T>.Default.Compare(b!, a!));

            _head = _tail = null;
            foreach (var item in elements)
            {
                InsertAtEnd(item!);
            }
        }

        public List<T> GetModes()
        {
            var frequency = new Dictionary<T, int>();
            var current = _head;

            while (current != null)
            {
                if (current.Data != null)
                {
                    if (frequency.ContainsKey(current.Data))
                        frequency[current.Data]++;
                    else
                        frequency[current.Data] = 1;
                }
                current = current.Next;
            }

            if (frequency.Count == 0) return new List<T>();

            int maxFreq = frequency.Values.Max();
            return frequency.Where(p => p.Value == maxFreq).Select(p => p.Key).ToList();
        }

        public bool Exists(T data)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Data != null && current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void RemoveOne(T data)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Data != null && current.Data.Equals(data))
                {
                    if (current.Prev != null)
                        current.Prev.Next = current.Next;
                    else
                        _head = current.Next;

                    if (current.Next != null)
                        current.Next.Prev = current.Prev;
                    else
                        _tail = current.Prev;

                    break;
                }
                current = current.Next;
            }
        }

        public void RemoveAll(T data)
        {
            var current = _head;
            while (current != null)
            {
                var next = current.Next;
                if (current.Data != null && current.Data.Equals(data))
                {
                    if (current.Prev != null)
                        current.Prev.Next = current.Next;
                    else
                        _head = current.Next;

                    if (current.Next != null)
                        current.Next.Prev = current.Prev;
                    else
                        _tail = current.Prev;
                }
                current = next;
            }
        }

        public Dictionary<T, int> GetFrequency()
        {
            var freq = new Dictionary<T, int>();
            var current = _head;
            while (current != null)
            {
                if (current.Data != null)
                {
                    if (freq.ContainsKey(current.Data))
                        freq[current.Data]++;
                    else
                        freq[current.Data] = 1;
                }
                current = current.Next;
            }
            return freq;
        }
    }
}
