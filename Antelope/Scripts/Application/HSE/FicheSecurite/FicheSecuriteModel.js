var FicheSecuriteModel = Backbone.Model.extend({
    urlRoot: '/api/FicheSecurite'
});

var FicheSecuriteCollection = Backbone.Collection.extend({
    url: '/api/RechercheFicheSecurite',
    model: FicheSecuriteModel,
    //parse: function (response) {
    //    this.trigger("collection:updated", { count: repsonse.count, total: response.total, startAt: response.startAt });
    //    return response.records;
    //}
});