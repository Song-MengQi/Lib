using System.Collections;
using System.Collections.Generic;

namespace Lib
{
    public static class StackExtend
    {
        public static bool IsEmpty(this Stack stack) { return stack.Count == 0; }
        public static bool TryPeek(this Stack stack, out object result)
        {
            result = default(object);
            if (stack.IsEmpty()) return false;
            result = stack.Peek();
            return true;
        }
        public static bool TryPop(this Stack stack, out object result)
        {
            result = default(object);
            if (stack.IsEmpty()) return false;
            result = stack.Pop();
            return true;
        }

        public static bool IsEmpty<T>(this Stack<T> stack) { return stack.Count == 0; }
        public static bool TryPeek<T>(this Stack<T> stack, out T result)
        {
            result = default(T);
            if (stack.IsEmpty()) return false;
            result = stack.Peek();
            return true;
        }
        public static bool TryPop<T>(this Stack<T> stack, out T result)
        {
            result = default(T);
            if (stack.IsEmpty()) return false;
            result = stack.Pop();
            return true;
        }
    }
}