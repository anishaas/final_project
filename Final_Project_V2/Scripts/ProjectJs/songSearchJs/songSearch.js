jQuery(document).ready(function () {
    alert('yo');
    $.post("/search/searchbySongTitle", { songTitle: "John", songArtist: "2pm" })
    .done(function (data) {
      alert("Data Loaded: " + data);
  });
});