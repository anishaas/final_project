jQuery(document).ready(function () {

    var songSearchBtn = $("#songSearchBtn");

    songSearchHelperFunctions.setupGenres();

    songSearchBtn.on('click', function () {
        var songTitle = $('#songTitle').val();
        var songArtist = $('#songArtist').val();
        var songAlbum = $('#songAlbum').val();
        var genreArray = [];
        var ratingFilterType = '';
        var ratingInput1 = '';
        var ratingInput2 = '';

        //Get selected genres
        $('.genreItem').each(function () {
            if ($(this).siblings('.genreCheckBox').prop("checked")) {
                genreArray.push($(this).html());
            }
        });
      
        //Get selected filter
        $('.filterTypeInput').each(function () {
            $('.filterTypeInput').each(function(){
                if($(this).is(':checked') == true){
                    ratingFilterType = $(this).val();
                }
            });
        });
        
        //Get filter parameters
        ratingInput1 = $('#ratingInput1').val();
        ratingInput2 = $('#ratingInput2').val();

        //Validation checks
        function validateForm() {

            return true;

            if(songTitle == '' && songArtist == '' && songAlbum == '' && genreArray.length == 0 && ratingFilterType == '' && ratingInput1 == '' && ratingInput2 == ''){
                alert("Please provide some search parameters.");
            }else if(ratingInput1 < 1 || ratingInput1 > 5){
                alert("You can't provide a rating value less than 1 or greater than 5");
            }else if(ratingInput2 != '' && (ratingInput2 > 5)){
                alert("Your second rating parameter can't be greater than 5");
            } else if (ratingInput2 != '' &&  (ratingInput2 < ratingInput1)) {
                alert("Your second rating parameter can't be less than the first rating parameter");
            } else {
                return true;
            }

        }

        if (validateForm() == true) {
            //send form data to the back end 
            $.post(songSearchURLs.searchSongURL, {
                songTitle: songTitle,
                songArtist: songArtist,
                songAlbum: songAlbum,
                genreArray: genreArray,
                ratingFilterType: ratingFilterType,
                ratingInput1: ratingInput1,
                ratingInput2: ratingInput2
            })
            .done(function (data) {
                //var test = jQuery.parseJSON(data);
                alert(data);
                //alert(jQuery.parseJSON( '{ "name": "John" }' ));
            });
        }
       });

    /*
    $.post("/search/searchbySongTitle", { songTitle: "John", songArtist: "2pm" })
    .done(function (data) {
      alert("Data Loaded: " + data);
  });
  */
});