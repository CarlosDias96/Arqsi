const express = require('express');
const router = express.Router();

// Require the controllers WHICH WE DID NOT CREATE YET!!
const encomenda_controller = require('../controllers/encomenda.controller');


// a simple test url to check that all of our files are communicating correctly.
router.get('/test', encomenda_controller.test);
router.post('/create', encomenda_controller.encomenda_create);
router.get('/:id', encomenda_controller.encomenda_details);
router.put('/:id/update', encomenda_controller.encomenda_update);
router.delete('/:id/delete', encomenda_controller.encomenda_delete);
module.exports = router;



