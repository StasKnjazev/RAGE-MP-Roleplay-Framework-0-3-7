global.chatopened = false;
global.isChat = false;
global.logged = 0;

let phone = undefined,
    apps, closestAtm = false,
    atm_size, atm_robbed, hacking = false,
    carCount = 0,
    carTimer, car_list = [],
    ingameTimer = null,
    incomingCaller = null,
    dialInterval = null,
    phoneNumber = 0,
    phoneContacts = [],
    timeNow = 0;

let phone_menu = false;
phone_msg = false;
phone_app = false;
phone_app_loaded = false;
atm_close = true;


let ringTone = null,
    ringToneCounter = 0;



let cinemaWindow = null;
let cinemaCamera = null;
let cinemaOpen = false;
const cinema_enter = [-1423.4061279296875, -215.29371643066406, 46.500423431396484];
const cinema_exit_here = [-1424.0640869140625, -210.75747680664062, 46.500423431396484, 3.9045610427856445];
const cinema_camera_pos = [-1426.763427734375, -230.83377075195312, 21.399110794067383];
const cinema_camera_lookat = [-1426.56396484375, -258.2504577636719, 21.399110794067383];

const localPlayer = mp.players.local;
var signal1, signal2, signalx;

var screenRes = mp.game.graphics.getScreenActiveResolution(0, 0);


let chat = mp.browsers.new('package://factionlife/clientcef/chat1/index.html');
mp.gui.execute("window.location = 'package://factionlife/clientcef/chat1/index.html'");
//chat.markAsChat();
/*
mp.events.add('chatMessagee', (message) => {
        chat.execute(`insertMessageToChat(${message});`);
    });

    mp.events.add('chatInputInactive', () => {
        chat.execute(`setChatActive(false);`);
    });
	*/

var posX = 1920 * 0.75;
var posY = 1080 * 0.3;

var resolution = mp.game.graphics.getScreenResolution(0, 0);
var duration;
let script_version = "v5.6";

var ui_fuel = 100;
var ui_distance = "";

global.lastCheck = 0;

function numberWithCommas(x) {
    var parts = x.toString().split(".");
    parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    return parts.join(".");
}

var res_X = 1920; //API.getScreenResolutionMaintainRatio().Width;
var res_Y = 1080; //API.getScreenResolutionMaintainRatio().Height;
var text = "";
var road = "";

/* Speed Limiter */
var limitMenu = null;
var limitSpeedItem = null;
var limitToggleItem = null;
var opened_custom = true;

var limitMultiplier = 5;

var vehicleMaxSpeed = {};
var vehicleMaxSpeedEnabled = {};

var blockedModels = [782665360, -1860900134]; // people can't speed limit these vehicles (rhino and insurgent for example)
var blockedCategories = [14, 15, 16]; // people can't speed limit vehicles that belong these categories - https://wiki.gt-mp.net/index.php?title=Vehicle_Classes
//

let jail_time = 0;

/* NativeUI */
const NativeUI = require("factionlife/clientjs/nativeui");
const Menu = NativeUI.Menu;
const UIMenuItem = NativeUI.UIMenuItem;
const UIMenuListItem = NativeUI.UIMenuListItem;
const UIMenuCheckboxItem = NativeUI.UIMenuCheckboxItem;
const BadgeStyle = NativeUI.BadgeStyle;
const Point = NativeUI.Point;
const ItemsCollection = NativeUI.ItemsCollection;
const Color = NativeUI.Color;


const camerasManager = require('./factionlife/camerasManager.js');

var menu_libary = false;
//Menus
var menuMain;
var menuMods = null;
var menuConfirmation;

//isAdminMenu
var isAdminMenu = false;

//Mod index for purchase procedure
var buyModIndex;


var updateTimeoutInMilliseconds = 500;
var lastUpdateTickCount = 0;

function numberWithCommas(x) {
    var parts = x.toString().split(".");
    parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    return parts.join(".");
}

let cashBar = null;
let bankBar = null;

var markers = {};
var blips = {};

class JobHelper {
    static createMarker(name, position, radius) {
        if (markers[name] != null) {
            return;
        }
        var marker = mp.markers.new(28, position, radius, {
            direction: new mp.Vector3(0, 0, 0),
            rotation: new mp.Vector3(0, 0, 0),
            color: [255, 0, 0, 100],
            visible: true,
            dimension: 0
        });
        markers[name] = marker;
        return marker;
    }
    static removeMarker(name) {
        if (markers.length == 0 || markers[name] == null) {
            return;
        }
        markers[name].destroy(); // Needs testing, should replace deleteEntity
        markers[name] = null;
    }
    static createBlip(name, position, color) {
        if (blips[name] != null) {
            return blips[name];
        }
        let blip = mp.blips.new(1, position, {
            name: name,
            color: color,
            shortRange: false,
        });
        blips[name] = blip;
        return blip;
    }
    static removeBlip(name) {
        if (blips.length == 0 || blips[name] === null || blips[name] === undefined) {
            return;
        }
        blips[name].destroy();
        blips[name] = null;
    }
}


class MarkerHelper {
    static createMarker(name, position, radius) {
        if (markers[name] != null) {
            return;
        }
        var marker = mp.markers.new(1, position, radius, {
            direction: new mp.Vector3(0, 0, 0),
            rotation: new mp.Vector3(0, 0, 0),
            color: [255, 0, 0, 100],
            visible: true,
            dimension: 0
        });
        markers[name] = marker;
        return marker;
    }
    static removeMarker(name) {
        if (markers.length == 0 || markers[name] == null) {
            return;
        }
        markers[name].destroy(); // Needs testing, should replace deleteEntity
        markers[name] = null;
    }
}

class BlipHelper {
    static createBlip(name, position, color) {
        if (blips.length != 0 && blips[name] !== undefined && blips[name] !== null) {
            blips[name].destroy();
            blips[name] = null;
        }

        var blip = mp.blips.new(1, position, {
            name: name,
            color: color,

            shortRange: false,
        });
        blips[name] = blip;
        return blip;
    }
    static createBlipExt(name, position, color, size, sprite = 0, shortRange = false, bname = null) {
        if (blips.length != 0 && blips[name] !== undefined && blips[name] !== null) {
            blips[name].destroy();
            blips[name] = null;
        }
        var blip;

        if (bname == null) {
            blip = mp.blips.new(1, position, {
                //name: name,
                color: color,
                scale: size,
                shortRange: false,
            });
        } else {
            blip = mp.blips.new(1, position, {
                name: bname,
                color: color,
                scale: size,
                shortRange: false,
            });
        }

        blips[name] = blip;
        blips[name].setColour(color);
        blips[name].setAsShortRange(shortRange);
        blips[name].setScale(size);
		blips[name].name = name;



        if (sprite != 0) blips[name].setSprite(sprite);
        return blip;
    }

    static removeBlip(name) {
        if (blips.length != 0 && blips[name] !== undefined && blips[name] !== null) {
            blips[name].destroy();
            blips[name] = null;
        }
    }

    static moveBlip(name, position) {
        if (blips[name] == null) {
            return;
        }
        blips[name].setCoords(position);
    }

    static colorBlip(name, color) {
        if (blips[name] == null) {
            return;
        }
        blips[name].setColour(color);
    }

    static SetRoute(name, enabled) {
        if (blips[name] == null) {
            return;
        }
        blips[name].setRoute(enabled);
    }
}

const Natives = {
    IS_RADAR_HIDDEN: "0x157F93B036700462",
    IS_RADAR_ENABLED: "0xAF754F20EB5CD51A",
    SET_TEXT_OUTLINE: "0x2513DFB0FB8400FE"
};

global.uiPlayer_Browsers = undefined;
global.uiGeneralStart_Browsers = undefined;
let uiGlobal_Browsers = undefined;
let uiProgressBar_Browsers = undefined;
let uiVelo_Browsers = undefined;
let uiAkten_Browsers = undefined;
let uiPurge_Browsers = undefined;
let uiPhone_Call_Browsers = undefined;
let uiPhone_SMS_inc_Browsers = undefined;
let uiPhone_SMS_send_Browsers = undefined;
let uiDisplay_Banned_Screen_Browsers = undefined;

let uiDeathScreen = undefined;

let streetName = null;
let zoneName = null;
let isMetric = false;
let minimap = {};
let currentMoney = null;
let currentBank = null;
let currentHunger = 0;
let currentThirsty = 0;
let currentThirsty_text = null;
let currentHunger_text = null;

function updateDirectionText() {
    var camera = mp.cameras.new("gameplay");
    var cameraDirection = camera.getDirection();

    if (0.3 < cameraDirection.x && 0.3 < cameraDirection.y) {
        text = "N";
    } else if (cameraDirection.x < -0.3 && 0.3 < cameraDirection.y) {
        text = "N";
    } else if (0.3 < cameraDirection.x && cameraDirection.y < -0.3) {
        text = "S";
    } else if (cameraDirection.x < -0.3 && cameraDirection.y < -0.3) {
        text = "S";
    } else if (-0.3 < cameraDirection.x && cameraDirection.x < 0.3 && cameraDirection.y < -0.3) {
        text = "S";
    } else if (cameraDirection.x < -0.3 && -0.3 < cameraDirection.y && cameraDirection.y < 0.3) {
        text = "W";
    } else if (0.3 < cameraDirection.x && -0.3 < cameraDirection.y && cameraDirection.y < 0.3) {
        text = "E";
    } else if (-0.3 < cameraDirection.x && cameraDirection.x < 0.3 && cameraDirection.y > 0.3) {
        text = "N";
    }
    camera.destroy(true);
}

function playerEnterVehicleHandler(vehicle, seat) {
    mp.players.local.setHelmet(false);

}
mp.events.add("playerEnterVehicle", playerEnterVehicleHandler);


function updateValues() {
    // only do stuff if radar is enabled and visible
    if (mp.players.local === null || mp.players.local === undefined)
        return;
    mp.game.player.restoreStamina(100);
    if (mp.game.invoke(Natives.IS_RADAR_ENABLED) && !mp.game.invoke(Natives.IS_RADAR_HIDDEN)) {
        isMetric = mp.game.gameplay.getProfileSetting(227) == 1;
        const position = mp.players.local.position;
        let getStreet = mp.game.pathfind.getStreetNameAtCoord(position.x, position.y, position.z, 0, 0);
        zoneName = mp.game.ui.getLabelText(mp.game.zone.getNameOfZone(position.x, position.y, position.z));
        streetName = mp.game.ui.getStreetNameFromHashKey(getStreet.streetName);
        if (getStreet.crossingRoad && getStreet.crossingRoad != getStreet.streetName) streetName += ` / ${mp.game.ui.getStreetNameFromHashKey(getStreet.crossingRoad)}`;
    } else {
        streetName = null;
        zoneName = null;
    }
    updateDirectionText();
}

let DAYNIGHT_TEXT = null;
var newCam = null;

var selectCharacter = camerasManager.createCamera('selectCharacter', 'default', new mp.Vector3(-533.1306, -224.914, 38.64975), new mp.Vector3(-10, 0, 2), 50);
var school_checkpoint = null;
var vehicle_beans = null;

