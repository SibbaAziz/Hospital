﻿using System.Windows;
using Hospital.Core.Repository;
using Hospital.Data.Repositories;
using Hospital.Wpf.IoC;
using Hospital.Wpf.ViewModels;
using Hospital.Wpf.Views;
using Unity;

namespace Hospital.Wpf
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var unity = new UnityContainer();
            unity.RegisterType<IRepository, MemoryRepository>();
            unity.RegisterType<IMainWindowModel, MainWindowViewModel>();

            InjectContainer.RegisterView<PlanningView>(unity.Resolve<PlanningView>());
            var mainWindow = unity.Resolve<MainWindow>(); // Creating Main window

            mainWindow.Show();
        }
    }
}
