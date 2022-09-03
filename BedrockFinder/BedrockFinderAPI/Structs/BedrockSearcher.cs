using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockFinder.BedrockFinderAPI.Structs;
public abstract class BedrockSearcher
{
    public BedrockSearcher(BedrockSearch parent)
    {
        Parent = parent;
    }
    public object @lock = new object();
    public bool Working;
    public bool CanStart = true;
    public abstract void Start();
    public BedrockSearch Parent;
}