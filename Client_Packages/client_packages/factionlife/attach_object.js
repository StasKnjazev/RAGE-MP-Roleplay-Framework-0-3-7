var attachedObjects = [];

mp.events.add('attachObject', attachObject);
mp.events.add('detachObject', function (player) {
    try {
        if (player && mp.players.exists(player)) {
            if (attachedObjects[player.id] != undefined) attachedObjects[player.id].destroy();
            attachedObjects[player.id] = undefined;
        }
    } catch (e) { } 
});

function attachObject(player) {
    try {
        if (player && mp.players.exists(player)) {
            if (attachedObjects[player.id] != undefined) attachedObjects[player.id].destroy();

            if (player.getVariable('attachedObject') == null) return;
            let data = JSON.parse(player.getVariable('attachedObject'));
            let boneID = player.getBoneIndex(data[0].Bone);
			let objectId = mp.game.joaat(data[0].Model);
            var object = mp.objects.new(objectId, player.position,
                {
                    rotation: new mp.Vector3(0, 0, 0),
                    alpha: 255,
                    dimension: player.dimension
                });
            object.attachTo(player.handle, boneID, data[0].PosOffset.x, data[0].PosOffset.y, data[0].PosOffset.z, data[0].RotOffset.x, data[0].RotOffset.y, data[0].RotOffset.z, true, true, false, false, 0, true);
            attachedObjects[player.id] = object;
        }
    } catch (e) { } 
}

mp.events.add('toggleInvisible', function (player, toggle) {
    try {
        if (player && mp.players.exists(player)) {
            if (toggle)
                player.setAlpha(0);
            else
                player.setAlpha(255);
        }
    } catch (e) { }
});

mp.events.add("playerQuit", function (player, exitType, reason) {
    try {
        if (attachedObjects[player.id] != undefined) {
            attachedObjects[player.id].destroy();
            attachedObjects[player.id] = undefined;
        }
    } catch (e) { }
});
mp.events.add('entityStreamOut', function (entity) {
    try {
        if (entity.type != 'player') return;
        if (attachedObjects[entity.id] != undefined) {
            attachedObjects[entity.id].destroy();
            attachedObjects[entity.id] = undefined;
        }
    } catch (e) { } 
});
mp.events.add('entityStreamIn', function (entity) {
    try {
        if (entity.type !== 'player') return;
        attachObject(entity);

        if (entity.getVariable('INVISIBLE') == true)
            entity.setAlpha(0);
    } catch (e) { }
});