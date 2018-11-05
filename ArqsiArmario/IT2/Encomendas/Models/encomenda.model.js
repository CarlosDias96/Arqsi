// JavaScript source code
const mongoose = require('mongoose');
const Schema = mongoose.Schema;

let EncomendaSchema = new Schema({
    name: { type: String, optional: true, max: 100 },
    nif: { type: Number, required: true },
    id: { type: Number, required: true },
    itens: [{ type: mongoose.Schema.Types.ObjectId, ref: 'Item' }],
    price: { type: Number, required: true },
    iva: { type: Number, required: true }
    morada: { type: String, required: true, max: 150 },
    data: { type: Date }
});


// Export the model
module.exports = mongoose.model('Encomenda', EncomendaSchema);