using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockFinder.Libraries.Custom_Controls;
public class CComboBoxBundle
{
    public CComboBoxBundle(params CComboBox[] comboBoxes)
    {
        this.comboBoxes = comboBoxes;
        this.comboBoxes.ToList().ForEach(z => z.Open += OnOpened);
    }
    private CComboBox[] comboBoxes;
    private void OnOpened()
    {
        foreach(CComboBox ccbox in comboBoxes)
        {
            if (ccbox.open)
            {
                ccbox.Size = ccbox.ItemSize;
            }
        }
    }
}