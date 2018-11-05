// JavaScript source code
var mongoose = require('mongoose');
mongoose.connect('mongodb://gruponove:3mosqueteiros@ds249623.mlab.com:49623/encomendas_mongodb');
var db = mongoose.connection;
db.on('error', console.error.bind(console, 'connection error:'));
db.once('open', function () {
    console.log("we're connected!");
});
mongoose.Promise = global.Promise;