var NonConformiteModel = Backbone.Model.extend({
    urlRoot: '/api/NonConformite',
    idAttribute: 'Id',
});

var NonConformiteCollection = Backbone.Collection.extend({
    url: '/api/NonConformite',
    model: NonConformiteModel
});