using Mutagen.Bethesda.Skyrim;

namespace HighPolyHeadUpdateRaces
{
    public class LinkedHeadPart
    {
        private IHeadPartGetter HphHeadPart { get; }
        private IHeadPartGetter VanillaHeadPart { get; }

        public LinkedHeadPart(IHeadPartGetter hphHeadPart, IHeadPartGetter vanillaHeadPart)
        {
            HphHeadPart = hphHeadPart;
            VanillaHeadPart = vanillaHeadPart;
        }
    }
}