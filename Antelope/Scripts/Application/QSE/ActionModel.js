var ActionModel = Backbone.Model.extend({
    urlRoot: '/api/ActionQSE'
});

var ActionCollection = Backbone.Collection.extend({
    model: ActionModel
});