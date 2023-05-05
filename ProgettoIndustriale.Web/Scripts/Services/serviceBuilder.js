import ApiCallerHelper from "./apiCallerHelper";
import ApiCallerCommon from "./apiCallerCommon";
import ApiCallerProtocollo from "./apiCallerProtocollo";
import ApiCallerEnti from "./apiCallerEnti";
import ApiCallerPersone from "./apiCallerPersone";

class Services {

    get apiCallerHelper() {
        return new ApiCallerHelper();
    }

    get apiCallerCommon() {
        return new ApiCallerCommon(this.apiCallerHelper);
    }

    get apiCallerProtocollo() {
        return new ApiCallerProtocollo(this.apiCallerHelper);
    }
    
    get apiCallerEnti() {
        return new ApiCallerEnti(this.apiCallerHelper);
    }
    
    get apiCallerPersone() {
        return new ApiCallerPersone(this.apiCallerHelper);
    }
    
    getDialogWidthVuetify(breakpoint) {
        switch (breakpoint) {
            case "xs":
                return 350;
            case "sm":
                return 550;
            case "md":
                return 650;
            case "lg":
                return 750;
            case "xl":
                return 1000;
        }
    }
}

Vue.prototype.getElementStyle = function (dark, request) {
    switch (request) {
        case "iconColor":
            return dark ? "myWaiBackgroundColorDark" : "myWaiBackgroundColorLight";
        case "backgroundColor":
            return dark ? "myWaiBackgroundColorDark" : "myWaiBackgroundColor";
        case "menuColor":
            return dark ? "darkmyWaiBackgrounColor myWaiColorTextGreen" : "myWaiBackgroundColor myWaiColorTextWhite";
        case "tabColor":
            return dark ? "darkmyWaiBackgrounColor myWaiColorTextWhite" : "myWaiBackgroundColor myWaiColorTextWhite";
        case "textColor":
            return dark ? "myWaiColorTextWhite" : "myWaiColor";
        case "tabtextColor":
            return dark ? "pa-4 ma-0 myWaiColorTextWhite" : "pa-4 ma-0 myWaiColor";
        case "bttextColor":
            return dark ? "d-flex justify-end align-center myWaiColorTextWhite" : "d-flex justify-end align-center myWaiColor";
        case "leftbar":
            return dark ? "darkTheme" : "lightTheme";
        case "overlay":
            return dark ? "darkOverlay" : "lightOverlay";
        case "textColorFocused":
            return dark ? "myWaiColorTextDark" : "myWaiColorText";
    }

    return null;
};

export var services = new Services();
