using VRC.SDK3.Data;

using Varneon.VUdon.ArrayExtensions;

using stack_data_t = VRC.SDK3.Data.DataDictionary;

namespace dev.zoebuffer.udsa.datastructures.stack
{
    internal static class StackUtils
    {
        internal const string TYPE = "type";
        internal const string SIZE = "size";
        internal const string TOP  = "top";
        internal const string DATA = "data";

        internal static stack_data_t New<T>(StackType type, int size)
        {
            var stack = new stack_data_t();

            stack[TYPE] = new DataToken(type);
            stack[SIZE] = size;
            stack[TOP]  = 0;
            stack[DATA] = new DataToken(new T[size]);

            return stack;
        }

        internal static StackType Type(this stack_data_t stack)
        {
            return (StackType)stack[TYPE].Reference;
        }

        internal static int GetSize(this stack_data_t stack)
        {
            return stack[SIZE].Int;
        }

        internal static int GetTop(this stack_data_t stack)
        {
            return stack[TOP].Int;
        }

        internal static void SetTop(this stack_data_t stack, int val)
        {
            stack[TOP] = val;
        }

        internal static T[] GetData<T>(this stack_data_t stack)
        {
            return (T[])stack[DATA].Reference;
        }

        internal static void SetData<T>(this stack_data_t stack, T[] data)
        {
            stack[DATA] = new DataToken(data);
        }

        internal static bool IsValid(object stack)
        {
            if (stack == null)
                return false;

            if (stack.GetType() != typeof(stack_data_t))
                return false;

            return true;
        }

        internal static bool AddItem<T>(object stack, T item)
        {
            if (!IsValid(stack))
                return false;

            var _stack = (stack_data_t)stack;

            StackType type = _stack.Type();
            int size = _stack.GetSize();
            int top = _stack.GetTop();

            if (type == StackType.Fixed && top >= size)
                return false;

            T[] data = _stack.GetData<T>();
            if (type == StackType.Dynamic)
            {
                data = data.Add(item);
            }
            else
            {
                data[top++] = item;
                _stack.SetTop(top);
            }

            _stack.SetData(data);

            return true;
        }

        internal static bool RemoveItem<T>(object stack, out T item)
        {
            item = default;

            if (!IsValid(stack))
                return false;

            var _stack = (stack_data_t)stack;

            StackType type = _stack.Type();
            int top = _stack.GetTop();

            if (type == StackType.Fixed && top < 1)
                return false;

            T[] data = _stack.GetData<T>();
            if (type == StackType.Dynamic)
            {
                if (data.Length == 0)
                    return false;

                int idx = data.Length - 1;
                item = data[idx];
                data = data.RemoveAt(idx);
            }
            else
            {
                item = data[--top];
                _stack.SetTop(top);
            }

            _stack.SetData(data);

            return true;
        }
    }
}