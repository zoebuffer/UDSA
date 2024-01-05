namespace dev.zoebuffer.udsa.algorithms
{
    public static class AlgoZ
    {
        public static void SelectionSortInPlace(this interfaces.IUdonComparer[] collection, bool descending = false)
        {
            sorting.SelectionSort.SortInPlace(collection, descending);
        }

        public static interfaces.IUdonComparer[] SelectionSort(interfaces.IUdonComparer[] collection, bool descending = false)
        {
            return sorting.SelectionSort.Sort(collection, descending);
        }
    }
}
