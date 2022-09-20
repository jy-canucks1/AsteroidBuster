const mongoose = require('mongoose');
const { Schema } = mongoose;

const accountSchema = new Schema({
   songnum: Number,
   users : [{
    username : String,
    score : Number,
    rank : String,
   }],
   
});

mongoose.model('accounts', accountSchema);