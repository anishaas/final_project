//This holds a js object that makes it easy to call helper functions in the main execution js file
var artistSearchHelperFunctions = {};

(function (context) {
    //Private scope 


    //Public API's	
    context.test = function () {
        $.post(artistSearchURLs
            .getGenreDataURL)
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
        var searchResultsJSONObject = jQuery.parseJSON(data);

        //var searchResultInsert = '';

        $('#datatable1').dataTable().fnDestroy();
        $('#datatable1').empty();

        var dataTable = $('#datatable1').DataTable({
            "dom": 'lCfrtip',
            "order": [],
            "columns": [
            { "title": "Artist Name", "targets": 0 },
            { "title": "Artist Genres", "targets": 0 },
            { "title": "Artist Rating", "targets": 0 }
            ],
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

        $.each(searchResultsJSONObject, function (index, item) {

            var genreString = '';

            $.each(item.ArtistGenres, function (index, item) {
                genreString += item.GenreName + ', ';
            });

            dataTable.row.add(["<a href='/details/getArtistDetailsPage/" + item.ArtistID + "'>" + item.ArtistName + "</a>", genreString, "N/A"]).draw();
        });
    }

    context.setupGenres = function setupGenres() {

        $.post(artistSearchURLs.getGenreDataURL)
        .done(function (data) {
            genreJSONObject = jQuery.parseJSON(data);
            if (data != "fail") {

                var genreListInsert = '';

                $.each(genreJSONObject, function (index, item) {
                    var genreListHTML = htmlComponents.genreListComponent;
                    genreListHTMLUpdated = genreListHTML.replace("GENRENAME", item.GenreName);
                    genreListInsert += genreListHTMLUpdated;
                });

                $('#genreListContainerArtist').html(genreListInsert);
            }
        });

    }

    

})(artistSearchHelperFunctions);
