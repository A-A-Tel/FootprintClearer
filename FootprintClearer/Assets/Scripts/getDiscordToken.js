// make sure the url is included in the request
const originalXhrOpen = XMLHttpRequest.prototype.open;
XMLHttpRequest.prototype.open = function (method, url) {
    this._url = url;
    return originalXhrOpen.apply(this, arguments);
};

const originalXhrSend = XMLHttpRequest.prototype.send;
XMLHttpRequest.prototype.send = function (body) {
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
