using System;
using System.Collections.Generic;
using System.Linq;
using MikeRobbins.Seshat.Models;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace MikeRobbins.Seshat.Repositories
{
    public class BrochureRespository : Sitecore.Services.Core.IRepository<Brochure>
    {
        public IQueryable<Brochure> GetAll()
        {
            var brochures = new List<Brochure>();

            var master = Sitecore.Data.Database.GetDatabase("master");

            var folder = master.GetItem(new ID("{CA002812-8C24-4AD5-8843-00492FAEC74D}"));

            foreach (Item item in folder.Children)
            {
                var brochure = new Brochure()
                {
                    Id = item.ID.ToString(),
                    ImagePath = "~/icon/Office/48x48/document_attachment.png",
                    Title = item["Title"],
                    Introduction = item["Introduction"],
                    CaseStudy = ((Sitecore.Data.Fields.LookupField)item.Fields["Case Study"]).TargetID.Guid,
                    ImageGallery = item["Image Gallery"],
                };

                brochures.Add(brochure);
            }

            return brochures.AsQueryable();
        }

        public Brochure FindById(string id)
        {
            throw new NotImplementedException();
        }

        public void Add(Brochure entity)
        {
            var master = Sitecore.Data.Database.GetDatabase("master");
            var folder = master.GetItem(new ID("{CA002812-8C24-4AD5-8843-00492FAEC74D}"));

            var newItem = Sitecore.Data.Items.ItemUtil.AddFromTemplate(entity.Title, "User Defined/MikeRobbins/Content/Brochure", folder);

            newItem.Editing.BeginEdit();

            newItem["Title"] = entity.Title;
            newItem["Introduction"] = entity.Introduction;
            newItem["Case Study"] = entity.CaseStudy.ToString();
            newItem["Image Gallery"] = entity.ImageGallery;

            newItem.Editing.EndEdit();
        }

        public bool Exists(Brochure entity)
        {
            return false;
        }

        public void Update(Brochure entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Brochure entity)
        {
            throw new NotImplementedException();
        }
    }
}