const camerasManager = require('./factionlife/camerasManager.js');

let player = mp.players.local;
let playerCamera;
let freeBrowser;
let inEditor = false;

let cameraPosition = {};
let cameraRotation = {};

function updateCamera() {
    camerasManager.setActiveCameraWithInterp(playerCamera, new mp.Vector3(cameraPosition[0], cameraPosition[1], cameraPosition[2]),
        new mp.Vector3(cameraRotation[0], cameraRotation[1], cameraRotation[2]), 500, 0, 0);
}

mp.events.add({
    'startFreemode' : (posx, posy, posz) => {
        cameraPosition[0] = posx;
        cameraPosition[1] = posy;
        cameraPosition[2] = posz;

        cameraRotation[0] = 0.0;
        cameraRotation[1] = 0.0;
        cameraRotation[2] = 0.0;

        playerCamera = camerasManager.createCamera('freeCamera', 'default', new mp.Vector3(posx, posy, posz),
            new mp.Vector3(cameraRotation[0], cameraRotation[1], cameraRotation[2]), 50);
        camerasManager.setActiveCamera(playerCamera, true);

		inEditor = true;
    },
	'stopFreemode' : () => {

        camerasManager.setActiveCamera(playerCamera, false);
        camerasManager.destroyCamera(playerCamera);
		mp.game.cam.renderScriptCams(false, false, 0, true, false);
		inEditor = false;
    },
    'xMenos' : () => {
        cameraPosition[0] = (cameraPosition[0] - 0.5);
        updateCamera();
    },
    'yMenos' : () => {
        cameraPosition[1] = (cameraPosition[1] - 0.5);
        updateCamera();
    },
    'zMenos' : () => {
        cameraPosition[2] = (cameraPosition[2] - 0.5);
        updateCamera();
    },
    'xrMenos' : () => {
        cameraRotation[0] = (cameraRotation[0] - 2.0);
        updateCamera();
    },
    'yrMenos' : () => {
        cameraRotation[1] = (cameraRotation[1] - 2.0);
        updateCamera();
    },
    'zrMenos' : () => {
        cameraRotation[2] = (cameraRotation[2] - 2.0);
        updateCamera();
    },
    'xMais' : () => {
        cameraPosition[0] = (cameraPosition[0] + 0.5);
        updateCamera();
    },
    'yMais' : () => {
        cameraPosition[1] = (cameraPosition[1] + 0.5);
        updateCamera();
    },
    'zMais' : () => {
        cameraPosition[2] = (cameraPosition[2] + 0.5);
        updateCamera();
    },
    'xrMais' : () => {
        cameraRotation[0] = (cameraRotation[0] + 2.0);
        updateCamera();
    },
    'yrMais' : () => {
        cameraRotation[1] = (cameraRotation[1] + 2.0);
        updateCamera();
    },
    'zrMais' : () => {
        cameraRotation[2] = (cameraRotation[2] + 2.0);
        updateCamera();
    },
    'saveFreePos' : () => {
        mp.events.callRemote('saveFreemodePosition', cameraPosition[0], cameraPosition[1], cameraPosition[2], cameraRotation[0], cameraRotation[1], cameraRotation[2]);
    }
});


mp.keys.bind(0x26, false, function () { // UP Arrow
    //y +
	if(inEditor === false) return;
	cameraPosition[1] = (cameraPosition[1] + 0.5);
    updateCamera();
});

mp.keys.bind(0x28, false, function () { // DOWN Arrow
    // y -
	if(inEditor === false) return;
	cameraPosition[1] = (cameraPosition[1] - 0.5);
    updateCamera();
});

mp.keys.bind(0x25, false, function () { // LEFT Arrow
    // x -
	if(inEditor === false) return;
    cameraPosition[0] = (cameraPosition[0] - 0.5);
    updateCamera();
});

mp.keys.bind(0x27, false, function () { // RIGHT Arrow
    // x +
	if(inEditor === false) return;
	cameraPosition[0] = (cameraPosition[0] + 0.5);
    updateCamera();
});

mp.keys.bind(0x68, false, function () { // Numeric UP 8
    // x +
	if(inEditor === false) return;
	cameraRotation[0] = (cameraRotation[0] + 2.0);
    updateCamera();
});

mp.keys.bind(0x62, false, function () { // Numeric DOWN 2
    // x -
	if(inEditor === false) return;
	cameraRotation[0] = (cameraRotation[0] - 2.0);
    updateCamera();
});

mp.keys.bind(0x64, false, function () { // Numeric LEFT 4
    // Y -
	if(inEditor === false) return;
	cameraRotation[1] = (cameraRotation[1] - 2.0);
    updateCamera();
});

mp.keys.bind(0x66, false, function () { // Numeric RIGHT 4
    // Y +
	if(inEditor === false) return;
	cameraRotation[1] = (cameraRotation[1] + 2.0);
    updateCamera();
});

mp.keys.bind(0x67, false, function () { // Numeric 7 UP
    // Z +
	if(inEditor === false) return;
	cameraPosition[2] = (cameraPosition[2] + 0.5);
    updateCamera();
});

mp.keys.bind(0x61, false, function () { // Numeric 1 MENOS
    // Z -
	if(inEditor === false) return;
	cameraPosition[2] = (cameraPosition[2] - 0.5);
    updateCamera();
});

mp.keys.bind(0x69, false, function () { // Numeric 9 UP
    // ZR +
	if(inEditor === false) return;
	cameraRotation[2] = (cameraRotation[2] + 2.0);
    updateCamera();
});

mp.keys.bind(0x63, false, function () { // Numeric 3 MENOS
    // ZR -
	if(inEditor === false) return;
	cameraRotation[2] = (cameraRotation[2] - 2.0);
    updateCamera();
});

mp.keys.bind(0x65, false, function () { // Save
    // ZR -
	if(inEditor === false) return;
	mp.gui.chat.push("Camera: " + cameraPosition[0] + ", " + cameraPosition[1] + ", " + cameraPosition[2] + " - ~c~" + cameraRotation[0] + ", " + cameraRotation[1] + ", " + cameraRotation[2] + " ");
	
	mp.events.callRemote('saveFreemodePosition', cameraPosition[0], cameraPosition[1], cameraPosition[2], cameraRotation[0], cameraRotation[1], cameraRotation[2]);
});