package com.sdl.tridion.context;

import java.net.URI;
import java.util.Map;

public class OsClaims extends ContextClaims {
	public OsClaims(Map<URI, Object> claims) {
		super(claims);
		tafContext = "taf:claim:context:os:";
	}

	public OsClaims() {
		super();
		tafContext = "taf:claim:context:os:";
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
