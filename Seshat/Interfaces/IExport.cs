using MikeRobbins.Seshat.Models;

namespace MikeRobbins.Seshat.Interfaces
{
    public interface IExport
    {
        string GenerateExport(Brochure brochure);
    }
}