using MikeRobbins.Seshat.Models;

namespace MikeRobbins.Seshat.Interfaces
{
    public interface IConfigurationReader
    {
        ApplicationConfiguration GetConfiguration();
    }
}