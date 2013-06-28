using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH_GraphControls.GraphPanel
{
    class Flags
    {
        [Flags]
        public enum State
        {
            None        =   0x00,
            Focus       =   0x01,	// This element has focus
            Hover       =   0x02,	// We're hovering over this element
            DraggedOver =   0x04,	// We're dragging over this element
            Dragging    =   0x08,	// We're dragging (or dragging from) this element
            HighLight   =   0x10,	// We're hovering over this element
        }
    }
}
