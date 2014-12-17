var CauseModel = Backbone.Model.extend({
    urlRoot: '/api/CauseQSE',
    validate: function (attrs, options) {

        if (attrs.Description == null) {
            return "Il manque un champ obligatoire, merci de saisir une Description de l'action";
        };
        if (attrs.DateButoireInitiale == '0001-01-01T00:00:00') {
            return "Il manque un champ obligatoire, merci de choisir une date initiale de l'action";
        };
    }
});

var CauseCollection = Backbone.Collection.extend({
    model: CauseModel
});