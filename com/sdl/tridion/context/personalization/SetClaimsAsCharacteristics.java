package com.sdl.tridion.context.personalization;

import java.net.URI;
import java.util.Collection;
import java.util.Map;
import java.util.Map.Entry;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.tridion.ambientdata.AmbientDataException;
import com.tridion.ambientdata.claimstore.ClaimStore;
import com.tridion.ambientdata.processing.AbstractClaimProcessor;
import com.tridion.ambientdata.web.WebClaims;
import com.tridion.broker.StorageException;
import com.tridion.meta.PageMeta;
import com.tridion.meta.PageMetaFactory;
import com.tridion.personalization.CustomerCharacteristics;
import com.tridion.user.User;
import com.tridion.user.UserManager;
import com.tridion.web.Admin;
import com.tridion.web.Presentation;
import com.tridion.web.context.Context;
import com.tridion.web.context.SiteIdentifier;

public class SetClaimsAsCharacteristics extends AbstractClaimProcessor {
	private Presentation presentation;
	private Context context;
	private static final Logger log = LoggerFactory
			.getLogger(SetClaimsAsCharacteristics.class);
	private ClaimStore claimStore;

	private Context getContext() {
		if (context == null) {
			PageMetaFactory pmf = new PageMetaFactory(0);
			String requestedUrl = claimStore.get(URI.create("taf:request:uri"))
					.toString();
			Collection<PageMeta> pages = pmf.getMetaByURL(requestedUrl);
			PageMeta pageMeta = null;
			if (pages.size() > 0) {
				pageMeta = pages.iterator().next();
			} else {
				log.info("The current page URI "
						+ requestedUrl
						+ " is not a valid Tridion Page, or I couldn't find it in the database");
				return null;
			}
			String uri = "tcm:" + pageMeta.getPublicationId() + "-"
					+ pageMeta.getId() + "-64";
			log.debug("Current Page ID: " + uri);
			URI fullUri = URI.create(claimStore.get(
					URI.create("taf:request:full_url")).toString());
			context = new Context(uri, new SiteIdentifier(fullUri.getHost(),
					fullUri.getPort(), fullUri.getPath()));
		}

		return context;

	}

	private Presentation getPresentation() {
		if (presentation == null) {
			if(getContext() == null)
				log.info("Could not determine context, is this a valid Tridion Page?");
			presentation = Admin.getInstance().getPresentation(
					getContext().getSiteIdentifier());
		}
		return presentation;
	}

	@Override
	public void onRequestStart(ClaimStore claimStore)
			throws AmbientDataException {
		this.claimStore = claimStore;
		// Get the Presentation ID as configured in cd_wai_conf
		int presentationId = getPresentation().getPresentationId();
		// Get the name of the cookie used for WAI, as configured in cd_wai_conf
		String cookieName = getPresentation().getCookieName();
		Map<String, String> cookies = (Map<String, String>) claimStore
				.get(WebClaims.REQUEST_COOKIES);
		int cookieValue = 0;
		// If the cookie exists, get the user ID from it. Otherwise, leave it as
		// 0
		if (cookies.get(cookieName) != null)
			cookieValue = Integer.parseInt(cookies.get(cookieName));

		log.debug("Presentation ID is " + presentationId);
		log.debug("Cookie name is " + cookieName);
		log.debug("Cookie value is " + cookieValue);
		User user = null;
		try {
			user = UserManager.checkUser(presentationId, cookieValue, null);
		} catch (StorageException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return;
		}
		log.debug("I might have loaded this user: " + user.getId());
		// Now set the Mobile Attributes as user Characteristics
		CustomerCharacteristics characteristics = new CustomerCharacteristics(
				user);
		Map<URI, Object> claims = claimStore.getAll();

		for (Entry<URI, Object> i : claims.entrySet()) {
			if (i.getKey().toString().startsWith("taf:claim:context:")) {
				String uri = i.getKey().toString()
						.replace("taf:claim:context:", "");
				uri = uri.replace(":", ".");
				if (uri.length() <= 25) {
					if (i.getValue().toString() != "")
						if (i.getValue().toString().length() <= 255)
							characteristics.setValue(uri, i.getValue()
									.toString());
				}
			}
		}
		characteristics.executeUpdate();

	}

}
