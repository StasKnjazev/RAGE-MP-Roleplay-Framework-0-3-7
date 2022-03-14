var voice=0;

function update() {
	if (voice === 0){
		document.getElementById("voice").style.backgroundImage='url("./laut0.png")';
	} else if (voice === 1){
		document.getElementById("voice").style.backgroundImage='url("./laut1.png")';
	} else if (voice === 2){
		document.getElementById("voice").style.backgroundImage='url("./laut2.png")';
	} else if (voice === 3){
		document.getElementById("voice").style.backgroundImage='url("./laut3.png")';
	} else if (voice === 4){
		document.getElementById("voice").style.backgroundImage='url("./laut4.png")';
	}
}

function setMicroValue(set) {
	voice = parseInt(set);
	update();
}

mp.events.add('setMicroValue', setMicroValue);