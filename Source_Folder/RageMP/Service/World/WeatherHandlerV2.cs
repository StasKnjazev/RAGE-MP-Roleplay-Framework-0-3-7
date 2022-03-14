using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTANetworkAPI;
using System.Timers;


/// <summary>
/// Class for managing weather
/// </summary>
class WeatherManager : Script
{
    private Random rdn = new Random();
    private Timer weatherTimer = new Timer();
    private int minTime = 1200000;
    private int maxTime = 2200000 * 2;


    /// <summary>
    /// Generates a random weather id
    /// </summary>
    /// <param name="exclude">Id that is excluded</param>
    /// <returns>Random weather id that isn't excluded id</returns>
    private int GenerateRandomWeatherId(int exclude)
    {
        int a = rdn.Next(0, 9);
        while (a == exclude)
        {
            a = rdn.Next(0, 9);
        }
        return a;
    }

    /// <summary>
    /// Gets random integer from selection
    /// </summary>
    /// <param name="ints">List of integers</param>
    /// <returns>Random integer from list</returns>
    private int GetRandomIntFromSelectedInts(params int[] ints)
    {
        return ints.ElementAt(rdn.Next(0, ints.Count()));
    }

    /// <summary>
    /// Sets random even after random time
    /// </summary>
    /// <param name="source">Timer</param>
    /// <param name="e">Timer arguments</param>
    private void OnTimedEvent(System.Object source, ElapsedEventArgs e)
    {
        SetRandomWeather();
        //NAPI.Util.ConsoleOutput("Clim Aalteraado");
    }

    /// <summary>
    /// Sets random weather
    /// </summary>
    private void SetRandomWeather()
    {
        string Weather = Convert.ToString(NAPI.World.GetWeather());
        int currentWeather = 0;
        int index = 0;
        foreach(var weather in Main.weather_list)
        {
            if(weather.name == Weather)
            {
                currentWeather = index;
            }
            index++;
        }
        //NAPI.Util.ConsoleOutput(currentWeather + weather_list[currentWeather].name);

        int new_weather = GetRandomIntFromSelectedInts(0, 1, 2);

        if(new_weather == currentWeather)
        {
            NAPI.World.SetWeather(weather_list[GetRandomIntFromSelectedInts(0, 1, 2)].name);
        }
        else NAPI.World.SetWeather(weather_list[new_weather].name);

    }

    /// <summary>
    /// Returns random time between two times
    /// </summary>
    /// <param name="time1">First time</param>
    /// <param name="time2">Second time</param>
    /// <returns>Time between first and second time</returns>
    private int GetRandomTimeBetweenSelectedTimes(int time1, int time2)
    {
        return rdn.Next(time1, time2 + 1);
    }

    /// <summary>
    /// Initializes weather timer
    /// </summary>
    private void InitWeatherTimer()
    {
        weatherTimer.Interval = GetRandomIntFromSelectedInts(this.minTime, this.maxTime);
        weatherTimer.Elapsed += OnTimedEvent;
        weatherTimer.AutoReset = true;
        weatherTimer.Enabled = true;
    }

    private List<dynamic> weather_list = new List<dynamic>();

    public WeatherManager()
    {
        weather_list.Add(new { name = "EXTRASUNNY" });
        weather_list.Add(new { name = "CLEAR" });
        weather_list.Add(new { name = "CLOUDS" });
        weather_list.Add(new { name = "SMOG" });
        weather_list.Add(new { name = "FOGGY" });
        weather_list.Add(new { name = "OVERCAST" });
        weather_list.Add(new { name = "RAIN" });
        weather_list.Add(new { name = "THUNDER" });
        weather_list.Add(new { name = "CLEARING" });
        weather_list.Add(new { name = "NEUTRAL" });
        weather_list.Add(new { name = "SNOW" });
        weather_list.Add(new { name = "BLIZZARD" });
        weather_list.Add(new { name = "SNOWLIGHT" });
        weather_list.Add(new { name = "XMAS" });
        weather_list.Add(new { name = "HALLOWEEN" });

        SetRandomWeather();
        InitWeatherTimer();
    }

    [Command("climadinamico")]
    public void CMD_cnn(Client player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 2)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Bitte geben Sie Ihre Erlaubnis ein, um zu uns zu gelangen.");
            return;
        }
        SetRandomWeather();
    }
}
