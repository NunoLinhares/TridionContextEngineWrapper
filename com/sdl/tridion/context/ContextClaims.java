package com.sdl.tridion.context;

import java.net.URI;
import java.util.Map;
import java.util.Map.Entry;

import com.tridion.ambientdata.AmbientDataContext;

public abstract class ContextClaims {

	Map<URI, Object> _claims;
	private Map<String, String> all = null;
	protected String tafContext;

	protected ContextClaims(Map<URI, Object> claims) {
		_claims = claims;
	}

	protected ContextClaims() {
		_claims = AmbientDataContext.getCurrentClaimStore().getAll();
	}

	boolean getBooleanValue(URI claimUri) {
		return Boolean.parseBoolean(_claims.get(claimUri).toString());
	}
	
	int getIntValue(URI claimUri) {
		return Integer.parseInt(_claims.get(claimUri).toString());
	}
	
	String getStringValue(URI claimUri) {
		return _claims.get(claimUri).toString();
	}
	
	
	protected Map<String, String> getAll() {
		if(all == null)
		{
			for (Entry<URI, Object> i : _claims.entrySet()) {
				if (i.getKey().toString().startsWith(tafContext)) {
					all.put(i.getKey().toString(), i.getValue().toString());
				}
			}
		}
		return all;
	}
}
