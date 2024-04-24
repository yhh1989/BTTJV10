namespace HealthExaminationSystem;

public static class HesDbProperties
{
    public static string DbTablePrefix { get; set; } = "Hes";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Default";
}