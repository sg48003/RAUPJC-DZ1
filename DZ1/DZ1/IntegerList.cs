using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    public class IntegerList
    {
        private int[] _internalStorage;

        public IntegerList()
        {
            _internalStorage = new int[4];
        }

        public IntegerList(int initialSize)
        {
            _internalStorage = new int[initialSize];
            //iznimka???
        }

        public void Add(int item)
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i] == 0)
                {
                    _internalStorage[i] = item;
                    return;
                }
            }
            int tmp = _internalStorage.Length; 
            Array.Resize<int>(ref _internalStorage, _internalStorage.Length * 2);
            _internalStorage[tmp] = item;
        }

        public bool Remove(int item)
        {
            int index = Array.IndexOf(_internalStorage, item);
            return RemoveAt(index);
        }

        public bool RemoveAt(int index)
        {
            try
            {
                if (_internalStorage[index] == 0) return false; //nula je kao inicijalno pa tamo "nema" broja

                List<int> tmp = new List<int>(_internalStorage);
                tmp.RemoveAt(index);
                _internalStorage = tmp.ToArray();
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        public int GetElement(int index)
        {
            try
            {
                return _internalStorage[index];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return 0;
               
            }
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i] == item) return i;
            }
            return -1;
            
        }
        
        public int Count
        {
            get
            {
                int count = 0;
                foreach (int number in _internalStorage)
                {
                    if (number != 0) count++;
                }

                return count;
            }
                 
        }

        public void Clear()
        {
            Array.Clear(_internalStorage, 0, _internalStorage.Length);
        }
        
        public bool Contains (int item)
        {
            foreach (int number in _internalStorage)
            {
                if (number == item) return true;
            }

            return false;
        }

        

    }

    public interface IIntegerList
    {
        /// <summary >
        /// Adds an item to the collection .
        /// </ summary >
        void Add(int item);

        /// <summary >
        /// Removes the first occurrence of an item from the collection .
        /// If the item was not found , method does nothing .
        /// </ summary >
        bool Remove(int item);

        /// <summary >
        /// Removes the item at the given index in the collection .
        /// </ summary >
        bool RemoveAt(int index);

        /// <summary >
        /// Returns the item at the given index in the collection .
        /// </ summary >
        int GetElement(int index);

        /// <summary >
        /// Returns the index of the item in the collection .
        /// If item is not found in the collection , method returns -1.
        /// </ summary >
        int IndexOf(int item);

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
        bool Contains(int item);
    }

   
}
