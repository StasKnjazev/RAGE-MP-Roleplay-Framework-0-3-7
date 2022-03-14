require('./betternotifs/index');
require('./ft/index');
require('./vehicleinteractions/index');
require('./vehicle/index');
require('./server_logs.js');

mp.world.trafficLights.locked = true;
mp.world.trafficLights.state = 0;
setLights();

function setLights()
{
    mp.world.trafficLights.state = 39;
    setTimeout(function(){
        mp.world.trafficLights.state = 88;
        setTimeout(function(){
            mp.world.trafficLights.state = 49;
            setTimeout(function(){
                mp.world.trafficLights.state = 88;
                setTimeout(function(){
                    mp.world.trafficLights.state = 39;
                    setTimeout(function(){
                        mp.world.trafficLights.state = 0;
                        setTimeout(function(){
                            setLights();
                        }, 25000); // Grünphase West -> Ost
                    }, 2000);  // Grün werden West -> Ost
                }, 4000); // Gelbphase Nord -> Süd
            }, 15000); // Grünphase Nord -> Süd
        }, 2000); // Grün werden Nord -> Süd
    }, 4000); // Gelbphase West -> Ost
}