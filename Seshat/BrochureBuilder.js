require.config({
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
                url: "/sitecore/api/ssc/MikeRobbins-Seshat-Controllers/Brochure"
            });


            return brochureService;
        },

        GetBrochures: function () {
            var datasource = this.DataSource;

            var brochureService = this.EntityServiceConfig();

            brochureService.fetchEntities().execute().then(function (brochures) {
                datasource.viewModel.items(brochures);
            });
        },

        DeleteBrochure: function () {
            var brochureService = this.EntityServiceConfig();

            var selectedItemId = this.lcBrochure.viewModel.selectedItemId();

            var self = this;

            brochureService.fetchEntity(selectedItemId).execute().then(function (brochure) {
                brochure.destroy().then(function () {
                    self.MessageBar.addMessage("notification", { text: "Item deleted successfully", actions: [], closable: true, temporary: true });
                    self.GetBrochures();
                });
            });
        },

        EditBrochure: function () {
            var selectedItemId = this.lcBrochure.viewModel.selectedItemId();

            window.location = location.protocol + '//' + location.hostname + "/sitecore/client/MikeRobbins/Applications/Seshat/BrochureTemplate?id=" + selectedItemId;
        },




    });

    return BrochureBuilder;
});