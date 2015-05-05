using System;
using System.Collections.Generic;
using System.Linq;
using MikeRobbins.Seshat.Interfaces;
using MikeRobbins.Seshat.Models;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace MikeRobbins.Seshat.Repositories
{
    public class BrochureRespository : Sitecore.Services.Core.IRepository<Brochure>
    {
        private IBrochureReader _brochureReader;
        private ISitecoreUtilities _sitecoreUtilities;

        public BrochureRespository(IBrochureReader brochureReader, ISitecoreUtilities sitecoreUtilities)
        {
            _brochureReader = brochureReader;
            _sitecoreUtilities = sitecoreUtilities;
        }

        public IQueryable<Brochure> GetAll()
        {
           

            return brochures.AsQueryable();
        }

        public Brochure FindById(string id)
        {
            var sId = _sitecoreUtilities.ParseId(id);
            return _brochureReader.GetBrochure(sId);
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