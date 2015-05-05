require.config({
    paths: {
        entityService: "/sitecore/shell/client/Services/Assets/lib/entityservice"
    }
});

define(["sitecore", "jquery", "underscore", "entityService"], function (Sitecore, $, _, entityService) {
    var BrochureBuilderCreate = Sitecore.Definitions.App.extend({

        EntityServiceConfig: function () {
            var brochureService = new entityService({
                url: "/sitecore/api/ssc/MikeRobbins-Seshat-Controllers/Brochure"
            });


            return brochureService;
        },


        SaveBrochure: function () {
            var brochureService = this.EntityServiceConfig();

            var brochure = {
                Title: this.tbTitle.viewModel.text(),
                Introduction: this.tbIntroduction.viewModel.text(),
                CaseStudy: this.tvCaseStudy.viewModel.checkedItemIds(),
                ImageGallery: this.tvImageGallery.viewModel.checkedItemIds()
            };

          //  var self = this;

            var result = brochureService.create(brochure).execute().then(function (newBrochure) {
               // self.messageBar.addMessage("notification", { text: "Item created successfully", actions: [], closable: true, temporary: true });
              //  self.ResetFields();
             //   self.GetNewsArticles();
            });

        },

        ExportPdf: function() {
            var brochureService = this.EntityServiceConfig();

            var brochure = {
                Title: this.tbTitle.viewModel.text(),
                Introduction: this.tbIntroduction.viewModel.text(),
                CaseStudy: this.tvCaseStudy.viewModel.checkedItemIds(),
                ImageGallery: this.tvImageGallery.viewModel.checkedItemIds()
            };


            $.ajax({
                url: "/sitecore/api/ssc/BrochureBuilder-Controllers/Brochure/1/GeneratePDF",
                type: "POST",
                data: JSON.stringify(brochure),
                contentType: 'application/json',
                context: this,
                success: function (data) {
                    window.location =  "http://cardano8//temp//"+data;
                }
            });
        }


    });

    return BrochureBuilderCreate;
});