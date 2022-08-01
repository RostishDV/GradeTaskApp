using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.SingleLinkList
{
	public class SingleLinkList<T> : ISingleList<T>, IEnumerable<T>, IAlgorithm where T : IComparable
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

        public INode<T> First()
        {
            return head;
		}
        public INode<T> Last() 
        {
            return tail;
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
            if (count == 0 || count == 1) return;
            if (p1 == p2) return;
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

        /// <summary>
        /// Natalia
        /// </summary>
        public void BubbleSort()
        {
            if (head == null)
                return;
            int iter = 0;
            INode<T> current = tail;
            INode<T> rightBorder = tail;
            while (iter < count - 1)
            {
                do
                {
                    current = current.Next;
                    if (current.Data.CompareTo(current.Next.Data) > 0)
                    {
                        var temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;
                    }
                } while (current.Next != rightBorder);
                rightBorder = current;
                current = tail;
                iter++;
            }
        }
        /// <summary>
        /// Denis
        /// </summary>
        public void Order()
        {
            INode<T> current = head;
            INode<T> previous = tail;

            for (int j = 1; j < count; j++)
            {
                for (int i = 0; i < count - 1; i++)
                {
                    if (current.Data.CompareTo(current.Next.Data) > 0)
                    {
                        var temp = current.Next.Next;
                        current.Next.Next = current;
                        previous.Next = current.Next;
                        current.Next = temp;
                        previous = previous.Next;
                    }
                    else
                    {
                        previous = current;
                        current = current.Next;
                    }
                }
                previous = current;
                current = current.Next;
            }

            tail = previous;
            head = current;
        }
        /// <summary>
        /// Kostya
        /// </summary>
        public void Swap(INode<T> first, INode<T> second)
        {
            var temp = second.Data;
            second.Data = first.Data;
            first.Data = temp;
        }
        /// <summary>
        /// Kostya simple sort
        /// </summary>
        public void SimpleSort()
        {
            var minItem = head;
            var current = head.Next;

            for (int i = 0; i < count; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    var a = minItem.Data;
                    var b = current.Data;

                    if (a.CompareTo(b) == 1)
                    {
                        Swap(minItem, current);
                    }
                    current = current.Next;
                }
                minItem = minItem.Next;
                current = minItem.Next;
            }
        }
        /// <summary>
        /// Kostya simple sort optimized by rost
        /// </summary>
        public void SimpleSortOptimezed()
        {
            var currentSt = head;
            var min = currentSt;
            for (int i = 0; i < count; i++)
            {
                var current = currentSt.Next;
                for (int j = i + 1; j < count; j++)
                {
                    if (min.Data.CompareTo(current.Data) > 0)
                    {
                        min = current;
                    }
                    current = current.Next;
                }
                Swap(currentSt, min);
                currentSt = currentSt.Next;
            }
        }
        /// <summary>
        /// Kostya
        /// </summary>
        public void QuickSort(int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return;
            }

            int pivotIndex = GetPivotIndex(minIndex, maxIndex);

            QuickSort(minIndex, pivotIndex - 1);
            QuickSort(pivotIndex + 1, maxIndex);
        }
        /// <summary>
        /// Kostya
        /// </summary>
        private int GetPivotIndex(int minIndex, int maxIndex)
        {
            int pivot = minIndex - 1;

            for (int i = minIndex; i <= maxIndex; i++)
            {
                var current = GetNodeByIndex(i);
                var next = GetNodeByIndex(maxIndex);

                var a = current.Data as IComparable;
                var b = next.Data as IComparable;

                if (a.CompareTo(b) == -1)
                {
                    pivot++;
                    Swap(GetNodeByIndex(pivot), current);
                }
            }
            pivot++;
            Swap(GetNodeByIndex(pivot), GetNodeByIndex(maxIndex));

            return pivot;
        }
        /// <summary>
        /// Kostya
        /// </summary>
        public INode<T> GetNodeByIndex(int index)
        {
            if (head == null || index >= count)
            {
                return default;
            }
            var current = head;
            var counter = 0;

            while (counter < index)
            {
                current = current.Next;
                counter++;
            }
            return current;
        }
    }
}
