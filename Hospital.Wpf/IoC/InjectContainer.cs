using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital.Wpf.IoC
{
    static class InjectContainer
    {
        private static Dictionary<Type, UserControl> _views = new Dictionary<Type, UserControl>();

        public static void RegisterView(Type type, UserControl view)
        {
            if(!_views.ContainsKey(type))
            {
                _views.Add(type, view);
            }
        }

        public static UserControl ResolveView(Type type)
        {
            if (_views.ContainsKey(type))
                return _views[type];
            return null;
        }
    }
}
