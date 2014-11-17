$(function () {

    window.ActionView = Backbone.View.extend({


        template: _.template($('#ActionTemplate').html()),
        render: function () {
            this.$el.html(this.template(this.model.toJSON()));

            $('#AddActionDateButoir').datetimepicker({
                pickTime: false,
                language: 'fr'
            });

            //On écoute les changements sur le DatePicker pour les passer à la fonction Backbone
            $('#AddActionDateButoir').on("dp.change", $.proxy(this.changeDateNonConformite, this));
            // TODO : Mettre des dp.hide sur tous les DateTimePickers ! >> Si on ne selectionne rien, il choisit date et heure du jour.
            $('#AddActionDateButoir').on("dp.hide", $.proxy(this.changeDateNonConformite, this));

        },
        initialize: function () {

            this.render();
        },
        events: {
            "click #BtnAddAction": "hideShow",
            "keyup #AddActionDateButoir": "changeDateNonConformite",
            "keyup #AddActionDescription": "changeAddActionDescription",
            "click #ActiveDirectoryAddActionResponsableRecherche": "showActiveDirectoryUtilisateurRecherche",
        },
        hideShow: function (ev) {
            $('.AjoutActionCollapse').collapse('toggle');
        },
        changeDateNonConformite: function () {
            this.model.get('actionModel').set({ 'DateButoir': this.dateFormatMVC($('#AddActionDateButoir').val()) });

        },
        dateFormatMVC: function (date) {
            // De date FR à DateTime
            var dateFormated = date.substring(6, 10) + '-' + date.substring(3, 5) + '-' + date.substring(0, 2);
            return dateFormated;
        },
        changeAddActionDescription: function () {
            this.model.get('actionModel').set({ 'Description': $('#AddActionDescription').val() });
        },
        showActiveDirectoryUtilisateurRecherche: function (ev) {

            //var rechercheActiveDirectoryModel = new RechercheActiveDirectoryModel();
            //rechercheActiveDirectoryModel.set({'rechercheActiveDirectoryCollection':new RechercheActiveDirectoryCollection()})

            var rechercheActiveDirectoryView = new window.RechercheActiveDirectoryView({
            });
            console.log($(ev.currentTarget).attr('data-SourceUtilisateurField'));
            rechercheActiveDirectoryView.model.set({ "SourceUtilisateurField": $(ev.currentTarget).attr('data-SourceUtilisateurField') })
            rechercheActiveDirectoryView.show()

        }

    });

});
