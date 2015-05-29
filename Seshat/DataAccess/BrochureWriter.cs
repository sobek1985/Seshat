using System.Linq;
using MikeRobbins.Seshat.Interfaces;
using MikeRobbins.Seshat.Models;
using Sitecore.Data;

namespace MikeRobbins.Seshat.DataAccess
{
    public class BrochureWriter : IBrochureWriter
    {
        //Todo: Remove these
        private ID _brochureFolder = new ID("{CA002812-8C24-4AD5-8843-00492FAEC74D}");
        private string _template = "User Defined/MikeRobbins/Content/Brochure";

        public void SaveBrochure(Brochure brochure)
        {
            var master = Sitecore.Data.Database.GetDatabase("master");
            var folder = master.GetItem(_brochureFolder);

            var newItem = Sitecore.Data.Items.ItemUtil.AddFromTemplate(brochure.Title, _template, folder);

            newItem.Editing.BeginEdit();

            newItem["Title"] = brochure.Title;
            newItem["Introduction"] = brochure.Introduction;
            newItem["Case Study"] = brochure.CaseStudy.ToString();
            newItem["Image Gallery"] = brochure.Images.Select(x => x.ToString()).Aggregate((c, n) => c + "|" + n);

            newItem.Editing.EndEdit();
        }
    }
}