document.addEventListener('DOMContentLoaded', function () {
    var connection = new signalR.HubConnectionBuilder()
        .withUrl("/chatHub")
        .build();

    connection.on("ReceiveMessage", function (message) {
        var li = document.createElement("li");
        li.textContent = message;
        document.getElementById("messages").appendChild(li);
    });

    connection.start().catch(function (err) {
        return console.error(err.toString());
    });

    var chatPopup = document.getElementById("chatPopup");
    var openChatBtn = document.getElementById("openChatBtn");
    var closeChatBtn = document.getElementById("closeChatBtn");
    var sendMessageBtn = document.getElementById("sendMessageBtn");
    var messageInput = document.getElementById("messageInput");
    var messagesList = document.getElementById("messages");

    function sendMessage() {
        var messageContent = messageInput.value.trim();

        if (messageContent) {
            // 将消息添加到聊天内容中
            var newMessageElement = document.createElement("li");
            newMessageElement.textContent = messageContent;
            messagesList.appendChild(newMessageElement);

            // 清空输入框
            messageInput.value = "";

            // 用于发送消息到服务器的代码（如使用 SignalR）
            connection.invoke("SendMessage", messageContent).catch(function (err) {
                return console.error(err.toString());
            });
        }
    }

    // 为发送按钮添加事件监听器
    sendMessageBtn.addEventListener("click", function () {
        event.preventDefault();
        sendMessage();
    });

    // 如果您希望在按下 Enter 键时发送消息，您还可以添加以下代码：
    messageInput.addEventListener("keyup", function (event) {
        if (event.key === "enter") {
            sendMessage();
        }
    });

    if (openChatBtn && closeChatBtn && chatPopup) {
        openChatBtn.addEventListener("click", function () {
            chatPopup.style.display = "flex";
            openChatBtn.style.display = "none";
        });

        closeChatBtn.addEventListener("click", function () {
            chatPopup.style.display = "none";
            openChatBtn.style.display = "block";
        });
    }
});
