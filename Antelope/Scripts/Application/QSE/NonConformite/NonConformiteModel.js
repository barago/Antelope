﻿var NonConformiteModel = Backbone.Model.extend({
    urlRoot: '/api/NonConformite'
});

var NonConformiteCollection = Backbone.Collection.extend({
    url: '/api/NonConformite',
    model: NonConformiteModel
});