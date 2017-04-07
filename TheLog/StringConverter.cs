using System;
using System.Linq;
using System.Linq.Expressions;

namespace TheLog {
    static class StringConverter {
        public static string ConvertToString<T>() {
            return ConvertToString(typeof(T));
        }

        public static string ConvertToString(Type type) {
            return GetGenericTypeString(type);
        }

        public static string ConvertToString(Expression<Action> action) {
            // TODO: Improve expression convertion to string
            return action.ToString();
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