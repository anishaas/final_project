//This holds a js object that makes it easy to call helper functions in the main execution js file
var songSearchHelperFunctions = {};

(function (context) {
    //Private scope 


    //Public API's	
    context.test = function () {
        alert('wtf');
    };

    context.setupGenres = function setupGenres(){
        $.post(songSearchURLs.getGenreDataURL)
        .done(function (data) {
            if (data != "fail") {
                alert(data);
                return;
                $.each(data, function (index, item) {
                    alert(item);
                });
            }
        });

    }

    

})(songSearchHelperFunctions);
