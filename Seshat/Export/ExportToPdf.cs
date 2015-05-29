using System;
using System.IO;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MikeRobbins.Seshat.Interfaces;
using MikeRobbins.Seshat.Models;
using Sitecore.ApplicationCenter.Applications;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace MikeRobbins.Seshat.Export
{
    public class ExportToPdf : IExport
    {
        public string GenerateExport(Brochure brochure)
        {
            var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

            var doc = new iTextSharp.text.Document();

            var filePath = AppDomain.CurrentDomain.BaseDirectory + @"temp\" + brochure.Title + ".pdf";
            var fileSteam = new FileStream(filePath, FileMode.Create);

            var writer = PdfWriter.GetInstance(doc, fileSteam);

            doc.Open();
            doc.Add(new Paragraph(brochure.Title));
            doc.Add(new Paragraph(brochure.Introduction));

            var master = Sitecore.Data.Database.GetDatabase("master");
            var caseStudy = master.GetItem(new ID(brochure.CaseStudy));

            if (caseStudy != null)
            {
                doc.Add(new Paragraph(caseStudy["Title"], boldFont));
                doc.Add(new Paragraph(caseStudy["Summary"]));
                doc.Add(new Paragraph("Challenge", boldFont));
                doc.Add(new Paragraph(caseStudy["Challenge"]));
                doc.Add(new Paragraph("Solution", boldFont));
                doc.Add(new Paragraph(caseStudy["Solution"]));
            }

            foreach (var id in brochure.Images)
            {
                var item = master.GetItem(new ID(id));
                var mediaItem = (MediaItem)item;

                var imageurl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem);
                iTextSharp.text.Image myImg = iTextSharp.text.Image.GetInstance(HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + "/" + imageurl);

                doc.Add(myImg);
            }

            doc.Close();

            return brochure.Title + ".pdf";
        }
    }
}