mp.events.delayInitialization = true;

let asyncDone = false;

mp.events.add('packagesLoaded', () =>
{
	mp.events.delayInitialization = true;

	asyncDone = true;
	console.log(`DLC Client Dateien geladen: ${asyncDone}`);
});

global.chatopened = false;
global.isChat = false;
global.logged = 0;
mp.nametags.enabled = false;
mp.game.audio.setAudioFlag("DisableFlightMusic", true);

function callback() {
	console.log("Callback Funktion wird aufgerufen");
	require('factionlife/index.js');
}

setTimeout(callback, 500);

require('factionlife/furniture.js');
require('factionlife/fly.js');
require('factionlife/fly_2.js');
require('factionlife/clientjs/ft/index.js');
require('factionlife/clientjs/scaleform_messages/index.js');
require('factionlife/clientjs/blackout/index.js');
require('factionlife/clientjs/parachute/index.js');
require('factionlife/clientcef/speedometer/index.js');
require('factionlife/clientjs/island/heistisland.js');

const timeOnServer = Math.floor(Date.now() / 1000);

setInterval(function() {
	let time = Math.floor((Math.floor(Date.now() / 1000) - timeOnServer) / 60);
	let text = `${time} Minuten`;
	if (time >= 60) {
		time = Math.floor(time / 60);
		text = `${time} Stunden`;
	}
	mp.discord.update(`Independence`, `Online: ${text}`);
	},
10000);