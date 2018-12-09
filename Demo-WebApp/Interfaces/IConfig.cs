namespace Demo_WebApp.Interfaces
{
    /// <summary>
    /// Methods must be thread safe due to potential object reuse in concurrent environment.
    /// </summary>
    public interface IConfig {
        string WeatherAppID {get;}

        string GoogleAppID {get;}
    }
}