mp.events.add({
    //
    // Chat
    //
    "menu_libary": (toggles) => {
        menu_libary = toggles;
		
		if(toggles === false) mp.events.callRemote('animationMenuVariableOff');
    },


	"Send_ToServer": (message) => {
        mp.events.callRemote('ServerChat', message);
    },
	
    "Send_ToChat": (time, name, text) => {

		if(time === undefined) time = "";
		if(name === undefined) name = "";
		if(text === undefined) text = "";
		
        let args = [name + "<span style='opacity:0; margin-left:-2px;'>a</span>", text];

        mp.gui.chat.push(name + "<span style='opacity:0; margin-left:-2px;'>a</span>" + text);
    },

	"openChat": () => {
        if (global.chatopened) return false;
        toggleChat(true);
        global.chatopened = true;
    },
    "closeChat": () => {
        if (!global.chatopened) return false;
        chat.execute("sendMsg();");

        toggleChat(false);
        global.chatopened = false;
    },
	"forceCloseChat": () => {
        if (!global.chatopened) return false;
        toggleChat(false);
        global.chatopened = false;
    },
    "getPreviousMessage": () => {
        if (!global.chatopened) return false;

        chat.execute("previous();");
    },
    "getNextMessage": () => {
        if (!global.chatopened) return false;

        chat.execute("next();");
    },
	
    "CreateRaceCheckpoint": (position, direction) => {

        school_checkpoint = mp.checkpoints.new(0, position, 6.0, {
            direction: direction,
            color: [247, 221, 52, 150],
            visible: true,
            dimension: 0
        });

        BlipHelper.createBlipExt("race_checkpoint", position, 81, 1.0, 0, false);
        BlipHelper.createBlipExt("race_checkpoint_2", direction, 81, 0.5, 0, false);
        BlipHelper.colorBlip("race_checkpoint", 81);
        BlipHelper.colorBlip("race_checkpoint_2", 81);

    },

    "DeleteRaceCheckpoint": () => {
        if (school_checkpoint != null) {
            school_checkpoint.destroy();
            school_checkpoint = null;
        }

        BlipHelper.removeBlip("race_checkpoint");
        BlipHelper.removeBlip("race_checkpoint_2");
    },

    "marker_create": (name, position, radius) => {
        MarkerHelper.createMarker(name, position, radius);
    },

    "delete_marker": (name) => {
        MarkerHelper.removeMarker(name);
    },

    "KEY_ARROW_UP": () => {
        if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || menu_libary === true || new Date().getTime() - lastCheck < 100) return;

        mp.events.callRemote('keypress:ARROW_UP');
    },

    "blip_create": (name, position, color) => {
        BlipHelper.createBlip(name, position, color);
    },

    "blip_create_ext": (name, position, color, size, sprite = 0, range = false, bname = null) => {
        BlipHelper.createBlipExt(name, position, color, size, sprite, range, bname);
        BlipHelper.colorBlip(name, color);
    },

    "blip_remove": (name) => {
        BlipHelper.removeBlip(name);
    },

    "blip_move": (name, position) => {
        BlipHelper.moveBlip(name, position);
    },

    "blip_color": (name, color) => {
        BlipHelper.colorBlip(name, color);
    },

    "blip_router_visible": (name, enabled) => {
        BlipHelper.SetRoute(name, enabled);
    },

    "gps_set_loc": (nearestX, nearestY) => {
        mp.game.ui.setNewWaypoint(nearestX, nearestY);
    },

    "show_radar": () => {
        mp.game.ui.displayRadar(true);
    },

    "hide_radar": () => {
        mp.game.ui.displayRadar(false);
    },

    "UI:DisplayRadar": (enable) => {
        mp.game.ui.displayRadar(true);
    },

    "job_create_marker": (name, position) => {
        var jobName = name;
        var vector = position;
        JobHelper.createMarker(jobName, vector, 1);
    },

    "job_create_blipped_marker": (name, jPosition) => {
        var jobName = name;
        var vector = jPosition;
        JobHelper.createMarker(jobName, vector, 1);
        JobHelper.createBlip(jobName, vector, 1);
    },

    "create_house_blip": (name, hPosition) => {
        var houseName = name;
        var position = hPosition;
        var blip = mp.blips.new(40, position, {
            name: houseName,
            color: 2,
            shortRange: true,
        });
        blips[houseName] = blip;
    },

    "create_garage_blip": (name, hPosition) => {
        var houseName = name;
        var position = hPosition;
        var blip = mp.blips.new(50, position, {
            name: houseName,
            color: 31,
            shortRange: true,
        });
        blips[houseName] = blip;
    },

    "create_faction_house_blip": (name, hPosition) => {
        var houseName = name;
        var position = hPosition;
        var blip = mp.blips.new(40, position, {
            name: houseName,
            color: 31,
            shortRange: true,
        });
    },

    "create_rent_blip": (name, hPosition) => {
        var houseName = name;
        var position = hPosition;
        var blip = mp.blips.new(40, position, {
            name: houseName,
            color: 28,
            shortRange: true,
        });
        blips[houseName] = blip;
    },

    "job_remove_marker": (name) => {
        var jobName = name;
        JobHelper.removeMarker(jobName);
        JobHelper.removeBlip(jobName);
    },

    "job_create_pickup": (jId, jPosition, jRadius) => {
        var id = jId;
        var position = jPosition;
        var radius = jRadius;
        JobHelper.createBlip(jId, jPosition, 0);
        JobHelper.createMarker(jId, jPosition, jRadius);
    },

    "job_create_pickup": () => {
        if (blips.length == 0 && markers.length == 0)
            return;
        for (var key in blips) {
            JobHelper.removeBlip(key);
        }
        for (var key in markers) {
            JobHelper.removeMarker(key);
        }
    },

    "job_remove_pickup": (jName) => {
        var name = jName;
        JobHelper.removeBlip(jName);
        JobHelper.removeMarker(jName);
    },

    "job_create_blip": (jName, jPosition, jColor) => {
        var name = jName;
        var position = jPosition;
        var color = jColor;
        JobHelper.createBlip(jName, jPosition, parseInt(jColor));
    },

    "job_remove_blip": (jName) => {
        var name = jName;
        JobHelper.removeBlip(jName);
    },

    "get_waypoint_pos": () => {
        var pos = getWaypointPos();

        setTimeout(() => {
            pos.z = mp.game.gameplay.getGroundZFor3dCoord(pos.x, pos.y, 9999, 9999, false);
            mp.events.callRemote('OnPlayerCreateWaypoint', pos.x, pos.y, pos.z);
        }, 1500);
    },

    "cef_show_name_creater": () => {
        mp.events.call('destroyBrowser');
        mp.events.call('createBrowser', ['package://factionlife/clientcef/player/dialog.html']);
    },

    "onSubmitGeneric": (string) => {
        onSubmitGeneric(string);
    },

    "reset_camera": () => {
        mp.game.cam.renderScriptCams(false, false, 0, true, false);
        if (newCam != null) newCam.setActive(false);
    },

    "play_sound": (soundName, soundSetName) => {
        if (soundName === null || soundSetName === null) return;
        mp.game.audio.playSoundFrontend(-1, soundName, soundSetName, true);
    },

    "createCustomCamera": (cameraOne, cameraTwo) => {
        /*newCam = mp.cameras.new('default', cameraOne, cameraTwo, 90);
        //newCam.pointAtCoord(new mp.Vector3(118.1804, -495.8049, 196.8651));
        newCam.setActive(true);
		mp.game.cam.renderScriptCams(true, false, 0, true, false);*/
    },

    "DestroyCamera": () => {
        mp.game.cam.renderScriptCams(false, false, 0, true, false);
        newCam.setActive(false);
    },

    "JailTime": (time) => {
        jail_time = time;
    },
    //
    "logged": () => {
        logged = 1;
        mp.players.local.setHelmet(false);

        mp.gui.chat.activate(true);
        mp.gui.chat.show(true);

        camerasManager.destroyCamera(selectCharacter);
        camerasManager.setActiveCamera(selectCharacter, false);
        mp.game.cam.renderScriptCams(false, false, 0, true, false);

    },
	
	"showChat": () => {

        mp.gui.chat.activate(true);
        mp.gui.chat.show(true);
    },
	
    "TimeOfDay": (time_text) => {
        DAYNIGHT_TEXT = time_text;
		 if (uiVelo_Browsers != undefined) {
            uiVelo_Browsers.execute("SetPlayerTime('" + time_text + "')");
        }
		
        if (phone != undefined) {
            phone.execute("UpdateTime('" + time_text + "');");
        }
    },

   "SetPlayerWanted": (wanted) => {
        if (uiVelo_Browsers != undefined) {
            uiVelo_Browsers.execute("SetPlayerWanted(" + wanted + ")");
        }
    },
	
    "update_money_display": (money, bank) => {
        currentMoney = money;
        currentBank = bank;

        if (uiVelo_Browsers != undefined) {
            uiVelo_Browsers.execute("SetPlayerMoney('" + currentMoney + "', '" + currentBank + "')");
        }

        mp.game.invoke('0x96DEC8D5430208B7', false);
    },
	
    "update_credits": (credits) => {
        if (uiVelo_Browsers != undefined) {
            uiVelo_Browsers.execute("SetPlayerCredits('" + credits + "')");
        }
    },


    "update_hunger_display": (hunger, thirsty) => {
        currentHunger = hunger;
        currentThirsty = thirsty;

        if (uiPlayer_Browsers != undefined) {
            uiPlayer_Browsers.execute("SetPlayerHungerThirsty(" + currentHunger + ", " + currentThirsty + ")");
        }
    },

    "update_health": (health) => {
        if (uiPlayer_Browsers != undefined) {
            uiPlayer_Browsers.execute("SetPlayerHealth(" + health + ")");
        }
    },

    "update_armor": (armor) => {
        if (uiPlayer_Browsers != undefined) {
            uiPlayer_Browsers.execute("SetPlayerArmor(" + armor + ")");
        }
    },

    "show_player_hud": (ui_enable) => {

        if (ui_enable === true) {
            if (uiPlayer_Browsers === undefined) {
                uiPlayer_Browsers = mp.browsers.new("package://factionlife/clientcef/overlay/index.html");
            }

            if (uiVelo_Browsers === undefined) {
                uiVelo_Browsers = mp.browsers.new("package://factionlife/clientcef/overlay/money.html");
            }

            uiPlayer_Browsers.execute("SetPlayerHungerThirsty(" + currentHunger + ", " + currentThirsty + ")");
            uiVelo_Browsers.execute("SetPlayerMoney(" + currentMoney + ", " + currentBank + ")");

        } else {
            if (uiPlayer_Browsers != undefined) {
                uiPlayer_Browsers.Destroy();
                uiPlayer_Browsers = undefined;
            }
            if (uiVelo_Browsers != undefined) {
                uiVelo_Browsers.Destroy();
                uiVelo_Browsers = undefined;
            }
        }
    },

    "displaySubtitle": (message_text, time) => {

        mp.game.ui.setTextEntry2("STRING");
        mp.game.ui.addTextComponentItemString(message_text);
        mp.game.ui.drawSubtitleTimed(time, 1);
    },

    "DisplayCustomCamera": (position, target, fov = 60) => {
        newCam = mp.cameras.new('default', position, target, fov);
        newCam.setCoord(position);
        newCam.pointAtCoord(target);
        newCam.setFov(fov);

        newCam.setActive(true);
        mp.game.cam.renderScriptCams(true, false, 0, true, false);
    },

    "DestroyCustomCamera": () => {
        mp.game.cam.renderScriptCams(false, false, 0, true, false);
        newCam.setActive(false);
    },

    "playAnimation": (dict, state, flag) => {
        mp.events.callRemote('PlayAnimationFromMenu', dict, state, flag);
    },

    "stopAnimation": () => {
        mp.events.callRemote('StopAnimationFromMenu');
    },

    "closeAnimationMenu": () => {
        mp.events.call('Destroy_Character_Menu');
        mp.events.callRemote('closeAnimationMenu');

    },
    "setAnimationShortcut": (e, category, t) => {
        mp.gui.chat.push('setAnimationShortcut(' + e + ', ' + category + ', ' + t + ')');
    },

    "Display_Animation": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/animation/animation.html");
        }

        mp.gui.cursor.visible = true;
    },

    "InjuredSystem": (time) => {
		/*if (uiDeathScreen != undefined) {
            uiDeathScreen.destroy();
			uiDeathScreen = undefined;
        }
		
        if (uiDeathScreen === undefined) {
            uiDeathScreen = mp.browsers.new("package://factionlife/clientcef/deathscreen/deathscreen.html");
        }

        uiDeathScreen.execute("updateBrowser('" + time + "');");*/
		mp.game.graphics.startScreenEffect("DeathFailMPIn", 0, true);
		mp.game.cam.setCamEffect(1);

    },
	
	"InjuredSystem:Destroy": () => {
		mp.game.graphics.stopScreenEffect("DeathFailMPIn");
		mp.game.cam.setCamEffect(0);
    },
	
    "InjuredSystem:Respawn": () => {
        if (uiDeathScreen != undefined) {
            uiDeathScreen.destroy();
			uiDeathScreen = undefined;
        }
		
		mp.events.callRemote("InjuredSystemHospital", 3 * 60);
    },
	
    "Display_Release_Vehicles": (vehicle_list) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/vehicles/vehicle_release.html");
        }

        uiGlobal_Browsers.execute("LoadPlayerVehiclesToRelease('" + vehicle_list + "');");
        mp.gui.cursor.visible = true;
    },

    "Player_Vehicle_Release": (index, price) => {
        mp.events.callRemote("PayInsure", index, price);
    },
	
	"LoadBannedlist": (data) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/banlist/banlist_manage.html");
        }

        uiGlobal_Browsers.execute("LoadBannedlist('" + data + "');");
        mp.gui.cursor.visible = true;
    },

    "Player_Bannedlist_Aprove": (index) => {
        mp.events.callRemote("Player_Bannedlist_Aprove", index);
    },

    "Player_Bannedlist_Remove": (index) => {
        mp.events.callRemote("Player_Bannedlist_Remove", index);
    },		
	
	"LoadWhiteList": (data) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/whitelist/whitelist_manage.html");
        }

        uiGlobal_Browsers.execute("LoadWhiteList('" + data + "');");
        mp.gui.cursor.visible = true;
    },

    "Display_Player_Vehicles": (vehicle_list) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/vehicles/vehicle_list.html");
        }

        uiGlobal_Browsers.execute("LoadPlayerVehicles('" + vehicle_list + "');");
        mp.gui.cursor.visible = true;
    },

    "Player_Whitelist_Aprove": (index) => {
        mp.events.callRemote("Player_Whitelist_Aprove", index);
    },

    "Player_Whitelist_Remove": (index) => {
        mp.events.callRemote("Player_Whitelist_Remove", index);
    },
	
    "Player_Vehicle_Track": (index) => {
        mp.events.callRemote("TrackVehicle", index);
    },

    "Player_Vehicle_Destroy": (index) => {
        mp.events.callRemote("DeleteVehicle", index);
    },

    "Display_Vehicle_Dealership_Player": (name, vehicle_list) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/vehicles/vehicle_buy.html");
        }

        uiGlobal_Browsers.execute("LoadVehiclesToDealership('" + name + "', '" + vehicle_list + "');");
        mp.gui.cursor.visible = true;
    },

    "Business_Buy_Vehicle": (vehicle, color) => {
        mp.events.callRemote("BuyVehicle_FromDealership", vehicle, color);
    },
    "Business_View_Vehicle": (vehicle, color) => {
        mp.events.callRemote("View_Vehicle", vehicle);
    },
    "Business_View_Vehicle_Color": (color) => {
        mp.events.callRemote("View_Vehicle_Color", color);
    },

    "Display_Whitelist_Screen": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/player/whitelist.html");
        }

    },
	
    "Display_DealerShip_Manage": (name, type, safe, vehicles_stock, vehicles_list) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/vehicles/dealership.html");
        }

        uiGlobal_Browsers.execute("LoadBusinessManageMenu('" + name + "', '" + type + "', " + safe + ", '" + vehicles_stock + "', '" + vehicles_list + "');");
        mp.gui.cursor.visible = true;
    },


    "Business_Change_Name": (new_name) => {
        mp.events.callRemote("Business_Change_Name", new_name);
    },

    "Business_Depositar_Fundos": (value) => {
        mp.events.callRemote("Business_Depositar_Fundos", value);
    },

    "Business_Retirar_Fundos": (value) => {
        mp.events.callRemote("Business_Retirar_Fundos", value);
    },

    "Business_Buy_Vehicle_Stock": (name, stock, price) => {
        mp.events.callRemote("vehicle_to_business", name, stock, price);
    },

    "Business_Save_Vehicle": (name, price, visibility) => {
        mp.events.callRemote("vehicle_save_business", name, price, visibility);
    },


    "Preview_Clothes": (category, index) => {
        mp.events.callRemote("Preview_Clothes", category, index);
    },

    "Buy_Clothes": (category, index) => {
        mp.events.callRemote("Buy_Clothes", category, index);
    },

    "Clothes_Menu_Destroy": () => {
        mp.events.callRemote("Clothes_Menu_Destroy");
    },


    "Update_Player_Clothes": () => {
        mp.events.callRemote("Update_Player_Clothes");
    },

    "Display_Clothes": (arr_shirts, arr_moletons, arr_pants, arr_shoes, arr_hats, arr_glasses) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/clothes/clothes.html");
        }


        uiGlobal_Browsers.execute("LoadClothes('" + arr_shirts + "', '" + arr_moletons + "', '" + arr_pants + "', '" + arr_shoes + "', '" + arr_hats + "', '" + arr_glasses + "');");
        mp.gui.cursor.visible = true;
    },

    "Display_Barber": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/clothes/barber.html");
        }

        mp.gui.cursor.visible = true;
    },

    "ClientOnRangeChangeBarber": (id, val) => {
        mp.events.callRemote("ClientOnRangeChangeBarber", id, val);
    },

    "Barber_Menu_Destroy": () => {
        mp.events.callRemote("Barber_Menu_Destroy");
    },

    "BuyBarber": (type) => {
        mp.events.callRemote("BuyBarber", type);
    },

    "Barber_Update_Character": () => {
        mp.events.callRemote("Barber_Update_Character");
    },

    "notify": (type, layout, msg, time) => {
		if (uiPhone_SMS_inc_Browsers === undefined) {
            uiPhone_SMS_inc_Browsers = mp.browsers.new("package://factionlife/clientcef/overlay/msg.html");
        }
		mp.gui.cursor.visible = false;
	    uiPhone_SMS_inc_Browsers.execute(`notify(${type},${layout},'${msg}',${time})`);
		mp.events.callRemote('notify', type, layout, msg, time);
    },

    "Display_MDC": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/factions/faction_police.html");
        }

        //uiGlobal_Browsers.execute("LoadBusinessManageMenu('"+name+"', '"+type+"', "+safe+", '"+vehicles_stock+"', '"+vehicles_list+"');");
        mp.gui.cursor.visible = true;
    },

    "mdc_checar_player": (name) => {
        mp.events.callRemote("mdc_checar_player", name);
    },

    "mdc_print_suspect": (name) => {
        mp.events.callRemote("mdc_print_suspect", name);
    },

    "mdc_print_prison": (name) => {
        mp.events.callRemote("mdc_print_prison", name);
    },

    "mdc_track_wanted": (name) => {
        mp.events.callRemote("mdc_track_wanted", name);
    },

    "mdc_response_player": (data) => {

        if (uiGlobal_Browsers === undefined) {
            return;
        }

        uiGlobal_Browsers.execute("CheckPlayer('" + data + "');");
    },

    "mdc_checar_vehicle": (name) => {
        mp.events.callRemote("mdc_checar_vehicle", name);
    },

    "mdc_response_vehicle": (data) => {

        if (uiGlobal_Browsers === undefined) {
            return;
        }

        uiGlobal_Browsers.execute("CheckVehicle('" + data + "');");
    },

    "mdc_warrant_list": () => {
        mp.events.callRemote("mdc_warrant_list");
    },


    "mdc_response_warrants": (data) => {

        if (uiGlobal_Browsers === undefined) {
            return;
        }

        uiGlobal_Browsers.execute("CheckWantedList('" + data + "');");
    },

    //
    "mdc_911_list": () => {
        mp.events.callRemote("mdc_911_list");
    },
    "mdc_911_accept": (index) => {
        mp.events.callRemote("mdc_911_accept", index);
    },
    "mdc_911_refuse": (index) => {
        mp.events.callRemote("mdc_911_refuse", index);
    },
    "mdc_response_911list": (data) => {

        if (uiGlobal_Browsers === undefined) {
            return;
        }

        uiGlobal_Browsers.execute("Check911List('" + data + "');");
    },

    "VPN_Blocker_Enable_Viewer": (arr_player, arr_store) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/anticheat/vpnblocked.html");
        }
        mp.gui.cursor.visible = false;
    },

    "Display_LSPD_Akten": (arr_player, arr_store) => {
        if (uiAkten_Browsers === undefined) {
            uiAkten_Browsers = mp.browsers.new("package://factionlife/clientcef/factions/LSPD/lspd.html");
        }
        mp.gui.cursor.visible = true;
    },

    "Destroy_Display_LSPD_Akten": () => {
        if (uiAkten_Browsers != undefined) {
            uiAkten_Browsers.destroy();
            uiAkten_Browsers = undefined;
        }
        mp.gui.cursor.visible = false;
    },	

    "Display_LSFD_Akten": (arr_player, arr_store) => {
        if (uiAkten_Browsers === undefined) {
            uiAkten_Browsers = mp.browsers.new("package://factionlife/clientcef/factions/LSFD/lsfd.html");
        }
        mp.gui.cursor.visible = true;
    },

    "Destroy_Display_LSFD_Akten": () => {
        if (uiAkten_Browsers != undefined) {
            uiAkten_Browsers.destroy();
            uiAkten_Browsers = undefined;
        }
        mp.gui.cursor.visible = false;
    },	

    "Display_DOJ_Akten": (arr_player, arr_store) => {
        if (uiAkten_Browsers === undefined) {
            uiAkten_Browsers = mp.browsers.new("package://factionlife/clientcef/factions/DOJ/doj.html");
        }
        mp.gui.cursor.visible = true;
    },

    "Destroy_Display_DOJ_Akten": () => {
        if (uiAkten_Browsers != undefined) {
            uiAkten_Browsers.destroy();
            uiAkten_Browsers = undefined;
        }
        mp.gui.cursor.visible = false;
    },	

    "Destroy_Purge_Banned_Player": () => {
        if (uiPurge_Browsers != undefined) {
            uiPurge_Browsers.destroy();
            uiPurge_Browsers = undefined;
        }
        mp.gui.cursor.visible = false;
    },

    "Purge_Banned_Player": (arr_player, arr_store) => {
        if (uiPurge_Browsers === undefined) {
            uiPurge_Browsers = mp.browsers.new("package://factionlife/clientcef/purge/purge.html");
        }
        mp.gui.cursor.visible = false;
    },

    "Destroy_Phone_Call_inc": () => {
        if (uiPhone_Call_Browsers != undefined) {
            uiPhone_Call_Browsers.destroy();
            uiPhone_Call_Browsers = undefined;
        }
    },

    "Phone_Call_inc": (arr_player, arr_store) => {
        if (uiPhone_Call_Browsers === undefined) {
            uiPhone_Call_Browsers = mp.browsers.new("package://factionlife/clientcef/phone/call.html");
        }
		mp.gui.cursor.visible = false;
    },	
	
    "Destroy_Phone_SMS_inc": () => {
        if (uiPhone_SMS_inc_Browsers != undefined) {
            uiPhone_SMS_inc_Browsers.destroy();
            uiPhone_SMS_inc_Browsers = undefined;
        }
    },
	
    "Display_Banned_Screen": (arr_player, arr_store) => {
        if (uiDisplay_Banned_Screen_Browsers === undefined) {
            uiDisplay_Banned_Screen_Browsers = mp.browsers.new("package://factionlife/clientcef/ban/banscreen.html");
        }
		mp.gui.cursor.visible = false;
    },	

    "Phone_SMS_inc": (arr_player, arr_store) => {
        if (uiPhone_SMS_inc_Browsers === undefined) {
            uiPhone_SMS_inc_Browsers = mp.browsers.new("package://factionlife/clientcef/phone/sms_inc.html");
        }
		mp.gui.cursor.visible = false;
    },	

    "Destroy_Phone_SMS_send": () => {
        if (uiPhone_SMS_send_Browsers != undefined) {
            uiPhone_SMS_send_Browsers.destroy();
            uiPhone_SMS_send_Browsers = undefined;
        }
    },

    "Phone_SMS_send": (arr_player, arr_store) => {
        if (uiPhone_SMS_send_Browsers === undefined) {
            uiPhone_SMS_send_Browsers = mp.browsers.new("package://factionlife/clientcef/phone/sms_send.html");
        }
		mp.gui.cursor.visible = false;
    },	
	
    "Destroy_Vehicle_Alarm_Player": () => {
        if (uiGlobal_Browsers != undefined) {
            uiGlobal_Browsers.destroy();
            uiGlobal_Browsers = undefined;
        }
        mp.gui.cursor.visible = false;
    },	

    "Vehicle_Alarm_Player": (arr_player, arr_store) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/alarm/alarm.html");
        }
        mp.gui.cursor.visible = false;
    },

    "Display_Credit_Store": (arr_player, arr_store) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/tablet/tablet.html");
        }
        uiGlobal_Browsers.execute("Load_VIP_Data('" + arr_player + "', '" + arr_store + "');");
        mp.gui.cursor.visible = true;
    },
    "Buy_Item_From_Credit_Store": (index) => {
        mp.events.callRemote("BuyItemFromCreditStore", index);
    },

    "Display_Characters": (character_data) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/player/charselect.html");
        }
        camerasManager.setActiveCamera(selectCharacter, true);
        camerasManager.setActiveCameraWithInterp(selectCharacter, new mp.Vector3(-533.1306, -222.414, 38.14975), new mp.Vector3(-10, 0, 2), 8000, 0, 0);

        uiGlobal_Browsers.execute("LoadCharacters('" + character_data + "');");
        mp.gui.cursor.visible = true;
    },

    "Destroy_Character_Menu": () => {
        if (uiGlobal_Browsers != undefined) {
            uiGlobal_Browsers.destroy();
            uiGlobal_Browsers = undefined;
        }
        mp.gui.cursor.visible = false;
		
        mp.events.callRemote('Inventory_Close');
        mp.events.callRemote('closeVehicleInventory');
        //mp.events.callRemote('View_Vehicle_Destroy');
    },

    "SelectCharacter": (character_id) => {
        mp.events.callRemote('SelectCharacter', character_id);
    },

    "ClientPreviewCharacterID": (character_id) => {
        mp.events.callRemote('ClientPreviewCharacterID', character_id);
    },

    "CreateCharacter": () => {
        mp.events.callRemote('CreateCharacter');
    },

    "Show_Char_Creator": (character_data) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/player/charcreator.html");
        }

        uiGlobal_Browsers.execute("LoadNewCharacter('" + character_data + "');");
        mp.gui.cursor.visible = true;

        localPlayer.taskPlayAnim("amb@world_human_guard_patrol@male@base", "base", 8.0, 1, -1, 1, 0.0, false, false, false);
    },

    "Show_Char_Creator_2": (character_data) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/player/charcreator_2.html");
        }

        uiGlobal_Browsers.execute("LoadFaceFeatures('" + character_data + "');");
        mp.gui.cursor.visible = true;
    },

    "Show_Char_Creator_3": (character_data) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/player/charcreator_3.html");
        }

        uiGlobal_Browsers.execute("LoadClothing('" + character_data + "');");
        mp.gui.cursor.visible = true;
    },

    "ClientCharCreationBack": () => {
        // Character selection
        mp.events.callRemote('ClientCharCreationBack');
    },

    "ClientCharCreationNext": (first_name, second_name) => {
        mp.events.callRemote('Display_Creator_part2', first_name, second_name);
    },

    "ClientCharCreation2Back": () => {
        mp.events.callRemote('Display_Creator_part1');
    },

    "ClientCharCreation2Next": () => {
        mp.events.callRemote('Display_Creator_part3');
    },

    "ClientCharCreation3Back": () => {
        mp.events.callRemote('ClientCharCreation3Back');
    },

    "ClientOnRangeChange": (id, val) => {
        mp.events.callRemote('ClientOnRangeChange', id, val);
    },
    "ClientSetFaceFeature": (id, val) => {
        mp.events.callRemote('ClientSetFaceFeature', id, val);
    },
    "ClientSetTraje": (id) => {
        mp.events.callRemote('ClientSetTraje', id);
    },
    "cameraPointTo": (id) => {
        mp.events.callRemote('cameraPointTo', id);
    },
    "ClientCharCreation3Next": () => {
        mp.events.callRemote('ClientCharCreation3Next');
    },


    "Display_Player_Help": (jobid, leaderid, grouptype, rankid) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/ucp/ucp.html");
        }
        uiGlobal_Browsers.execute("LoadDataToHelp(" + jobid + ", " + leaderid + ", " + grouptype + ", " + rankid + ");");
        mp.gui.cursor.visible = true;
    },
	
    "Display_Player_Job": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/help/job.html");
        }

        mp.gui.cursor.visible = true;
    },
	  "Get_Job": (id) => {
        mp.events.callRemote('Get_Job', id);
    },

    //
    // First
    //
    "ShowModal": (callback_id, title, text, bottom_confirm, bottom_cancel) => {

        if (uiPlayer_Browsers != undefined) {
            uiPlayer_Browsers.execute("ShowModal('" + callback_id + "', '" + title + "', '" + text + "', '" + bottom_confirm + "', '" + bottom_cancel + "')");
            mp.gui.cursor.visible = true;
        }
    },

    "modalConfirm": (response_callback) => {
        mp.events.callRemote('modalConfirm', response_callback);
        mp.gui.cursor.visible = false;
    },

    "modalCancel": (response_callback) => {
        mp.events.callRemote('modalCancel', response_callback);
        mp.gui.cursor.visible = false;
    },

    //

    "Display_Calls": (name, arrjson) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/dispatch/dispatch.html");
        }

        uiGlobal_Browsers.execute("LoadCalls('" + name + "', '" + arrjson + "');");
        mp.gui.cursor.visible = true;
    },

    "Service_Track": (id) => {
        mp.events.callRemote("Service_Track_Server", id);
    },

    "Service_Remove": (id) => {
        mp.events.callRemote("Service_Remove_Server", id);
    },

	"Display_House_Storage": (inv, storage, weight, limit, vehicle_weight, vehicle_limit) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/inventory/inventory_house.html");
        }
        var xitems = [];
        var xstorage = [];

        xitems = inv.replace(/'/g, "\\'");
        xstorage = storage.replace(/'/g, "\\'");


        uiGlobal_Browsers.execute("updateBrowser('" + xitems + "', '" + xstorage + "', " + weight + ", " + limit + ", " + vehicle_weight + ", " + vehicle_limit + ");");
        mp.gui.cursor.visible = true;
    },
	
    "House_Storage_Give_Item": (item_type, amount) => {
        mp.events.callRemote("House_Storage_Give_Item", item_type, amount);
    },

    "House_Storage_Take_Item": (item_type, amount) => {
        mp.events.callRemote("House_Storage_Take_Item", item_type, amount);
    },
	
	"Display_HQ_Storage": (inv, storage, weight, limit, vehicle_weight, vehicle_limit) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/inventory/inventory_HQ.html");
        }
        var xitems = [];
        var xstorage = [];

        xitems = inv.replace(/'/g, "\\'");
        xstorage = storage.replace(/'/g, "\\'");


        uiGlobal_Browsers.execute("updateBrowser('" + xitems + "', '" + xstorage + "', " + weight + ", " + limit + ", " + vehicle_weight + ", " + vehicle_limit + ");");
        mp.gui.cursor.visible = true;
    },

    "HQ_Storage_Give_Item": (item_type, amount) => {
        mp.events.callRemote("HQ_Storage_Give_Item", item_type, amount);
    },

    "HQ_Storage_Take_Item": (item_type, amount) => {
        mp.events.callRemote("HQ_Storage_Take_Item", item_type, amount);
    },

    "Display_Player_List": (player_list, online, max) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/scoreboard/Scoreboard.html");
        }

        uiGlobal_Browsers.execute("LoadPlayers('" + player_list + "', " + online + ", " + max + ");");
        mp.gui.cursor.visible = true;
    },

    "Display_Player_Storage": (inv, storage, weight, limit, vehicle_weight, vehicle_limit) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/inventory/inventory_vehicle.html");
        }
        var xitems = [];
        var xstorage = [];

        xitems = inv.replace(/'/g, "\\'");
        xstorage = storage.replace(/'/g, "\\'");


        uiGlobal_Browsers.execute("updateBrowser('" + xitems + "', '" + xstorage + "', " + weight + ", " + limit + ", " + vehicle_weight + ", " + vehicle_limit + ");");
        mp.gui.cursor.visible = true;
    },

    "Storage_Give_Item": (item_type, amount) => {
        mp.events.callRemote("Storage_Give_Item", item_type, amount);
    },

    "Storage_Take_Item": (item_type, amount) => {
        mp.events.callRemote("Storage_Take_Item", item_type, amount);
    },

    "Display_Player_Inventory": (items, character_money, limit, weight) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://factionlife/clientcef/inventory/inventory.html");
        }

        uiGlobal_Browsers.execute("updateBrowser('" + items + "', '"+ null+"', '"+ 0+"', '"+ null+"', '"+ false+"', '"+ null+"', '"+ false+"', '"+ null+"', '"+ 0+"', '"+ character_money+"', '"+ limit +"', '"+ weight +"');");
        mp.gui.cursor.visible = true;
    },

    "InventoryService:ToggleClothing": (type) => {
        mp.events.callRemote("InventoryService:ToggleClothing", type);
    },
	
    "Client_ItemAction": (item, action, amount) => {
        mp.events.callRemote("OnClientItemAction", item, action, amount);
    },

    "Client_ItemAction_Drop": (item, amount) => {
        mp.events.callRemote("JogarItem", item, amount);
    },

    "handle_seatbelt": (toggled) => {
        mp.game.invoke("SET_PED_CONFIG_FLAG", mp.players.local, 32, toggled);
    },

    "SetProgressBar": (value, name) => {

        if (uiProgressBar_Browsers === undefined) {
            uiProgressBar_Browsers = mp.browsers.new("package://factionlife/clientcef/progressbar/progressbar.html");
        }

        uiProgressBar_Browsers.execute("setStatus('" + value + "', '100', '" + name + "')");

    },

    "DestroyProgressBar": () => {
        if (uiProgressBar_Browsers != undefined) {
            uiProgressBar_Browsers.destroy();
            uiProgressBar_Browsers = undefined;
        }
    },

    "uiGeneralInput": (callbackId, title, placeHolder, description, type) => {

        if (uiGeneralStart_Browsers === undefined) {
            uiGeneralStart_Browsers = mp.browsers.new("package://factionlife/clientcef/player/input.html");
        } else {
            uiGeneralStart_Browsers.destroy();
            uiGeneralStart_Browsers = undefined;
            uiGeneralStart_Browsers = mp.browsers.new("package://factionlife/clientcef/player/input.html");
        }

        uiGeneralStart_Browsers.execute("DisplayDialogFunction('" + callbackId + "', '" + title + "', '" + placeHolder + "', '" + description + "', '" + type + "')");
        mp.gui.cursor.visible = true;

    },

    "death_screen_false": () => {
        mp.game.ui.displayHud(true);
        mp.game.gameplay.setFadeOutAfterDeath(false);
        mp.game.gameplay.disableAutomaticRespawn(true);
    },

    "speed_limiter": () => {
        if (mp.players.local.isInVehicle() && mp.players.local.seat == -1) {
            var model = mp.players.local.vehicle.getModel();

            if (mp.players.local.isInVehicle() && mp.players.local.seat == -1) {
                var model = mp.players.local.vehicle.getModel();
                if (IsModelBlocked(model)) {
                    mp.game.graphics.notify("~r~Can't use Speed Limiter on this vehicle!");
                    return;
                }

                if (limitMenu == null || limitMenu == null) {
                    // first time
                    limitMenu = new Menu("Speed Limiter", "Model: ~b~" + mp.game.vehicle.getDisplayNameFromVehicleModel(model), 0, 0, 6);

                    var limits = [];
                    limits.push("No Limit");
                    for (var i = limitMultiplier; i <= 120; i += limitMultiplier) limits.push(i.toString());

                    limitSpeedItem = new UIMenuListItem("Limit", "Adjusts the speed limit.", new ItemsCollection(limits), 0);
                    limitMenu.AddItem(limitSpeedItem);

                    limitToggleItem = new UIMenuCheckboxItem("Active", "Toggles the speed limit.", (vehicleMaxSpeedEnabled[model] !== null) ? vehicleMaxSpeedEnabled[model] : false);
                    limitMenu.AddItem(limitToggleItem);

                    limitSpeedItem.ListChange.on(function(sender, new_index) {
                        var vehicle = mp.players.local.vehicle;

                        SetVehicleMaxSpeed(vehicle, (new_index == 0) ? (mp.game.vehicle.getVehicleModelMaxSpeed(mp.players.local.vehicle.model) * 3.6) : parseInt(limitSpeedItem.IndexToItem(new_index)));
                        SetVehicleLimiterStatus(vehicle, GetVehicleLimiterStatus(vehicle));
                    });

                    limitToggleItem.CheckboxEvent.connect(function(sender, is_checked) {
                        SetVehicleLimiterStatus(mp.players.local.vehicle, is_checked);

                    });

                    limitMenu.RefreshIndex();
                    limitMenu.Visible = true;
                } else {
                    // update the menu
                    limitMenu.RefreshIndex();
                    limitMenu.Visible = !limitMenu.Visible;

                    if (limitMenu.Visible) {
                        //API.setMenuSubtitle(limitMenu, "Model: ~b~" + API.getVehicleDisplayName(model));

                        var index = 0;
                        if (vehicleMaxSpeed[model] !== null) {
                            for (var i = limitMultiplier; i <= 120; i += limitMultiplier) {
                                if (i == vehicleMaxSpeed[model]) {
                                    index = (i / limitMultiplier);
                                    return;
                                }
                            }
                        }

                        limitSpeedItem.Index = index;
                        limitToggleItem.Checked = GetVehicleLimiterStatus(mp.players.local.vehicle);
                    }
                }
            }
        }
    },

    "speed_limiter_command": (args) => {
        var vehicle = mp.players.local.vehicle;
        var speed = parseInt(args);
        if (isNaN(speed)) {
            if (args == "off") {
                SetVehicleLimiterStatus(vehicle, false)
                //mp.game.graphics.notify("~y~Cruise Control ~r~Desligador!~n~~n~~w~Limitador de Velocidade: ~r~desligado.");
            }
        } else {
            SetVehicleMaxSpeed(vehicle, speed);
            SetVehicleLimiterStatus(vehicle, true)
            //mp.game.graphics.notify("~y~Cruise Control ~g~Ligado!~n~~n~~w~Limitador de Velocidade: ~b~" + speed + "~w~.");
        }
    },

    "VehicleModdingCalled": (price, bool) => {
        mapModToIndex = initModMap();
        mapModToPrice = initModToPrice(price);
        isAdminMenu = bool;

        menuConfirmation = createPurchConfirmMenu();
        createMainMenuVehMod();
        openMainMenuVehMod();
    },

});

