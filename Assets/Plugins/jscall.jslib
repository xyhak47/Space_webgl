mergeInto(LibraryManager.library,{


InitJS : function()
{
	var KKJSBridge =  
	(
		function () 
		{
			function KKJSBridge()
			{
		        this.uniqueId = 1;
		        this.callbackCache = {};
		        this.eventCallbackCache = {};
		    }


	       	KKJSBridge.prototype.callNative = function (module, method, data, callback) 
	       	{
		        var message = {
		            module: module || 'default',
		            method: method,
		            data: data,
		            callbackId: null
		        };
		        if (callback) {
		            var callbackId = 'cb_' + message.module + '_' + method + '_' + (this.uniqueId++) + '_' + new Date().getTime();
		            this.callbackCache[callbackId] = callback;
		            message.callbackId = callbackId;
		        }
		        window.webkit.messageHandlers.KKJSBridgeMessage.postMessage(message);
		    };


	       	KKJSBridge.prototype._handleMessageFromNative = function (messageString) 
	       	{
		        var callbackMessage = JSON.parse(messageString);
		        if (callbackMessage.messageType === "callback" ) { 
		            var callback = this.callbackCache[callbackMessage.callbackId];
		            if (callback) { 
		                callback(callbackMessage.data);
		                this.callbackCache[callbackMessage.callbackId] = null;
		                delete this.callbackCache[callbackMessage.callbackId];
		            }
		        }
		        else if (callbackMessage.messageType === "event") { 
		            var eventCallback = this.eventCallbackCache[callbackMessage.eventName];
		            if (eventCallback) {
		                eventCallback(callbackMessage.data);
		            }
		        }
		    };


		    KKJSBridge.prototype.call = function (module, method, data, callback) 
		    {
		        this.callNative(module, method, data, callback);
		    };


		    KKJSBridge.prototype.on = function (eventName, callback) 
		    {
		        this.eventCallbackCache[eventName] = callback;
		    };


		    return KKJSBridge;
		}()
	);

	var KKJSBridgeInstance = new KKJSBridge();
	window.KKJSBridge = KKJSBridgeInstance;
},


NikeShop : function ()
{
	window.KKJSBridge.call('router', 'open', {link:'here://shop?name=nike'}, function(res) { console.log(res); });
  	//window.webkit.messageHandlers.open.postMessage({'link':'here://shop?name=nike'});
},


});
