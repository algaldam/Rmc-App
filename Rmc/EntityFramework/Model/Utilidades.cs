using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace Rmc.Modelo
{
    class Utilidades
    {
        #region CLASES
        public class CustomAutoCompleteSuggestHelper : AutoCompleteSuggestHelper
        {
            public CustomAutoCompleteSuggestHelper(RadDropDownListElement owner)
                : base(owner)
            {
            }
            public override void ApplyFilterToDropDown(string filter)
            {
                base.ApplyFilterToDropDown(filter);
                this.DropDownList.ListElement.DataLayer.DataView.Comparer = new CustomComparer();
            }
        }
        public class CustomComparer : IComparer<RadListDataItem>
        {
            public int Compare(RadListDataItem x, RadListDataItem y)
            {
                return x.Text.Length.CompareTo(y.Text.Length);
            }
        }
        #endregion
    }
}
