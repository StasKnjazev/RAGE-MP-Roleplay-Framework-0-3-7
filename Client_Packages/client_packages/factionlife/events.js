global.localplayer = mp.players.local;

global.bodyCam = null;
global.bodyCamStart = new mp.Vector3(0, 0, 0);

// BODY CUSTOM //
function getCameraOffset(pos, angle, dist) {
    angle = angle * 0.0174533;

    pos.y = pos.y + dist * Math.sin(angle);
    pos.x = pos.x + dist * Math.cos(angle);
    return pos;
}
var bodyCamValues = {
    "hair": { Angle: 0, Dist: 0.5, Height: 0.7 },
    "beard": { Angle: 0, Dist: 0.5, Height: 0.7 },
    "eyebrows": { Angle: 0, Dist: 0.5, Height: 0.7 },
    "chesthair": { Angle: 0, Dist: 1, Height: 0.2 },
    "lenses": { Angle: 0, Dist: 0.5, Height: 0.7 },

    "torso": [
        { Angle: 0, Dist: 1, Height: 0.2 },
        { Angle: 0, Dist: 1, Height: 0.2 },
        { Angle: 0, Dist: 1, Height: 0.2 },
        { Angle: 180, Dist: 1, Height: 0.2 },
        { Angle: 180, Dist: 1, Height: 0.2 },
        { Angle: 180, Dist: 1, Height: 0.2 },
        { Angle: 180, Dist: 1, Height: 0.2 },
        { Angle: 305, Dist: 1, Height: 0.2 },
        { Angle: 55, Dist: 1, Height: 0.2 },
    ],
    "head": [
        { Angle: 0, Dist: 1, Height: 0.5 },
        { Angle: 305, Dist: 1, Height: 0.5 },
        { Angle: 55, Dist: 1, Height: 0.5 },
        { Angle: 180, Dist: 1, Height: 0.5 },
        { Angle: 0, Dist: 0.5, Height: 0.5 },
        { Angle: 0, Dist: 0.5, Height: 0.5 },
    ],
    "leftarm": [
        { Angle: 55, Dist: 1, Height: 0.0 },
        { Angle: 55, Dist: 1, Height: 0.1 },
        { Angle: 55, Dist: 1, Height: 0.1 },
    ],
    "rightarm": [
        { Angle: 305, Dist: 1, Height: 0.0 },
        { Angle: 305, Dist: 1, Height: 0.1 },
        { Angle: 305, Dist: 1, Height: 0.1 },
    ],
    "leftleg": [
        { Angle: 55, Dist: 1, Height: -0.6 },
        { Angle: 55, Dist: 1, Height: -0.6 },
    ],
    "rightleg": [
        { Angle: 305, Dist: 1, Height: -0.6 },
        { Angle: 305, Dist: 1, Height: -0.6 },
    ],
};

mp.events.add("ps_BodyCamera", () => {
    
	bodyCamStart = localplayer.position;
    var camValues = { Angle: localplayer.getRotation(2).z + 90, Dist: 2.6, Height: 0.2 };
    var pos = getCameraOffset(new mp.Vector3(bodyCamStart.x, bodyCamStart.y, bodyCamStart.z + camValues.Height), camValues.Angle, camValues.Dist);
    bodyCam = mp.cameras.new('default', pos, new mp.Vector3(0, 0, 0), 50);
    bodyCam.pointAtCoord(bodyCamStart.x, bodyCamStart.y, bodyCamStart.z + camValues.Height);
    bodyCam.setActive(true);
    mp.game.cam.renderScriptCams(true, false, 500, true, false);
	
	localplayer.taskPlayAnim("amb@world_human_guard_patrol@male@base", "base", 8.0, 1, -1, 1, 0.0, false, false, false);
});

mp.events.add("ps_SetCamera", (id) => {

	// torso
	var camValues = { Angle: 0, Dist: 1, Height: 0.2 };
	switch(id)
	{
		case 0: // Torso
		{
			camValues = { Angle: 0, Dist: 2.6, Height: 0.2 };
			break;
		}
		case 1: // Head
		{
			camValues = { Angle: 0, Dist: 1, Height: 0.5 };
			break;
		}
		case 2: // Hair / Bear / Eyebrows
		{
			camValues = { Angle: 0, Dist: 0.5, Height: 0.7 };
			break;
		}
		case 3: // chesthair
		{
			camValues = { Angle: 0, Dist: 1, Height: 0.2 };
			break;
		}
	}

	const camPos = getCameraOffset(new mp.Vector3(bodyCamStart.x, bodyCamStart.y, bodyCamStart.z + camValues.Height), localplayer.getRotation(2).z + 90 + camValues.Angle, camValues.Dist);
	//bodyCam.setCoord(camPos.x, camPos.y, camPos.z);
	//var bodyCam.pointAtCoord(bodyCamStart.x, bodyCamStart.y, bodyCamStart.z + camValues.Height);
	
});

