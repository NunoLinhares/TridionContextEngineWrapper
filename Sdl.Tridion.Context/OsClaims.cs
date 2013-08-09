using System;
using System.Collections.Generic;
using Tridion.ContentDelivery.AmbientData;

namespace Sdl.Tridion.Context
{
    public class OsClaims
    {
        private readonly Dictionary<Uri, object> _claims;
        public OsClaims(Dictionary<Uri, object> claims)
        {
            _claims = claims;
        }

        public OsClaims()
        {
            _claims = (Dictionary<Uri, object>)AmbientDataContext.CurrentClaimStore.GetAll();
        }

        public string Model { get { return _claims[ClaimUris.UriOsModel].ToString(); } }
        public string Variant { get { return _claims[ClaimUris.UriOsVariant].ToString(); } }
        public string Vendor { get { return _claims[ClaimUris.UriOsVendor].ToString(); } }
        public string Version { get { return _claims[ClaimUris.UriOsVersion].ToString(); } }
    }
}
