using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sdl.Tridion.Context.Controls
{
    [DefaultProperty("Names")]
    [ParseChildren(false)]
    [PersistChildren(true)]
    [ToolboxData("<{0}:Family Names=\"{1}\" runat=server></{0}:Family>")]
    public class Family : WebControl
    {
        
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("desktop")]
        [Localizable(true)]

        public string Names
        {
            get
            {
                String s = (String)ViewState["FamilyNames"];
                return (s ?? "[" + ID + "]");
            }
 
            set
            {
                ViewState["FamilyNames"] = value;
                _names = value.Split(',').ToList();
            }
        }

        private List<string> _names = new List<string>();

        private ContextEngine _context;

        private bool IsDeviceInFamily
        {
            get
            {
                if(_context == null)
                    _context = new ContextEngine();
                return _names.Contains(_context.DeviceFamily);
            }
        }

        protected override void Render(HtmlTextWriter output)
        {
            if(IsDeviceInFamily)
                RenderChildren(output);
 
        }
    }
}