mp.events.add("ps_DestroyCamera", () => {

    if (bodyCam == null) return;
    bodyCam.setActive(false);
    bodyCam.destroy();
    mp.game.cam.renderScriptCams(false, false, 3000, true, true);
	
    bodyCam = null;
});

mp.events.add("playScenario", () => {
	mp.players.local.taskStartScenarioInPlace('WORLD_HUMAN_CONST_DRILL', 0, false);
});

mp.events.add('screenFadeOut', function (duration) {
    mp.game.cam.doScreenFadeOut(duration);
});

mp.events.add('screenFadeIn', function (duration) {
    mp.game.cam.doScreenFadeIn(duration);
});

mp.events.add('showChat', function (enable) {
    mp.gui.chat.show(enable);
});

mp.events.add('enableInteriorProp', function (value, name) {
    mp.game.interior.enableInteriorProp(value, name);
	mp.game.interior.refreshInterior(value);
});

// Head Notification
class HeadNotification {
    constructor(text) {
        // why on earth does this take arguments? damn ragemp
        this.resolution = mp.game.graphics.getScreenActiveResolution(0, 0);

        this.text = text;
        this.startDuration = duration;

        this.alpha = 255;
        this.offset = 0;

        this.onUpdateEventHandler = mp.events.add('render', () => this.onUpdateHandler());
    }

    onUpdateHandler() {
        if (this.alpha <= 0) {
            return;
        }

        mp.game.graphics.drawText(
            this.text,
            [0.5, 0.5 + this.offset], {
            font: 4,
            color: [255, 255, 255, this.alpha],
            scale: [0.5, 0.5],
            outline: true
        });

        this.offset -= 0.0005;
        this.alpha -= 1;
    }
}

mp.events.add("createNewHeadNotificationAdvanced", (notificationText) => {
    new HeadNotification(notificationText);
});

mp.events.add("ShowSignToCreator", (dimension) => {
    mp.players.local.mugshotboard.show("NOVO PERSONAGEM", "", "000000001", "LOS SANTOS POLICE DEPT", 1, dimension);
});

// Peds
let Peds = [];
mp.events.add({

    "Sync_PedCreate": (name, model, position, heading = 0, callback, dimension = mp.players.local) => {
        let ped = mp.peds.new(model, position, heading, (streamPed) => streamPed.setAlpha(0), dimension);
        Peds[name] = ped;
		
		ped = mp.players.local.taskStartScenarioInPlace('CODE_HUMAN_MEDIC_TIME_OF_DEATH', -1, false);
		//ped.setSynchronizedSceneLooped("CODE_HUMAN_MEDIC_TIME_OF_DEATH", true);
    },
    
    "Sync_PedRemove": (name) => {
        if(!name) return;
        Peds[name].destroy();
        delete Peds[name];
    },

    "Sync_PutPedInVehicle": (name, veh, seat) => {
        if(!name || !veh) return;
        let ped = Peds[name];
        ped.taskEnterVehicle(veh.handle, -1, seat, 2, 16, 0);
    }

});

// Screen Effect and Drug Effects
mp.events.add("screen_cocaine", () => {
    mp.game.graphics.startScreenEffect("DrugsDrivingOut", 180000, false);
    //API.setPlayerIsDrunk(mp.players.local, true);
    mp.game.cam.shakeGameplayCam("DRUNK_SHAKE", 4);
});

mp.events.add("screen_cocaine_off", () => {
    mp.game.cam.stopGameplayCamShaking(true);
});

mp.events.add("screen_weed", () => {
    mp.game.graphics.startScreenEffect("DrugsMichaelAliensFight", 60000, false);
});

mp.events.add("screen_steroid", () => {
    mp.game.graphics.startScreenEffect("ChopVision", 60000, false);
});

mp.events.add("play_screen_effect", (effectName, duration, looped) => {
	mp.game.graphics.startScreenEffect(effectName, duration, looped);
});
	
mp.events.add("stop_screen_effect", (effectName) => {
    mp.game.graphics.stopScreenEffect(effectName);
});

// Attach
mp.events.add('attachObjectToPlayer', function (playerRemoteID, boneIndex, posOffset, rotOffset) {
	let playerHandle = mp.players.atHandle(playerRemoteID);
	playerHandle.getVariable('temp_object_handle').attachTo(playerHandle, playerHandle.getBoneIndex(boneIndex), posOffset.x, posOffset.y, posOffset.z, rotOffset.x, rotOffset.y, rotOffset.z, true, true, false, true, 0, true);
});

