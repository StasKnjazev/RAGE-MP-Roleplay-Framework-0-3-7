var speedo = null;
var hud = null;
var sshowed = false;
var hshowed = false;
let player = mp.players.local;

mp.events.add("render", () => {
  if (player.vehicle && player.vehicle.getPedInSeat(-1) === player.handle) {
    if (sshowed === false) {
      speedo = mp.browsers.new(
        "package://factionlife/clientcef/speedometer/CEF/speed.html"
      );
      speedo.execute(`$('.huds').fadeIn()`);
      sshowed = true;
    }

    let vel = player.vehicle.getSpeed() * 3.6;
    let rpm = player.vehicle.rpm * 1000;
    let health = player.vehicle.getHealth();
    let maxHealth = player.vehicle.getMaxHealth();
    let healthPercent = Math.floor((health / maxHealth) * 100);
    let gas = player.vehicle.getVariable("vehicle_fuel");
    // kmS = player.vehicle.getVariable("Kilometer");

    var velo = parseInt(vel, 10);

    speedo.execute(`setProgressSpeed(` + velo + `, '.progress-speed');`);
    speedo.execute(`setProgressFuel(` + gas + `, '.progress-fuel');`);
  } else {
    if (sshowed) {
      speedo.execute("hideSpeedo();");
      sshowed = false;
      setTimeout(function() {
        speedo.destroy();
        speedo = null;
      }, 2000);
    }
  }
});

setInterval(function() {
  _intervalFunction();
}, 1000);

function _intervalFunction() {
  let player = mp.players.local;
  if (player.vehicle && player.vehicle.getPedInSeat(-1) === player.handle) {
    let speed = mp.players.local.vehicle.getSpeed();
    let veh_data = JSON.stringify({ speedofcar: speed });
    mp.events.callRemote("calc_km", (player, veh_data));
  }
}