mp.events.add('client_input_response', (response, inputtext) => {

    uiGeneralStart_Browsers.destroy();
    uiGeneralStart_Browsers = undefined;
    mp.events.callRemote('uiInput_response', response, inputtext);
    mp.gui.cursor.visible = false;
});

mp.events.add('client_input_destroy', (response) => {
    mp.events.callRemote('uiInput_destroy', response);
    uiGeneralStart_Browsers.destroy();
    uiGeneralStart_Browsers = undefined;
    mp.gui.cursor.visible = false;
});



let freezeMe = false;
let freezeVehicle = false;

mp.events.add("freeze", (bool) => {
    //freezeMe = bool;
    mp.players.local.freezePosition(bool);
});

mp.events.add("freezeEx", (bool) => {
    freezeMe = bool;
});

mp.events.add("freezeVehicle", (bool) => {
    //freezeMe = bool;
    freezeVehicle = bool;
});

var displayMessage = null;

mp.events.add("displayMessage", (string) => {
    //freezeMe = bool;
    displayMessage = string;
});

var bottomText = null;
var bottomTextTime = -1;
var bottomTextInterval = null;

mp.events.add("showBottomText", (message, time = 5000) => {
    bottomText = message;
    bottomTextTime = time;
    bottomTextInterval = setInterval(() => {
        if (bottomTextTime == 0 || bottomTextTime < 0) {
            clearInterval(bottomTextInterval);
            bottomTextInterval = null;
            return bottomTextTime = -1
        }
        bottomTextTime -= 1000;
    }, 1000);
});

