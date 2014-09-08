var CauseModel = Backbone.Model.extend({
    urlRoot: '/api/CauseQSE'
});

var CauseCollection = Backbone.Collection.extend({
    model: CauseModel
});