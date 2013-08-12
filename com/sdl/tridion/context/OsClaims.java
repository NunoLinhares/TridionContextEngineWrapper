package com.sdl.tridion.context;

import java.net.URI;
import java.util.Map;

public class OsClaims extends ContextClaims {
	public OsClaims(Map<URI, Object> claims) {
		super(claims);
	}

	public OsClaims() {
		super();
	}

	public String getModel() {
		return getStringValue(ClaimUris.UriOsModel);
	}

	public String getVariant() {
		return getStringValue(ClaimUris.UriOsVariant);
	}

	public String getVendor() {
		return getStringValue(ClaimUris.UriOsVendor);
	}

	public String getVersion() {
		return getStringValue(ClaimUris.UriOsVersion);
	}
}
