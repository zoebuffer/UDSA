namespace dev.zoebuffer.udsa.utils
{
    public static class ArrayUtils
    {
        // See: https://stackoverflow.com/a/43759678
        public static void Swap<T>(this T[] source, int idx1, int idx2)
        {
            T temp = source[idx1];
            source[idx1] = source[idx2];
            source[idx2] = temp;
        }
    }
}
