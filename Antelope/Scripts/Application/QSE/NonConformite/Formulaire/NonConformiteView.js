$(function () {

    window.NonConformiteView = Backbone.View.extend({

        template: _.template($('#NonConformiteTemplate').html()),
        render: function () {
            this.$el.html(this.template(this.model.toJSON()));

            $('#DateNonConformite').datetimepicker({
                pickTime: false,
                language: 'fr'
            });
            //On écoute les changements sur le DatePicker pour les passer à la fonction Backbone
            $('#DateNonConformite').on("dp.change", $.proxy(this.changeDateNonConformite, this));
            // TODO : Mettre des dp.hide sur tous les DateTimePickers ! >> Si on ne selectionne rien, il choisit date et heure du jour.
            $('#DateNonConformite').on("dp.hide", $.proxy(this.changeDateNonConformite, this));

            // TODO : BUG Boostrap, si on n'initialise pas toggle:false, les collapse vont show lorsqu'on fait un hide ...
            $('.AjoutActionCollapse').collapse({ 'toggle': false });

        },
        initialize: function () {
            this.render();
        },
        events: {
            "change #Site": "changeSite",
            "change #NonConformiteOrigine": "changeNonConformiteOrigine",
            "change #NonConformiteDomaine": "changeNonConformiteDomaine",
            "change #NonConformiteGravite": "changeNonConformiteGravite",
            "keyup #Description": "changeDescription",
            "keyup #Attendu": "changeAttendu",
            "keyup #Cause": "changeCause",
            "click #Enregistrer": "enregistrer"
        },
        changeDescription: function () {
            this.model.get('nonConformiteModel').set({ 'Description': $('#Description').val() });
        },
        changeAttendu: function () {
            this.model.get('nonConformiteModel').set({ 'Attendu': $('#Attendu').val() });
        },
        changeCause: function () {
            this.model.get('nonConformiteModel').set({ 'Cause': $('#Cause').val() });
        },
        changeSite: function () {
            this.model.get('nonConformiteModel').set({ 'SiteId': $('#Site').val() });
        },
        changeNonConformiteOrigine: function () {
            this.model.get('nonConformiteModel').set({ 'NonConformiteOrigineId': $('#NonConformiteOrigine').val() });
        },
        changeNonConformiteDomaine: function () {
            this.model.get('nonConformiteModel').set({ 'NonConformiteDomaineId': $('#NonConformiteDomaine').val() });
        },
        changeNonConformiteGravite: function () {
            this.model.get('nonConformiteModel').set({ 'NonConformiteGraviteId': $('#NonConformiteGravite').val() });
        },
        changeDateNonConformite: function () {
            this.model.get('nonConformiteModel').set({ 'Date': this.dateFormatMVC($('#DateNonConformiteInput').val()) + 'T' + '00:00:00.0' });
            this.model.get('nonConformiteModel').set({ 'DateJavascript': $('#DateNonConformiteInput').val() });
        },
        dateFormatMVC: function (date) {
            // De date FR à DateTime
            var dateFormated = date.substring(6, 10) + '-' + date.substring(3, 5) + '-' + date.substring(0, 2);
            return dateFormated;
        },
        enregistrer: function () {
            this.model.get('nonConformiteModel').save(null,
                {
                    async: false, wait: true,
                    success: _.bind(function (model, response) {

                        Backbone.applicationEvents.trigger('NonConformiteEnregistree');

                        this.render(this.model.get('nonConformiteModel'));
                        Backbone.applicationEvents.trigger('validNonConformite', 'La Non-Conformité est enregistrée.');

                    }, this)
                });
        }

    });

});