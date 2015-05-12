require.config({
    paths: {
        entityService: "/sitecore/shell/client/Services/Assets/lib/entityservice",
        unit: "/sitecore/shell/client/MikeRobbins/lib/unit"
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

        LoadBrochure: function () {
            var id = this.GetParameterByName('id');

            if (id!=null) {
                var brochureService = this.EntityServiceConfig();

                var result = brochureService.fetchEntity(selectedId).execute().then(function (brochure) {
                    self.tbID.viewModel.text(brochure.Id);
                    self.tbTitle.viewModel.text(brochure.Title);
                    self.tbDescription.viewModel.text(brochure.Description);
                    self.dpDate.viewModel.setDate(brochure.Date);
                });
            }
        },

        SaveBrochure: function () {
            var brochureService = this.EntityServiceConfig();

            var brochure = {
                Title: this.tbTitle.viewModel.text(),
                Introduction: this.tbIntroduction.viewModel.text(),
                CaseStudy: this.tvCaseStudy.viewModel.checkedItemIds(),
                ImageGallery: this.tvImageGallery.viewModel.checkedItemIds()
            };

            var self = this;

            brochureService.create(brochure).execute().then(function (newBrochure) {
                self.messageBar.addMessage("notification", { text: "Item created successfully", actions: [], closable: true, temporary: true });
                self.ResetFields();
                self.GetNewsArticles();
            });

        },

        ExportPdf: function () {
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
                    window.location = "http://cardano8//temp//" + data;
                }
            });
        },

        GetParameterByName: function (name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                results = regex.exec(location.search);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }
    });

    return BrochureBuilderCreate;
});