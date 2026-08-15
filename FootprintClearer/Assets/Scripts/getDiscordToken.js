function sendToAvalonia(data) {
    invokeCSharpAction(data);
}

function setUpLogger() {
    sendToAvalonia("Test");
    try {
        const originalXhrOpen = XMLHttpRequest.prototype.open;
        XMLHttpRequest.prototype.open = function (method, url) {
            this._url = url;
            return originalXhrOpen.apply(this, arguments);
        };

        const originalXhrSend = XMLHttpRequest.prototype.send;
        XMLHttpRequest.prototype.send = function (body) {
            
            sendToAvalonia(this.responseText)
            
            this.addEventListener("load", () => {
                const url = this._url ?? "";

                if (!url.includes("auth")) return;

                try {
                    const data = JSON.parse(this.responseText);

                    if (typeof data.token === "string") {
                        sendToAvalonia(data.token);
                    }
                } catch {
                }
            });

            return originalXhrSend.apply(this, arguments);
        };
        
        const originalWebSocket = window.WebSocket;
        const webSocketProxy = function(url, protocols) {
            let ws;
            if (arguments.length > 1) {
                ws = new originalWebSocket(url, protocols);
            } else {
                ws = new originalWebSocket(url);
            }
            
            ws.addEventListener('message', (event) => {
                sendToAvalonia("Incoming:");
                sendToAvalonia(event.data);
            })
            
            const originalSend = ws.send;
            ws.send = (data) => {
                sendToAvalonia("Outgoing:")
                sendToAvalonia(data)
                originalSend(data);
            }
            
            return ws;
        }
        window.WebSocket = webSocketProxy;
        window.WebSocket.prototype = webSocketProxy.prototype;
        window.WebSocket.prototype.constructor = webSocketProxy;
        
    } catch (error) {
        return error.toString();
    }
    return "finished";
}

window.addEventListener("load", setUpLogger)
