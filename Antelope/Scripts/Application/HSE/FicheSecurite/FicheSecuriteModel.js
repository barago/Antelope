var FicheSecuriteModel = Backbone.Model.extend({
    urlRoot: '/api/FicheSecurite'
});

var FicheSecuriteCollection = Backbone.Collection.extend({
   url: '/api/RechercheFicheSecurite'
});