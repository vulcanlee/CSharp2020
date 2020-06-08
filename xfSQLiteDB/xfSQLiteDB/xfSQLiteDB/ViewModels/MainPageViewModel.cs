using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xfSQLiteDB.ViewModels
{
    using System.ComponentModel;
    using Microsoft.EntityFrameworkCore;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public string URL { get; set; }
        public string DBPath { get; set; }
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            using (var db = new DatabaseContext())
            {
                db.Database.Migrate();

                if ((await db.Blogs.CountAsync()) == 0)
                {
                    db.Add(new Blog() { Rating = 5, Url = "https://mylabtw.blogspot.com/" });
                    db.SaveChanges();
                }

                URL = db.Blogs.ToList().FirstOrDefault().Url;
                DBPath = db._databasePath;
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
