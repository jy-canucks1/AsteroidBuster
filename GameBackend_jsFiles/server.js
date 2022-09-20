const express =require('express');
const keys = require('./config/keys.js');

const app = express();

// Setting up DB
const mongoose = require('mongoose');
mongoose.connect(keys.mongoURI, {useNewUrlParser: true, useUnifiedTopology: true});

//Setup database models
require('./model/Account');


// Setup the routes
require('./routes/Routes')(app);


app.listen(keys.port, () => {
    console.log("Listening on "+ keys.port);
});

