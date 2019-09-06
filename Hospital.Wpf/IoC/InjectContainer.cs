using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Hospital.Wpf.IoC
{
    static class InjectContainer
    {
        private static readonly Dictionary<Type, UserControl> Views = new Dictionary<Type, UserControl>();

        public static void RegisterView<T>( UserControl view) where T : class
        {
            if(!Views.ContainsKey(typeof(T)))
            {
                Views.Add(typeof(T), view);
            }
        }

        public static UserControl ResolveView<T>() where T : class
        {
            return Views.ContainsKey(typeof(T)) ? Views[typeof(T)] : null;
        }
    }
}
