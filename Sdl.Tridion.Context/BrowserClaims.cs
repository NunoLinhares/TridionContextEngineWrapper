using System.Collections.Generic;
using Tridion.ContentDelivery.AmbientData;

namespace Sdl.Tridion.Context
{
    public class BrowserClaims
    {

        public BrowserClaims()
        {
        }

        public bool CookieSupport
        {
            get
            {
                // BUG: Returns false on desktop FF, IE, Safari
                return AmbientDataContext.CurrentClaimStore.Get<bool>(ClaimUris.UriCookieSupport);
            }
        }

        public string CssVersion { get { return AmbientDataContext.CurrentClaimStore.Get<string>(ClaimUris.UriCssVersion); } }

        public int DisplayColorDepth { get { return AmbientDataContext.CurrentClaimStore.Get<int>(ClaimUris.UriDisplayColorDepth); } }

        public int DisplayHeigth { get { return AmbientDataContext.CurrentClaimStore.Get<int>(ClaimUris.UriBrowserDisplayHeight); } }

        public int DisplayWidth { get { return AmbientDataContext.CurrentClaimStore.Get<int>(ClaimUris.UriBrowserDisplayWidth); } }

        public List<string> ImageFormatSupport
        {
            get
            {
                return AmbientDataContext.CurrentClaimStore.Get<List<string>>(ClaimUris.UriImageFormatSupport);
            }
        }

        public List<string> InputDevices
        {
            get
            {
                return AmbientDataContext.CurrentClaimStore.Get<List<string>>(ClaimUris.UriInputDevices);
            }
        }

        public List<string> InputModeSupport
        {
            get { return AmbientDataContext.CurrentClaimStore.Get<List<string>>(ClaimUris.UriInputModeSupport); }
        }

        public string JsVersion { get { return AmbientDataContext.CurrentClaimStore.Get<string>(ClaimUris.UriJsVersion); } }

        public List<string> MarkupSupport
        {
            get { return AmbientDataContext.CurrentClaimStore.Get<List<string>>(ClaimUris.UriMarkupSupport); }
        }
        public string Model
        {
            get { return AmbientDataContext.CurrentClaimStore.Get<string>(ClaimUris.UriBrowserModel); }
        }

        public string PreferredHtmlContentType { get { return AmbientDataContext.CurrentClaimStore.Get<string>(ClaimUris.UriPreferredHtmlContentType); } }

        public List<string> ScriptSupport { get { return AmbientDataContext.CurrentClaimStore.Get<List<string>>(ClaimUris.UriScriptSupport); } }

        public List<string> StylesheetSupport
        {
            get { return AmbientDataContext.CurrentClaimStore.Get<List<string>>(ClaimUris.UriStylesheetSupport); }
        }

        public string Variant { get { return AmbientDataContext.CurrentClaimStore.Get<string>(ClaimUris.UriBrowserVariant); } }

        public string Vendor { get { return AmbientDataContext.CurrentClaimStore.Get<string>(ClaimUris.UriBrowserVendor); } }

        public string Version { get { return AmbientDataContext.CurrentClaimStore.Get<string>(ClaimUris.UriBrowserVersion); } }


    }
}
