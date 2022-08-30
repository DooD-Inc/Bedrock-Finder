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
        comboBoxes.ToList().ForEach(z => z.Opened += OnOpened);
    }
    private void OnOpened()
    {
        
    }
}