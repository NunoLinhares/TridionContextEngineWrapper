package com.sdl.tridion.context;

import java.net.URI;
import java.util.Map;

public class DeviceClaims extends ContextClaims {
	public DeviceClaims(Map<URI, Object> claims) {
		super(claims);
		tafContext = "taf:claim:context:device:";
	}

	public DeviceClaims() {
		super();
		tafContext = "taf:claim:context:device:";
	}

	public int getDisplayHeight() {
		return getIntValue(ClaimUris.UriDeviceDisplayHeight);
	}

	public int getDisplayWidth() {
		return getIntValue(ClaimUris.UriDeviceDisplayWidth);
	}

	public boolean isMobile() {
		return getBooleanValue(ClaimUris.UriMobile);
	}

	public String getModel() {
		return getStringValue(ClaimUris.UriDeviceModel);
	}

	public int getPixelDensity() {
		return getIntValue(ClaimUris.UriPixelDensity);
	}

	public int getPixelRatio() {
		return getIntValue(ClaimUris.UriPixelRatio);
	}

	public boolean isRobot() {
		return getBooleanValue(ClaimUris.UriRobot);
	}

	public boolean isTablet() {
		return getBooleanValue(ClaimUris.UriTablet);
	}

	public String getVariant() {
		return getStringValue(ClaimUris.UriDeviceVariant);
	}

	public String getVendor() {
		return getStringValue(ClaimUris.UriDeviceVendor);
	}

	public String getVersion() {
		return getStringValue(ClaimUris.UriDeviceVendor);
	}
}
