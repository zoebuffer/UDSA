using UdonSharp;
using UnityEngine;

using dev.zoebuffer.udsa.algorithms;

namespace dev.zoebuffer.udsa.samples.sortableobjectexample
{
    public class SortableObjectExample : UdonSharpBehaviour
    {
        [SerializeField]
        SortableObject[] _objects;

        private void Start()
        {
            SendCustomEventDelayedSeconds(nameof(SortObjects), 1f);
        }

        public void SortObjects()
        {
            Debug.Log("Before sort...");
            PrintObjects();

            // Return new sorted array and keep original unmodified.
            //_objects = (SortableObject[])AlgoZ.SelectionSort(_objects);

            // Sort original array and modify it in place.
            _objects.SelectionSortInPlace();

            Debug.Log("After sort...");
            PrintObjects();
        }

        public void PrintObjects()
        {
            string vals = "";

            for (int i = 0; i < _objects.Length; i++)
            {
                vals += _objects[i].val;
                vals += i == _objects.Length - 1 ? "\n" : ", ";
            }

            Debug.Log(vals);
        }
    }
}
