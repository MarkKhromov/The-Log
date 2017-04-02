using System;
using System.Linq;

namespace TheLog {
    static class StringConverter {
        public static string ConvertToString<T>() {
            return ConvertToString(typeof(T));
        }

        public static string ConvertToString(Type type) {
            return GetGenericTypeString(type);
        }

        static string GetGenericTypeString(Type type) {
            if(type.IsGenericType) {
                var typeNames = type.GetGenericArguments().Select(GetGenericTypeString);
                return $"{GetGenericTypeName(type)}<{string.Join(", ", typeNames)}>";
            } else {
                return type.Name;
            }
        }

        static string GetGenericTypeName(Type type) {
            return type.Name.Remove(type.Name.IndexOf('`'));
        }
    }
}