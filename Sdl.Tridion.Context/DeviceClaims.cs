using System;
using System.Collections.Generic;
using Tridion.ContentDelivery.AmbientData;

namespace Sdl.Tridion.Context
{
    public class DeviceClaims
    {
        private readonly Dictionary<Uri, object> _claims;
        public DeviceClaims(Dictionary<Uri, object> claims)
        {
            _claims = claims;
        }

        public DeviceClaims()
        {
            _claims = (Dictionary<Uri, object>)AmbientDataContext.CurrentClaimStore.GetAll();
        }

        public int DisplayHeight { get { return Convert.ToInt32(_claims[ClaimUris.UriDeviceDisplayHeight].ToString()); } }
        public int DisplayWidth { get { return Convert.ToInt32(_claims[ClaimUris.UriDeviceDisplayWidth].ToString()); } }
        public bool IsMobile { get { return Convert.ToBoolean(_claims[ClaimUris.UriMobile].ToString()); } }
        public string Model { get { return _claims[ClaimUris.UriDeviceModel].ToString(); } }
        public int PixelDensity
        {
            get { return Convert.ToInt32(_claims[ClaimUris.UriPixelDensity].ToString()); }
        }

        public int PixelRatio
        {
            get { return Convert.ToInt32(_claims[ClaimUris.UriPixelRatio].ToString()); }
        }
        public bool IsRobot { get { return Convert.ToBoolean(_claims[ClaimUris.UriRobot].ToString()); } }
        public bool IsTablet { get { return Convert.ToBoolean(_claims[ClaimUris.UriTablet].ToString()); } }
        public string Variant { get { return _claims[ClaimUris.UriDeviceVariant].ToString(); } }
        public string Vendor { get { return _claims[ClaimUris.UriDeviceVendor].ToString(); } }
        public string Version { get { return _claims[ClaimUris.UriDeviceVendor].ToString(); } }

    }
}
