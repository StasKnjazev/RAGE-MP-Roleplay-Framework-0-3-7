global.circleEntity = null;
global.circleOpen = false;
var circleTitle = "";

function OpenCircle(title, data) {
    if (menuCheck() || circleOpen) return;
    board.execute(`circle.show("${title}",${data})`);
    circleTitle = title;
    circleOpen = true;
    menuOpen();
}
function CloseCircle(hide) {
    if(hide) board.execute("circle.hide()");
    circleOpen = false;
    menuClose();
}

// // //
mp.events.add('circleCallback', (index) => {
    if (index == -1) {
        CloseCircle(false);
    } else {
        CloseCircle(false);
        switch (circleTitle) {
            case "Fahrzeug":
                switch (index) {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        if (entity == null) return;
                        mp.events.callRemote('keypress:INSERT', entity, index);
                        return;
                }
                return;
        }
    }
});