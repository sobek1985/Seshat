require.config({
    paths: {
        entityService: "/sitecore/shell/client/Services/Assets/lib/entityservice",
        unit: "/sitecore/shell/client/MikeRobbins/lib/unit"
    }
});

define(["sitecore", "jquery", "underscore", "entityService", "unit"], function (Sitecore, $, _, entityService, unit) {
    var BrochureBuilderCreate = Sitecore.Definitions.App.extend({

        initialize: function () {
            entityService.use(function (data, next) {
                if (data.Id) {
                    entityService.utils.request({ url: "/sitecore/api/ssc/MikeRobbins-Seshat-Controllers/Brochure/" + data.Id, type: "GET" }).then(function (res) {
                        next(null, res);
                    });
                }
                else {
                    next(null, data);
                }
            });
        },

        initialized: function () {
            this.LoadBrochure();
        },

        EntityServiceConfig: function () {
            var brochureService = new entityService({
                url: "/sitecore/api/ssc/MikeRobbins-Seshat-Controllers/Brochure"
            });


            return brochureService;
        },

        LoadBrochure: function () {
            var id = this.GetParameterByName('id');

            var self = this;

            if (id !== "") {
                var brochureService = this.EntityServiceConfig();

                brochureService.fetchEntity(id).execute().then(function (brochure) {
                    self.tbTitle.viewModel.text(brochure.Title);
                    self.tbIntroduction.viewModel.text(brochure.Introduction);

                    //  TODO: Wire up treelists. With Sitecore Support to setter not available
                    
                    var date = new Date(brochure.Date);
                    self.dpDate.set("date", Sitecore.Helpers.date.toISO(date));
                });
            }
        },

        CreateBrochure: function () {
            var brochureService = this.EntityServiceConfig();

            var brochure = {
                Title: this.tbTitle.viewModel.text(),
                Introduction: this.tbIntroduction.viewModel.text(),
                CaseStudy: this.tvCaseStudy.viewModel.checkedItemIds(),
                Images: this.tvImageGallery.viewModel.checkedItemIds(),
                Date: this.dpDate.viewModel.getDate()
            };

            var self = this;

            brochureService.create(brochure).execute().then(function (newBrochure) {
                newBrochure.should.be.an.instanceOf(entityService.Entity);
                newBrochure.isNew.should.be.false; // this is because its created by the server rather than JS, so its not new.
                newBrochure.should.have.a.property("Title").and.be.an.String;

                self.messageBar.addMessage("notification", { text: "Item created successfully", actions: [], closable: true, temporary: true });

            }).fail(function (error) {
                self.messageBar.addMessage("error", { text: error.message, actions: [], closable: true, temporary: true });
            });

        },

        UpdateBrochure: function (id) {
            var brochureService = this.EntityServiceConfig();

            var self = this;

            brochureService.fetchEntity(id).execute().then(function (brochure) {

                brochure.Title = self.tbTitle.viewModel.text();
                brochure.Introduction = self.tbIntroduction.viewModel.text();
                brochure.CaseStudy = self.tvCaseStudy.viewModel.checkedItemIds();
                brochure.Images = self.tvImageGallery.viewModel.checkedItemIds();
                brochure.Date = self.dpDate.viewModel.getDate();

                brochure.on('save', function () {
                    self.UpdateSuccessful(self);
                });

                brochure.save().execute();
            });
        },

        UpdateSuccessful: function (self) {
            self.messageBar.addMessage("notification", { text: "Item updated successfully", actions: [], closable: true, temporary: true });
        },

        SaveBrochure: function () {

            var id = this.GetParameterByName('id');

            if (id !== "") {
                this.UpdateBrochure(id);

            } else {
                this.CreateBrochure();
            }
        },

        ExportPdf: function () {
            var brochure = {
                Title: this.tbTitle.viewModel.text(),
                Introduction: this.tbIntroduction.viewModel.text(),
                CaseStudy: this.tvCaseStudy.viewModel.checkedItemIds(),
                ImageGallery: this.tvImageGallery.viewModel.checkedItemIds()
            };

            $.ajax({
                url: "/sitecore/api/ssc/MikeRobbins-Seshat-Controllers/Brochure/1/GeneratePdf",
                type: "POST",
                data: JSON.stringify(brochure),
                contentType: 'application/json',
                context: this,
                success: function (data) {
                    window.location = "http://mikerobbins8u2//temp//" + data;
                }
            });
        },

        GetParameterByName: function (name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                results = regex.exec(location.search);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        },
    });

    return BrochureBuilderCreate;
});