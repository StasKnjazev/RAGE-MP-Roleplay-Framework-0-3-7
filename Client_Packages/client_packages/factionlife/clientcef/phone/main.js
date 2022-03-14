const Misc = require('Identity-Five/core/misc.js');
const Client = require('Identity-Five/core/client.js');
const Game = require('Identity-Five/core/game.js');
const Key = require('Identity-Five/core/key.js');
const Voice = require('Identity-Five/core/voice.js');

let phone = null, apps, closestAtm = false, atm_size, atm_robbed, hacking = false, carCount = 0, carTimer, car_list = [], ingameTimer = null, incomingCaller = null, dialInterval = null, phoneNumber = 0, phoneContacts = [], timeNow = 0;
let phone_menu = false
    phone_msg = false
    phone_app = false
    phone_app_loaded = false
    atm_close = true
    
let atms = [];
let tick = 0;

Key.add('togglePhone', false, 66);
Key.add('removeNumber', false, 8);

mp.events.add({
    "initPhone": (apps) => {
        phone = mp.browsers.new("package://Identity-Five/menus/phone/index.html");
        
        phone.execute(`initApps('${apps}');`);
        phone.execute(`setPhoneNumber('${phoneNumber}');`);
        phone.execute(`startTime('${timeNow}')`);

        phoneContacts.forEach((contact) => {
            let con = JSON.stringify(contact);

            phone.execute(`addContact('${con}');`);
        });
    },
    "destroyPhone": () => {
        if(phone) {
            phone.destroy();
            phone = null;
        }
    },
    "registerATMApp": (loadAtm) => {
        atms.push(JSON.parse(loadAtm));
    },
    "syncATMRobbery": (id, atmRobbed) => {
        atms[id] = JSON.parse(atmRobbed);
    },
    "openPhone": () => {
        if(phone && !phone_menu) {
            if(Client.isChat) return false;
            Client.player.phone = true;
            Client.setCursor(true);
            phone_menu = true;
            Key.phone(true);

            phone.execute(`togglePhone(true)`);
        }
    },
    "closePhone": () => {
        if(phone && phone_menu) {
            Client.player.phone = false;
            Client.setCursor(false);
            phone_menu = false;
            Key.phone(false);

            phone.execute(`togglePhone(false)`);
        }
    },
    "togglePhone": (forcefully = false) => {
        if(Client.isInTask && !forcefully) return false;
        if(phone && !Client.player.shared.cuffed && !Client.player.shared.restrained && !Client.player.shared.handsup && !Client.player.shared.froze || phone && forcefully) {
            if(phone_menu || forcefully) {
                Client.remote('leavePhone');
                Client.isPhone = false;
                phone.execute(`closeApp();`);
            } else {
                Client.call('toggleInventory', 0, true);
                Client.call('closeShop');
                Client.remote('takePhone');

                Client.isPhone = true;

                if(Client.player.shared.team.id == 1) {
                    if(phone) phone.execute(`hideApp('atm_hacker');`);
                } else {
                    if(phone) phone.execute(`showApp('atm_hacker');`);
                }
            }

            if(phone_app != false) phone_app_loaded = false;
            if(hacking != false) hacking = false;
            if(atm_close != false) atm_close = false;
        }
    },
    "newMsg": (number, msg) => {
        if(phone && !phone_msg && !phone_menu) {
            if(msg.length > 28) msg = msg.substring(0, 27) + '...';
            
            phone.execute(`newMsg(true, '${number}', '${msg}')`);
            phone_msg = true;
        } else {
            phone.execute(`newMsg(false, '${number}', '${msg}')`);
        }    
    },
    "readMsg": () => {
        if(phone && phone_msg && phone_menu) {
            phone_msg = false;
        }  
    },
    "startApp": (app) => {
        if(phone && !phone_app) {
            phone_app = app;
        }  
    },
    "getPlayerVehicles": () => {
        if(phone && phone_app && phone_app == 'car_finder') {
            Client.remote('getVehicleList');
        }
    },
    "sendVehicleList": (vehicles) => {
        if(phone && phone_app && phone_app == 'car_finder') {
            car_list = JSON.parse(vehicles);

            car_list.forEach(function(car, idx, arr) {
                let distance = Game.travelDistance(Client.player.position, car.position);

                car.distance = (distance <= 3000) ? distance : "> 3000";
            });

            phone.execute(`showCarList('${JSON.stringify(car_list)}')`);
        }
    },
    "locateVehicle": (vehID) => {
        Game.debug('VEHICLE ID: ' + vehID + ' / ' + carCount);

        if(carCount == 0) {
            car_list.forEach(function(car, idx, arr) {
                if(car.id != vehID) return false;

                carCount = 120;
                
                mp.events.call('waypoint', car.position.x, car.position.y);
                phone.execute(`setTimer('${carCount}')`);
                Client.pushNotification("FindMyCar", "Vehicle located", "CHAR_SOCIAL_CLUB", "We found your vehicle and marked it in your map.", true, 1);

                carTimer = setInterval(function() {
                    if(carCount > 0) {
                        carCount -= 1;
                    } else clearInterval(carTimer);
                }, 1000);
            });
        }
    },
    "setTime": (time) => {
        if(ingameTimer != null) clearInterval(ingameTimer);
        timeNow = Math.abs(time / 1000);

        if(phone) phone.execute(`startTime('${timeNow}')`);

        ingameTimer = setInterval(function() {
            timeNow += 8;
        }, 1000);        
    },
    "getCarTimer": () => {
        if(phone && phone_app && phone_app == 'car_finder') {
            phone.execute(`setTimer('${carCount}')`);
        }  
    },
    "setPhoneNumber": (number) => {
        phoneNumber = number;

        if(phone) phone.execute(`setPhoneNumber('${phoneNumber}');`);
    },
    "syncPhoneContacts": (contact) => {
        phoneContacts.push(JSON.parse(contact));

        if(phone) {
            phone.execute(`addContact('${contact}')`);
        }
    },
    "startCall": (number) => {
        if(Client.player.debug) Game.debug('Phone -> main.js -> startCall called');

        Client.remote('dialingNumber', number);
        Client.call('playClientSound', 'dialTone', 0.2);

        dialInterval = setInterval(function() {
            Client.call('playClientSound', 'dialTone', 0.2);
        }, 4630);
    },
    "incomingCall": (caller, number) => {
        if(Client.player.debug) Game.debug('Phone -> main.js -> incomingCall called');

        incomingCaller = caller;
        phone.execute(`callIncoming('${number}')`);
    },
    "cancelCall": () => {
        if(Client.player.debug) Game.debug('Phone -> main.js -> cancelCall called');

        if(dialInterval != null) {
            clearInterval(dialInterval);
            dialInterval = null;
        }

        if(incomingCaller != null) {
            incomingCaller.isInCallWith = null;
            incomingCaller = null;
        }

        Client.remote('cancelCallingNumber');
    },
    "denyCall": () => {
        if(Client.player.debug) Game.debug('Phone -> main.js -> denyCall called');
        phone.execute(`cancelCall()`);

        if(dialInterval != null) {
            clearInterval(dialInterval);
            dialInterval = null;
        }

        Client.call('playClientSound', 'dialDenied', 0.2);
    },
    "acceptIncomingCall": (number) => {
        if(Client.player.debug) Game.debug('Phone -> main.js -> acceptIncomingCall called');

        incomingCaller.isInCallWith = Client.player;
        Client.remote('acceptCall', number);
    },
    "incomingCallFor": (playerID) => {
        if(Client.player.debug) Game.debug('Phone -> main.js -> incomingCallFor called');

        let player = mp.players.atRemoteId(playerID);

        if(player) {
            Client.ringtone(playerID);
        }
    },
    "callAcceptFor": (playerID) => {
        if(Client.player.debug) Game.debug('Phone -> main.js -> callAcceptFor called');

        let player = mp.players.atRemoteId(playerID);

        if(player) Client.ringtone(playerID, true);
    },
    "callDeniedFor": (playerID) => {
        if(Client.player.debug) Game.debug('Phone -> main.js -> callDeniedFor called');

        let player = mp.players.atRemoteId(playerID);

        if(player) Client.ringtone(playerID, true);
        if(player == Client.player) phone.execute(`cancelCall()`);
    },
    "callAccepted": (caller, number) => {
        if(Client.player.debug) Game.debug('Phone -> main.js -> callAccepted called');

		//voice.phoneCall caller
        //Voice.add(caller, true);

        if(dialInterval != null) {
            clearInterval(dialInterval);
            dialInterval = null;
        }

        phone.execute(`setCallScreen('${number}', 0, true)`);
    },
    "callEnded": (caller = null) => {
        if(Client.player.debug) Game.debug('Phone -> main.js -> callEnded called');

        if(caller) Voice.remove(caller, true);

        if(dialInterval != null) {
            clearInterval(dialInterval);
            dialInterval = null;
        }

        if(incomingCaller != null) {
            incomingCaller.isInCallWith = null;
            incomingCaller = null;
        }
        
        phone.execute(`cancelCall('true')`);
    },
    "closeApp": () => {
        if(phone && phone != false) {
            phone_app = false;
            phone_app_loaded = false;

            phone.execute(`closeApp();`);
            if(dialInterval != null) {
                clearInterval(dialInterval);
                dialInterval = null;
            }
        }
    },
    "respondLoading": () => {
        if(phone && phone != false) {
            phone_app_loaded = true;
        }  
    },
    "hackATM": (id) => {
        hacking = id;
        Client.remote('startRob', 'atm', id, 'hack'); 
    },
    "finishHack": (id) => {
        if(typeof atms[id] !== 'undefined') {
            atms[id].close = false;
            atm_close = false;
            hacking = false;
            Client.remote('finishRob', 'atm', id); 
            Client.call('closeApp');
        }
    },
    "cancelHack": (id) => {
        if(hacking == id) {
            if(typeof atms[id] !== 'undefined') {
                atms[id].close = false;
                atm_close = false;
                hacking = false;
                Client.remote('abortRob', 'atm', id); 
            }
        }
    },
    "removeNumber": () => {
        phone.execute(`removeNumber();`);
    },
    "callNumber": (number) => {
        Client.remote('dialNumber', number);
    },
    "removeSound": () => {
        Game.audio.playSoundFromEntity(-1, "ERROR", Client.player.handle, "HUD_FRONTEND_CLOTHESSHOP_SOUNDSET", true, 0);
    },
    "typeWords": () => {
        Game.audio.playSoundFromEntity(-1, "EDIT", Client.player.handle, "HUD_DEATHMATCH_SOUNDSET", true, 0);
    },
    "processFail": () => {
        Game.audio.playSoundFromEntity(-1, "Pin_Bad", Client.player.handle, "DLC_HEIST_BIOLAB_PREP_HACKING_SOUNDS", true, 0);
    },
    "processSuccess": () => {
        Game.audio.playSoundFromEntity(-1, "Pin_Good", Client.player.handle, "DLC_HEIST_BIOLAB_PREP_HACKING_SOUNDS", true, 0);
    },
    "render": () => {
        if(Client.player.shared.ready) {
            tick++;
        
            if(tick % 10 === 0) {
                if(phone) {
                    if(phone_app == 'atm_hacker' && phone_app_loaded) {
                        let foundAtm = false;

                        atms.forEach(function(atm, idx, arr) {
                            if(Misc.isInRadius(1.7, Client.player, atm.a_pos)) {
                                foundAtm = true;
                                if(atm_close) return false;

                                phone.execute(`foundAtm('${idx}', '${atm.size}', '${atm.isRobbed}')`);
                                atm_close = true;
                            }

                            if(idx == arr.length - 1) {
                                if(!foundAtm && atm_close) {
                                    atm_close = false;
                                    return phone.execute(`searchAtm(0)`);
                                }
                            }
                        });
                    }

                    if(phone_menu) {
                        if(Client.player.isBeingStunned(0)) {
                            if(hacking != false) Client.closeMenus();
                        }
                    }
                }  
            }
            
            if(tick > 130) tick = 0;
        }
    }
});
