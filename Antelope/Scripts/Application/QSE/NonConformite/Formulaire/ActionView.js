$(function () {

    window.ActionView = Backbone.View.extend({


        template: _.template($('#ActionTemplate').html()),
        render: function () {
            this.$el.html(this.template(this.model.toJSON()));

            $('#AddActionDateButoireInitiale').datetimepicker({
                pickTime: false,
                language: 'fr'
            });

            $('.EditActionDateButoireInitiale').datetimepicker({
                pickTime: false,
                language: 'fr'
            });

            $('.EditActionDateButoireNouvelle').datetimepicker({
                pickTime: false,
                language: 'fr'
            });

            $('.EditActionRealiseDate').datetimepicker({
                pickTime: false,
                language: 'fr'
            });

            $('.EditActionDateVerification').datetimepicker({
                pickTime: false,
                language: 'fr'
            });

            //On écoute les changements sur le DatePicker pour les passer à la fonction Backbone
            $('#AddActionDateButoireInitiale').on("dp.change", $.proxy(this.changeAddActionDateButoireInitiale, this));
            // Mettre des dp.hide sur tous les DateTimePickers ! >> Si on ne selectionne rien, il choisit date et heure du jour.
            $('#AddActionDateButoireInitiale').on("dp.hide", $.proxy(this.changeAddActionDateButoireInitiale, this));
            $('.EditActionDateButoireInitiale').on("dp.change", $.proxy(this.changeEditActionDateButoireInitiale, this));
            $('.EditActionDateButoireInitiale').on("dp.hide", $.proxy(this.changeEditActionDateButoireInitiale, this));
            $('.EditActionDateButoireNouvelle').on("dp.change", $.proxy(this.changeEditActionDateButoireNouvelle, this));
            $('.EditActionDateButoireNouvelle').on("dp.hide", $.proxy(this.changeEditActionDateButoireNouvelle, this));
            $('.EditActionRealiseDate').on("dp.change", $.proxy(this.changeEditActionRealiseDate, this));
            $('.EditActionRealiseDate').on("dp.hide", $.proxy(this.changeEditActionRealiseDate, this));
            $('.EditActionDateVerification').on("dp.change", $.proxy(this.changeEditActionVerificationDate, this));
            $('.EditActionDateVerification').on("dp.hide", $.proxy(this.changeEditActionVerificationDate, this));

        },
        fillUtilisateur: function (params) {
            switch (params[0].get('sourceUtilisateurField')) {
                case "AddActionResponsable":
                    this.model.get('actionModel').set({ 'Responsable': params[0] });
                    this.model.get('actionModel').set({ 'ResponsableId': params[0].get('PersonneId') });
                    
                    $('#AddActionResponsableNom').val(this.model.get('actionModel').get('Responsable').get('Nom'));
                    $('#AddActionResponsablePrenom').val(this.model.get('actionModel').get('Responsable').get('Prenom'));
                          
                    break;
                case "AddActionVerificateur":
                    this.model.get('actionModel').set({ 'Verificateur': params[0] });
                    this.model.get('actionModel').set({ 'VerificateurId': params[0].get('PersonneId') });
                    
                    $('#AddActionVerificateurNom').val(this.model.get('actionModel').get('Verificateur').get('Nom'));
                    $('#AddActionVerificateurPrenom').val(this.model.get('actionModel').get('Verificateur').get('Prenom'));

                    break;
                default:
                    alert ('ELSE');
                    break;
            }


        },
        initialize: function () {

            // Ecoute du Popup de selection utilisateur, doit traiter quel est le champ concerné par la demande de sélection
            Backbone.applicationEvents.on('selectionUtilisateur', function (params) {
                this.fillUtilisateur(params);
            }, this);

            Backbone.applicationEvents.on('NonConformiteEnregistree', function () {
                this.render();
            }, this);


            this.render();
        },
        events: {
            "keyup #AddActionTitre": "changeAddActionTitre",
            "click #BtnAddAction": "hideShow",
            "keyup #AddActionDescription": "changeAddActionDescription",
            "keyup #AddActionCritere": "changeAddActionCritere",
            "click #ActiveDirectoryAddActionResponsableRecherche": "showActiveDirectoryUtilisateurRecherche",
            "click #ActiveDirectoryAddActionVerificateurRecherche": "showActiveDirectoryUtilisateurRecherche",
            "click .ActiveDirectoryEditActionResponsableRecherche": "showActiveDirectoryUtilisateurRecherche",
            "click .ActiveDirectoryEditActionVerificateurRecherche": "showActiveDirectoryUtilisateurRecherche",
            "keyup #AddActionDateButoireInitiale": "changeAddActionDateButoireInitiale",
            "click #BtnAddActionEnregistrer": "enregistrerAddAction",
            "keyup .EditActionTitre": "changeEditActionTitre",
            "click .BtnEditActionDelete": "deleteAction",
            "click .BtnEditActionSave": "saveAction",
            "keyup .EditActionTitre": "changeEditActionTitre",
            "keyup .EditActionDescription": "changeEditActionDescription",
            "keyup .EditActionAvancement": "changeEditActionAvancement",
            "keyup .EditActionCritere": "changeEditActionCritere",
            "keyup .EditActionCommentaire": "changeEditActionCommentaire"

        },
        hideShow: function (ev) {
            $('.AjoutActionCollapse').collapse('toggle');
        },
        changeDateNonConformite: function () {
            this.model.get('actionModel').set({ 'DateButoireInitiale': this.dateFormatMVC($('#AddActionDateButoir').val()) });

        },
        dateFormatMVC: function (date) {
            // De date FR à DateTime
            var dateFormated = date.substring(6, 10) + '-' + date.substring(3, 5) + '-' + date.substring(0, 2);
            return dateFormated;
        },
        changeAddActionTitre: function () {
            this.model.get('actionModel').set({ 'Titre': $('#AddActionTitre').val() });
        },
        changeAddActionDescription: function () {
            this.model.get('actionModel').set({ 'Description': $('#AddActionDescription').val() });
        },
        changeAddActionCritere: function () {
            this.model.get('actionModel').set({ 'CritereEfficaciteVerification': $('#AddActionCritere').val() });
        },
        showActiveDirectoryUtilisateurRecherche: function (ev) {

            //TODO :  Créer un constructeur prenant "sourceUtilisateurField" en param. pour créer ce qui suit
            var rechercheActiveDirectoryView = new window.RechercheActiveDirectoryView({
            });
            rechercheActiveDirectoryView.model.set({ "sourceUtilisateurField": $(ev.currentTarget).attr('data-SourceUtilisateurField') });
            if ($(ev.currentTarget).attr('data-actionid') != null) {
                rechercheActiveDirectoryView.model.set({ "sourceId": $(ev.currentTarget).attr('data-actionid') })
            };
            rechercheActiveDirectoryView.show()
        },
        changeAddActionDateButoireInitiale: function (ev) {
            this.model.get('actionModel').set({ 'DateButoireInitiale': this.dateFormatMVC($('#AddActionDateButoireInitialeInput').val()) + 'T' + '00:00:00.0' });
            this.model.get('actionModel').set({ 'DateButoireInitialeJavascript': $('#AddActionDateButoireInitialeInput').val() });
        },
        enregistrerAddAction: function(){

            var actionToAdd = this.model.get('actionModel');
            var actionAdded = this.model.get('nonConformiteModel').get('actionCollection').create(
                    new ActionModel(actionToAdd.toJSON()), { async: false, wait: true }
                )

            actionAdded.set({ 'Responsable': new ResponsableModel(actionAdded.get('Responsable')) });
            actionAdded.set({ 'Verificateur': new ResponsableModel(actionAdded.get('Verificateur')) });
            
            
            this.model.get('actionModel').clear();
            this.model.get('actionModel').set({ 'Responsable': new ResponsableModel() });
            this.model.get('actionModel').set({ 'Verificateur': new ResponsableModel() });


            this.render();

        },
        deleteAction: function(){
            alert('DELETE');
        },
        saveAction: function(){
            alert('SAVE');
        },
        changeEditActionTitre: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionid');
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'Titre': $(ev.currentTarget).val() });
        },
        changeEditActionDateButoireInitiale: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionid');
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'DateButoireInitiale': this.dateFormatMVC($('#InputEditActionDateButoireInitiale' + actionToEditId).val()) + 'T' + '00:00:00.0' });
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'DateButoireInitialeJavascript': $('#InputEditActionDateButoireInitiale' + actionToEditId).val() });
        },
        changeEditActionDateButoireNouvelle: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionid');
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'DateButoireNouvelle': this.dateFormatMVC($('#InputEditActionDateButoireNouvelle' + actionToEditId).val()) + 'T' + '00:00:00.0' });
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'DateButoireNouvelleJavascript': $('#InputEditActionDateButoireNouvelle' + actionToEditId).val() });
        },
        changeEditActionDescription: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionid');
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'Description': $(ev.currentTarget).val() });
        },
        changeEditActionAvancement: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionid');
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'Avancement': $(ev.currentTarget).val() });
        },
        changeEditActionRealiseDate: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionid');
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'RealiseDate': this.dateFormatMVC($('#InputEditActionRealiseDate' + actionToEditId).val()) + 'T' + '00:00:00.0' });
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'RealiseDateJavascript': $('#InputEditActionRealiseDate' + actionToEditId).val() });
        },
        changeEditActionCritere: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionid');
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'CritereEfficaciteVerification': $(ev.currentTarget).val() });
            console.log(this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }));
        },
        changeEditActionCommentaire: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionid');
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'CommentaireEfficaciteVerification': $(ev.currentTarget).val() });
        },
        changeEditActionVerificationDate: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionid');
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'VerificationDate': this.dateFormatMVC($('#EditActionDateVerificationInput' + actionToEditId).val()) + 'T' + '00:00:00.0' });
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'VerificationDateJavascript': $('#EditActionDateVerificationInput' + actionToEditId).val() });
            console.log(this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }));
        },
    });

});
