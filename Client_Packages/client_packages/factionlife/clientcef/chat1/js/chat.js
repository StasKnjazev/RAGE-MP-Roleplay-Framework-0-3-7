const chat =
{
	size: 0,
	container: null,
	input: null,
	enabled: false,
    timer: null,
    current: 1,
    previous: [],
	hide_chat: 15000
}
const chatAPI =
{
	push: (args) =>
	{
        let arr = args.split("(/\)");
        let d = new Date();
            d.setHours(d.getHours() + d.getTimezoneOffset()/60 - 4);

            if(arr.length == 1) {
                arr = [(d.getHours() + ':' + ((d.getMinutes() < 10) ? '0' : '') + d.getMinutes()),'<font style="color: orange !important;">Server</font>',arr[0]];
            }
		chat.size++;
		if (chat.size >= 50)
		{
			chat.container.children(":first").remove();
        }

        chat.container.append('<li><span class="time">' + (d.getHours() + ':' + ((d.getMinutes() < 10) ? '0' : '') + d.getMinutes()) + '</span><span class="name">' + arr[1] + ' :</span><span class="msg">' + arr[2] + '</span></li>');
        chat.container.scrollTop(9999);
        show();
        hide();
	},
	clear: () =>
	{
        chat.container.html("");
        chat.previous = [];
	},
	activate: (toggle) =>
	{
        if (!toggle) enableChatInput(false);
	},
	show: (toggle) =>
	{
		if(toggle) {
            $("#chat").show();
        } else $("#chat").hide();
	}
}
function enableChatInput(enable)
{
    if(enable == "true") {
        show();
        chat.current = 1;
        chat.input.val('');
        chat.input.fadeIn().focus();
    } else {
        chat.input.val('');
        chat.input.fadeOut();
    }

    chat.enabled = (enable == "true");
}
function hide() {
    chat.timer = setTimeout(function () {
        $("#chat").css("opacity", 0.2);
        $(".background").css("opacity", 0);
		$("#chat_messages").css("overflow",'hidden');
    }, chat.hide_chat);
}
function show() {
    clearTimeout(chat.timer);
    $("#chat").css("opacity", 1);
    $(".background").css("opacity", 0.1);
	$("#chat_messages").css("overflow",'overlay');
}
function previous() {
    if(!chat.enabled) return false;
    if(!chat.previous.length) return false;

    if((chat.previous.length - chat.current) < 0) return false;

    chat.input.val(chat.previous[chat.previous.length - chat.current]);
    chat.current++;
}
function next() {
    if(!chat.enabled) return false;
    if(!chat.previous.length) return false;
    if(chat.current == 1) return chat.input.val('');

    chat.current--;
    chat.input.val(chat.previous[chat.previous.length - chat.current]);
}
function sendMsg() {
    let msg = chat.input.val();

    if(msg.length > 0 && msg.length <= 200) {
        if(msg[0] == '/') {
            mp.invoke("command", msg.substring(1));
        } else 
		{
			mp.trigger("Send_ToServer", msg);
			//mp.invoke("chatMessage", msg);
		}
		
        if(chat.previous.length >= 20) chat.previous.splice(0, 1);
        chat.previous.push(msg);
    } else if(msg.length > 200) {}
}

$("body").on('input', '#chat_msg', function() {
    if(!chat.enabled) return $(this).val('');

    let value = $(this).val();

    if(value.length > 200) $(this).val(value.substring(0, 200));
});
$(document).ready(function() {
    chat.input = $("#chat_msg");
    chat.container = $("#chat ul#chat_messages");
    hide();
});
