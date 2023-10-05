using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace Gammon;

public static class ConfigConsts
{
    public const string PathName = "Gammon";

    public static readonly string ConfigPath =
        Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), PathName);

    public static readonly string DbPath = Path.Join(ConfigPath, "gammon.db");

    public static readonly string ConnectionString = new SqliteConnectionStringBuilder()
    {
        Mode = SqliteOpenMode.ReadWriteCreate,
        Cache = SqliteCacheMode.Shared,
        DataSource = ConfigConsts.DbPath,
    }.ToString();
}