mp.events.add("attachEntityToEntityForVehicles", (entity1, entity2, boneName, posOffset, rotOffset) => {
    AttachEntityToEntityForVehicles(entity1, entity2, boneName, posOffset, rotOffset);
});

function AttachEntityToEntityForVehicles(entity1, entity2, boneName, posOffset, rotOffset) {
	if (entity1 !== null && entity2 !== null)
		entity1.attachTo(entity2.handle, entity2.getBoneIndexByName(boneName), posOffset.x, posOffset.y, posOffset.z, rotOffset.x, rotOffset.y, rotOffset.z, true, true, false, true, 0, true);
}

mp.events.add("attachEntityToEntity", (entity1, entity2, boneIndex, posOffset, rotOffset) => {
    if (entity1 !== null && entity2 !== null)
		AttachEntityToEntity(entity1, entity2, boneIndex, posOffset, rotOffset);
});

function AttachEntityToEntity(entity1, entity2, boneIndex, posOffset, rotOffset) {
    entity1.attachTo(entity2.handle, entity2.getBoneIndex(boneIndex), posOffset.x, posOffset.y, posOffset.z, rotOffset.x, rotOffset.y, rotOffset.z, true, true, false, true, 0, true);
}

mp.events.add('movePosition', function (x, y, z) {
	localplayer.clearTasks();
	localplayer.taskGoStraightToCoord(x, y, z, 1, -1, 270, 1.0);
});

// Follow
mp.events.add('setFollow', function (toggle, entity) {
    if (toggle) {
        if (entity && mp.players.exists(entity))
            localplayer.taskFollowToOffsetOf(entity.handle, 0, -1, 0, 1.0, -1, 1.0, true)
    }//0, -2, 0, 1.0, -1, 1.0
    else
        localplayer.clearTasks();
});

mp.events.add('spMode', function (toggle, target) {
    if (toggle) {
        if (target && mp.players.exists(target))
            localplayer.attachTo(target.handle, 0, 1, 1, 2, 0, 0, 0, true, true, false, false, 0, true);
    }
    else
        localplayer.detach(true, false);
});

// CANINE
var canineList = [];
var canineGroup = null; // Relationship group Hash/Int

