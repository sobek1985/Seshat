﻿require.config({
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
                    self.dpDate.set(brochure.Date);
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
                newBrochure.should.be.an.instanceOf(entityService.Entity);
                newBrochure.isNew.should.be.false; // this is because its created by the server rather than JS, so its not new.
                newBrochure.should.have.a.property("Title").and.be.an.String;

                self.messageBar.addMessage("notification", { text: "Item created successfully", actions: [], closable: true, temporary: true });
                self.ResetFields();
                self.GetNewsArticles();
            }).fail(function (error) {
                self.messageBar.addMessage("error", { text: error.message, actions: [], closable: true, temporary: true });
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
        }
    });

    return BrochureBuilderCreate;
});