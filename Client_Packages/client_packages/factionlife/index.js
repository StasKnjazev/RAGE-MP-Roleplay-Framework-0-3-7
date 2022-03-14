require('./factionlife/main.js');
require('./factionlife/natives.js');
require('./factionlife/events.js');
require('./factionlife/attach_object.js');
require('./factionlife/zones.js');
require('./factionlife/clientcef/xmr/xmr.js');
require('./factionlife/basicsync.js');

let chatAPI = 1;

let api = {"chat:push": chatAPI.push, "chat:clear": chatAPI.clear, "chat:activate": chatAPI.activate, "chat:show": chatAPI.show}; 

for(let fn in api)
{
    mp.events.add(fn, api[fn]);
}

const localPlayer = mp.players.local;


