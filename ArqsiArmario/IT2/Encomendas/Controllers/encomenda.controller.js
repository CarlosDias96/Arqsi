const Encomenda = require('../models/encomenda.model');

//Simple version, without validation or sanitation
exports.test = function (req, res) {
    res.send('Greetings from the Test controller!');
};

exports.encomenda_create = function (req, res) {
    let encomenda = new Encomenda(
        {
            name: req.body.name,
            price: req.body.price,
            iva: req.body.iva,
            nif: req.body.nif,
            itens: req.body.itens,
            morada: req.body.morada,
            data: req.body.data
        }
    );

    encomenda.save(function (err) {
        if (err) {
            return next(err);
        }
        res.send('Encomenda Created successfully');
    })
};

exports.encomenda_details = function (req, res) {
    Encomenda.findById(req.params.id, function (err, encomenda) {
        if (err) return next(err);
        res.send(encomenda);
    })
};

exports.encomenda_update = function (req, res) {
    Encomenda.findByIdAndUpdate(req.params.id, { $set: req.body }, function (err, encomenda) {
        if (err) return next(err);
        res.send('Encomenda udpated.');
    });
};
exports.encomenda_delete = function (req, res) {
    Encomenda.findByIdAndRemove(req.params.id, function (err) {
        if (err) return next(err);
        res.send('Deleted successfully!');
    })
}