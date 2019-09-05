using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GalaSoft.MvvmLight.Command;
using Hospital.Core.Models;

namespace Hospital.Wpf.Controls
{
    [TemplatePart(Name = "Root", Type = typeof(Grid))]
    [TemplatePart(Name = "Headers", Type = typeof(Grid))]
    [TemplatePart(Name = "Timeline", Type = typeof(Grid))]
    [TemplatePart(Name = "Content", Type = typeof(Grid))]
    public class PlaningControl : Control
    {
        private Grid _root;
        private Grid _headers;
        private Grid _timeline;
        private Grid _content;

        static PlaningControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlaningControl), new FrameworkPropertyMetadata(typeof(PlaningControl)));
        }
        public PlaningControl()
        {
            ExecuteCommand = new RelayCommand<Service>(Execute);
            Visibility = Visibility.Hidden;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _root = base.GetTemplateChild("Root") as Grid;
            _headers = GetTemplateChild("Headers") as Grid;
            _timeline = GetTemplateChild("Timeline") as Grid;
            _content = GetTemplateChild("Content") as Grid;

            DrawTimeline();
        }

        public DateTime StartDate
        {
            get { return (DateTime)GetValue(StartDateProperty); }
            set { SetValue(StartDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartDateProperty =
            DependencyProperty.Register("StartDate", typeof(DateTime), typeof(PlaningControl), new PropertyMetadata(DateTime.Today));



        public IList<Resource> ResourceItems
        {
            get { return (IList<Resource>)GetValue(ResourceItemsProperty); }
            set { SetValue(ResourceItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResourceItemsProperty =
            DependencyProperty.Register("ResourceItems", typeof(IList<Resource>), typeof(PlaningControl), new PropertyMetadata(null));



        public DateTime EndDate
        {
            get { return (DateTime)GetValue(EndDateProperty); }
            set { SetValue(EndDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EndDateProperty =
            DependencyProperty.Register("EndDate", typeof(DateTime), typeof(PlaningControl), new PropertyMetadata(DateTime.Today));



        public string Service
        {
            get { return (string)GetValue(ServiceProperty); }
            set { SetValue(ServiceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Service.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ServiceProperty =
            DependencyProperty.Register("Service", typeof(string), typeof(PlaningControl), new PropertyMetadata(string.Empty));



        public RelayCommand<Service> ExecuteCommand { get; set; }

        private void Execute(Service service)
        {
            Visibility = Visibility.Visible;
            Service = service.Name;
            _headers.Children.Clear();
            _content.Children.Clear();
            _headers.ColumnDefinitions.Clear();
            _content.ColumnDefinitions.Clear();
            _content.RowDefinitions.Clear();
            

            int days = (EndDate - StartDate).Days;
            _content.RowDefinitions.Add(new RowDefinition(){Height = new GridLength(10, GridUnitType.Star)});
            _content.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(10, GridUnitType.Star) });


            for (int i = 0; i <= days; i++)
            {
                if (days > 0)
                {
                    var columnNumber = 100 / days;
                    _headers.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(columnNumber, GridUnitType.Star) });
                    _content.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(columnNumber, GridUnitType.Star) });
                }
                
                var headerBorder = new Border();
                var label = new Label {Content = StartDate.AddDays(i).Date.ToString("dddd d MMM yyyy").ToUpper() };
                label.Foreground = Brushes.White;
                label.VerticalAlignment = VerticalAlignment.Center;
                label.FontWeight = FontWeights.Bold;
                label.Padding = new Thickness(10);
                label.HorizontalAlignment = HorizontalAlignment.Center;
                headerBorder.BorderBrush = Brushes.Gray;
                headerBorder.BorderThickness = new Thickness(0,0,1,0);
                headerBorder.Child = label;
                Grid.SetColumn(headerBorder, i);
                _headers.Children.Add(headerBorder);

                var border1 = new Border();
                border1.BorderBrush = Brushes.Gray;
                border1.BorderThickness = new Thickness(0,0.5,1,0.5);
                border1.Child = new ListEditorControl(){ResourceItems = ResourceItems};
                Grid.SetColumn(border1,i);
                _content.Children.Add(border1);

                var border2 = new Border();
                border2.BorderBrush = Brushes.Gray;
                border2.BorderThickness = new Thickness(0, 0.5, 1, 0.5);
                border2.Child = new ListEditorControl(){ResourceItems = ResourceItems};
                Grid.SetColumn(border2, i);
                Grid.SetRow(border2,1);
                _content.Children.Add(border2);
            }
        }

        private void DrawTimeline()
        {
            for (int i = 0; i < 24; i++)
            {
                _timeline.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100 / 24, GridUnitType.Star) });
                var hour = (8 + i) % 24;
                var border = new Border();
                var hourShow = hour <= 9 ? $"0{hour}" : $"{hour}";
                var label = new Label { Content = $"{hourShow}:00" };
                label.FontSize = 8;
                border.BorderThickness = new Thickness(0.25);
                border.BorderBrush = Brushes.SlateGray;
                label.VerticalAlignment = VerticalAlignment.Center;
                border.Padding = new Thickness(1);
                Grid.SetRow(border, i);
                border.Child = label;
                _timeline.Children.Add(border);
            }
            
        }
    }
}
