using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using Hospital.Repository;
using Hospital.ViewModels;
using Unity;

namespace Hospital
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var unity = new UnityContainer();
            unity.RegisterType<IRepository, SqliteRepository>();
            unity.RegisterType<IMainWindowModel, MainWindowViewModel>();
            var mainWindow = unity.Resolve<MainWindow>(); // Creating Main window

            //using (var db = new ApplicationDbContext())
            //{
            //    db.Database.Migrate();
            //}

            mainWindow.Show();
        }
    }
}
