// ****************************************************************
// * MibAjaxCache 
// ***************************************************************
function MibAjaxCache() {
}
MibAjaxCache.prototype.items = this.items = Array();

// ****************************************************************
// * MibAjaxCache Methods
// ***************************************************************
MibAjaxCache.prototype.Add = function (item) {
    this.items.push(item);
}
MibAjaxCache.prototype.Get = function (url) {
    for (var i = 0; i < this.items.length; i++) {
        if (this.items[i].cacheKey == url) {
            return this.items[i];
        }
    }
    return null;
}

// ****************************************************************
// * MibAjaxManager
// ***************************************************************
function MibAjaxManager() {
}
MibAjaxManager.prototype.CreateLoading = function () { };
MibAjaxManager.prototype.DestroyLoading = function () { };
MibAjaxManager.prototype.Cache = new MibAjaxCache();

// ****************************************************************
// * MibAjaxManager Methods
// ***************************************************************
MibAjaxManager.prototype.Get = function (url, useCache, beginRequest, parseRequest, endRequest, requestError, contentType) {
    var urlPath = url.toString().split(/\?/)[0];
    var data = url.toString().split(/\?/)[1];

    if (!contentType) contentType = 'html';

    var item =
    {
        beforeSend: beginRequest,
        type: "POST",
        cacheKey: url,
        url: urlPath,
        data: data,
        error: requestError,
        complete: endRequest,
        cache: useCache,
        success: parseRequest,
        dataType: contentType
    }

    if (useCache) {
        var ajaxItem = this.Cache.Get(url);
        if (ajaxItem) {
            if (ajaxItem.beforeSend) ajaxItem.beforeSend();
            ajaxItem.success(ajaxItem.content);
            if (ajaxItem.complete) ajaxItem.complete();
        }
        else {
            this.Cache.Add(item);
            $.ajax(item);
        }
    }
    else {
        $.ajax(item);
    }
}
MibAjaxManager.prototype.GetContent = function (url, target, useCache, beginRequest, endRequest, requestError) {
    this.Get(
		url,
		useCache,
		beginRequest ? beginRequest : this.CreateLoading,
		function (content) {
		    $(target).html(content);
		    this.content = content;
		},
		endRequest ? endRequest : this.DestroyLoading,
		requestError,
		'html'
	);
}
MibAjaxManager.prototype.GetJson = function (url, callback, useCache, beginRequest, endRequest, requestError) {
    this.Get(
		url,
		useCache,
		beginRequest ? beginRequest : this.CreateLoading,
        callback,
		endRequest ? endRequest : this.DestroyLoading,
		requestError,
		'json'
	);
}
MibAjaxManager.prototype.GetScript = function (url, callback, useCache, beginRequest, endRequest, requestError) {
    this.Get(
		url,
		useCache,
		beginRequest ? beginRequest : this.CreateLoading,
        callback,
		endRequest ? endRequest : this.DestroyLoading,
		requestError,
		'script'
	);
}

var mibAjaxManager = new MibAjaxManager();

// ****************************************************************
// * UrlBuilder
// ***************************************************************
function Url() { }
Url.Build = function (selector, url) {
    url = url ? url : "";

    var list = jQuery(selector);
    if (url.indexOf("?", 0) < 0) {
        url += "?";
    }
    else {
        url += "&";
    }
    for (var i = 0; i < list.length; i++) {
        url += list[i].id + "=" + list[i].value;
        if (i < list.length - 1) {
            url += "&";
        }
    }
    return url;
}