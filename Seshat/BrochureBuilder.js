﻿require.config({
    paths: {
        entityService: "/sitecore/shell/client/Services/Assets/lib/entityservice"
    }
});

define(["sitecore", "jquery", "underscore", "entityService"], function (Sitecore, $, _, entityService) {
    var BrochureBuilder = Sitecore.Definitions.App.extend({

        filesUploaded: [],

        initialized: function () {
            this.GetBrochures();
        },


        EntityServiceConfig: function () {
            var brochureService = new entityService({
                url: "/sitecore/api/ssc/BrochureBuilder-Controllers/Brochure"
            });


            return brochureService;
        },

        GetBrochures: function () {

            var datasource = this.DataSource;

            var brochureService  = this.EntityServiceConfig();

            var result = brochureService.fetchEntities().execute().then(function (brochures) {
                datasource.viewModel.items(brochures);
            });
        },

     


    });

    return BrochureBuilder;
});