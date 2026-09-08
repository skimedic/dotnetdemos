// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Services - AppLoggerSettings.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Services.Logging.Settings;

public class AppLoggerSettings
{
    [Required]
    public GeneralSettings General { get; set; }

    [Required]
    public FileSettings File { get; set; }

    [Required]
    public SqlServerSettings MsSqlServer { get; set; }

    public class GeneralSettings
    {
        [Required(AllowEmptyStrings = false)]
        public string RestrictedToMinimumLevel { get; set; }
    }

    public class SqlServerSettings
    {
        [Required(AllowEmptyStrings = false)]
        public string TableName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Schema { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ConnectionStringName { get; set; }
    }

    public class FileSettings
    {
        [Required(AllowEmptyStrings = false)]
        public string Drive { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string FilePath { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string FileName { get; set; }

        public string FullLogPathAndFileName =>
            $"{Drive}{Path.VolumeSeparatorChar}{Path.DirectorySeparatorChar}{FilePath}{Path.DirectorySeparatorChar}{FileName}";
    }
}