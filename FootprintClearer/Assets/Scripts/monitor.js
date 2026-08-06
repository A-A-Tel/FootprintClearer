// const originalFetch = window.fetch;
// window.fetch = async (input, init) => {
//     const response = await originalFetch(input, init);
//
//     if (typeof invokeCSharpAction === 'function') {
//         invokeCSharpAction(`Fetch Request to: ${typeof input === 'string' ? input : input.url}`);
//     }
//
//     return response;
// };
//
// const originalXhrSend = XMLHttpRequest.prototype.send;
// XMLHttpRequest.prototype.send = function(body) {
//    
//     this.addEventListener('load', () => {
//         invokeCSharpAction(`XHR Request Completed: ${this._url || 'Unknown URL'} | Status: ${this.status}`);
//     });
//
//     return originalXhrSend.apply(this, arguments);
// };
//
// const originalXhrOpen = XMLHttpRequest.prototype.open;
// XMLHttpRequest.prototype.open = function(method, url) {
//     this._url = url;
//     return originalXhrOpen.apply(this, arguments);
// };
//
// sendToAvalonia("What the fuck");

sendToAvalonia("Hello")
