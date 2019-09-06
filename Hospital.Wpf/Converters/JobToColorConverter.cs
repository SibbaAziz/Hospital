using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using Hospital.Wpf.Helpers;

namespace Hospital.Wpf.Converters
{
    public class JobToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var converter = new System.Windows.Media.BrushConverter();
            if (value == null)
                return Brushes.Transparent;

            var job = (JobEnum) EnumExtension.GetEnumByDescription(typeof(JobEnum), (string)value);
            SolidColorBrush brush = Brushes.Transparent;
            
            switch (job)
            {
                case JobEnum.Directeur:
                    brush = (SolidColorBrush)converter.ConvertFrom("#FFA726");
                    break;
                case JobEnum.MedecinSpecialiste:
                    brush = (SolidColorBrush)converter.ConvertFrom("#EEFF41");
                    break;
                case JobEnum.MedecinGeneraliste:
                    brush = (SolidColorBrush)converter.ConvertFrom("#BCAAA4");
                    break;
                case JobEnum.SageFemme:
                    brush = (SolidColorBrush)converter.ConvertFrom("#FF7043");
                    break;
                case JobEnum.TechnicienDeSurface:
                    brush = (SolidColorBrush)converter.ConvertFrom("#689F38");
                    break;
                case JobEnum.AgentHygiene:
                    brush = (SolidColorBrush)converter.ConvertFrom("#00ACC1");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
