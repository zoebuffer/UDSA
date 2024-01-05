namespace dev.zoebuffer.udsa.datastructures.stack
{
    public static class Stack
    {
        public static object Init<T>()
        {
            return StackUtils.New<T>(StackType.Dynamic, 0);
        }

        public static object Init<T>(int size)
        {
            return StackUtils.New<T>(StackType.Fixed, size);
        }

        public static bool Push<T>(this object stack, T item)
        {
            return StackUtils.AddItem(stack, item);
        }

        public static bool Pop<T>(this object stack, out T item)
        {
            return StackUtils.RemoveItem(stack, out item);
        }
    }
}
