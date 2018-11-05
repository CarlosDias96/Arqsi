var express = require('express');
var app = express();
var bodyParser = require('body-parser');

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));

let port = process.env.PORT || 1991;

require('./dbConnection');

const encomenda = require('./routes/encomenda.route');
app.use('/encomendas', encomenda);

app.listen(port, () => {
    console.log('Server is up and running on port number ' + port);
});