const drawText = (text, position, options) => {
    options = {
        ...{
            align: 1,
            font: 4,
            scale: 0.3,
            outline: true,
            shadow: true,
            color: [255, 255, 255, 255]
        },
        ...options
    };

    const ui = mp.game.ui;
    const font = options.font;
    const scale = options.scale;
    const outline = options.outline;
    const shadow = options.shadow;
    const color = options.color;
    const wordWrap = options.wordWrap;
    const align = options.align;

    ui.setTextEntry("CELL_EMAIL_BCON");
    for (let i = 0; i < text.length; i += 99) {
        const subStringText = text.substr(i, Math.min(99, text.length - i));
        mp.game.ui.addTextComponentSubstringPlayerName(subStringText);
    }

    ui.setTextFont(font);
    ui.setTextScale(scale, scale);
    ui.setTextColour(color[0], color[1], color[2], color[3]);

    if (shadow) {
        mp.game.invoke(Natives.SET_TEXT_DROP_SHADOW);
        ui.setTextDropshadow(2, 0, 0, 0, 255);
    }

    if (outline) {
        mp.game.invoke("0x2513DFB0FB8400FE");
    }

    switch (align) {
        case 1:
            {
                ui.setTextCentre(true);
                break;
            }
        case 2:
            {
                ui.setTextRightJustify(true);
                ui.setTextWrap(0.0, position[0] || 0);
                break;
            }
    }

    if (wordWrap) {
        ui.setTextWrap(0.0, (position[0] || 0) + wordWrap);
    }

    ui.drawText(position[0] || 0, position[1] || 0);
}

let turf_name = "";

mp.events.add("CurrentTurf", (name) => {
    turf_name = name;
});

let scoreboard_turf = "";
mp.events.add("Display_turfScoreBoard", (name) => {
    scoreboard_turf = name;
});

var iteration = 0;
var atmHashes = [-1126237515, -1364697528, 506770882, -870868698];
var ATMTrackedBlips = [];
var ATMTrackedBlipHashes = [];
var ATMTrackedPositions = [];

function calculateDist(vec1, vec2) {
    return Math.sqrt((vec1.X - vec2.X) * (vec1.X - vec2.X) + (vec1.Y - vec2.Y) * (vec1.Y - vec2.Y) + (vec1.Z - vec2.Z) * (vec1.Z - vec2.Z));
}

function doesVectorExist(list, vec) {
    for (var i = 0; i < list.length; i++) {
        if (list[i] === vec)
            return true;
        if (vec.X < list[i].X + 0.25 && vec.X > list[i].X - 0.25) {
            if (vec.Y < list[i].Y + 0.25 && vec.Y > list[i].Y - 0.25) {
                if (vec.Z < list[i].Z + 0.25 && vec.Z > list[i].Z - 0.25)
                    return true;
            }
        }
    }
    return false;
}

function listContains(list, key) {
    for (var i = 0; i < list.length; i++) {
        if (list[i] === key)
            return true;
    }
    return false;
}

let isTaxiFare = false;
let isCustomer = false;
let currentToPay = 0;
let currentFare = 0;

mp.events.add("update_taxi_fare", (arg1, arg2, arg3, arg4) => {

    isTaxiFare = arg1;
    currentFare = arg2;
    currentToPay = arg3;
    isCustomer = arg4;

});

//var taxiFare = "Fare charge";
let taxiFare = "Cobrança da Tarifa";
let taxiFareInfo = "Cobrado cada 10/s";
let dollar = "$";

let taxiCustomer = "Cliente";
let taxiCustomerInfo = "Pago";
let taxiCustomerAsk = "Você pagará";

const maxDistance = 25 * 25;
const width = 1.03;
const height = 1.0065;
const border = 0.001;
var lasthealth = 100;
var color = [255, 255, 255, 255];
mp.nametags.enabled = false;

mp.events.add("vehicleDistance", (amount) => {
    ui_distance = amount;
});

const scalable = (dist, maxDist) => {
    return Math.max(0.1, 1 - (dist / maxDist));
}
const clamp = (min, max, value) => {
    return Math.min(Math.max(min, value), max);
};

var falando = false;

var res = false;

function DisableControl(...args) {
    if (args.length == 0) return false;
    args[0].forEach((control) => {
        mp.game.controls.disableControlAction(0, control, args[1]);
    });
}

let turf_active = 0,
    turf_war_name = "",
    turf_time_left = 0,
    turf_attack_name = "",
    turf_attack_kills = 0,
    turf_attack_points = 0,
    turf_defend_name = "",
    turf_defend_kills = 0,
    turf_defend_points = 0;

mp.events.add('UpdateTurfScoreBoard', (name, time, att_name, att_kills, att_points, defend_name, defend_kills, defend_points) => {
    turf_active = 1;

    turf_war_name = name;
    turf_time_left = time;

    turf_attack_name = att_name;
    turf_attack_kills = att_kills;
    turf_attack_points = att_points;

    turf_defend_name = defend_name;
    turf_defend_kills = defend_kills;
    turf_defend_points = defend_points;
});

mp.events.add('HideTurfScoreBoard', () => {
    turf_active = 0;
});
mp.events.add('vehicleFuel', (intFuel) => {
    ui_fuel = intFuel;
});

let timeNow_2 = Date.now();

var isInSafeZone = false;
mp.events.add('playerWeaponShot', (targetPosition, targetEntity) => {
    if (targetEntity && targetEntity.type == "player") {
        mp.events.callRemote("DamageSystem_ShotPlayerAtHealth", targetEntity, targetEntity.getHealth());
    }
});

var tsBrowser = null;

mp.events.add('ConnectTeamspeak', (status) => {
    if (status) {
        tsBrowser = mp.browsers.new('');
        setTimeout(function () {
            refresh = true;
            mp.game.audio.playSoundFrontend(-1, 'Hack_Success', 'DLC_HEIST_BIOLAB_PREP_HACKING_SOUNDS', true);
        }, 500);
    } else {
        if (tsBrowser !== null) {
            tsBrowser.destroy();
            tsBrowser = null;
        }
        mp.game.audio.playSoundFrontend(-1, 'Hack_Failed', 'DLC_HEIST_BIOLAB_PREP_HACKING_SOUNDS', true);
    }
});


var entity = null;
var nearestObject = null;

var res_2 = mp.game.graphics.getScreenActiveResolution(1, 1);

function getLookingAtEntity() {
    let startPosition = localPlayer.getBoneCoords(12844, 0.5, 0, 0);
    let secondPoint = mp.game.graphics.screen2dToWorld3d([res_2.x / 2, res_2.y / 2, (2 | 4 | 8)]);
    if (secondPoint == undefined) return null;

    startPosition.z -= 0.3;
    const result = mp.raycasting.testPointToPoint(startPosition, secondPoint, localPlayer, (2 | 4 | 8 | 16));
	

    if (typeof result !== 'undefined') {
        if (typeof result.entity.type === 'undefined') {return null; }
        if (result.entity.type == 'object' && result.entity.getVariable('TYPE') == undefined) { return null; }
		
        let entPos = result.entity.position;
        let lPos = localPlayer.position;
        if (mp.game.gameplay.getDistanceBetweenCoords(entPos.x, entPos.y, entPos.z, lPos.x, lPos.y, lPos.z, true) > 4) return null;
        return result.entity;
    }
    return null;
}

function getNearestObjects() {

    var tempO = null;
    var objects = mp.objects.toArray();
    objects.forEach(
        (object) => {
            var posL = localPlayer.position;
            var posO = object.position;
            var distance = mp.game.gameplay.getDistanceBetweenCoords(posL.x, posL.y, posL.z, posO.x, posO.y, posO.z, true);
            if (object.getVariable('TYPE') != undefined && localPlayer.dimension === object.dimension && distance < 3) {
                if (tempO === null) tempO = object;
                else if (mp.game.gameplay.getDistanceBetweenCoords(posL.x, posL.y, posL.z, posO.x, posO.y, posO.z, true) <
                    mp.game.gameplay.getDistanceBetweenCoords(posL.x, posL.y, posL.z, tempO.position.x, tempO.position.y, tempO.position.z, true))
                    tempO = object;
            }
        });
    nearestObject = tempO;
}

const width_x = 0.03; // Ширина
const height_x = 0.0050; // Высота
const border_x = 0.001; // Обвока

