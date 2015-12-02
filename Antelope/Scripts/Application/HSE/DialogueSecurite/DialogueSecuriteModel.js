var DialogueSecuriteModel = Backbone.Model.extend({
    urlRoot: '/api/DialogueSecurite',
    idAttribute: 'Id',
    validate: function (attrs, options) {
        console.log('Passage Validate DS');
        if (attrs.SiteId == 0) {
            return "Il manque un champ obligatoire, merci de choisir un Site";
        };
        //if (attrs.NonConformiteOrigineId == 0 || attrs.NonConformiteOrigineId == null) {
        //    return "Il manque un champ obligatoire, merci de choisir une Origine";
        //};
        if (attrs.Date == '0001-01-01T00:00:00') {
            return "Il manque un champ obligatoire, merci de choisir une Date";
        };

        if (attrs.Contexte == null) {
            return "Il manque un champ obligatoire, merci de saisir une Contexte";
        };
        if (attrs.Observation == null) {
            return "Il manque un champ obligatoire, merci de saisir une Observation";
        };
        if (attrs.Reflexion == null) {
            return "Il manque un champ obligatoire, merci de saisir une Reflexion";
        };
        if (attrs.Action == null) {
            return "Il manque un champ obligatoire, merci de saisir une Action";
        };
        if (attrs.Atelier == null) {
            return "Il manque un champ obligatoire, merci de saisir un Atelier";
        };

    }
});

var NonConformiteCollection = Backbone.Collection.extend({
    url: '/api/DialogueSecurite',
    model: DialogueSecuriteModel
});