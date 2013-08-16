package com.sdl.tridion.context;

import java.net.URI;
import java.util.Map;

public class BrowserClaims extends ContextClaims {

	public BrowserClaims(Map<URI, Object> claims) {
		super(claims);
		tafContext = "taf:claim:context:browser:";
	}

	public BrowserClaims() {
		super();
		tafContext = "taf:claim:context:browser:";
	}

	public boolean hasCookieSupport() {
		return getBooleanValue(ClaimUris.UriCookieSupport);
	}
	public String getCssVersion() {
		return getStringValue(ClaimUris.UriCssVersion);
	}

	public int getDisplayColorDepth() {
		return getIntValue(ClaimUris.UriDisplayColorDepth);
	}

	public int getDisplayHeigth() {
		return getIntValue(ClaimUris.UriBrowserDisplayHeight);
	}

	public int getDisplayWidth() {
		return getIntValue(ClaimUris.UriBrowserDisplayWidth);
	}

	public String getImageFormatSupport() {
		return getStringValue(ClaimUris.UriImageFormatSupport);
	}

	public String getInputDevices() {
		return getStringValue(ClaimUris.UriInputDevices);
	}

	public String getInputModeSupport() {
		return getStringValue(ClaimUris.UriInputModeSupport);
	}

	public String getJsVersion() {
		return getStringValue(ClaimUris.UriJsVersion);
	}

	public String getMarkupSupport() {
		return getStringValue(ClaimUris.UriMarkupSupport);
	}

	public String getModel() {
		return getStringValue(ClaimUris.UriBrowserModel);
	}

	public String getPreferredHtmlContentType() {
		return getStringValue(ClaimUris.UriPreferredHtmlContentType);
	}

	public String getScriptSupport() {
		return getStringValue(ClaimUris.UriScriptSupport);
	}

	public String getStylesheetSupport() {
		return getStringValue(ClaimUris.UriStylesheetSupport);
	}

	public String getVariant() {
		return getStringValue(ClaimUris.UriBrowserVariant);
	}

	public String getVendor() {
		return getStringValue(ClaimUris.UriBrowserVendor);
	}

	public String getVersion() {
		return getStringValue(ClaimUris.UriBrowserVersion);
	}

}