mp.events.add('render', (nametags) => {
    try {
		
        if (mp.players.local === null || mp.players.local === undefined)
            return;

		mp.game.controls.disableControlAction(2, 243, true);
			 
        if (!res) {
            resolution = mp.game.graphics.getScreenResolution(0, 0);
            if (resolution.x < 1920) {
                res_X = resolution.x;
                res_Y = resolution.y;
            }
            res = true;
        }

        var player = mp.players.local;
        if (mp.players.local === undefined || mp.players.local === null)
            return;
        var inVeh = player.isInVehicle();

        const graphics = mp.game.graphics;
        const screenRes = graphics.getScreenResolution(0, 0);

        if (lasthealth - player.getHealth() >= 5) {
            mp.events.callRemote("OnPlayerHealthChange", lasthealth - player.getHealth());
        }
        lasthealth = player.getHealth();


        if (chatopened && uiGlobal_Browsers != undefined && uiGeneralStart_Browsers != undefined && mp.gui.cursor.visible) {
            mp.game.controls.disableControlAction(2, 199, true);

        }

        if (mp.gui.cursor.visible == true && !chatopened) {
            mp.game.controls.enableControlAction(2, 249, true);
        }

        mp.game.player.setHealthRechargeMultiplier(0.0);
        mp.game.player.restoreStamina(100);

        if (logged != 0) {

            if (mp.players.local.hasBeenDamagedByAnyPed()) {
                mp.players.forEachInStreamRange((player, id) => {
                    if (player != mp.players.local) {
                        if (mp.players.local.hasBeenDamagedBy(player.handle, true)) {
                            mp.events.callRemote("DamageSystem_OnDamagedByPed", player, mp.players.local.getLastDamageBone(0));
                            mp.players.local.clearLastDamage();
                            return;
                        }
                    }
                });
                mp.players.local.clearLastDamage();
            }
			
			
            if (global.chatopened) {
                //DisableControl([0,16,17,21,22,23,24,25,26,28,29,30,31,32,33,34,35,37,44,45,50,53,54,55,58,68,69,70,71,75,79,86,91,140,141,142,199,257,278,279,280,281], true);
                mp.game.controls.disableAllControlActions(2);

                mp.game.controls.enableControlAction(2, 1, true);
                mp.game.controls.enableControlAction(2, 2, true);
                mp.game.controls.enableControlAction(2, 3, true);
                mp.game.controls.enableControlAction(2, 4, true);
                mp.game.controls.enableControlAction(2, 5, true);
                mp.game.controls.enableControlAction(2, 6, true);
                mp.game.controls.enableControlAction(2, 249, true);
                mp.game.controls.enableControlAction(2, 286, true);
                mp.game.controls.enableControlAction(2, 287, true);
                mp.game.controls.enableControlAction(2, 290, true);
                mp.game.controls.enableControlAction(2, 291, true);
                mp.game.controls.enableControlAction(2, 292, true);
                mp.game.controls.enableControlAction(2, 293, true);
                mp.game.controls.enableControlAction(2, 294, true);
                mp.game.controls.enableControlAction(2, 295, true);
                mp.game.controls.enableControlAction(2, 270, true);
                mp.game.controls.enableControlAction(2, 271, true);
                mp.game.controls.enableControlAction(2, 272, true);
                mp.game.controls.enableControlAction(2, 273, true);
                mp.game.controls.enableControlAction(2, 329, true);
                mp.game.controls.enableControlAction(2, 330, true);
            }
			
			 if (mp.keys.isDown(17) === true) {
				CTRL = true;
			} else {
				CTRL = false;
			}
           
        }

        nametags.forEach(nametag => {
            let [player, x, y, distance] = nametag;
            var isVisible = true;
            if (player.getVariable('nametag_visible') != null)
                isVisible = player.getVariable('nametag_visible');
            if (isVisible && logged) {
                //mp.gui.chat.push("Printing nametag " + nametag + " for player " + player.name);
                if (distance <= maxDistance) {

                    let scale = 1 - (distance / maxDistance);
                    let diff = Math.abs(scale * 100) / 100;
                    if (scale < 0.4) {
                        scale = 0.4;
                    } else if (scale > 0.7) scale = 0.7;

                    y += 0.02 * scale;


                    let scaleX = ((32 / screenRes.x) * 1.8) * scale;
                    let scaleY = ((32 / screenRes.y) * 1.8) * scale;


                    var health = player.getHealth();
                    health = health < 100 ? 0 : ((health - 100) / 100);
                    var color2 = color;
                    if (player.getVariable('nametag_color') != null) {
                        color2 = player.getVariable('nametag_color');
                        /*var r = color2[0];
                        var g = color2[1];
                        var b = color2[2];
                        var a = color2[3];*/
                        if (color2 == "red")
                            color = [255, 0, 0, 255];
                        else if (color2 == "white")
                            color = [255, 255, 255, 255];
                    }
                }
            }
        })

        if (freezeMe) {
            mp.game.controls.disableAllControlActions(2);

            mp.game.controls.enableControlAction(2, 1, true);
            mp.game.controls.enableControlAction(2, 2, true);
            mp.game.controls.enableControlAction(2, 3, true);
            mp.game.controls.enableControlAction(2, 4, true);
            mp.game.controls.enableControlAction(2, 5, true);
            mp.game.controls.enableControlAction(2, 6, true);
            mp.game.controls.enableControlAction(2, 249, true);
            mp.game.controls.enableControlAction(2, 286, true);
            mp.game.controls.enableControlAction(2, 287, true);
            mp.game.controls.enableControlAction(2, 290, true);
            mp.game.controls.enableControlAction(2, 291, true);
            mp.game.controls.enableControlAction(2, 292, true);
            mp.game.controls.enableControlAction(2, 293, true);
            mp.game.controls.enableControlAction(2, 294, true);
            mp.game.controls.enableControlAction(2, 295, true);
            mp.game.controls.enableControlAction(2, 270, true);
            mp.game.controls.enableControlAction(2, 271, true);
            mp.game.controls.enableControlAction(2, 272, true);
            mp.game.controls.enableControlAction(2, 273, true);
            mp.game.controls.enableControlAction(2, 329, true);
            mp.game.controls.enableControlAction(2, 330, true);
			
			mp.game.controls.disableControlAction(2, 71, true);
			mp.game.controls.disableControlAction(2, 72, true);
        }

        if (bottomTextTime != -1) {
            mp.game.ui.setTextFont(7);
            mp.game.ui.setTextEntry2("STRING");
            mp.game.ui.addTextComponentSubstringPlayerName(bottomText);
            mp.game.ui.drawSubtitleTimed(1, true);
        }


        if (logged) {

            if (!localPlayer.isInAnyVehicle(false) && !localPlayer.isDead()) {
                entity = getLookingAtEntity();
				//getNearestObjects();
				
            } else {
                entity = null;
            }

            if (entity != null) {
                mp.game.graphics.drawText("~h~~w~- ~b~M~w~ -", [entity.position.x, entity.position.y, entity.position.z], {
                    font: 4,
                    color: [255, 255, 255, 185],
                    scale: [0.4, 0.4],
                    outline: true
                });

            }
				
            if (freezeVehicle) {
                mp.game.controls.disableControlAction(2, 71, true);
                mp.game.controls.disableControlAction(2, 72, true);
           
            }

            if (mp.game.invoke(getNative('IS_CUTSCENE_ACTIVE'))) {
                mp.game.invoke(getNative('STOP_CUTSCENE_IMMEDIATELY'))
            }

            if (mp.game.invoke(getNative('GET_RANDOM_EVENT_FLAG'))) {
                mp.game.invoke(getNative('SET_RANDOM_EVENT_FLAG'), false);
            }

            if (mp.game.invoke(getNative('GET_MISSION_FLAG'))) {
                mp.game.invoke(getNative('SET_MISSION_FLAG'), false);
            }

            mp.game.ui.hideHudComponentThisFrame(6);
            mp.game.ui.hideHudComponentThisFrame(7);
            mp.game.ui.hideHudComponentThisFrame(8);
            mp.game.ui.hideHudComponentThisFrame(9);

             var currentTimeInMilliseconds = new Date().getTime();

             if (currentTimeInMilliseconds - lastUpdateTickCount > updateTimeoutInMilliseconds) {
                 lastUpdateTickCount = currentTimeInMilliseconds;
                 updateValues();
             }

		drawText(" |    |", [235 / res_X, (res_Y - 50) / res_Y], {
			font: 6,
			color: [180, 180, 180, 230],
			scale: 1.0,
			outline: true,
			align: 0,
			shadow: false
		});
		
		drawText(""+text+"", [255.4 / res_X, (res_Y - 46) / res_Y], {
			font: 6,
			color: [180, 180, 180, 230],
			scale: 0.7,
			outline: true,
			align: 0,
			shadow: false
		});
		
		drawText("~y~"+zoneName+"", [288 / res_X, (res_Y - 43.7) / res_Y], {
			font: 4,
			color: [180, 180, 180, 230],
			scale: 0.3,
			outline: true,
			align: 0,
			shadow: false
		});
		
		drawText(""+streetName+"", [288 / res_X, (res_Y - 28.5) / res_Y], {
			font: 4,
			color: [180, 180, 180, 230],
			scale: 0.3,
			outline: true,
			align: 0,
			shadow: false
		});
		
			           mp.game.graphics.drawLightWithRange(1137, -1542, 48, 255, 255, 255, 25, 1);
                    mp.game.graphics.drawLightWithRange(1140, -1578, 41, 255, 255, 255, 25, 1);
                    mp.game.graphics.drawLightWithRange(-1019, -2797, 29, 255, 255, 255, 40, 0.8);
                    mp.game.graphics.drawLightWithRange(-1055.307, -2806.795, 22.5, 255, 255, 255, 40, 0.8);
                    mp.game.graphics.drawLightWithRange(-1067.206, -2799.9325, 22.5, 255, 255, 255, 40, 0.8);
                    mp.game.graphics.drawLightWithRange(-1056, -2786, 25, 255, 255, 255, 40, 0.8);
                    mp.game.graphics.drawLightWithRange(-1090, -2781, 25, 255, 255, 255, 40, 1);
					
            if (scoreboard_turf != "") {
                drawText(scoreboard_turf, [120 / res_X, (res_Y - 248) / res_Y], {
                    font: 0,
                    color: [255, 255, 255, 188],
                    scale: 0.35,
                    outline: true,
                    align: 1,
                    shadow: true
                });
            }

            var color = [255, 255, 255, 150];

            if (mp.players.local.getVariable("Injured") > 0) 
			{
				if (mp.players.local.getVariable("Injured") == 1) 
				{
					if (mp.players.local.getVariable("InjuredTime") > 0) {
						mp.game.graphics.drawText("~w~Sie werden ins Krankenhaus geschickt in:~b~ "+ mp.players.local.getVariable("InjuredTime").toString() + " Sekunden", [(res_X / 2) / res_X, (res_Y - 102) / res_Y], {
							font: 4,
							color: [255, 255, 255, 220 - 20],
							scale: [0.54, 0.54],
							outline: true,
							shadow: true,
							centre: false
						});



					}
					else
					{
							mp.game.graphics.drawText("~w~Benutzen Sie nun ~b~ [~y~ O ~b~] ~w~ öffnen, um ins Krankenhaus zu kommen", [(res_X / 2) / res_X, (res_Y - 102) / res_Y], {
							font: 4,
							color: [255, 255, 255, 220 - 20],
							scale: [0.54, 0.54],
							outline: true,
							shadow: true,
							centre: false
						});
					}
					
											
						mp.game.graphics.drawText("~c~((~w~ Unter 912 kannst du Hilfe herbei rufen. ~c~))", [(res_X / 2) / res_X, (res_Y - 75) / res_Y], {
							font: 4,
							color: [255, 255, 255, 220 - 20],
							scale: [0.45, 0.45],
							outline: true,
							shadow: true,
							centre: false
						});
                }
				
                if (mp.players.local.getVariable("Injured") == 2) 
				{
					if (mp.players.local.getVariable("InjuredTime") > 0) {
							
						mp.game.graphics.drawText("~w~Sie werden geheilt in: ~b~ "+ mp.players.local.getVariable("InjuredTime").toString() + " Sekunden", [(res_X / 2) / res_X, (res_Y - 102) / res_Y], {
							font: 4,
							color: [255, 255, 255, 220 - 20],
							scale: [0.5, 0.5],
							outline: true,
							shadow: true,
							centre: false
						});
					}
                }
            }

            if (jail_time > 0) {
                mp.game.graphics.drawText("~w~Sie werden freigelassen in: ~b~ "+ jail_time.toString() + " Sekunden", [(res_X / 2) / res_X, (res_Y - 102) / res_Y], {
					font: 4,
					color: [255, 255, 255, 220 - 20],
					scale: [0.5, 0.5],
					outline: true,
					shadow: true,
					centre: false
				});
            }

            mp.game.graphics.drawText(mp.players.local.getVariable("SubTitle"), [(res_X / 2) / res_X, (res_Y - 120) / res_Y], {
                font: 0,
                color: [255, 255, 255, 210],
                scale: [0.42, 0.42],
                outline: false,
                centre: false
            });




            if (isTaxiFare && localPlayer.isInAnyVehicle(true)) {
                drawText(taxiFare, [(res_X - 10) / res_X, 0.60 - 0.31], {
                    scale: 0.6,
                    color: [115, 186, 131, 255],
                    font: 4,
                    align: 2,
                    shadow: false,
                    outline: true
                });

                drawText(taxiFareInfo, [(res_X - 10) / res_X, 0.64 - 0.31], {
                    scale: 0.4,
                    color: [255, 255, 255, 255],
                    font: 4,
                    align: 2,
                    shadow: false,
                    outline: true
                });

                drawText(dollar + `${currentFare}`, [(res_X - 10) / res_X, 0.667 - 0.31], {
                    scale: 0.7,
                    color: [255, 255, 255, 255],
                    font: 4,
                    align: 2,
                    shadow: false,
                    outline: true
                });

                drawText(taxiCustomer, [(res_X - 10) / res_X, 0.740 - 0.31], {
                    scale: 0.6,
                    color: [115, 186, 131, 255],
                    font: 4,
                    align: 2,
                    shadow: false,
                    outline: true
                });

                if (isCustomer == true) {
                    drawText(taxiCustomerAsk, [(res_X - 10) / res_X, 0.784 - 0.31], {
                        scale: 0.4,
                        color: [255, 255, 255, 255],
                        font: 4,
                        align: 2,
                        shadow: false,
                        outline: true
                    });
                } else {
                    drawText(taxiCustomerInfo, [(res_X - 10) / res_X, 0.784 - 0.31], {
                        scale: 0.4,
                        color: [255, 255, 255, 255],
                        font: 4,
                        align: 2,
                        shadow: false,
                        outline: true
                    });
                }

                drawText(dollar + `${currentToPay}`, [(res_X - 10) / res_X, 0.808 - 0.31], {
                    scale: 0.7,
                    color: [255, 255, 255, 255],
                    font: 4,
                    align: 2,
                    shadow: false,
                    outline: true
                });
            }
        }
    } catch (e) {
        //mp.game.graphics.notify('RE:' + e.toString());
    }
});



const drawSprite = (dist, name, scale, heading, colour, x, y, layer) => {
    const graphics = mp.game.graphics,
        resolution = graphics.getScreenActiveResolution(0, 0),
        textureResolution = graphics.getTextureResolution(dist, name),
        SCALE = [(scale[0] * textureResolution.x) / resolution.x, (scale[1] * textureResolution.y) / resolution.y]

    if (graphics.hasStreamedTextureDictLoaded(dist) === 1) {
        if (typeof layer === 'number') {
            graphics.set2dLayer(layer);
        }

        graphics.drawSprite(dist, name, x, y, SCALE[0], SCALE[1], heading, colour[0], colour[1], colour[2], colour[3]);
    } else {
        graphics.requestStreamedTextureDict(dist, true);
    }
}

function distanceBetweenVectors(vec1, vec2) {
    return Math.sqrt((vec1.X - vec2.X) * (vec1.X - vec2.X) + (vec1.Y - vec2.Y) * (vec1.Y - vec2.Y) + (vec1.Z - vec2.Z) * (vec1.Z - vec2.Z));
}

var CTRL = false;

var onSubmitGeneric = function(string) {
    mp.events.call('destroyBrowser');
    mp.events.callRemote('new_character_name', string);

};

let velocimer_ui = false;

setInterval(() => {
    if (mp.players.local === null || mp.players.local === undefined || logged === 0) return;

    let player = mp.players.local;
    if (player.isSittingInAnyVehicle()) {
        let vehicle = mp.players.local.vehicle;

		if(player.handle == vehicle.getPedInSeat(-1))
		{
			if (uiPlayer_Browsers != undefined) {
				if (velocimer_ui == false) {
					uiPlayer_Browsers.execute('EnableSpeedo(true);');
					velocimer_ui = true;
				}


				let rpm = vehicle.getIsEngineRunning() ? vehicle.rpm * 10000 : 0;
				rpm = rpm * (rpm / 12000);
				let gear = vehicle.gear;
				let displaySpeed = Math.round(3.6 * vehicle.getSpeed());


				uiPlayer_Browsers.execute('UpdateSpeed(' + displaySpeed + ', ' + gear + ', ' + rpm+ ', ' + ui_fuel + ');');
			}
		}

    } else {
        if (velocimer_ui == true && uiPlayer_Browsers != undefined) {
            velocimer_ui = false;
            uiPlayer_Browsers.execute('EnableSpeedo(false);');

        }
    }
	
	if(cinemaWindow != null)
	{
		if(mp.gui.cursor.visible == false)
		{
			if(mp.game.ui.isPauseMenuActive() == false)
			{
				mp.gui.cursor.show(true, true);
			}
		}
	}
}, 200);


mp.events.add("updateRankBar", (currentRankLimit, nextRankLimit, playersPreviousXP, playersCurrentXP, rank) => {
    if (!mp.game.graphics.hasHudScaleformLoaded(19)) {
        mp.game.graphics.requestHudScaleform(19);
        while (!mp.game.graphics.hasHudScaleformLoaded(19)) mp.game.wait(0);
    }

    mp.game.graphics.pushScaleformMovieFunctionFromHudComponent(19, "SET_COLOUR");
    mp.game.graphics.pushScaleformMovieFunctionParameterInt(116); //Active bar color
    mp.game.graphics.pushScaleformMovieFunctionParameterInt(123); //Background bar color
    mp.game.graphics.popScaleformMovieFunctionVoid();

    mp.game.graphics.pushScaleformMovieFunctionFromHudComponent(19, "SET_RANK_SCORES");
    mp.game.graphics.pushScaleformMovieFunctionParameterInt(currentRankLimit); //current rank limit
    mp.game.graphics.pushScaleformMovieFunctionParameterInt(nextRankLimit); //next rank limit
    mp.game.graphics.pushScaleformMovieFunctionParameterInt(playersPreviousXP); //players previous xp
    mp.game.graphics.pushScaleformMovieFunctionParameterInt(playersCurrentXP); //players current xp
    mp.game.graphics.pushScaleformMovieFunctionParameterInt(rank); //rank
    mp.game.graphics.popScaleformMovieFunctionVoid();

    mp.game.graphics.pushScaleformMovieFunctionFromHudComponent(19, "OVERRIDE_ANIMATION_SPEED");
    mp.game.graphics.pushScaleformMovieFunctionParameterInt(2000);
    mp.game.graphics.popScaleformMovieFunctionVoid();
});

// Key CODE's from https://docs.microsoft.com/en-us/windows/desktop/inputdev/virtual-key-codes
// 0x71 is the F2 key code

mp.events.add('Show_Cursor', () => {
    mp.gui.cursor.visible = true;
    cursor_status = true;
});

var cursor_status = false;
mp.keys.bind(0x71, true, function() {

    if (cursor_status == false) {
        mp.gui.cursor.visible = true;
        cursor_status = true;
    } else {
        cursor_status = false;
        mp.gui.cursor.visible = false;
    }
    //mp.gui.chat.push('F2 key is pressed. This message will be shown until you release the key, because "keyhold" is true.');
});


mp.keys.bind(0x0D, true, (player) => { // If Chat was triggered
	
    mp.events.call('closeChat');
});

mp.keys.bind(0x1B, true, (player) => { // If Chat was triggered
    mp.events.call('forceCloseChat');
});

mp.keys.bind(0x26, true, (player) => { // If Chat was triggered3
	if(chatopened == false) return;
    mp.events.call('getPreviousMessage');
});

mp.keys.bind(0x28, true, (player) => { // If Chat was triggered
	if(chatopened == false) return;
    mp.events.call('getNextMessage');
});


mp.keys.bind(0x54, true, (player) => { // If Chat was triggered
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || new Date().getTime() - lastCheck < 100) return;
	toggleChat(true);
    chatopened = true;
});


function toggleChat(toggle) {
    global.chatopened = toggle;
    global.isChat = toggle;
    mp.events.callRemote('enableChatInput', toggle);
    chat.execute("enableChatInput('" + toggle + "');");
    mp.gui.cursor.visible = toggle;
}



mp.keys.bind(0x30, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;

	if(CTRL === false)
	{
		mp.events.callRemote('StopAnimationFromMenu');
	}
	else mp.events.callRemote('keypress:0');

});
mp.keys.bind(0x31, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || CTRL === false || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:1');

});

mp.keys.bind(0x26, true, (player) => { // If Chat was triggered3

	if(chatopened === false) mp.events.call('KEY_ARROW_UP');
});


mp.keys.bind(0x32, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || CTRL === false || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:2');

});
mp.keys.bind(0x33, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || CTRL === false || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:3');

});
mp.keys.bind(0x34, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || CTRL === false || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:4');

});
mp.keys.bind(0x35, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || CTRL === false || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:5');

});
mp.keys.bind(0x36, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || CTRL === false || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:6');

});
mp.keys.bind(0x37, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || CTRL === false || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:7');

});
mp.keys.bind(0x38, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || CTRL === false || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:8');

});
mp.keys.bind(0x39, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || CTRL === false || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:9');

});


mp.keys.bind(0x72, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    mp.events.callRemote('keypress:F1'); // Calling server event "keypress:F2"
    //mp.gui.chat.push('F2 key is pressed. This message will be shown until you release the key, because "keyhold" is true.');
});

mp.keys.bind(0x73, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    mp.events.callRemote('keypress:F4');
});

mp.keys.bind(0x74, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    mp.events.callRemote('KeyPress:F5');
    lastCheck = new Date().getTime();
});

mp.keys.bind(0x75, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    mp.events.callRemote('KeyPress:F6');
    lastCheck = new Date().getTime();
});

mp.keys.bind(0x76, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    mp.events.callRemote('KeyPress:F7');
    lastCheck = new Date().getTime();
});

// 0x59 is the Y key code
mp.keys.bind(0x59, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:Y');
    lastCheck = new Date().getTime();

});

// 0x49 is the O key code
mp.keys.bind(0x4F, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:O');
    lastCheck = new Date().getTime();
});