mp.events.add({
		"create_canine": (id, player, unitType, pos, target) => {
            if (id === null || player === null || unitType === null || pos === null)
                return;

            var dist = mp.game.gameplay.getDistanceBetweenCoords(mp.players.local.position.x,
                                                                 mp.players.local.position.y,
                                                                 mp.players.local.position.z,
                                                                 pos.x,
                                                                 pos.y,
                                                                 pos.z, true);
            let unit = null;
            if (dist <= 350) {
                unit = mp.peds.new(mp.game.joaat(unitType), pos, 270.0, (streamPed) => {
                    streamPed.freezePosition(false);
                    streamPed.setRelationshipGroupHash(canineGroup);
                    streamPed.setCanBeDamaged(true);
                    streamPed.setInvincible(false);
                    streamPed.setCanRagdoll(true);
                    streamPed.setOnlyDamagedByPlayer(true);
                    streamPed.setCanRagdollFromPlayerImpact(true);
                    streamPed.setSweat(100);
                    streamPed.setRagdollOnCollision(true);

                    // Set all abilities and attributes needed for 'taskCombat' to work.
                    streamPed.setCombatAbility(100);
                    streamPed.setCombatRange(1);
                    streamPed.setCombatMovement(3);
                    streamPed.setCombatAttributes(46, true);
                    streamPed.setCombatAttributes(5, true);
                    streamPed.setFleeAttributes(0.0, false);
                }, player.dimension);
            }

            var canineUnit = new CanineUnit(id, player, unit, 0, target, pos, unitType);            
            canineList.push(canineUnit);

            if (mp.players.local === player)
                canineUnit.init();
        },

        "delete_canine": (id) => {
            var unit = null;

            unit = canineList.find(x => x.id === id)

            if (unit !== null && unit !== undefined) {
                unit.cleanUp();
                var index = canineList.indexOf(unit);
                if (index > -1) {
                    canineList.splice(index, 1);
                }
            }
        },

        "create_canine_relationship_group": () => {
            canineGroup = mp.game.ped.addRelationshipGroup("CanineGroup", mp.game.joaat("CanineGroup"));
            mp.game.ped.setRelationshipBetweenGroups(5, canineGroup, mp.players.local.getRelationshipGroupHash());
            mp.game.ped.setRelationshipBetweenGroups(5, mp.players.local.getRelationshipGroupHash(), canineGroup);
        },

        "update_canine_position": (id, x, y, z) => {
            const tempUnit = canineList.find(x => x.id === id)
            if (tempUnit !== null && tempUnit !== undefined) {
                // Save pos to variable
                tempUnit.position = new mp.Vector3(x, y, z);

                // Check if new position is within our streaming range
                if (tempUnit.position !== null && tempUnit.position !== undefined) {
                    var dist = mp.game.gameplay.getDistanceBetweenCoords(mp.players.local.position.x,
                                                                         mp.players.local.position.y,
                                                                         mp.players.local.position.z,
                                                                         tempUnit.position.x,
                                                                         tempUnit.position.y,
                                                                         tempUnit.position.z, true);
                    if (dist <= 350) {
                        if (tempUnit.canineHandle === null || tempUnit.canineHandle === undefined) {
                            let unit = mp.peds.new(mp.game.joaat(tempUnit.unitType), tempUnit.position, 270.0, (streamPed) => {
                                streamPed.freezePosition(false);
                                streamPed.setRelationshipGroupHash(canineGroup);
                                streamPed.setCanBeDamaged(true);
                                streamPed.setInvincible(false);
                                streamPed.setCanRagdoll(true);
                                streamPed.setOnlyDamagedByPlayer(true);
                                streamPed.setCanRagdollFromPlayerImpact(true);
                                streamPed.setSweat(100);
                                streamPed.setRagdollOnCollision(true);

                                // Set all abilities and attributes needed for 'taskCombat' to work.
                                streamPed.setCombatAbility(100);
                                streamPed.setCombatRange(1);
                                streamPed.setCombatMovement(3);
                                streamPed.setCombatAttributes(46, true);
                                streamPed.setCombatAttributes(5, true);
                                streamPed.setFleeAttributes(0.0, false);
                            }, 0);
                            tempUnit.canineHandle = unit;
                            tempUnit.setState();
                            tempUnit.playAnim();
                        }
                    }
                    // Else if distance is greater than 350, we should delete the entity just before reaching the 500 mark,
                    // or we'll lose control of it. Delete to avoid desync!
                    else {
                        if (tempUnit.canineHandle !== null && tempUnit.canineHandle !== undefined && tempUnit.canineHandle.doesExist()) {
                            tempUnit.canineHandle.destroy();
                            tempUnit.canineHandle = null;
                        }
                    }
                }
            }
        },

        "update_canine_state": (id, state, target) => {
            const tempUnit = canineList.find(x => x.id === id)
            if (tempUnit !== null && tempUnit !== undefined) {
                tempUnit.state = state;
                if (target !== null && target !== undefined)
                    tempUnit.targetHandle = target;
                tempUnit.animInfo = null;
                tempUnit.setState();
            }
        },

        "play_canine_anim": (id, animDict, animName, loop) => {
            const tempUnit = canineList.find(x => x.id === id)
            if (tempUnit !== null && tempUnit !== undefined) {
                if (loop) {
                    // If the anim is set to loop, we'll need to store it,
                    // so players who streamin will also see the anim playing.
                    tempUnit.animInfo = [];
                    tempUnit.animInfo[0] = animDict;
                    tempUnit.animInfo[1] = animName;
                    tempUnit.playAnim();
                }
                // Otherwise just play the anim once for those in range.
                else {
                    if (tempUnit.canineHandle !== null && tempUnit.canineHandle !== undefined && tempUnit.canineHandle.doesExist()) {
                        mp.game.streaming.requestAnimDict(animDict);
                        while (!mp.game.streaming.hasAnimDictLoaded(animDict)) mp.game.wait(0);

                        tempUnit.canineHandle.taskPlayAnim(animDict, animName, 8.0, 0, -1, 0, 0.0, false, false, false);
                    }
                }
            }
        }
});
		
// Canine
class CanineUnit {
    constructor(id, ownerHandle, canineHandle, state, targetHandle, position, unitType) {
        this.id = id;
        this.ownerHandle = ownerHandle;
        this.canineHandle = canineHandle;
        this.state = state;
        this.targetHandle = targetHandle;
        this.posTimer = null;
        this.distTimer = null;
        this.position = position;
        this.unitType = unitType;
        this.animInfo = null;
    }

    init() {
        // Only call init() for the owner of the K-9
        this.posTimer = setInterval(() => {
            this.sendPositionLoop();
        }, 1000);

        this.distTimer = setInterval(() => {
            this.checkDistanceLoop();
        }, 2000);
    }

