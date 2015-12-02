$(function () {

    window.DialogueSecuriteView = Backbone.View.extend({

        template: _.template($('#DialogueSecuriteTemplate').html()),
        render: function () {
            this.$el.html(this.template(this.model.toJSON()));

            $('#DateDialogueSecurite').datetimepicker({
                pickTime: false,
                language: 'fr'
            });
            //On écoute les changements sur le DatePicker pour les passer à la fonction Backbone
            $('#DateDialogueSecurite').on("dp.change", $.proxy(this.changeDate, this));
            // TODO : Mettre des dp.hide sur tous les DateTimePickers ! >> Si on ne selectionne rien, il choisit date et heure du jour.
            $('#DateDialogueSecurite').on("dp.hide", $.proxy(this.changeDate, this));

            // TODO : BUG Boostrap, si on n'initialise pas toggle:false, les collapse vont show lorsqu'on fait un hide ...
            // $('.AjoutActionCollapse').collapse({ 'toggle': false });

        },
        initialize: function () {
            this.render();
        },
        events: {
            "change #Site": "changeSite",
            "keyup #Atelier": "changeAtelier",
            "keyup #Contexte": "changeContexte",
            "keyup #Observation": "changeObservation",
            "keyup #Reflexion": "changeReflexion",
            "keyup #Action": "changeAction",
            "click #Enregistrer": "enregistrer"
        },
        changeAtelier: function () {
            this.model.get('dialogueSecuriteModel').set({ 'Atelier': $('#Atelier').val() });
        },
        changeObservation: function () {
            this.model.get('dialogueSecuriteModel').set({ 'Observation': $('#Observation').val() });
        },
        changeContexte: function () {
            this.model.get('dialogueSecuriteModel').set({ 'Contexte': $('#Contexte').val() });
        },
        changeReflexion: function () {
            this.model.get('dialogueSecuriteModel').set({ 'Reflexion': $('#Reflexion').val() });
        },
        changeAction: function () {
            this.model.get('dialogueSecuriteModel').set({ 'Action': $('#Action').val() });
        },
        changeSite: function () {
            this.model.get('dialogueSecuriteModel').set({ 'SiteId': $('#Site').val() });
        },
        changeDate: function () {
            this.model.get('dialogueSecuriteModel').set({ 'Date': this.dateFormatMVC($('#DateDialogueSecuriteInput').val()) + 'T' + '00:00:00.0' });
            this.model.get('dialogueSecuriteModel').set({ 'DateJavascript': $('#DateDialogueSecuriteInput').val() });
        },
        dateFormatMVC: function (date) {
            // De date FR à DateTime
            var dateFormated = date.substring(6, 10) + '-' + date.substring(3, 5) + '-' + date.substring(0, 2);
            return dateFormated;
        },
        enregistrer: function () {
            this.model.get('dialogueSecuriteModel').on("invalid", function (model, error) {
                Backbone.applicationEvents.trigger('alerteInvalid', error);
                console.log("INVALID");
            });
            this.model.get('dialogueSecuriteModel').save(null,
                {
                    async: false, wait: true,
                    success: _.bind(function (model, response) {

                        //this.model.set({ 'actionModel': new ActionModel() });
                        //this.model.get('actionModel').set({ 'Responsable': new ResponsableModel() });
                        //this.model.get('actionModel').set({ 'Verificateur': new VerificateurModel() });
                        //this.model.get('actionModel').set({ 'NonConformiteId': this.model.get('nonConformiteModel').get('Id') });

                        Backbone.applicationEvents.trigger('DialogueSecuriteEnregistree');

                        this.render(this.model.get('dialogueSecuriteModel'));
                        Backbone.applicationEvents.trigger('alerteValid', 'Le Dialogue Sécurité \"' + this.model.get('dialogueSecuriteModel').get('Code') + '\" est enregistrée.');

                    }, this),
                    error: _.bind(function (model, response) {
                        Backbone.applicationEvents.trigger('alerteInvalid', 'Une erreur est survenue sur l\'ajout du Dialogue Sécurité');
                    }, this)

                });
        }

    });

});