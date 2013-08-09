using System;
using System.Collections.Generic;
using System.Linq;
using Tridion.ContentDelivery.AmbientData;

namespace Sdl.Tridion.Context
{
    public class BrowserClaims
    {
        private readonly Dictionary<Uri, object> _claims;

        public BrowserClaims(Dictionary<Uri, object> claims)
        {
            _claims = claims;
        }

        public BrowserClaims()
        {
            _claims = (Dictionary<Uri, object>) AmbientDataContext.CurrentClaimStore.GetAll();
        }

        public bool CookieSupport
        {
            get { return Convert.ToBoolean(_claims[ClaimUris.UriCookieSupport].ToString()); }
        }

        public string CssVersion { get { return _claims[ClaimUris.UriCssVersion].ToString(); } }

        public int DisplayColorDepth { get { return Convert.ToInt32(_claims[ClaimUris.UriDisplayColorDepth].ToString()); } }

        public int DisplayHeigth { get { return Convert.ToInt32(_claims[ClaimUris.UriBrowserDisplayHeight].ToString()); } }

        public int DisplayWidth { get { return Convert.ToInt32(_claims[ClaimUris.UriBrowserDisplayWidth].ToString()); } }

        public List<string> ImageFormatSupport
        {
            get
            {
                string x = _claims[ClaimUris.UriImageFormatSupport].ToString();
                return x.Split(',').ToList();
            }
        }

        public List<string> InputDevices
        {
            get
            {
                string x = _claims[ClaimUris.UriInputDevices].ToString();
                return x.Split(',').ToList();
            }
        }

        public string InputModeSupport
        {
            get { return _claims[ClaimUris.UriInputModeSupport].ToString(); }
        }

        public string JsVersion { get { return _claims[ClaimUris.UriJsVersion].ToString(); } }

        public string MarkupSupport
        {
            get { return _claims[ClaimUris.UriMarkupSupport].ToString(); }
        }
        public string Model
        {
            get { return _claims[ClaimUris.UriBrowserModel].ToString(); }
        }

        public string PreferredHtmlContentType { get { return _claims[ClaimUris.UriPreferredHtmlContentType].ToString(); } }

        public string ScriptSupport { get { return _claims[ClaimUris.UriScriptSupport].ToString(); } }

        public List<string> StylesheetSupport
        {
            get { return _claims[ClaimUris.UriStylesheetSupport].ToString().Split(',').ToList(); }
        }

        public string Variant { get { return _claims[ClaimUris.UriBrowserVariant].ToString(); } }

        public string Vendor { get { return _claims[ClaimUris.UriBrowserVendor].ToString(); } }

        public string Version { get { return _claims[ClaimUris.UriBrowserVersion].ToString(); } }


    }
}
