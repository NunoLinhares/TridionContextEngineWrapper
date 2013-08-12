package com.sdl.tridion.context;

import java.net.URI;

public class ClaimUris {
	private static final String UriContext = "taf:claim:context:";
    private static final String UriDevice = UriContext + "device:";
    private static final String UriBrowser = UriContext + "browser:";
    private static final String UriOs = UriContext + "os:";

        
    public static URI UriCookieSupport = URI.create(UriBrowser + "cookieSupport");
    public static URI UriCssVersion = URI.create(UriBrowser + "cssVersion");
    public static URI UriDisplayColorDepth = URI.create(UriBrowser + "displayColorDepth");
    public static URI UriBrowserDisplayHeight = URI.create(UriBrowser + "displayHeight");
    public static URI UriBrowserDisplayWidth = URI.create(UriBrowser + "displayWidth");
    public static URI UriImageFormatSupport = URI.create(UriBrowser + "imageFormatSupport");
    public static URI UriInputDevices = URI.create(UriBrowser + "inputDevices");
    public static URI UriInputModeSupport = URI.create(UriBrowser + "inputModeSupport");
    public static URI UriJsVersion = URI.create(UriBrowser + "jsVersion");
    public static URI UriMarkupSupport = URI.create(UriBrowser + "markupSupport");
    public static URI UriBrowserModel = URI.create(UriBrowser + "model");
    public static URI UriPreferredHtmlContentType = URI.create(UriBrowser + "preferredHtmlContentType");
    public static URI UriScriptSupport = URI.create(UriBrowser + "scriptSupport");
    public static URI UriStylesheetSupport = URI.create(UriBrowser + "stylesheetSupport");
    public static URI UriBrowserVariant = URI.create(UriBrowser + "variant");
    public static URI UriBrowserVendor = URI.create(UriBrowser + "vendor");
    public static URI UriBrowserVersion = URI.create(UriBrowser + "version");

    public static URI UriDeviceDisplayHeight = URI.create(UriDevice + "displayHeight");
    public static URI UriDeviceDisplayWidth = URI.create(UriDevice + "displayWidth");
    public static URI UriMobile = URI.create(UriDevice + "mobile");
    public static URI UriDeviceModel = URI.create(UriDevice + "model");
    public static URI UriPixelDensity = URI.create(UriDevice + "pixelDensity");
    public static URI UriPixelRatio = URI.create(UriDevice + "pixelRatio");
    public static URI UriRobot = URI.create(UriDevice + "robot");
    public static URI UriTablet = URI.create(UriDevice + "tablet");
    public static URI UriDeviceVariant = URI.create(UriDevice + "variant");
    public static URI UriDeviceVendor = URI.create(UriDevice + "vendor");
    public static URI UriDeviceVersion = URI.create(UriDevice + "version");

    public static URI UriOsModel = URI.create(UriOs + "model");
    public static URI UriOsVariant = URI.create(UriOs + "variant");
    public static URI UriOsVendor = URI.create(UriOs + "vendor");
    public static URI UriOsVersion = URI.create(UriOs + "version");
}
