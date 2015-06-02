using System;
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
        private IBrochureUpdater _brochureUpdater;
        private IBrochureWriter _brochureWriter;
        private ISitecoreUtilities _sitecoreUtilities;

        public BrochureRespository(IBrochureReader brochureReader, IBrochureUpdater brochureUpdater, IBrochureWriter brochureWriter, ISitecoreUtilities sitecoreUtilities)
        {
            _brochureReader = brochureReader;
            _brochureUpdater = brochureUpdater;
            _brochureWriter = brochureWriter;
            _sitecoreUtilities = sitecoreUtilities;
        }

        public IQueryable<Brochure> GetAll()
        {
            var brochures = _brochureReader.GetAllBrochures();
            return brochures.AsQueryable();
        }

        public Brochure FindById(string id)
        {
            var sId = _sitecoreUtilities.ParseId(id);
            return _brochureReader.GetBrochure(sId);
        }

        public void Add(Brochure entity)
        {
            _brochureWriter.SaveBrochure(entity);
        }

        public bool Exists(Brochure entity)
        {
            var sId = _sitecoreUtilities.ParseId(entity.itemId);

            return _brochureReader.BrochureExists(sId);
        }

        public void Update(Brochure entity)
        {
            _brochureUpdater.UpdateBrochure(entity);
        }

        public void Delete(Brochure entity)
        {
            _brochureUpdater.DeleteBrochure(entity);
        }
    }
}