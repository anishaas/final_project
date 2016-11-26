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

    context.displaySearchResults = function (data) {      
        alert(data);
       
        var searchResultsJSONObject = jQuery.parseJSON(data);

        var searchResultInsert = '';

        $.each(searchResultsJSONObject, function (index, item) {
            var tableDataComponentHTML = htmlComponents.tableDataComponent;
            var songNameUpdate = tableDataComponentHTML.replace("SONGTITLE", item.SongTitle);
            var artistNameUpdate = songNameUpdate.replace("SONGARTIST", item.ArtistName);
            var priceUpdate = artistNameUpdate.replace("SONGPRICE", item.SongPrice);
            var songRatingUpdate = priceUpdate.replace("SONGRATING", "N/A");

            searchResultInsert += songRatingUpdate;
        });

        $('#dataContainer').html(searchResultInsert);

        return;

        $('#datatable1').DataTable({
            "dom": 'lCfrtip',
            "order": [],
            "colVis": {
                "buttonText": "Columns",
                "overlayFade": 0,
                "align": "right"
            },
            "language": {
                "lengthMenu": '_MENU_ entries per page',
                "search": '<i class="fa fa-search"></i>',
                "paginate": {
                    "previous": '<i class="fa fa-angle-left"></i>',
                    "next": '<i class="fa fa-angle-right"></i>'
                }
            }
        });

        $('#datatable1 tbody').on('click', 'tr', function () {
            $(this).toggleClass('selected');
        });

    }

    context.setupGenres = function setupGenres() {

        $.post(songSearchURLs.getGenreDataURL)
        .done(function (data) {
            genreJSONObject = jQuery.parseJSON(data);
            if (data != "fail") {

                var genreListInsert = '';

                $.each(genreJSONObject, function (index, item) {
                    var genreListHTML = htmlComponents.genreListComponent;
                    genreListHTMLUpdated = genreListHTML.replace("GENRENAME", item.GenreName);
                    genreListInsert += genreListHTMLUpdated;
                });

                $('#genreListContainer').html(genreListInsert);
            }
        });

    }

    

})(songSearchHelperFunctions);
