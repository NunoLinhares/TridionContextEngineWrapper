using System;
using System.IO;
using System.Xml.Linq;
using Tridion.ContentDelivery.AmbientData;

namespace Sdl.Tridion.Context
{
    public class ContextEngine
    {
        private readonly BrowserClaims _browser;
        private readonly DeviceClaims _device;
        private readonly OsClaims _os;

        public ContextEngine()
        {
            _browser = new BrowserClaims();
            _device = new DeviceClaims();
            _os = new OsClaims();
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

            // Could use: string path = VirtualPathUtility.ToAbsolute("~/App_Data/somedata.xml");
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "Families.xml");
            if (File.Exists(path))
            {
                XDocument families = XDocument.Load(path);
                foreach (var i in families.Descendants("devicefamily"))
                {
                    string family = i.Attribute("name").Value;
                    bool inFamily = true;
                    foreach (var c in i.Descendants("condition"))
                    {
                        Uri uri = new Uri(c.Attribute("uri").Value);
                        string expectedValue = c.Attribute("value").Value;

                        if (expectedValue.StartsWith("<"))
                        {
                            int value = Convert.ToInt32(expectedValue.Replace("<", ""));
                            int claimValue = Convert.ToInt32(GetClaimAsString(uri));
                            if (claimValue >= value)
                                inFamily = false;
                        }
                        else if (expectedValue.StartsWith(">"))
                        {
                            int value = Convert.ToInt32(expectedValue.Replace(">", ""));
                            int claimValue = Convert.ToInt32(GetClaimAsString(uri));
                            if (claimValue <= value)
                                inFamily = false;
                        }
                        else
                        {
                            // 7.1 introduced strongly typed claims
                            // Must check return types...
                            string stringClaimValue = GetClaimAsString(uri);
                            if (!stringClaimValue.Equals(expectedValue))
                                inFamily = false; // move on to next family
                        }
                    }
                    if (inFamily)
                    {
                        _deviceFamily = family;
                        break;
                    }
                    // Need to evaluate if all conditions are true.
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

        private string GetClaimAsString(Uri uri)
        {
            object claim = AmbientDataContext.CurrentClaimStore.Get<object>(uri);
            return claim.ToString().ToLower();
        }

    }
}
