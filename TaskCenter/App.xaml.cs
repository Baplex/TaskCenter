﻿using TaskCenter.Views;
using System.IO;


namespace TaskCenter
{
    public partial class App : Application
    {
        private static SQLiteHelper db;
        public static SQLiteHelper MyDatabase
        {
            get 
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                        "MyStore.db3"));
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainMenu());
            
            
        }
    }
}