// 0x49 is the O key code
mp.keys.bind(0x55, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:U');
    lastCheck = new Date().getTime();
});

// 0x49 is the I key code
mp.keys.bind(0x49, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:I');
    lastCheck = new Date().getTime();
});

// 0x48 is the H key code
mp.keys.bind(0x48, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:H');
    lastCheck = new Date().getTime();
});

// 0x4B is the K key code
mp.keys.bind(0x4B, true, function() {
	if(menu_libary === true)
	{
		mp.events.callRemote('DisplayInfoAnimationShot');
	}
	else
	{
		if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || new Date().getTime() - lastCheck < 100) return;
		mp.events.callRemote('keypress:K');
		lastCheck = new Date().getTime();
	}
});

// 0x45 is the E key code
mp.keys.bind(0x45, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    mp.events.callRemote('keypress:E');
    lastCheck = new Date().getTime();
});

// 0x4D is the M key code
mp.keys.bind(0x4D, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    
	
	if(entity != null)
	{
		if(entity.type == 'player')
		{
			mp.events.callRemote('Display_InteractPlayer_Menu', entity);
		}
		else if(entity.type == 'vehicle')
		{
			mp.events.callRemote('Display_InteractVehicle_Menu', entity);
		}
	}
	lastCheck = new Date().getTime();
});

// 0x45 is the L key code
mp.keys.bind(0x4C, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    mp.events.callRemote('keypress:L');
	mp.events.callRemote('keypress:INSERT');
    lastCheck = new Date().getTime();
});

// 0x45 is the INSERT key code
mp.keys.bind(0x58, true, (index) => {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    mp.events.callRemote('keypress:INSERT');
    lastCheck = new Date().getTime();
});

// 0x45 is the INSERT key code
mp.keys.bind(0x4D, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    mp.events.call('house_KeyM');
    lastCheck = new Date().getTime();
});


//
// G Passege
//
function calcDist(v1, v2) {
    return mp.game.system.vdist(
        v1.x,
        v1.y,
        v1.z,
        v2.x,
        v2.y,
        v2.z
    );
}

mp.game.controls.useDefaultVehicleEntering = true;

mp.keys.bind(
    71,
    false,
    () => {
        if (global.chatopened) return true;
        if (mp.players.local.vehicle === null) {
            let playerPos = mp.players.local.position;
            let vehHandle = mp.game.vehicle.getClosestVehicle(playerPos.x, playerPos.y, playerPos.z, 10, 0, 70);
            let vehicle = mp.vehicles.atHandle(vehHandle);

            if (vehicle !== null) {
                let seat_pside_r = vehicle.getWorldPositionOfBone(vehicle.getBoneIndexByName("seat_pside_r"));
                let seat_pside_f = vehicle.getWorldPositionOfBone(vehicle.getBoneIndexByName("seat_pside_f"));
                let seat_dside_r = vehicle.getWorldPositionOfBone(vehicle.getBoneIndexByName("seat_dside_r"));
                let seat_r = vehicle.getWorldPositionOfBone(vehicle.getBoneIndexByName("seat_r"));

                let distance = calcDist(playerPos, seat_pside_r);
                let seat = 2;
                if (vehicle.isSeatFree(0) && calcDist(playerPos, seat_pside_f) < distance) {
                    distance = calcDist(playerPos, seat_pside_f);
                    seat = 0;
                }
                if (vehicle.isSeatFree(1) && calcDist(playerPos, seat_dside_r) < distance) {
                    distance = calcDist(playerPos, seat_dside_r);
                    seat = 1;
                }
                if (vehicle.isSeatFree(3) && calcDist(playerPos, seat_r) < distance) {
                    seat = 3;
                }

                if (vehicle.isSeatFree(seat))
                    mp.players.local.taskEnterVehicle(vehHandle, 5000, seat, 2.0, 1, 0);
            }
        }
    }
);


// Take screenshot - Key: F8
mp.keys.bind(0x77, false, (player) => {
    var time = mp.game.time.getLocalTime(1, 1, 1, 1, 1, 1);
    var screenName = "DerStr1k3r-" + time.year + "-" + time.month + "-" + time.day + "-" + time.hour + "-" + time.minute + "-" + time.second + ".png";
    mp.gui.takeScreenshot(screenName, 1, 100, 0);
    mp.game.graphics.notify("~b~Screenshot nun in dein RageMP Ordner!");
});

mp.events.add("StopVehicle", () => {
    if (localPlayer.vehicle) {
        localPlayer.vehicle.setHalt(1.5, 1, false);
    }
});

mp.keys.bind(0x25, true, function() { //Left indicator

    if (signal1 && localPlayer.vehicle) {
        signal1 = false;
        //mp.game.graphics.notify('Left Signal was deactivated.');
        localPlayer.vehicle.setIndicatorLights(1, false);
    } else

    if (signal2 && localPlayer.vehicle) {

        //mp.game.graphics.notify('Left Signal was activated.');
        //localPlayer.vehicle.setIndicatorLights(0, false);
        localPlayer.vehicle.setIndicatorLights(1, true);
        signal1 = true;
        //signal2 = false;
    } else if (localPlayer.vehicle) {
        //mp.game.graphics.notify('Left Signal was activated.');
        localPlayer.vehicle.setIndicatorLights(1, true);
        signal1 = true;
        //signal2 = false;
    }
});

mp.keys.bind(0x27, true, function() { // Right Indicator
    if (signal2 && localPlayer.vehicle) {
        signal2 = false;
        localPlayer.vehicle.setIndicatorLights(0, false);
    } else
    if (signal1 && localPlayer.vehicle) {
        //localPlayer.vehicle.setIndicatorLights(1, false);
        localPlayer.vehicle.setIndicatorLights(0, true);
        //signal1 = false;
        signal2 = true;
    } else if (localPlayer.vehicle) {
        localPlayer.vehicle.setIndicatorLights(0, true);
        signal2 = true;
    }
});

mp.events.add("getPedOverlay", (cash) => {

    let featureData = [];
    for (let i = 0; i < 20; i++) mp.events.callRemote("Get_Feature_Data", i, mp.game.ped.getNumHeadOverlayValues(i));

});

function getWaypointPos() {
    // GET_FIRST_BLIP_INFO_ID
    let waypointBlip = mp.game.invoke("0x1BEDE233E6CD2A1F", 8); // 8 is the ID for Waypoint blip.
    if (waypointBlip > 0) {
        // Calculate position
        var wayPointPos = mp.game.ui.getBlipInfoIdCoord(waypointBlip);
        //mp.players.local.position = wayPointPos;
        return wayPointPos;
    } else {
        // Return empty positon
        return new mp.Vector3();
    }
}


/* Speed Limiter */

function IsModelBlocked(model) {
    // model check
    if (blockedModels.indexOf(model) > -1) return true;

    // category check
    if (blockedCategories.indexOf(mp.game.vehicle.getVehicleClassFromName(model)) > -1) return true;

    // wow not blocked
    return false;
}

function SetVehicleMaxSpeed(vehicle, limit) {
    vehicleMaxSpeed[vehicle.getModel()] = limit;
    mp.events.callRemote('SetCruiseValue', limit);
}

function GetVehicleLimiterStatus(vehicle) {
    var model = vehicle.getModel();
    return (vehicleMaxSpeedEnabled[model] === null) ? false : vehicleMaxSpeedEnabled[model];
}

function SetVehicleLimiterStatus(vehicle, status) {
    var model = vehicle.getModel();

    if (status) {
        // SET_ENTITY_MAX_SPEED
        vehicle.setMaxSpeed((vehicleMaxSpeed[model] === null) ? (mp.game.vehicle.getVehicleModelMaxSpeed(model) * 3.6) : (vehicleMaxSpeed[model] / 3.6));

    } else {
        // SET_ENTITY_MAX_SPEED
        vehicle.setMaxSpeed(mp.game.vehicle.getVehicleModelMaxSpeed(model) * 3.6);
    }

    vehicleMaxSpeedEnabled[model] = status;
}

//
//
//

let customBrowser = undefined;
let parameters = [];

mp.events.add('createBrowser', (arguments) => {
    // Check if there's a browser already opened
    if (customBrowser === undefined) {
        // Save the parameters
        parameters = arguments.slice(1, arguments.length);

        // Create the browser
        customBrowser = mp.browsers.new(arguments[0]);
    }
});

mp.events.add('browserDomReady', (browser) => {
    if (customBrowser === browser) {
        // Enable the cursor
        mp.gui.cursor.visible = true;

        if (parameters.length > 0) {
            // Call the function passed as parameter
            mp.events.call('executeFunction', parameters);
        }
    }
});

mp.events.add('executeFunction', (arguments) => {
    // Check for the parameters
    let input = '';

    for (let i = 1; i < arguments.length; i++) {
        if (input.length > 0) {
            input += ', \'' + arguments[i] + '\'';
        } else {
            input = '\'' + arguments[i] + '\'';
        }
    }

    // Call the function with the parameters
    customBrowser.execute(`${arguments[0]}(${input});`);
});

mp.events.add('destroyBrowser', () => {
    // Disable the cursor
    mp.gui.cursor.visible = false;

    // Destroy the browser
    if (customBrowser != undefined) {
        customBrowser.destroy();
        customBrowser = undefined;
    }
});

//
//
//

let policeMainDoors = undefined;
let policeBackDoors = undefined;
let policeCellDoors = undefined;
let motorsportMain = undefined;
let motorsportParking = undefined;
let supermarketDoors = undefined;
let clubhouseDoor = undefined;
let oficina_portao = undefined;
let oficina_porta = undefined;

mp.events.add('guiReady', () => {
    // Police station's doors
    policeMainDoors = mp.colshapes.newSphere(468.535, -1014.098, 26.386, 5.0);
    policeBackDoors = mp.colshapes.newSphere(435.131, -981.9197, 30.689, 5.0);
    policeCellDoors = mp.colshapes.newSphere(461.7501, -998.361, 24.915, 5.0);

    // Car dealer's doors
    motorsportMain = mp.colshapes.newSphere(-59.893, -1092.952, 26.8836, 5.0);
    motorsportParking = mp.colshapes.newSphere(-39.134, -1108.22, 26.72, 5.0);

    // Supermarket's doors
    supermarketDoors = mp.colshapes.newSphere(-711.545, -915.54, 19.216, 5.0);

    // Club house's doors
    clubhouseDoor = mp.colshapes.newSphere(981.7533, -102.7987, 74.8487, 5.0);

    oficina_portao = mp.colshapes.newSphere(484.5166, -1315.502, 29.20002, 10.0);
    oficina_porta = mp.colshapes.newSphere(482.911, -1312.584, 29.20103, 10.0);
});



mp.events.add('playerEnterColshape', (shape) => {
    switch (shape) {
        case policeMainDoors:
            mp.game.object.setStateOfClosestDoorOfType(mp.game.joaat('v_ilev_ph_door002'), 434.7479, -983.2151, 30.83926, false, 0, false);
            mp.game.object.setStateOfClosestDoorOfType(mp.game.joaat('v_ilev_ph_door01'), 434.7479, -980.6184, 30.83926, false, 0, false);
            break;
        case policeBackDoors:
            mp.game.object.setStateOfClosestDoorOfType(mp.game.joaat('v_ilev_rc_door2'), 469.9679, -1014.452, 26.53623, false, 0, false);
            mp.game.object.setStateOfClosestDoorOfType(mp.game.joaat('v_ilev_rc_door2'), 467.3716, -1014.452, 26.53623, false, 0, false);
            break;
        case policeCellDoors:
            mp.game.object.setStateOfClosestDoorOfType(mp.game.joaat('v_ilev_ph_cellgate'), 461.8065, -994.4086, 25.06443, false, 0, false);
            mp.game.object.setStateOfClosestDoorOfType(mp.game.joaat('v_ilev_ph_cellgate'), 461.8065, -997.6583, 25.06443, false, 0, false);
            mp.game.object.setStateOfClosestDoorOfType(mp.game.joaat('v_ilev_ph_cellgate'), 461.8065, -1001.302, 25.06443, false, 0, false);
            break;
        case motorsportMain:
            mp.game.object.setStateOfClosestDoorOfType(mp.game.joaat('v_ilev_csr_door_l'), -59.89302, -1092.952, 26.88362, false, 0, false);
            mp.game.object.setStateOfClosestDoorOfType(mp.game.joaat('v_ilev_csr_door_r'), -60.54582, -1094.749, 26.88872, false, 0, false);
            break;
        case supermarketDoors:
            mp.game.object.setStateOfClosestDoorOfType(mp.game.joaat('v_ilev_gasdoor'), -711.5449, -915.5397, 19.21559, false, 0, false);
            mp.game.object.setStateOfClosestDoorOfType(mp.game.joaat('v_ilev_gasdoor_r'), -711.5449, -915.5397, 19.2156, false, 0, false);
            break;
        case oficina_portao:
            mp.game.object.setStateOfClosestDoorOfType(mp.game.joaat('prop_com_gar_door_01'), 484.5166, -1315.502, 29.20002, false, 0, false);
            break;
        case oficina_porta:
            mp.game.object.setStateOfClosestDoorOfType(mp.game.joaat('v_ilev_cs_door'), 482.911, -1312.584, 29.20103, false, 0, false);
            break;
    }
});

mp.events.add('doorLock', (model, position, locked, handling) => {
    mp.game.object.setStateOfClosestDoorOfType(model, position.x, position.y, position.z, locked, 0, false);
});

mp.events.add('explode', (position, explosionType, damageScale, isAudible, isInvisible, cameraShake) => {
    mp.game.fire.addExplosion(position.x, position.y, position.z, explosionType, damageScale, isAudible, isInvisible, cameraShake);
});

//
// Login
//
var loginCamera = camerasManager.createCamera('loginCamera', 'default', new mp.Vector3(3433.339, 5177.579, 39.79541), new mp.Vector3(0, 0, 181.1729), 50);

mp.events.add('accountLoginForm', () => {
	setTimeout(() => {
		// Create login window
		mp.events.call('createBrowser', ['package://factionlife/clientcef/player/login.html']);

		mp.game.graphics.startScreenEffect('SwitchHUDIn', 5000, false);

		// about the chat
		mp.gui.chat.activate(false);
		mp.gui.chat.safeMode = false;
		mp.gui.chat.colors = true;

		camerasManager.setActiveCamera(loginCamera, true);
		camerasManager.setActiveCameraWithInterp(loginCamera, new mp.Vector3(3476.85, 5228.022, 9.453369), new mp.Vector3(0, 0, 181.1729), 10000, 0, 0);

		mp.game.ui.displayRadar(false);
		mp.game.gameplay.enableMpDlcMaps(true);
		mp.game.player.disableVehicleRewards();
    }, 1000);
	

});


mp.events.add('loginUser', (login_name, login_password) => {

    setTimeout(function() {
        // Check for the credentials
        mp.events.callRemote('loginUser', login_name, login_password);

    }, 100);
});

mp.events.add('registerUser', (register_username, register_password, register_email) => {

    setTimeout(function() {
        // Check for the credentials
        mp.events.callRemote('registerUser', register_username, register_password, register_email);


    }, 100);
});

mp.events.add('clearLoginWindow', () => {
    // Unfreeze the player
    mp.players.local.freezePosition(false);

    // Destroy the login window
    mp.events.call('destroyBrowser');

    mp.game.graphics.stopScreenEffect('SwitchHUDIn');
});


mp.events.add('displayLoginButton', () => {
	if (customBrowser != undefined) {
        customBrowser.execute("displayLoginButton();");
    }
});

mp.events.add('displayRegisterButton', () => {
	if (customBrowser != undefined) {
        customBrowser.execute("displayRegisterButton();");
    }
});

//
// Admin / Camera
//

let spyCamera = mp.cameras.new('default', new mp.Vector3(0.0, 0.0, 0.0), new mp.Vector3(0.0, 0.0, 0.0), 0);

findPlayerByIdOrNickname = function(playerName) {
    let foundPlayer = null;
    if (playerName == parseInt(playerName)) {
        foundPlayer = mp.players.at(playerName);
    }

    if (!foundPlayer) {
        mp.players.forEach((_player) => {
            if (_player.name === playerName) {
                foundPlayer = _player;
            }
        });
    }
    return foundPlayer;
}

mp.events.add({
    'adminSpyPlayer': (targetid) => {
        let target = findPlayerByIdOrNickname(targetid);

        spyCamera.attachTo(target.handle, 0.0, 0.0, 0.0, true);
        spyCamera.setActive(true);

        mp.game.cam.renderScriptCams(true, false, 0, true, false);
    },
    'adminStopSpy': () => {
        spyCamera.setActive(false);
        mp.game.cam.renderScriptCams(false, false, 0, true, false);
    }
});

//
// Camera
//

let driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(-878.0559, -2081.562, 23.799), new mp.Vector3(-14, 0, 46), 50);

