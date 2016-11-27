//This holds a js object that makes it easy to call helper functions in the main execution js file
var albumSearchHelperFunctions = {};

(function (context) {
    //Private scope 


    //Public API's	
    context.displaySearchResults = function (data) {      
        var searchResultsJSONObject = jQuery.parseJSON(data);

        //var searchResultInsert = '';

        $('#datatable1').dataTable().fnDestroy();
        $('#datatable1').empty();

        var dataTable = $('#datatable1').DataTable({
            "dom": 'lCfrtip',
            "order": [],
            "columns": [
            { "title": "Album Name", "targets": 0 },
            { "title": "Album Artist", "targets": 0 },
            { "title": "Album Genres", "targets": 0 },
            { "title": "Album Rating", "targets": 0 }
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

            $.each(item.albumGenres, function (index, item) {
                genreString += item.GenreName + ', ';
            });

            dataTable.row.add([item.albumName, item.albumArtist.ArtistName, genreString, "N/A"]).draw();
        });
    }

    context.setupGenres = function setupGenres() {
        $.post(albumSearchURLs.getGenreDataURL)
        .done(function (data) {
            genreJSONObject = jQuery.parseJSON(data);
            if (data != "fail") {

                var genreListInsert = '';

                $.each(genreJSONObject, function (index, item) {
                    var genreListHTML = htmlComponents.genreListComponent;
                    genreListHTMLUpdated = genreListHTML.replace("GENRENAME", item.GenreName);
                    genreListInsert += genreListHTMLUpdated;
                });

                $('#genreListContainerAlbum').html(genreListInsert);
            }
        });

    }

    

})(albumSearchHelperFunctions);
