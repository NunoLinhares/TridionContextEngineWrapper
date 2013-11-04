using System.Collections.Generic;
using Tridion.ContentDelivery.AmbientData;

namespace Sdl.Tridion.Context
{
    public class DeviceClaims
    {

        public DeviceClaims()
        {
        }

        public int DisplayHeight { get { return AmbientDataContext.CurrentClaimStore.Get<int>(ClaimUris.UriDeviceDisplayHeight); } }
        public int DisplayWidth { get { return AmbientDataContext.CurrentClaimStore.Get<int>(ClaimUris.UriDeviceDisplayWidth); } }
        public List<string> InputDevices { get { return AmbientDataContext.CurrentClaimStore.Get<List<string>>(ClaimUris.UriDeviceInputDevices); } }
        public bool IsMobile { get { return AmbientDataContext.CurrentClaimStore.Get<bool>(ClaimUris.UriMobile); } }
        public string Model { get { return AmbientDataContext.CurrentClaimStore.Get<string>(ClaimUris.UriDeviceModel); } }
        public int PixelDensity { get { return AmbientDataContext.CurrentClaimStore.Get<int>(ClaimUris.UriPixelDensity); } }
        public int PixelRatio { get { return AmbientDataContext.CurrentClaimStore.Get<int>(ClaimUris.UriPixelRatio); } }
        public bool IsRobot { get { return AmbientDataContext.CurrentClaimStore.Get<bool>(ClaimUris.UriRobot); } }
        public bool IsTablet { get { return AmbientDataContext.CurrentClaimStore.Get<bool>(ClaimUris.UriTablet); } }
        public string Variant { get { return AmbientDataContext.CurrentClaimStore.Get<string>(ClaimUris.UriDeviceVariant); } }
        public string Vendor { get { return AmbientDataContext.CurrentClaimStore.Get<string>(ClaimUris.UriDeviceVendor); } }
        public string Version { get { return AmbientDataContext.CurrentClaimStore.Get<string>(ClaimUris.UriDeviceVendor); } }

    }
}
