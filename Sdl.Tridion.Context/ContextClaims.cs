using System;
using System.Collections.Generic;
using Tridion.ContentDelivery.AmbientData;

namespace Sdl.Tridion.Context
{
    public class ContextClaims
    {
        private readonly Dictionary<Uri, object> _claims;

        public ContextClaims(Dictionary<Uri, object> claims)
        {
            _claims = claims;
        }

        public ContextClaims()
        {
            _claims = (Dictionary<Uri, object>)AmbientDataContext.CurrentClaimStore.GetAll();
        }

        protected internal bool GetBooleanValue(Uri claimUri)
        {
            bool value;
            try
            {
                value = Convert.ToBoolean(_claims[claimUri].ToString());
            }
            catch (Exception)
            {
                return false;
            }
            return value;
        }

        protected internal int GetIntValue(Uri claimUri)
        {
            int value;
            try
            {
                value = Convert.ToInt32(_claims[claimUri].ToString());
            }
            catch
            {
                return 0;
            }
            return value;
        }

        protected internal string GetStringValue(Uri claimUri)
        {
            string value;
            try
            {
                value = _claims[claimUri].ToString();
            }
            catch
            {
                return null;
            }
            return value;
        }
    }
}
