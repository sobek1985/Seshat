using System.Collections.Generic;
using MikeRobbins.Seshat.Models;
using Sitecore.Data;

namespace MikeRobbins.Seshat.Interfaces
{
    public interface IBrochureReader
    {
        List<Brochure> GetAllBrochures();
        Brochure GetBrochure(ID id );
    }
}