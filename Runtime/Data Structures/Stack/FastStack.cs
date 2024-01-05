using Varneon.VUdon.ArrayExtensions;

namespace dev.zoebuffer.udsa.datastructures.stack
{
    public static class FastStack
    {
        public static T[] Init<T>()
        {
            return new T[0];
        }

        public static T[] Init<T>(int size)
        {
            return new T[size];
        }

        public static void Push<T>(ref T[] stack, T val)
        {
            stack = stack.Add(val);
        }

        public static bool Push<T>(ref T[] stack, ref int idx, T val)
        {
            if (idx < 0 || idx >= stack.Length - 1)
                return false;

            stack[idx++] = val;
            return true;
        }

        public static bool Pop<T>(ref T[] stack, out T val)
        {
            if (stack.Length == 0)
            {
                val = default;
                return false;
            }

            int idx = stack.Length - 1;
            val = stack[idx];
            stack = stack.RemoveAt(idx);
            return true;
        }

        public static bool Pop<T>(ref T[] stack, ref int idx, out T val)
        {
            if (idx < 1 || idx > stack.Length - 1)
            {
                val = default;
                return false;
            }

            val = stack[--idx];
            return true;
        }

        public static void Clear<T>(ref T[] stack)
        {
            stack = stack.Resize(0);
        }

        public static void Clear<T>(ref T[] stack, ref int idx)
        {
            for (int i = 0; i < stack.Length; i++)
                stack[i] = default;

            idx = 0;
        }
    }
}
