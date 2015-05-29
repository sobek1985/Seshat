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
        private IBrochureWriter _brochureWriter;
        private ISitecoreUtilities _sitecoreUtilities;

        public BrochureRespository(IBrochureReader brochureReader, IBrochureWriter brochureWriter, ISitecoreUtilities sitecoreUtilities)
        {
            _brochureReader = brochureReader;
            _sitecoreUtilities = sitecoreUtilities;
            _brochureWriter = brochureWriter;
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