    sendPositionLoop() {
        if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist()) {
            var coord = this.canineHandle.getCoords(true);
            this.position = coord;
			if (coord != null)
				mp.events.callRemote('update_canine_position', this.ownerHandle, coord.x, coord.y, coord.z);
        }
    }

    checkDistanceLoop() {
        if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist()) {
            // Check if distance is more than streaming range.
            var coords = this.canineHandle.getCoords(true);
            var dist = mp.game.gameplay.getDistanceBetweenCoords(mp.players.local.position.x,
                                                                mp.players.local.position.y,
                                                                mp.players.local.position.z,
                                                                coords.x,
                                                                coords.y,
                                                                coords.z, true);
            if (dist >= 350)
                mp.events.callRemote('force_delete_canine', this.ownerHandle);
        }
    }

    cleanUp() {
        // Clean up everything
        if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist())
            this.canineHandle.destroy()

        if (this.posTimer !== null && this.posTimer !== undefined)
            clearInterval(this.posTimer);

        if (this.distTimer !== null && this.distTimer !== undefined)
            clearInterval(this.distTimer);
    }

    playAnim() {
        if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist())
        {
            if (this.animInfo !== null && this.animInfo !== undefined) {
                mp.game.streaming.requestAnimDict(this.animInfo[0]);
                while (!mp.game.streaming.hasAnimDictLoaded(this.animInfo[0])) mp.game.wait(0);

                this.canineHandle.taskPlayAnim(this.animInfo[0], this.animInfo[1], 8.0, 0, -1, 1, 0.0, false, false, false);
            }
        }
    }

    setState() {
        switch (this.state) {
            case 0: // Idle
                if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist()) {
                    this.canineHandle.clearTasksImmediately();
                }
                break;
            case 1: // Follow me
                if (this.ownerHandle !== null && this.ownerHandle !== undefined && mp.players.exists(this.ownerHandle))
                {
                    if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist())
                    {
                        this.canineHandle.clearTasksImmediately();
                        this.canineHandle.taskFollowToOffsetOf(this.ownerHandle.handle, 0, 0, 0, 5, -1, 10.0, true);
                    } 
                }
                break;
            case 2: // Goto me
                if (this.ownerHandle !== null && this.ownerHandle !== undefined && mp.players.exists(this.ownerHandle))
                {
                    if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist())
                    {
                        this.canineHandle.clearTasksImmediately();
                        var pos = this.ownerHandle.position;
                        this.canineHandle.taskGoStraightToCoord(pos.x, pos.y, pos.z, 5, -1, 270, 1.0);
                    }
                }
                break;
            case 3: // Attack
                if (this.targetHandle !== null && this.targetHandle !== undefined && mp.players.exists(this.targetHandle))
                {
                    if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist())
                    {
                        this.canineHandle.clearTasksImmediately();
                        this.canineHandle.taskCombat(this.targetHandle.handle, 0, 16);
                    }
                }
                break;
            case 4: // Tackle
                if (this.targetHandle !== null && this.targetHandle !== undefined && mp.players.exists(this.targetHandle))
                {
                    if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist())
                    {
                        this.canineHandle.clearTasksImmediately();
                        this.canineHandle.taskCombat(this.targetHandle.handle, 0, 16);
                    }
                }
                break;
            case 5: // WanderTrack
                if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist())
                {
                    this.canineHandle.clearTasksImmediately();
                    this.canineHandle.taskWanderInArea(this.position.x, this.position.y, this.position.z, 50, 0, 0);
                    if (this.ownerHandle !== null && this.ownerHandle !== undefined && mp.players.exists(this.ownerHandle))
                    {
                        if (this.ownerHandle === mp.players.local)
                        {
                            setTimeout(() => {
                                mp.events.callRemote('canine_wandertrack_completed');
                            }, 12000);
                        }
                    }
                }
                break;
            case 6: // Track
                if (this.targetHandle !== null && this.targetHandle !== undefined && mp.players.exists(this.targetHandle))
                {
                    if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist())
                    {
                        this.canineHandle.clearTasksImmediately();
                        var pos = this.targetHandle.position;
                        this.canineHandle.taskGoStraightToCoord(pos.x, pos.y, pos.z, 10.0, -1, 270, 1.0);
                    }
                }
                break;
            case 7: // Wander
                if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist()) {
                    this.canineHandle.clearTasksImmediately();
                    this.canineHandle.taskWanderInArea(this.position.x, this.position.y, this.position.z, 50, 0, 0);
                }
                break;
            default:
                break;
        }
    }
}
