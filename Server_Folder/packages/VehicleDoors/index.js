mp.events.add({
    'entityCreated' : (entity) => {
        if(entity.type == 'vehicle') {
            entity.doors = [0,0,0,0,0,0,0]
        }
    },
    'server.vehicles.sync.doors' : (player, vehicle, doors) => {
        vehicle.doors = JSON.parse(doors);
        mp.players.call(player.streamedPlayers, 'client.vehicles.sync.doors', [vehicle, JSON.stringify(vehicle.doors)]);
        player.call('client.vehicles.sync.doors', [vehicle, JSON.stringify(vehicle.doors)]);
    },
    'server.vehicles.get.sync.doors' : (player, vehicle) => {
        if(typeof vehicle.doors == 'object') {
            player.call('client.vehicles.sync.doors', [vehicle, JSON.stringify(vehicle.doors)]);
        }
    }
})

// test command
mp.events.addCommand({
    'v' : (player, name) => {
        //if(!name) return player.outputChatBox('/v [vehicle name]')
        if(typeof player.veh !== 'undefined') player.veh.destroy();
        player.veh = mp.vehicles.new(mp.joaat(name), new mp.Vector3(player.position.x + 1.2, player.position.y, player.position.z), {});
    }
})