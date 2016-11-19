jQuery(document).ready(function () {
    alert('yo');
    $.post("/ajaxControllers/customerSearchAjaxControllers/SearchController/searchbySongTitle", { songTitle: "John", songArtist: "2pm" })
    .done(function (data) {
      alert("Data Loaded: " + data);
  });
});