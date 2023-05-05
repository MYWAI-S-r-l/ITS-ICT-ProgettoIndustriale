let commonModule = (function () {

    'use strict';

    // larghezza browser
    let browserWidth = function () {
        return Math.max(
            document.body.scrollWidth,
            document.documentElement.scrollWidth,
            document.body.offsetWidth,
            document.documentElement.offsetWidth,
            document.documentElement.clientWidth
        );
    };

    // altezza browser
    let browserHeight = function () {
        return Math.max(
            document.body.scrollHeight,
            document.documentElement.scrollHeight,
            document.body.offsetHeight,
            document.documentElement.offsetHeight,
            document.documentElement.clientHeight
        );
    };

    // add a single class
    let addClass = function (id, className, setParent) {
        if (typeof id === "undefined" || typeof className === "undefined")
            return;
        if (typeof setParent === "undefined")
            setParent = false;
        if (id.substring(0, 1) != "#" && id.substring(0, 1) != ".")
            id = "#".concat(id);
        if (setParent) {
            if (!$(id).parent().hasClass(className))
                $(id).parent().addClass(className);
        } else {
            if (!$(id).hasClass(className))
                $(id).addClass(className);
        }
    };

    // remove a single class
    let removeClass = function (id, className, setParent) {
        if (typeof id === "undefined" || typeof className === "undefined")
            return;
        if (typeof setParent === "undefined")
            setParent = false;
        if (id.substring(0, 1) != "#" && id.substring(0, 1) != ".")
            id = "#".concat(id);
        if (setParent) {
            if ($(id).parent().hasClass(className))
                $(id).parent().removeClass(className);
        } else {
            if ($(id).hasClass(className))
                $(id).removeClass(className);
        }
    };

    return {
        appBaseUrl: "",    // base URL app,
        webApiBaseUrl: "",      // base URL web API
        webBaseUrl: "",      // base URL API
        addClass: addClass,
        browserHeight: browserHeight,
        browserWidth: browserWidth,
        removeClass: removeClass
    };
})();

