namespace dev.zoebuffer.udsa.algorithms.sorting
{
    public static class SelectionSort
    {
        public static void SortInPlace(this interfaces.IUdonComparer[] collection, bool descending = false)
        {
            int i, j;
            for (i = 0; i < collection.Length - 1; i++)
            {
                int jMin = i;
                for (j = i + 1; j < collection.Length; j++)
                {
                    if (collection[j].Compare(collection[jMin]) < 0)
                    {
                        jMin = j;
                    }
                }
                utils.ArrayUtils.Swap(collection, i, jMin);
            }
        }

        public static interfaces.IUdonComparer[] Sort(interfaces.IUdonComparer[] collection, bool descending = false)
        {
            interfaces.IUdonComparer[] sortedList = new interfaces.IUdonComparer[collection.Length];
            collection.CopyTo(sortedList, 0);

            int i, j;
            for (i = 0; i < sortedList.Length - 1; i++)
            {
                int jMin = i;
                for (j = i + 1; j < sortedList.Length; j++)
                {
                    if (sortedList[j].Compare(sortedList[jMin]) < 0)
                    {
                        jMin = j;
                    }
                }
                utils.ArrayUtils.Swap(sortedList, i, jMin);
            }

            return sortedList;
        }
    }
}
