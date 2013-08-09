using System;
using System.Collections.Generic;
using Tridion.ContentDelivery.AmbientData;

namespace Sdl.Tridion.Context
{
    public class ContextEngine
    {
        private readonly BrowserClaims _browser;
        private readonly DeviceClaims _device;
        private readonly OsClaims _os;

        public ContextEngine(Dictionary<Uri, object> claims)
        {
            _browser = new BrowserClaims(claims);
            _device = new DeviceClaims(claims);
            _os = new OsClaims(claims);
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

    }
}
