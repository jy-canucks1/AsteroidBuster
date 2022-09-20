    const mongoose = require('mongoose');
    const User = mongoose.model('accounts');

    module.exports = app => {
        // Routes
        app.get('/game_record', async (req, res) => {

            const { songnum, username, score, rank, call } = req.query;        
            
            
            console.log(username);
            console.log(songnum);
            console.log(score);
            console.log(rank);
            console.log(call);
            if(username == ""){
                res.send("Invalid credentials");
                return;
            }
            else if(call == 0){
            var LeaderList = await User.findOne({songnum: songnum});        
            if(LeaderList == null){
                            
                // Create a new account
                console.log("Create new account...");
                
                var newList = new User({
                    songnum: songnum,
                    users : [],               
                                
                });
                var newUser = {username : username, score: 0, rank: ""}
                newList.users.push(newUser);            
                await newList.save();
                res.send(newList);
                return;
            } 
            else {
                var i=0;
                var userData = await User.findOne({songnum: songnum, users:{$elemMatch:{username:username}}});
                if(userData !=null){
                    res.send("Already created.");
                }else{
                   var userData2 = await User.findOne({songnum: songnum});
                   var newUser = {username : username, score: 0, rank: ""}
                   userData2.users.push(newUser); 
                   await userData2.save();                
                   res.send("User Successfully updated.");
                }             
            }
        }
        else{
            var userData1 = await User.updateOne({"songnum": songnum, "users.username":username},
            {"$set": {"users.$.score": score,"users.$.rank": rank}});
            var userData = await User.findOne({songnum: songnum});
                if(userData.users.length > 1){
                userData.users.sort((a, b) => b.score - a.score);}
             var x ="";
             for(var i=0; i < 8; i++){
                if(i> userData.users.length-1){
                    break;
                }
                 x = x + userData.users[i].username +","+ userData.users[i].score +"," +userData.users[i].rank +","
             
                }
                 res.send(x);
                
           
            return;    
            }
            
        })
};
