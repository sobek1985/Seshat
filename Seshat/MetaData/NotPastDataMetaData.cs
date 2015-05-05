using MikeRobbins.Seshat.Attributes;
using Sitecore.Services.Core.MetaData;

namespace MikeRobbins.Seshat.MetaData
{
    public class NotPastDateMetaData : ValidationMetaDataBase<NotPastDateAttribute>
    {
        public NotPastDateMetaData()
            : base("notPastDate")
        {
        }
    }
}