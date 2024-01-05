using UdonSharp;
using UnityEngine;

using dev.zoebuffer.udsa.interfaces;

namespace dev.zoebuffer.udsa.samples.sortableobjectexample
{
    public class SortableObject : IUdonComparer
    {
        [SerializeField]
        public int val;

        public override int Compare(UdonSharpBehaviour other)
        {
            SortableObject o = (SortableObject)other;

            if (val < o.val)
                return -1;
            if (val > o.val)
                return 1;

            return 0;
        }
    }
}
