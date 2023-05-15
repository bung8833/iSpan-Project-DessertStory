(function () {
    if (window.signalRConnection) {
        return;
    }

    var connection = new signalR.HubConnectionBuilder()
        .withUrl("/chatHub")
        .build();

    window.signalRConnection = connection;

    connection.on("ReceiveMessage", function (username, message, timestamp) {
        var li = document.createElement("li");
        li.textContent = username + ": " + message + " (" + new Date(timestamp).toLocaleTimeString() + ")";
        document.getElementById("chatroom").appendChild(li);
        var chatroom = document.getElementById("chatroom");
        chatroom.scrollTop = chatroom.scrollHeight;
    });

    connection.start().then(function () {
        connection.invoke("GetChatHistory").catch(function (err) {
            return console.error(err.toString());
        });
    }).catch(function (err) {
        return console.error(err.toString());
    });

    var chatForm = document.getElementById("chat-form");
    var chatInput = document.getElementById("new-chat-input");
    var usernameInput = document.getElementById("username-input");
    var chatroom = document.getElementById("chatroom");
    function sendMessage() {
        var messageContent = chatInput.value.trim();
        var username = usernameInput.value.trim();

        if (messageContent && username) {
            // 清空输入框
            chatInput.value = "";

            // 用于发送消息到服务器的代码（如使用 SignalR）
            connection.invoke("SendMessage", username, messageContent).catch(function (err) {
                return console.error(err.toString());
            });
        }
    }
    // 为发送按钮添加事件监听器
    chatForm.addEventListener("submit", function (event) {
        event.preventDefault();
        sendMessage();
    });
    // 如果您希望在按下 Enter 键时发送消息，您还可以添加以下代码：
    chatInput.addEventListener("keyup", function (event) {
        if (event.key === "Enter") {
            event.preventDefault();
            sendMessage();
        }
    });
})();