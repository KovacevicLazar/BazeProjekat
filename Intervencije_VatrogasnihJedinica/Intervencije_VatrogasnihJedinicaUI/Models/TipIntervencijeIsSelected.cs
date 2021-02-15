using Intervencije_VatrogasnihJedinica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervencije_VatrogasnihJedinicaUI.Models
{
    public class TipIntervencijeIsSelected
    {
        public TipIntervencijeEnum Tip { get; set; }
        public bool IsSelected { get; set; }
    }
}
