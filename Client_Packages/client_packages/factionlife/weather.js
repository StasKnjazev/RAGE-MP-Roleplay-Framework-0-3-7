require("Sector-V/vector.js");
mp.game.audio.startAudioScene("FBI_HEIST_H5_MUTE_AMBIENCE_SCENE");
mp.game.audio.startAudioScene("MIC1_RADIO_DISABLE");
var Weather = new class {
    constructor() {
        let self = this;
        self._areas = [];
        self._inside = undefined;
        mp.events.add("Weather:LoadAreas", (weathers) => {
            self.loadWeather(JSON.parse(weathers));
        });
        mp.events.add("Weather:SetWeather", (weather) => {
            self.setWeather(JSON.parse(weather));
        });
        setInterval(function() {
            self._check();
        }, 1000);
    }
    setWeather(weather_data) {
        if(this._inside == undefined) {

            mp.game.gameplay.setWind(weather_data.wind.speed);
            mp.game.gameplay.setWindDirection(weather_data.wind.dir);
            mp.game.gameplay.setWeatherTypeOverTime(weather_data.name, 1);
            mp.game.gameplay.setRainFxIntensity(weather_data.rain);
        }
    }
    loadWeather(arr) {
        let self = this;
        self._areas = arr;
        self._areas.forEach(function(area, index) {
            area.polygon.forEach(function(coords, index1) {
                self._areas[index].polygon[index1] = [coords.x, coords.y];
            })
        });
    }
    enter(key) {
        this._inside = key;
        let weather = this._areas[key];
        mp.game.gameplay.setWind(weather.wind.speed);
        mp.game.gameplay.setWindDirection(weather.wind.dir);
        mp.game.gameplay.setWeatherTypeOverTime(weather.name, 1);
        mp.game.gameplay.setRainFxIntensity(weather.rain);
        mp.events.callRemote("Weather:TransitionTo", this._inside);
    }
    exit() {
        this._inside = undefined;
        mp.events.callRemote("Weather:Exit");
        mp.game.gameplay.setWeatherTypeOverTime("CLEAR", 1);
        mp.game.gameplay.setWind(0);
        mp.game.gameplay.setWindDirection(0);
        mp.game.gameplay.setRainFxIntensity(0);
    }
    _check() {
        let self = this;
        if (self._areas.length > 0) {
            let lp = mp.vector(mp.players.local.position);
            let inside = self._areas.findIndex(function(area, key) {
                let inside1 = lp.insidePolygon(area.polygon);
                return (inside1 == true)
            })
            if (self._inside != inside) {
                if (inside > -1) {
                    self.enter(inside);
                } else {
                    self.exit();
                }
            }
        }
    }
}
exports = Weather;