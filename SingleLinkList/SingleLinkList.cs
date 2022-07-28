using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.SingleLinkList
{
	internal class SingleLinkList<T> : ISingleList<T>, IEnumerable<T>, IAlgorithm where T : IComparable
    {
        private INode<T> head;
        private INode<T> tail;
        private int count;

        public int Count { get { return count; } set { count = value; } }

		public bool IsReadOnly => throw new NotImplementedException();

		public T this[int index] { get
            {
                INode<T> current = head;
                int pos = 0;
                while (pos < index)
                {
                    current = current.Next;
                    pos++;
                }
                return current.Data;
            }
            set 
            { 
                Insert(index, value); 
            } 
        }

        public bool Remove(T data)
        {

            if (count == 1) 
            {
                if (head.Data.Equals(data))
                {
                    Clear();
                    return true;
                }
                return false;
			}

            INode<T> current = head;
            INode<T> previous = null;
            int pos = 0;
            while (pos < count)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current == tail)
                            tail = previous;
                    }
                    else
                    {
                        head = current.Next;
                        tail.Next = head;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
                pos++;
            }

            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            if (count == 0) return false;

            INode<T> current = head;
            int pos = 0;
            while (pos < count)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
                pos++;
            }
            return false;
        }

		public int IndexOf(T item)
		{
            if (count == 0) return -1;

            INode<T> current = head;
            int pos = 0;
            while (pos < count)
            {
                if (current.Data.Equals(item))
                    return pos;
                current = current.Next;
                pos++;
            }
            return -1;
        }

		public void Insert(int index, T item)
		{
            if (index > count) Add(item);
            if (index < 0) return;

            INode<T> current = head;
            INode<T> previous = null;
            int pos = 0;
            
            while (pos < count)
            {
                if (pos == index)
                {
                    INode<T> newItem = new Node<T>(item);
                    if (previous != null) {
                        previous.Next = newItem;
                        newItem.Next = current;
					}
                    newItem.Next = current;
                    head = newItem;
                    tail.Next = head;
                    count++;
                    return;
                }
                previous = current;
                current = current.Next;
                pos++;
            }
        }

		public void RemoveAt(int index)
		{
            if (count == 0) return;

            INode<T> current = head;
            int pos = 0;
            while (pos < count)
            {
                if (pos == index)
                {
                    Remove(current.Data);
                    return;
                }
                pos++;
            }
        }

		public void Add(T item)
		{
            INode<T> node = new Node<T>(item);

            if (head == null)
            {
                head = node;
                tail = node;
                tail.Next = head;
            }
            else
            {
                node.Next = head;
                tail.Next = node;
                tail = node;
            }
            count++;
        }

		public void CopyTo(T[] array, int arrayIndex)
		{
            INode<T> current = head;
            int pos = 0;
            while (pos < count)
            {
                array[pos + arrayIndex] = current.Data;
                current = current.Next;
                pos++;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            INode<T> current = head;
            int pos = 0;
            while (pos < count)
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
                pos++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

		public void Sort()
		{
            INode<T> start = head;
            INode<T> stPrev = tail;
            int startPos = 0;

            while (startPos < count)
            {
                INode<T> min = start;
                INode<T> minPrev = stPrev;
                INode<T> previos = start;
                INode<T> current = start.Next;
                int curPos = startPos + 1;
                while (curPos < count){
                    if (current.Data.CompareTo(min.Data) < 0)
                    {
                        minPrev = previos;
				        min = current;
                    }
                    previos = current;
                    current = current.Next;
                    curPos++;
				}

                ChangePositions(stPrev, start, minPrev, min);
                if (min != start){
                    stPrev = min;
                    start = min.Next;
                } else
                {
                    stPrev = start;
                    start = start.Next;
				}
                
                startPos++;
            }
		}

        private void ChangePositions(INode<T> p1Prev, INode<T> p1, INode<T> p2Prev, INode<T> p2)
        {
            if (p1 == p2) return;
            if (count == 0 || count == 1) return;
            if (count == 2) 
            {
                if (p1 == head) {
                    tail = p1;
                    head = p2;
				}
                if (p2 == head)
                {
                    tail = p2;
                    head = p1;
                }
            }
            INode<T> p1Next = p1.Next;
            INode<T> p2Next = p2.Next;

            if (p1Next == p2){
                p1Prev.Next = p2;
                p2.Next = p1;
                p1.Next = p2Next;
            } else if (p2Next == p1) {
                p2Prev.Next = p1;
                p1.Next = p2;
                p2.Next = p1;
			} else {
                p1Prev.Next = p2;
                p1.Next = p2Next;
                p2Prev.Next = p1;
                p2.Next = p1Next;
            }

            if (p1 == head || p2 == head) {
                if (p1 == head) {
                    head = p2;
				} else {
                    head = p1;
				}
			}
            if (p1 == tail || p2 == tail)
            {
                if (p1 == tail)
                {
                    tail = p2;
                } else {
                    tail = p1;
                }
            }
        }
	}
}
