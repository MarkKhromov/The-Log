using System;
using System.Threading;

namespace TheLog.Tests {
    class TestClass {
        public static void Sleep(int seconds) {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }
    }

    class TestInnerGenericClass<T1, T2> { }

    class TestGenericClass<T1, T2, T3> { }
}