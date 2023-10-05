using System;
using System.IO;
using Avalonia.Controls;
using Gammon.Db;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Gammon.Views;

public partial class MainWindow : Window
{
    public const string ConfigPathName = "Gammon";

    public MainWindow()
    {
        var configPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var myConfigFolderPath = Path.Join(configPath, ConfigPathName);


        Directory.CreateDirectory(myConfigFolderPath);
        var dbFile = Path.Join(myConfigFolderPath, "gammon.db");

        var connectionString = new SqliteConnectionStringBuilder()
        {
            Mode = SqliteOpenMode.ReadWriteCreate,
            Cache = SqliteCacheMode.Shared,
            DataSource = dbFile,
        }.ToString();

        Console.WriteLine(connectionString);
        var ctx = new GamesContext(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);

        ctx.Database.EnsureCreated();
        ctx.Games.Add(new Game()
        {
            Name = "A Hat in Time",
            Image =
                "https://assets.nintendo.com/image/upload/ar_16:9,c_lpad,w_1240/b_white/f_auto/q_auto/ncom/software/switch/70010000003813/32caf691ee34a12f7ca126f3905fea623a7ac30f5d604f9ac950460f25704ff4"
        });
        ctx.SaveChanges();
        InitializeComponent();
    }
}