mp.events.add('ShowDMVCamera', (type) => {
    if (type === 1) {
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(-878.0559, -2081.562, 23.799), new mp.Vector3(-14, 0, 46), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(-878.0559, -2081.562, 23.799), new mp.Vector3(-14, 0, 46), 30000, 0, 0);
    } else if (type === 2) {
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(79.85892, -1369.071, 37.84154), new mp.Vector3(-10, 0, 88), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(79.85892, -1369.071, 37.84154), new mp.Vector3(-10, 0, 88), 30000, 0, 0);
    } else if (type === 3) {
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(-99.26994, -1178.103, 31.79146), new mp.Vector3(-12, 0, -8), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(-99.26994, -1178.103, 31.79146), new mp.Vector3(-12, 0, -8), 30000, 0, 0);
    } else if (type === 4) {
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(95.80418, -1043.833, 40.31485), new mp.Vector3(-34, 0, -20), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(95.80418, -1043.833, 40.31485), new mp.Vector3(-34, 0, -20), 30000, 0, 0);
    } else if (type === 5) {
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(396.9243, -989.0579, 33.46381), new mp.Vector3(-12, 0, -90), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(396.9243, -989.0579, 33.46381), new mp.Vector3(-12, 0, -90), 30000, 0, 0);
    } else if (type === 6) {
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(2767.7, 3917.981, 69.10294), new mp.Vector3(-10, 0, 34), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(2767.7, 3917.981, 69.10294), new mp.Vector3(-10, 0, 34), 30000, 0, 0);
    } else if (type === 7) {
        camerasManager.destroyCamera(driverLicenseCamera);
        camerasManager.setActiveCamera(driverLicenseCamera, false);
        mp.game.cam.renderScriptCams(false, false, 0, true, false);
    }
});

mp.events.add('ShowTutorialCam', (type) => {
    if (type === 1) {
		// Pier
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(-1894.573, -1293.929, 41.53985), new mp.Vector3(-14, 0, -40), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(-1894.573, -1293.929, 41.53985), new mp.Vector3(-14, 0, -40), 30000, 0, 0);
    } else if (type === 2) {
		// Spawn
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(-488.0137, -299.9866, 71.51349), new mp.Vector3(-16, 0, 30), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(-488.0137, -299.9866, 71.51349), new mp.Vector3(-16, 0, 30), 30000, 0, 0);
    } else if (type === 3) {
		// Auto Escola
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(-882.0059, -2075.573, 21.51187), new mp.Vector3(-10, 0, 46), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(-882.0059, -2075.573, 21.51187), new mp.Vector3(-10, 0, 46), 30000, 0, 0);
    } else if (type === 4) {
		// Loja de Veiculos
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(-49.14376, -1149.689, 40.55699), new mp.Vector3(-18, 0, -8), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(-49.14376, -1149.689, 40.55699), new mp.Vector3(-18, 0, -8), 30000, 0, 0);
    } else if (type === 5) {
		// Mercadinho
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(28.97695, -1372.534, 37.99702), new mp.Vector3(-18, 0, 0), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(28.97695, -1372.534, 37.99702), new mp.Vector3(-18, 0, 0), 30000, 0, 0);
    } else if (type === 6) {
		// Loja Roupa
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(103.185, -1397.887, 37.37612), new mp.Vector3(-10, 0, 82), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(103.185, -1397.887, 37.37612), new mp.Vector3(-10, 0, 82), 30000, 0, 0);
    } else if (type === 7) {
		// Delega
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(398.3175, -985.5212, 43.18961), new mp.Vector3(-14, 0, -88), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(398.3175, -985.5212, 43.18961), new mp.Vector3(-14, 0, -88), 30000, 0, 0);
    } else if (type === 8) {
		// Taxista
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(931.272, -187.6363, 91.57872), new mp.Vector3(-20, 0, 58), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(931.272, -187.6363, 91.57872), new mp.Vector3(-20, 0, 58), 30000, 0, 0);
    } else if (type === 9) {
		// LSC
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(-387.7276, -108.9925, 55.42762), new mp.Vector3(-18, 0, -128), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(-387.7276, -108.9925, 55.42762), new mp.Vector3(-18, 0, -128), 30000, 0, 0);
    } else if (type === 10) {
		// Garbage

        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(1378.448, -2018.354, 66.84343), new mp.Vector3(-10, 0, 188), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(1378.448, -2018.354, 66.84343), new mp.Vector3(-10, 0, 188), 30000, 0, 0);
    } else if (type === 11) {
		// Entregador
		
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(-502.532, -2816.423, 17.00038), new mp.Vector3(-14, 0, 134), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(-502.532, -2816.423, 17.00038), new mp.Vector3(-14, 0, 134), 30000, 0, 0);
    } else if (type === 12) {
		// Casa
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(-14.69305, -1463.441, 37.00965), new mp.Vector3(-16, 0, 0), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(-14.69305, -1463.441, 37.00965), new mp.Vector3(-16, 0, 0), 30000, 0, 0);
    }  else if (type === 13) {
		// Pesca
		
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3( -1894.573, -1293.929, 41.53985), new mp.Vector3(-14, 0, -40), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3( -1894.573, -1293.929, 41.53985), new mp.Vector3(-14, 0, -40), 30000, 0, 0);
    }  else if (type === 14) {
		// HQ Gang
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(85.98487, -1906.479, 36.40412 ), new mp.Vector3(-22, 0, 192), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(85.98487, -1906.479, 36.40412 ), new mp.Vector3(-22, 0, 192), 30000, 0, 0);
    }  else if (type === 15) {
		// Hospital
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3( -465.6996, -325.4315, 37.46659), new mp.Vector3(0, 0, 106), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3( -465.6996, -325.4315, 37.46659), new mp.Vector3(0, 0, 106), 30000, 0, 0);
    }   else if (type === 16) {
		// LS Visao
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3( -131.1932, -959.8748, 269.135), new mp.Vector3(-22, 0, -80), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(-131.1932, -959.8748, 269.135), new mp.Vector3(-22, 0, -80), 30000, 0, 0);
   
   } else if (type === 17) {
        camerasManager.destroyCamera(driverLicenseCamera);
        camerasManager.setActiveCamera(driverLicenseCamera, false);
        mp.game.cam.renderScriptCams(false, false, 0, true, false);
    }
});


mp.events.add("PlaySoundFrontend", (audioName, audioLibrary) => {
    mp.game.audio.playSoundFrontend(-1, audioName, audioLibrary, true);
});

// Leitstelle
mp.events.add('getLeitstelle', () => {
    mp.events.callRemote('leitstelleToggle');
});

//
// Phone System
//

function ringtone(clientID, stop = false) {
    if (ringTone != null) clearInterval(ringTone);
    if (stop) return false;

    ringToneCounter = 0;

    ringTone = setInterval(function() {
        ringToneCounter++;

        if (ringToneCounter < 11) {
            mp.events.call('playSoundFor', clientID, 'On_Call_Player_Join', 'DLC_HEISTS_GENERAL_FRONTEND_SOUNDS');
        }

        if (ringToneCounter > 30) ringToneCounter = 0;
    }, 78);
}

mp.events.add({
    "playSoundFor": (player, sound, dict) => {
        let target = mp.players.atRemoteId(player);

        /*if (target) {
            mp.game.audio.playSoundFromEntity(-1, sound, target.handle, dict, true, 0);
        }*/
    },
    "playSoundFrom": (position, sound, dict) => {
        mp.game.audio.playSoundFromCoord(-1, sound, position.x, position.y, position.z, dict, false, 0, false);
    },
    "playSpeechSoundFor": (playerID, speechName, speechVoice) => {
        let player = mp.players.atRemoteId(playerID);

        if (player) mp.game.playSpeech(player, speechName, speechVoice);
    },
    "playRingtone": (playerID) => {
        let target = mp.players.atRemoteId(playerID);

       /* if (target) {
            mp.game.audio.playPedRingtone('Remote_Ring', target.handle, true);
        }*/
    },
    "playClientSound": (soundName, volume) => {
        if (uiPlayer_Browsers != undefined) {
            volume = Math.round(volume * 10) / 10;

            uiPlayer_Browsers.execute(`playAudio('${soundName}', '${volume}');`);
        }
    },
    "initPhone": () => {
        if (phone === undefined) {

            phone = mp.browsers.new("package://factionlife/clientcef/phone/index.html");

            phone.execute(`setPhoneNumber('${phoneNumber}');`);

        } else {
            phone.execute(`setPhoneNumber('${phoneNumber}');`);
        }
    },
    "destroyPhone": () => {
        if (phone != undefined) {
            phone.destroy();
            phone = undefined;
        }
    },
    "openPhone": () => {
        if (phone != undefined) {
            //mp.gui.chat.push('phoneOpen');
            phone.execute(`togglePhone(true)`);

            phone_menu = true;

            mp.gui.cursor.visible = true;
            cursor_status = true;
        }
    },
    "closePhone": () => {
        if (phone != undefined) {
            //phone = false;
            //mp.gui.chat.push('closePhone');
            phone_menu = false;

            mp.gui.cursor.visible = false;
            cursor_status = false;

            phone.execute(`togglePhone(false)`);
        }
    },
    "togglePhone": (forcefully = false) => {
        isPhone = false;
        phone.execute(`closeApp();`);
    },
    "setPhoneNumber": (number) => {
        //mp.gui.chat.push('setPhoneNumber');
        phoneNumber = number;

        if (phone) phone.execute(`setPhoneNumber('${phoneNumber}');`);
    },
    "Update_Contacts": (contact) => {
        //mp.gui.chat.push('setPhoneNumber');

        if (phone) phone.execute(`loadContacts('${contact}');`);
    },
    "startCall": (number) => {
        let intNumber = parseInt(number);

        switch (intNumber) {

            case 110: // Cops
                mp.players.forEach(caller => {
                    if (caller.getVariable('leitstelle110') != 0) {
                        let newnumber = parseInt(caller.getVariable('leitstelle110'));
                        mp.events.callRemote('dialingNumber', newnumber);
                    }
                });

                break;

            case 112:  // Medics
                mp.players.forEach(caller => {
                    if (caller.getVariable('leitstelle112') != 0) {
                        let newnumber = parseInt(caller.getVariable('leitstelle112'));
                        mp.events.callRemote('dialingNumber', newnumber);
                    }
                });

                break;

            case 113:  // Acls
                mp.players.forEach(caller => {
                    if (caller.getVariable('leitstelle113') != 0) {
                        let newnumber = parseInt(caller.getVariable('leitstelle113'));
                        mp.events.callRemote('dialingNumber', newnumber);
                    }
                });

                break;

            case 114:  // Taxi
                mp.players.forEach(caller => {
                    if (caller.getVariable('leitstelle113') != 0) {
                        let newnumber = parseInt(caller.getVariable('leitstelle113'));
                        mp.events.callRemote('dialingNumber', newnumber);
                    }
                });

                break;

            default:

                mp.events.callRemote('dialingNumber', intNumber);

                break;
        }
    },

    "request_sms": (number) => {
        mp.events.callRemote('Update_SMS', number);
    },

    "request_sms_list": () => {
        mp.events.callRemote('Show_SMS');
    },

    "Send_SMS": (number, texto) => {
        mp.events.callRemote('Send_SMS_SERVER', number, texto);
    },

    "Remove_Contact": (number) => {
        mp.events.callRemote('onClientRequestRemovePlayerContact', number);
    },

    "Update_SMS_Web": (sms) => {
        //mp.gui.chat.push('setPhoneNumber');

        if (phone) phone.execute(`Load_SMS('${sms}');`);
    },

    "Update_SMS_List": (sms) => {
        //mp.gui.chat.push('setPhoneNumber');

        if (phone) phone.execute(`loadSMSList('${sms}');`);
    },

    /*"Update_SMS": (sms) => {

        if (phone) phone.execute(`Load_SMS('${sms}');`);
    },*/


    "addContact": (number, name) => {
        mp.events.callRemote('Add_Contact', number, name);
    },
    "incomingCall": (caller, number) => {
        incomingCaller = caller;
        phone.execute(`callIncoming('${number}')`);
        //mp.gui.chat.push('incomingCall');
    },
    "startApp": (name) => {
        phone.execute(`startApp('${name}')`);
        //mp.gui.chat.push('incomingCall');
    },
    "cancelCall": () => {
        //mp.gui.chat.push('cancelCall');
        if (dialInterval != null) {
            clearInterval(dialInterval);
            dialInterval = null;
        }

        if (incomingCaller != null) {
            incomingCaller.isInCallWith = null;
            incomingCaller = null;
        }

        mp.events.callRemote('cancelCallingNumber');
    },
    "denyCall": () => {
        //mp.gui.chat.push('denyCall');
        phone.execute(`cancelCall()`);

        if (dialInterval != null) {
            clearInterval(dialInterval);
            dialInterval = null;
        }

        mp.events.call('playClientSound', 'chamada_recusada', 0.2);
    },
    "acceptIncomingCall": (number) => {
        //mp.gui.chat.push('acceptIncomingCall');
        incomingCaller.isInCallWith = mp.players.local;
        mp.events.callRemote('acceptCall', number);
    },
    "incomingCallFor": (playerID) => {
        //mp.gui.chat.push('incomingCallFor');
        let player = mp.players.atRemoteId(playerID);

        if (player) {
            ringtone(playerID);
        }
    },
    "callAcceptFor": (playerID) => {
        //mp.gui.chat.push('callAcceptFor');
        let player = mp.players.atRemoteId(playerID);

        if (player) ringtone(playerID, true);
    },
    "callDeniedFor": (playerID) => {
        //mp.gui.chat.push('callDeniedFor');
        let player = mp.players.atRemoteId(playerID);

        if (player) ringtone(playerID, true);
        if (player == mp.players.local) phone.execute(`cancelCall()`);
    },
     "callAccepted": (caller, number) => {

        //Voice.add(caller, true);
        // mp.events.call('voice.phoneCall', caller); // ******** Altes Rage Voice ********* //
        
        mp.events.callRemote("saltyCallAccepted", caller); // Salty Chat

        if (dialInterval != null) {
            clearInterval(dialInterval);
            dialInterval = null;
        }

        phone.execute(`setCallScreen('${number}', 0, true)`);
        //mp.gui.chat.push('callAccepted -- ' + caller + ' ' + number + '');
    },
    "callEnded": (caller = null) => {

        //if(caller) Voice.remove(caller, true);
        // mp.events.call('voice.phoneStop'); // ******** Altes Rage Voice ********* //

        mp.events.callRemote("saltyCallEnded"); // Salty Chat
       
		
        if (dialInterval != null) {
            clearInterval(dialInterval);
            dialInterval = null;
        }

        if (incomingCaller != null) {
            incomingCaller.isInCallWith = null;
            incomingCaller = null;
        }

        phone.execute(`cancelCall('true')`);

        //mp.gui.chat.push('callEnded -- ' + caller + '');
    },
    "closeApp": () => {
        if (phone && phone != false) {
            phone_app = false;
            phone_app_loaded = false;

            phone.execute(`closeApp();`);
            if (dialInterval != null) {
                clearInterval(dialInterval);
                dialInterval = null;
            }
        }
    },
    "removeNumber": () => {
        phone.execute(`removeNumber();`);
    },
    "callNumber": (number) => {
        mp.events.callRemote('dialNumber', number);
    },
    "removeSound": () => {
        mp.game.audio.playSoundFromEntity(-1, "ERROR", mp.players.local.handle, "HUD_FRONTEND_CLOTHESSHOP_SOUNDSET", true, 0);
    },
    "typeWords": () => {
        mp.game.audio.playSoundFromEntity(-1, "EDIT", mp.players.local.handle, "HUD_DEATHMATCH_SOUNDSET", true, 0);
    },
    "processFail": () => {
        mp.game.audio.playSoundFromEntity(-1, "Pin_Bad", mp.players.local.handle, "DLC_HEIST_BIOLAB_PREP_HACKING_SOUNDS", true, 0);
    },
    "processSuccess": () => {
        mp.game.audio.playSoundFromEntity(-1, "Pin_Good", mp.players.local.handle, "DLC_HEIST_BIOLAB_PREP_HACKING_SOUNDS", true, 0);
    },
    "helmetFalse": () => {
		mp.players.local.setHelmet(false);
    },

    "service_accept": (number) => {

        if (dialInterval != null) {
            clearInterval(dialInterval);
            dialInterval = null;
        }

        phone.execute(`setCallScreen('${number}', 0, true)`);
    },
    "service_cancel": () => {

        if (dialInterval != null) {
            clearInterval(dialInterval);
            dialInterval = null;
        }

        if (incomingCaller != null) {
            incomingCaller.isInCallWith = null;
            incomingCaller = null;
        }

        phone.execute(`cancelCall('true')`);
    },
});


