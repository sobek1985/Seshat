using MikeRobbins.Seshat.Models;

namespace MikeRobbins.Seshat.Interfaces
{
    public interface IBrochureUpdater
    {
        void UpdateBrochure(Brochure brochure);
        void DeleteBrochure(Brochure brochure);
    }
}