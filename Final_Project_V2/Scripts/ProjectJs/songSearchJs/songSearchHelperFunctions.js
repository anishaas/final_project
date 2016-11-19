//This holds a js object that makes it easy to call helper functions in the main execution js file
var songSearchHelperFunctions = {};

(function (context) {
    //Private scope 


    //Public API's	
    context.test = function () {
        $.post(songSearchURLs.getGenreDataURL)
        .done(function (data) {
            if (data != "fail") {
                //alert(data);

                $.each(data, function (index, item) {
                    alert(index);
                });
            }
        });
    };

    context.setupGenres = function setupGenres(){
        $.post(songSearchURLs.getGenreDataURL)
        .done(function (data) {
            if (data != "fail") {
                //alert(data);
                /*
                $.each(data, function (index, item) {
                    alert(index);
                });
                */
            }
        });

    }

    

})(songSearchHelperFunctions);
