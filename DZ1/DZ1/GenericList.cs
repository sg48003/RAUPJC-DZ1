using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    public class GenericList <X> : IGenericList <X>
    {
        private X[] _internalStorage;

        public GenericList()
        {
            _internalStorage = new X[4];
        }

        public GenericList(int initialSize)
        {
            _internalStorage = new X[initialSize];
            //iznimka???
        }

        public void Add(X item)
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (EqualityComparer<X>.Default.Equals(_internalStorage[i], default(X)))
                {
                    _internalStorage[i] = item;
                    return;
                }
            }
            int tmp = _internalStorage.Length;
            Array.Resize<X>(ref _internalStorage, _internalStorage.Length * 2);
            _internalStorage[tmp] = item;
        }

        public bool Remove(X item)
        {
            int index = Array.IndexOf(_internalStorage, item);
            return RemoveAt(index);
        }

        public bool RemoveAt(int index)
        {
            try
            {
                if (EqualityComparer<X>.Default.Equals(_internalStorage[index], default(X))) return false; //nula je kao inicijalno pa tamo "nema" broja

                List<X> tmp = new List<X>(_internalStorage);
                tmp.RemoveAt(index);
                _internalStorage = tmp.ToArray();
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        public X GetElement(int index)
        {
            try
            {
                return _internalStorage[index];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return default(X);

            }
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i].Equals(item)) return i;
            }
            return -1;

        }

        public int Count
        {
            get
            {
                int count = 0;
                foreach (X number in _internalStorage)
                {
                    if (!( EqualityComparer<X>.Default.Equals(number, default(X)))) count++;
                }

                return count;
            } 

        }

        public void Clear()
        {
            Array.Clear(_internalStorage, 0, _internalStorage.Length);
        }

        public bool Contains(X item)
        {
            foreach (X number in _internalStorage)
            {
                if (number.Equals(item)) return true;
            }

            return false;
        }

        // IEnumerable <X> implementation
        public IEnumerator <X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class GenericListEnumerator<T> : IEnumerator<T>
        {
            private GenericList<T> _genericList;

            public GenericListEnumerator(GenericList<T> genericList)
            {
                this._genericList = genericList;
            }

            int position = -1;

            object IEnumerator.Current
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            T IEnumerator<T>.Current
            {
                get
                {
                    try
                    {
                        return _genericList._internalStorage[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }


            public bool MoveNext()
            {
                position++;
                return (position < _genericList._internalStorage.Length);
            }

            public void Reset()
            {
                position = -1;
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }

    public interface IGenericList<X> : IEnumerable<X>
    {

        /// <summary >
        /// Adds an item to the collection .
        /// </ summary >
        void Add(X item);
        /// <summary >
        /// Removes the first occurrence of an item from the collection .
        /// If the item was not found , method does nothing .
        /// </ summary >
        bool Remove(X item);
        /// <summary >
        /// Removes the item at the given index in the collection .
        /// </ summary >
        bool RemoveAt(int index);
        /// <summary >
        /// Returns the item at the given index in the collection .
        /// </ summary >
        X GetElement(int index);
        /// <summary >
        /// Returns the index of the item in the collection .
        /// If item is not found in the collection , method returns -1.
        /// </ summary >
        int IndexOf(X item);
        /// <summary >
        /// Readonly property . Gets the number of items contained in the collection.
        /// </ summary >
        int Count { get; }
        /// <summary >
        /// Removes all items from the collection .
        /// </ summary >
        void Clear();
        /// <summary >
        /// Determines whether the collection contains a specific value .
        /// </ summary >
        bool Contains(X item);
    }

   
}
