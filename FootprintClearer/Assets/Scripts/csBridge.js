function getAvaloniaSender() {
    if (typeof invokeCSharpAction === "function") {
        return invokeCSharpAction;
    }

    const webkitHandler = window.webkit?.messageHandlers?.avalonia;
    if (webkitHandler?.postMessage) {
        return webkitHandler.postMessage.bind(webkitHandler);
    }

    if (window.avalonia?.postMessage) {
        return window.avalonia.postMessage.bind(window.avalonia);
    }

    return msg => console.log("[Dev Log]: ", msg);
}

const sendToAvalonia = getAvaloniaSender();