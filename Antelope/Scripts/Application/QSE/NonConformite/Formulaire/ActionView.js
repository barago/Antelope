$(function () {

    window.ActionView = Backbone.View.extend({


        template: _.template($('#ActionTemplate').html()),
        render: function () {
            this.$el.html(this.template(this.model.toJSON()));

            $('#AddActionDateButoireInitiale').datetimepicker({
                pickTime: false,
                language: 'fr'
            });

            //On écoute les changements sur le DatePicker pour les passer à la fonction Backbone
            $('#AddActionDateButoireInitiale').on("dp.change", $.proxy(this.changeAddActionDateButoireInitiale, this));
            // TODO : Mettre des dp.hide sur tous les DateTimePickers ! >> Si on ne selectionne rien, il choisit date et heure du jour.
            $('#AddActionDateButoireInitiale').on("dp.hide", $.proxy(this.changeAddActionDateButoireInitiale, this));

        },
        fillUtilisateur: function(utilisateurSelectionne){

            switch (utilisateurSelectionne.get('sourceUtilisateurField')){
                case "AddActionResponsable":
                    this.model.get('actionModel').set({ 'Responsable': utilisateurSelectionne });
                    
                    $('#AddActionResponsableNom').val(this.model.get('actionModel').get('Responsable').get('Nom'));
                    $('#AddActionResponsablePrenom').val(this.model.get('actionModel').get('Responsable').get('Prenom'));
                          
                    break;
                case "AddActionVerificateur":
                    this.model.get('actionModel').set({ 'Verificateur': utilisateurSelectionne });
                    
                    $('#AddActionVerificateurNom').val(this.model.get('actionModel').get('Verificateur').get('Nom'));
                    $('#AddActionVerificateurPrenom').val(this.model.get('actionModel').get('Verificateur').get('Prenom'));

                    break;
            }


        },
        initialize: function () {

            // Ecoute du Popup de selection utilisateur, doit traiter quel est le champ concerné par la demande de sélection
            Backbone.applicationEvents.on('selectionUtilisateur', function (utilisateurSelectionne) {
                this.fillUtilisateur(utilisateurSelectionne);
            }, this);

            Backbone.applicationEvents.on('NonConformiteEnregistree', function () {
                this.render();
            }, this);


            this.render();
        },
        events: {
            "click #BtnAddAction": "hideShow",
            "keyup #AddActionDescription": "changeAddActionDescription",
            "keyup #AddActionCritere": "changeAddActionCritere",
            "click #ActiveDirectoryAddActionResponsableRecherche": "showActiveDirectoryUtilisateurRecherche",
            "click #ActiveDirectoryAddActionVerificateurRecherche": "showActiveDirectoryUtilisateurRecherche",
            "keyup #AddActionDateButoireInitiale": "changeAddActionDateButoireInitiale",
            "click #BtnAddActionEnregistrer" : "enregistrerAddAction"
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
        changeAddActionDescription: function () {
            this.model.get('actionModel').set({ 'Description': $('#AddActionDescription').val() });
        },
        changeAddActionCritere: function () {
            this.model.get('actionModel').set({ 'Critere': $('#AddActionCritere').val() });
        },
        showActiveDirectoryUtilisateurRecherche: function (ev) {

            //TODO :  Créer un constructeur prenant "sourceUtilisateurField" en param. pour créer ce qui suit
            var rechercheActiveDirectoryView = new window.RechercheActiveDirectoryView({
            });
            rechercheActiveDirectoryView.model.set({ "sourceUtilisateurField": $(ev.currentTarget).attr('data-SourceUtilisateurField') })
            rechercheActiveDirectoryView.show()
        },
        changeAddActionDateButoireInitiale: function (ev) {
            this.model.get('actionModel').set({ 'DateButoireInitiale': this.dateFormatMVC($('#AddActionDateButoireInitialeInput').val()) + 'T' + '00:00:00.0' });
            this.model.get('actionModel').set({ 'DateButoireInitialeJavascript': $('#AddActionDateButoireInitialeInput').val() });
        },
        enregistrerAddAction: function(){
            console.log(this.model.get('actionModel'));

            var action = this.model.get('nonConformiteModel').get('actionCollection').create(
                    this.model.get('actionModel'), {async: false, wait:true}
                )

            this.model.get('actionModel').clear();
            this.render();

        }

    });

});
