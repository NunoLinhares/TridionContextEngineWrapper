using System;
using System.Collections.Generic;
using System.IO;
using Tridion.ContentDelivery.AmbientData;
using System.Xml.Linq;

namespace Sdl.Tridion.Context
{
    public class ContextEngine
    {
        private readonly BrowserClaims _browser;
        private readonly DeviceClaims _device;
        private readonly OsClaims _os;
        private Dictionary<Uri, object> _claims;

        public ContextEngine(Dictionary<Uri, object> claims)
        {
            _browser = new BrowserClaims(claims);
            _device = new DeviceClaims(claims);
            _os = new OsClaims(claims);
            _claims = claims;
        }

        public ContextEngine()
        {
            Dictionary<Uri, object> claims = (Dictionary<Uri, object>) AmbientDataContext.CurrentClaimStore.GetAll();
            _browser = new BrowserClaims(claims);
            _device = new DeviceClaims(claims);
            _os = new OsClaims(claims);
        }

        public BrowserClaims Browser { get { return _browser; } }
        public DeviceClaims Device { get { return _device; } }
        public OsClaims Os { get { return _os; } }

        public string DeviceFamily
        {
            get { return GetDeviceFamily(); }
        }


        private string _deviceFamily = null;

        private string GetDeviceFamily()
        {
            // check configuration
            // evaluate conditions from top to bottom
            // return current device family

            // if families.xml does not exist will use defaults

            // YUCK

            if (_deviceFamily != null) return _deviceFamily;

            if (File.Exists("Families.xml"))
            {
                XDocument families = XDocument.Load("Families.xml");
                foreach (var i in families.Descendants("devicefamily"))
                {
                    string family = i.Attribute("name").Value;
                    foreach (var c in i.Descendants("condition"))
                    {
                        Uri uri = new Uri(c.Attribute("uri").Value);
                        string expectedValue = c.Attribute("value").Value;
                        if (expectedValue.StartsWith("&"))
                        {
                            if (expectedValue.StartsWith("&lt;"))
                            {
                                int value = Convert.ToInt32(expectedValue.Replace("&lt;", ""));
                                int claimValue = Convert.ToInt32(AmbientDataContext.CurrentClaimStore.Get<string>(uri));
                                if (claimValue > value)
                                    break;
                            }
                            if (expectedValue.StartsWith("&gt;"))
                            {
                                int value = Convert.ToInt32(expectedValue.Replace("&gt;", ""));
                                int claimValue = Convert.ToInt32(AmbientDataContext.CurrentClaimStore.Get<string>(uri));
                                if (claimValue < value)
                                    break;
                            }
                        }
                        if (!AmbientDataContext.CurrentClaimStore.Get<string>(uri).Equals(expectedValue))
                            break; // move on to next family
                        _deviceFamily = family;
                    }
                }
            }
            else
            {
                // Defaults
                if (!Device.IsMobile && !Device.IsTablet) _deviceFamily = "desktop";
                if (Device.IsTablet) _deviceFamily = "tablet";
                if (Device.IsMobile && !Device.IsTablet)
                {
                    _deviceFamily = Device.DisplayWidth > 319 ? "smartphone" : "featurephone";
                }
            }

            return _deviceFamily;

        }

    }
}
