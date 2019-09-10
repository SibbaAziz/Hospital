using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Hospital.Wpf.IoC
{
    static class InjectContainer
    {
        private static readonly Dictionary<Type, Control> Views = new Dictionary<Type, Control>();

        public static void RegisterView<T>(Control view) where T : class
        {
            if(!Views.ContainsKey(typeof(T)))
            {
                Views.Add(typeof(T), view);
            }
        }

        public static Control ResolveView<T>() where T : class
        {
            return Views.ContainsKey(typeof(T)) ? Views[typeof(T)] : null;
        }
    }
}
