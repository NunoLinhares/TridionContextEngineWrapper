package com.sdl.tridion.context;

import java.net.URI;
import java.util.Map;

import com.tridion.ambientdata.AmbientDataContext;

public class ContextEngine {

	private DeviceClaims deviceClaims;
	private BrowserClaims browserClaims;
	private OsClaims osClaims;
	
	public ContextEngine (Map<URI, Object> claims) {
		setDeviceClaims(new DeviceClaims(claims));
		setBrowserClaims(new BrowserClaims(claims));
		setOsClaims(new OsClaims(claims));
	}
	public ContextEngine () {
		Map<URI,Object> claims = AmbientDataContext.getCurrentClaimStore().getAll();
		setDeviceClaims(new DeviceClaims(claims));
		setBrowserClaims(new BrowserClaims(claims));
		setOsClaims(new OsClaims(claims));
	}
	public DeviceClaims getDeviceClaims() {
		return deviceClaims;
	}
	private void setDeviceClaims(DeviceClaims deviceClaims) {
		this.deviceClaims = deviceClaims;
	}
	public BrowserClaims getBrowserClaims() {
		return browserClaims;
	}
	private void setBrowserClaims(BrowserClaims browserClaims) {
		this.browserClaims = browserClaims;
	}
	public OsClaims getOsClaims() {
		return osClaims;
	}
	private void setOsClaims(OsClaims osClaims) {
		this.osClaims = osClaims;
	}
}
