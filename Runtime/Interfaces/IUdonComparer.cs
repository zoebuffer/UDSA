using UdonSharp;

namespace dev.zoebuffer.udsa.interfaces
{
    public abstract class IUdonComparer : UdonSharpBehaviour
    {
        public virtual int Compare(UdonSharpBehaviour other)
        {
            return 0;
        }
    }
}
