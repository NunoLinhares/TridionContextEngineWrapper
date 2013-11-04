using Tridion.ContentDelivery.AmbientData;

namespace Sdl.Tridion.Context
{
    public class OsClaims
    {

        public OsClaims()
        {
        }

        public string Model { get { return AmbientDataContext.CurrentClaimStore.Get<string>(ClaimUris.UriOsModel); } }
        public string Variant { get { return AmbientDataContext.CurrentClaimStore.Get<string>(ClaimUris.UriOsVariant); } }
        public string Vendor { get { return AmbientDataContext.CurrentClaimStore.Get<string>(ClaimUris.UriOsVendor); } }
        public string Version { get { return AmbientDataContext.CurrentClaimStore.Get<string>(ClaimUris.UriOsVersion); } }
    }
}