//
// Point figer
//
//Fingerpointing
let pointing = {
    active: false,
    interval: null,
    lastSent: 0,
    start: function() {
        if (!this.active) {
            this.active = true;

            mp.game.streaming.requestAnimDict("anim@mp_point");

            while (!mp.game.streaming.hasAnimDictLoaded("anim@mp_point")) {
                mp.game.wait(0);
            }
            mp.game.invoke("0x0725a4ccfded9a70", mp.players.local.handle, 0, 1, 1, 1);
            mp.players.local.setConfigFlag(36, true)
            mp.players.local.taskMoveNetwork("task_mp_pointing", 0.5, false, "anim@mp_point", 24);
            mp.game.streaming.removeAnimDict("anim@mp_point");

            this.interval = setInterval(this.process.bind(this), 0);
        }
    },

    stop: function() {
        if (this.active) {
            clearInterval(this.interval);
            this.interval = null;

            this.active = false;



            mp.game.invoke("0xd01015c7316ae176", mp.players.local.handle, "Stop");

            if (!mp.players.local.isInjured()) {
                mp.players.local.clearSecondaryTask();
            }
            if (!mp.players.local.isInAnyVehicle(true)) {
                mp.game.invoke("0x0725a4ccfded9a70", mp.players.local.handle, 1, 1, 1, 1);
            }
            mp.players.local.setConfigFlag(36, false);
            mp.players.local.clearSecondaryTask();


        }
    },

    gameplayCam: mp.cameras.new("gameplay"),
    lastSync: 0,

    getRelativePitch: function() {
        let camRot = this.gameplayCam.getRot(2);

        return camRot.x - mp.players.local.getPitch();
    },

    process: function() {
        if (this.active) {
            mp.game.invoke("0x921ce12c489c4c41", mp.players.local.handle);

            let camPitch = this.getRelativePitch();

            if (camPitch < -70.0) {
                camPitch = -70.0;
            } else if (camPitch > 42.0) {
                camPitch = 42.0;
            }
            camPitch = (camPitch + 70.0) / 112.0;

            let camHeading = mp.game.cam.getGameplayCamRelativeHeading();

            let cosCamHeading = mp.game.system.cos(camHeading);
            let sinCamHeading = mp.game.system.sin(camHeading);

            if (camHeading < -180.0) {
                camHeading = -180.0;
            } else if (camHeading > 180.0) {
                camHeading = 180.0;
            }
            camHeading = (camHeading + 180.0) / 360.0;

            let coords = mp.players.local.getOffsetFromGivenWorldCoords((cosCamHeading * -0.2) - (sinCamHeading * (0.4 * camHeading + 0.3)), (sinCamHeading * -0.2) + (cosCamHeading * (0.4 * camHeading + 0.3)), 0.6);
            let blocked = (typeof mp.raycasting.testPointToPoint([coords.x, coords.y, coords.z - 0.2], [coords.x, coords.y, coords.z + 0.2], mp.players.local.handle, 7) !== 'undefined');

            mp.game.invoke('0xd5bb4025ae449a4e', mp.players.local.handle, "Pitch", camPitch)
            mp.game.invoke('0xd5bb4025ae449a4e', mp.players.local.handle, "Heading", camHeading * -1.0 + 1.0)
            mp.game.invoke('0xb0a6cfd2c69c1088', mp.players.local.handle, "isBlocked", blocked)
            mp.game.invoke('0xb0a6cfd2c69c1088', mp.players.local.handle, "isFirstPerson", mp.game.invoke('0xee778f8c7e1142e2', mp.game.invoke('0x19cafa3c87f7c2ff')) == 4)

            if ((Date.now() - this.lastSent) > 100) {
                this.lastSent = Date.now();
                mp.events.callRemote("fpsync.update", camPitch, camHeading);
            }
        }
    }
}

mp.events.add("fpsync.update", (id, camPitch, camHeading) => {
    let netPlayer = getPlayerByRemoteId(parseInt(id));
    if (netPlayer != null) {
        if (netPlayer != mp.players.local) {
            netPlayer.lastReceivedPointing = Date.now();

            if (!netPlayer.pointingInterval) {
                netPlayer.pointingInterval = setInterval((function() {
                    if ((Date.now() - netPlayer.lastReceivedPointing) > 1000) {
                        clearInterval(netPlayer.pointingInterval);

                        netPlayer.lastReceivedPointing = undefined;
                        netPlayer.pointingInterval = undefined;

                        mp.game.invoke("0xd01015c7316ae176", netPlayer.handle, "Stop");


                        if (!netPlayer.isInAnyVehicle(true)) {
                            mp.game.invoke("0x0725a4ccfded9a70", netPlayer.handle, 1, 1, 1, 1);
                        }
                        netPlayer.setConfigFlag(36, false);

                    }
                }).bind(netPlayer), 500);

                mp.game.streaming.requestAnimDict("anim@mp_point");

                while (!mp.game.streaming.hasAnimDictLoaded("anim@mp_point")) {
                    mp.game.wait(0);
                }

                mp.game.invoke("0x0725a4ccfded9a70", netPlayer.handle, 0, 1, 1, 1);
                netPlayer.setConfigFlag(36, true)
                netPlayer.taskMoveNetwork("task_mp_pointing", 0.5, false, "anim@mp_point", 24);
                mp.game.streaming.removeAnimDict("anim@mp_point");
            }

            mp.game.invoke('0xd5bb4025ae449a4e', netPlayer.handle, "Pitch", camPitch)
            mp.game.invoke('0xd5bb4025ae449a4e', netPlayer.handle, "Heading", camHeading * -1.0 + 1.0)
            mp.game.invoke('0xb0a6cfd2c69c1088', netPlayer.handle, "isBlocked", 0);
            mp.game.invoke('0xb0a6cfd2c69c1088', netPlayer.handle, "isFirstPerson", 0);
        }
    }
});

mp.keys.bind(0x42, true, () => {
    if (!mp.gui.cursor.visible) {
        if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined) return;

        pointing.start();
    }
});

mp.keys.bind(0x42, false, () => {
    pointing.stop();

});

function getPlayerByRemoteId(remoteId) {
    let pla = mp.players.atRemoteId(remoteId);
    if (pla == undefined || pla == null) {
        return null;
    }
    return pla;
}

const Natives2 = {
    SWITCH_OUT_PLAYER: '0xAAB3200ED59016BC',
    SWITCH_IN_PLAYER: '0xD8295AF639FD9CB8',
    IS_PLAYER_SWITCH_IN_PROGRESS: '0xD9D2CFFF49FAB35F'
};
let gui;

mp.events.add('moveSkyCamera', moveFromToAir);

function moveFromToAir(player, moveTo, switchType, showGui) {   
   
   switch (moveTo) {
       case 'up':
            if (showGui == false) {
                mp.gui.chat.show(showGui);
                gui = 'false';
            };
            mp.game.invoke(Natives2.SWITCH_OUT_PLAYER, player.handle, 0, parseInt(switchType));
           break;
       case 'down':
            if (gui == 'false') {
                checkCamInAir();
            };
            mp.game.invoke(Natives2.SWITCH_IN_PLAYER, player.handle);
           break;
   
       default:
           break;
   }
}

// Checks whether the camera is in the air. If so, then reset the timer
function checkCamInAir() {
    if (mp.game.invoke(Natives2.IS_PLAYER_SWITCH_IN_PROGRESS)) {
        setTimeout(() => {
            checkCamInAir();
        }, 400);
    } else {
        mp.gui.chat.show(true);
        gui = 'true';
    }
}

//
//
//

var cam = mp.cameras.new('default', new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0), false);

mp.events.add('View_Dealership', function () {
    cam = mp.cameras.new('default', new mp.Vector3(-42.3758, -1101.672, 27.52235), new mp.Vector3(0, 0, 0), 50);
    cam.pointAtCoord(-42.79771, -1095.676, 26.0117);
    cam.setActive(true);
    mp.game.cam.renderScriptCams(true, false, 0, true, false);
});


mp.events.add('destroyCameraDealer', function () {
    cam.destroy();
    mp.game.cam.renderScriptCams(false, false, 3000, true, true);
});


mp.events.add("Cinema_Open", (toggle) => {
	mp.events.callRemote("Server:Cinema_Open", toggle);
});

mp.events.add("enterCinema", () => {
	mp.game.cam.doScreenFadeOut(500);
	
	if(cinemaWindow == null) 
	{
		mp.game.cam.doScreenFadeOut(500);
		localPlayer.setVelocity(0.0, 0.0, 0.0);

		setTimeout(function() {
			localPlayer.freezePosition(true);
			mp.events.callRemote("requestCinemaScreen");
		}, 700);
	}
});


mp.events.add("showCinemaScreen", (autor, time, url, isadm) => {

	if(cinemaWindow == null) 
	{
		cinemaWindow = mp.browsers.new("package:/factionlife/clientcef/cinema/cinema-screen.html");

		mp.gui.cursor.show(true, true);

		cinemaCamera = mp.cameras.new("default", new mp.Vector3(cinema_camera_pos[0], cinema_camera_pos[1], cinema_camera_pos[2]), new mp.Vector3(0,0,0), 40);
		cinemaCamera.pointAtCoord(cinema_camera_lookat[0], cinema_camera_lookat[1], cinema_camera_lookat[2]); 
		cinemaCamera.setActive(true);
		mp.game.cam.renderScriptCams(true, false, 0, true, false);

		setTimeout(function() {
			mp.game.cam.doScreenFadeIn(1000);
		}, 500);
	}
	
	if(isadm === true)
	{
		cinemaWindow.execute("DisplayMenu(true)");
	}
	
	uiVelo_Browsers.execute("DisplayMenu(false)");
	uiPlayer_Browsers.execute("DisplayMenu(false)");

	if(url == "null")
	{
		cinemaWindow.execute('clearCinema()');
	}
	else
	{
		cinemaWindow.execute('setCinema("'+autor+'", '+time+', "'+url+'")');
	}
});


mp.events.add("exitCinema", () => {

	//ENABLE_VOICE_WITH_CURSOR = false;
	
	mp.game.cam.doScreenFadeOut(500);

	mp.events.callRemote("exitCinema");
	
	setTimeout(function() {	

		if(cinemaWindow != null) 
		{
			cinemaWindow.destroy();
			cinemaWindow = null;
			mp.gui.cursor.show(false, false);
		}
	
		if(cinemaCamera != null)
		{
			cinemaCamera.setActive(false);
			cinemaCamera.destroy();
			cinemaCamera = null;
			mp.game.cam.renderScriptCams(false, false, 0, true, false);
		}
		
		uiVelo_Browsers.execute("DisplayMenu(true)");
		uiPlayer_Browsers.execute("DisplayMenu(true)");

		localPlayer.position = new mp.Vector3(cinema_exit_here[0], cinema_exit_here[1], cinema_exit_here[2]);
		localPlayer.setHeading(cinema_exit_here[3]);
		localPlayer.freezePosition(false);

		mp.game.cam.doScreenFadeIn(1000);

	}, 500);
});


mp.events.add("addCinemaVideo", (url) => {
	
	mp.events.callRemote("addCinemaVideo", url);
	
});


var sk_markers = [];

mp.events.add('createCheckpoint', function (uid, type, position, scale, dimension, r, g, b, dir) {
    if (typeof sk_markers[uid] != "undefined") {
        sk_markers[uid].destroy();
        sk_markers[uid] = undefined;
    }
    if (dir != undefined) {
        sk_markers[uid] = mp.checkpoints.new(type, position, scale, {
            direction: dir,
            color: [r, g, b, 200],
            visible: true,
            dimension: dimension
        });
    } else {
        sk_markers[uid] = mp.markers.new(type, position, scale, {
            visible: true,
            dimension: dimension,
            color: [r, g, b, 255]
        });
    }
});

mp.events.add('deleteCheckpoint', function (uid) {
    if (typeof sk_markers[uid] == "undefined") return;
    sk_markers[uid].destroy();
    sk_markers[uid] = undefined;
});

mp.events.add('createWaypoint', function (x, y) {
    mp.game.ui.setNewWaypoint(x, y);
});

var workBlip = null;
mp.events.add('createWorkBlip', function (position) {
    if (workBlip != null) workBlip.destroy();
    workBlip = mp.blips.new(0, position, {
        name: "Kontrollpunkt",
        scale: 1,
        color: 49,
        alpha: 255,
        drawDistance: 100,
        shortRange: false,
        rotation: 0,
        dimension: 0
    });
});
mp.events.add('deleteWorkBlip', function () {
    if (workBlip != null) workBlip.destroy();
    workBlip = null;
});

var garageBlip = null;
mp.events.add('createGarageBlip', function (position) {
    if (garageBlip != null) garageBlip.destroy();
    garageBlip = mp.blips.new(473, position, {
        name: "Garage",
        scale: 1,
        color: 45,
        alpha: 255,
        drawDistance: 100,
        shortRange: true,
        rotation: 0,
        dimension: 0
    });
});

mp.events.add('deleteGarageBlip', function () {
    if (garageBlip != null) garageBlip.destroy();
    garageBlip = null;
});

var fireEntities = [];

// Each instance of the FireUnit class is a fire with all of its children
// We can have many fires for each primary/main fire started.
class FireUnit {
    constructor(mainID, fireID, fireEntityId, position)
    {
        this.mainID = mainID; // Main ID of the fire belonging to the parent/class
        this.fireID = fireID; // fire ID of this specific fire
        this.fireEntityId = fireEntityId; // Local ID that differs from client to client
        this.position = position; // The position where this specific fire was started
    }
}

// Start a fire and store the instance of the new FireUnit in our Array
mp.events.add("StartFire", (mainID, posX, posY, posZ, maxChilderen, gasPowerd, fireID) => {
    let fireEntityId = mp.game.fire.startScriptFire(posX, posY, posZ, maxChilderen, gasPowerd);

    var fireUnit = new FireUnit(Number(mainID), Number(fireID), fireEntityId, new mp.Vector3(posX, posY, posZ));

    fireEntities.push(fireUnit);
});

// Every second we check if any of the fires have been extinguished
setInterval(() =>
{
    if (fireEntities === null || fireEntities === undefined)
        return;
    
    if (fireEntities.length <= 0)
        return;

    fireEntities.forEach(function (fireUnit)
    {
        if (fireUnit !== null && fireUnit !== undefined)
        {
            // Check if this one fire is extinguished or not, if so tell the server so all players can have it deleted
            if (mp.game.fire.getNumberOfFiresInRange(fireUnit.position.x, fireUnit.position.y, fireUnit.position.z, 2) < 1)
            {
                mp.events.callRemote("fireHasBeenPutOut", Number(fireUnit.mainID), Number(fireUnit.fireID));
                return;
            }
        }
    });
}, 1000);

mp.events.add("Clear_Fire_Data", () => {
    fireEntities = null;
    fireEntities = [];
    mp.events.callRemote("clear_data_done");
});

mp.events.add('StopFireByID', (id) => {
    if (fireEntities === null || fireEntities === undefined)
        return;

    if (fireEntities.length <= 0)
        return;

    for (var i = fireEntities.length - 1; i > -1; i--) {
        if (fireEntities[i] !== null && fireEntities[i] !== undefined) {
            if (fireEntities[i].mainID === id) {
                mp.game.fire.removeScriptFire(fireEntities[i].fireEntityId);

                var index = fireEntities.indexOf(fireEntities[i]);
                if (index > -1) {
                    fireEntities.splice(index, 1);
                }
            }
        }
    }
});

mp.events.add('StopSingleFireByID', (mainID, fireID) => {
    if (fireEntities === null || fireEntities === undefined)
        return;

    if (fireEntities.length <= 0)
        return;

    for (i = 0; i < fireEntities.length; i++)
    {
        if (fireEntities[i] !== null && fireEntities[i] !== undefined)
        {
            if (fireEntities[i].mainID === mainID && fireEntities[i].fireID === fireID)
            {
                mp.game.fire.removeScriptFire(fireEntities[i].fireEntityId);

                var index = fireEntities.indexOf(fireEntities[i]);
                if (index > -1) {
                    fireEntities.splice(index, 1);
                }
            }
        }
    }
});


mp.events.add('CheckIfReachable', (id, main, posX, posY, posZ, maxChilderen, gasPowerd) => {

    pos = mp.game.pathfind.getSafeCoordForPed(posX, posY, posZ, false, main, 0);

    var myObj, x,y,z;
    myObj = pos;
    x = pos.x;
    y = pos.y;
    z = pos.z;
 
    mp.events.callRemote('StartFire', id, x, y, z, maxChilderen, gasPowerd);

    //mp.events.callRemote('SafeCoords', JSON.stringify(pos));
    // mp.gui.chat.push(JSON.stringify(pos));

});
