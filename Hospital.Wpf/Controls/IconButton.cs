using System.Windows;
using System.Windows.Controls;

namespace Hospital.Wpf.Controls
{
    [TemplatePart(Name = "Loading", Type = typeof(Border))]
    public class IconButton : Button
    {
        private Border image;
        static IconButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconButton), new FrameworkPropertyMetadata(typeof(IconButton)));
        }


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            image = GetTemplateChild("Loading") as Border;
            image.MouseDown += Image_MouseDown;
        }

        private void Image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsLoading.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register("IsLoading", typeof(bool), typeof(IconButton), new PropertyMetadata(false));



        public object Icon
        {
            get { return (object)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(object), typeof(IconButton), new PropertyMetadata(null));


    }
}
